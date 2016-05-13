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
                    ListViewItem newItem = new ListViewItem(String.Format("0x{0:x8}", memoryInfo.BaseAddress));
                    newItem.Tag = memoryInfo;
                    newItem.SubItems[0].Tag = memoryInfo.BaseAddress;

                    // If the state is MEM_FREE then AllocationProtect, RegionSize, Protect and Type
                    // are undefined.
                    if (memoryInfo.State == MemoryState.MEM_FREE)
                    {
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, "", null));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, "", null));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, memoryInfo.RegionSizePretty, memoryInfo.RegionSize));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, memoryInfo.State.ToString(), memoryInfo.State));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, "", null));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, "", null));
                    }
                    else
                    {
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, String.Format("0x{0:x8}", memoryInfo.AllocationBase), memoryInfo.AllocationBase));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, memoryInfo.AllocationProtect.ToString(), memoryInfo.AllocationProtect));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, memoryInfo.RegionSizePretty, memoryInfo.RegionSize));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, memoryInfo.State.ToString(), memoryInfo.State));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, memoryInfo.Protect.ToString(), memoryInfo.Protect));
                        newItem.SubItems.Add(new ListViewSubItemEx(newItem, memoryInfo.Type.ToString(), memoryInfo.Type));
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

        #endregion

        private void DisplaySelectedMemoryBlock()
        {
            MiniDumpMemoryInfo memoryBlock = (MiniDumpMemoryInfo)listView1.SelectedItems[0].Tag;

            // First check if we have all of the process memory, if we don't then there's no need to proceed.
            if ((this.Memory64Stream == null) || (this.Memory64Stream.MemoryRanges.Length <= 0))
            {
                MessageBox.Show("Memory information is only available when using a full-memory dump.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ulong startAddress = memoryBlock.BaseAddress;
            ulong endAddress = memoryBlock.BaseAddress + memoryBlock.RegionSize - 1;
            ulong offsetToReadFrom = MiniDumpHelper.FindInclusiveMemory64Block(this.Memory64Stream, startAddress, endAddress);

            if (offsetToReadFrom == 0)
            {
                MessageBox.Show("Sorry, I couldn't locate the data for that memory region inside the minidump.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            byte[] data = new byte[memoryBlock.RegionSize];

            _minidumpFile.CopyMemoryFromOffset(offsetToReadFrom, data, (uint)memoryBlock.RegionSize);

            HexViewerDialog hexViewerDialog = new HexViewerDialog(data);
            hexViewerDialog.Text = $"Displaying {Formatters.FormatAsMemoryAddress(startAddress)} - {Formatters.FormatAsMemoryAddress(endAddress)} ({Formatters.FormatAsSizeString(memoryBlock.RegionSize)}, {memoryBlock.RegionSize} bytes)";

            hexViewerDialog.Show();
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
