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

namespace MinidumpExplorer.Views
{
    public partial class MemoryInfoView : BaseViewControl
    {
        private MiniDumpMemoryInfoStream _memoryInfoStream;
        private List<ListViewItem> _originalItems;

        public MemoryInfoView()
        {
            InitializeComponent();

            listView1.SetFilteringForColumn(2, true);
        }

        public MemoryInfoView(MiniDumpMemoryInfoStream memoryInfoStream)
            : this()
        {
            _memoryInfoStream = memoryInfoStream;

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
    }
}
