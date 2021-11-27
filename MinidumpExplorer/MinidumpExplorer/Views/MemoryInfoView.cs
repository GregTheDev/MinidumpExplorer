using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbgHelp.MinidumpFiles;
using MinidumpExplorer.Utilities;
using System.Collections;
using MinidumpExplorer.Controls;
using System.Runtime.InteropServices;
using MinidumpExplorer.Dialogs;
using System.IO;

namespace MinidumpExplorer.Views
{
    public partial class MemoryInfoView : BaseViewControl
    {
        private MiniDumpMemoryInfoStream _memoryInfoStream;
        private MiniDumpFile _minidumpFile;

        private const int COL_BASE_ADDRESS = 0;
        private const int COL_ALLOCATION_BASE = 1;
        private const int COL_ALLOCATION_PROTECT = 2;
        private const int COL_REGION_SIZE = 3;
        private const int COL_STATE = 4;
        private const int COL_PROTECT = 5;
        private const int COL_TYPE = 6;

        public MemoryInfoView()
        {
            InitializeComponent();

            listView1.SetFilteringForColumn(COL_ALLOCATION_PROTECT, true);
            listView1.SetFilteringForColumn(COL_STATE, true);
            listView1.SetFilteringForColumn(COL_PROTECT, true);
            listView1.SetFilteringForColumn(COL_TYPE, true);

            listView1.ColumnSorter.SortColumn(COL_BASE_ADDRESS, listItem => (listItem.Tag as MiniDumpMemoryInfo).BaseAddress);
            listView1.ColumnSorter.SortColumn(COL_ALLOCATION_BASE, listItem => (listItem.Tag as MiniDumpMemoryInfo).AllocationBase);
            listView1.ColumnSorter.SortColumn(COL_ALLOCATION_PROTECT, listItem => (listItem.Tag as MiniDumpMemoryInfo).AllocationProtect.ToString());
            listView1.ColumnSorter.SortColumn(COL_REGION_SIZE, listItem => (listItem.Tag as MiniDumpMemoryInfo).RegionSize);
            listView1.ColumnSorter.SortColumn(COL_STATE, listItem => (listItem.Tag as MiniDumpMemoryInfo).State.ToString());
            listView1.ColumnSorter.SortColumn(COL_PROTECT, listItem => (listItem.Tag as MiniDumpMemoryInfo).Protect.ToString());
            listView1.ColumnSorter.SortColumn(COL_TYPE, listItem => (listItem.Tag as MiniDumpMemoryInfo).Type.ToString());
        }

        public MemoryInfoView(MiniDumpMemoryInfoStream memoryInfoStream, MiniDumpFile minidumpFile)
            : this()
        {
            _memoryInfoStream = memoryInfoStream;
            _minidumpFile = minidumpFile;

            if (_memoryInfoStream.NumberOfEntries == 0)
            {
                this.listView1.Items.Add("No data found for stream");
            }
            else
            {
                List<ListViewItem> listItems = new List<ListViewItem>();

                foreach (MiniDumpMemoryInfo memoryInfo in _memoryInfoStream.Entries)
                {
                    ListViewItem newItem = new ListViewItem(Formatters.FormatAsMemoryAddress(memoryInfo.BaseAddress));
                    newItem.Tag = memoryInfo;

                    // If the state is MEM_FREE then AllocationProtect, RegionSize, Protect and Type are undefined.
                    if (memoryInfo.State == MemoryState.MEM_FREE)
                    {
                        newItem.SubItems.Add(string.Empty);
                        newItem.SubItems.Add(string.Empty);
                        newItem.SubItems.Add(memoryInfo.RegionSizePretty);
                        newItem.SubItems.Add(memoryInfo.State.ToString());
                        newItem.SubItems.Add(string.Empty);
                        newItem.SubItems.Add(string.Empty);
                    }
                    else
                    {
                        newItem.SubItems.Add(Formatters.FormatAsMemoryAddress(memoryInfo.AllocationBase));
                        newItem.SubItems.Add(memoryInfo.AllocationProtect.ToString());
                        newItem.SubItems.Add(memoryInfo.RegionSizePretty);
                        newItem.SubItems.Add(memoryInfo.State.ToString());
                        // Some regions don't have any Protection information
                        newItem.SubItems.Add(((int) memoryInfo.Protect == 0) ? string.Empty : memoryInfo.Protect.ToString());
                        newItem.SubItems.Add(memoryInfo.Type.ToString());
                    }

                    listItems.Add(newItem);
                }

                listView1.AddItemsForFiltering(listItems);
            }
        }

