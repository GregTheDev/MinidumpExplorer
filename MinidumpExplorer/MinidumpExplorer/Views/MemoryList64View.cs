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
    public partial class MemoryList64View : BaseViewControl
    {
        private MiniDumpMemoryDescriptor64[] _memoryList;

        public MemoryList64View()
        {
            InitializeComponent();
        }

        public MemoryList64View(MiniDumpMemoryDescriptor64[] memoryList)
            : this()
        {
            _memoryList = memoryList;

            if (_memoryList.Length == 0)
            {
                this.listView1.Items.Add("No data found for stream");
            }
            else
            {
                foreach (MiniDumpMemoryDescriptor64 memoryRange in memoryList)
                {
                    ListViewItem newItem = new ListViewItem(memoryRange.StartOfMemoryRangeFormatted);
                    newItem.SubItems.Add(memoryRange.EndOfMemoryRangeFormatted);
                    newItem.SubItems.Add(memoryRange.DataSizePretty);

                    this.listView1.Items.Add(newItem);
                }
            }
        }
    }
}
