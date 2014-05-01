using DbgHelp.MinidumpFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Views
{
    public partial class ThreadListView : BaseViewControl
    {
        private MiniDumpThread[] _threadList;

        public ThreadListView()
        {
            InitializeComponent();
        }

        public ThreadListView(MiniDumpThread[] threadList)
            : this()
        {
            _threadList = threadList;

            if (_threadList.Length == 0)
            {
                this.listView1.Items.Add("No data found for stream");
            }
            else
            {
                foreach (MiniDumpThread thread in threadList)
                {
                    ListViewItem newItem = new ListViewItem("0x" + thread.ThreadId.ToString("X8") + " (" + thread.ThreadId + ")");
                    newItem.SubItems.Add(thread.SuspendCount.ToString());
                    newItem.SubItems.Add(thread.PriorityClass.ToString());
                    newItem.SubItems.Add(thread.Priority.ToString());
                    newItem.SubItems.Add("0x" + thread.Teb.ToString("X8"));
                    newItem.SubItems.Add(thread.Stack.StartOfMemoryRangeFormatted + " (" + thread.Stack.Memory.DataSizePretty + ")");
                    newItem.SubItems.Add(thread.ThreadContext.DataSize + " bytes");

                    newItem.Tag = thread;

                    this.listView1.Items.Add(newItem);
                }
            }
        }
    }
}
