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

namespace MinidumpExplorer.Views
{
    public partial class MemoryInfoView : BaseViewControl
    {
        private MiniDumpMemoryInfoStream _memoryInfoStream;

        public MemoryInfoView()
        {
            InitializeComponent();
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
                foreach (MiniDumpMemoryInfo memoryInfo in _memoryInfoStream.Entries)
                {
                    ListViewItem newItem = new ListViewItem(String.Format("0x{0:x8}", memoryInfo.BaseAddress));

                    // If the state is MEM_FREE then AllocationProtect, RegionSize, Protect and Type
                    // are undefined.
                    if (memoryInfo.State == MemoryState.MEM_FREE)
                    {
                        newItem.SubItems.Add("");
                        newItem.SubItems.Add("");
                        newItem.SubItems.Add(memoryInfo.RegionSizePretty);
                        newItem.SubItems.Add(memoryInfo.State.ToString());
                        newItem.SubItems.Add("");
                        newItem.SubItems.Add("");
                    }
                    else
                    {
                        newItem.SubItems.Add(String.Format("0x{0:x8}", memoryInfo.AllocationBase));
                        newItem.SubItems.Add(memoryInfo.AllocationProtect.ToString());
                        newItem.SubItems.Add(memoryInfo.RegionSizePretty);
                        newItem.SubItems.Add(memoryInfo.State.ToString());
                        newItem.SubItems.Add(memoryInfo.Protect.ToString());
                        newItem.SubItems.Add(memoryInfo.Type.ToString());
                    }

                    this.listView1.Items.Add(newItem);
                }
            }
        }
    }
}
