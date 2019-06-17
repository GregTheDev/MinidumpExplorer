using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DbgHelp.MinidumpFiles;

namespace MinidumpExplorer.Views
{
    public partial class MemoryListView : BaseViewControl
    {
        private MiniDumpMemoryDescriptor[] _memoryList;

        public MemoryListView()
        {
            InitializeComponent();
        }

        public MemoryListView(MiniDumpMemoryDescriptor[] memoryList)
            : this()
        {
            _memoryList = memoryList;

            if (_memoryList.Length == 0)
            {
                this.listView1.Items.Add("No data found for stream");
            }
            else
            {
                foreach (MiniDumpMemoryDescriptor memoryRange in memoryList)
                {
                    ListViewItem newItem = new ListViewItem(memoryRange.StartOfMemoryRangeFormatted);
                    newItem.SubItems.Add(memoryRange.EndOfMemoryRangeFormatted);
                    newItem.SubItems.Add(memoryRange.Memory.DataSizePretty);

                    this.listView1.Items.Add(newItem);
                }
            }
        }
    }
}