        #region Event handlers

        private void MemoryInfoView_DoubleClick(object sender, EventArgs e)
        {
            DisplaySelectedMemoryBlock();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplaySelectedMemoryBlock();
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                DisplaySelectedMemoryBlock();

                e.Handled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSelectedMemoryBlock();
        }

        #endregion

        private void DisplaySelectedMemoryBlock()
        {
            MiniDumpMemoryInfo selectedMemoryBlock = (MiniDumpMemoryInfo)listView1.SelectedItems[0].Tag;

            byte[] data = ReadMemoryBlock(selectedMemoryBlock);

            if (data.Length <= 0) return;

            ulong startAddress = selectedMemoryBlock.BaseAddress;
            ulong endAddress = selectedMemoryBlock.BaseAddress + selectedMemoryBlock.RegionSize - 1;

            HexViewerDialog hexViewerDialog = new HexViewerDialog(data);
            hexViewerDialog.Text = $"Displaying {Formatters.FormatAsMemoryAddress(startAddress)} - {Formatters.FormatAsMemoryAddress(endAddress)} ({Formatters.FormatAsSizeString(selectedMemoryBlock.RegionSize)}, {selectedMemoryBlock.RegionSize} bytes)";

            hexViewerDialog.Show();
        }

        private void SaveSelectedMemoryBlock()
        {
            MiniDumpMemoryInfo selectedMemoryBlock = (MiniDumpMemoryInfo)listView1.SelectedItems[0].Tag;

            byte[] data = ReadMemoryBlock(selectedMemoryBlock);

            if (data.Length <= 0) return;

            saveFileDialog1.FileName = Formatters.FormatAsMemoryAddress(selectedMemoryBlock.BaseAddress);

            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            File.WriteAllBytes(saveFileDialog1.FileName, data);
        }

        private byte[] ReadMemoryBlock(MiniDumpMemoryInfo memoryBlock)
        {
            // First check if we have all of the process memory, if we don't then there's no need to proceed.
            if ((this.Memory64Stream == null) || (this.Memory64Stream.MemoryRanges.Length <= 0))
            {
                MessageBox.Show("Memory information is only available when using a full-memory dump.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new byte[0];
            }

            ulong startAddress = memoryBlock.BaseAddress;
            ulong endAddress = memoryBlock.BaseAddress + memoryBlock.RegionSize - 1;
            ulong offsetToReadFrom = MiniDumpHelper.FindMemory64Block(this.Memory64Stream, startAddress, endAddress);

            if (offsetToReadFrom == 0)
            {
                MessageBox.Show("Sorry, I couldn't locate the data for that memory region inside the minidump.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new byte[0];
            }

            byte[] data = new byte[memoryBlock.RegionSize];

            _minidumpFile.CopyMemoryFromOffset(offsetToReadFrom, data, (uint)memoryBlock.RegionSize);

            return data;
        }

        private MiniDumpMemory64Stream _memory64Stream;

        private MiniDumpMemory64Stream Memory64Stream
        {
            get
            {
                if (_memory64Stream == null)
                    _memory64Stream = _minidumpFile.ReadMemory64List();

                return _memory64Stream;
            }
        }
    }
}
