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
    public partial class ThreadNamesView : UserControl // BaseViewControl
    {
        private MiniDumpThreadNamesStream _threadNamesStream;

        public ThreadNamesView()
        {
            InitializeComponent();
        }

        public ThreadNamesView(MiniDumpThreadNamesStream threadNamesStream)
            : this()
        {
            this._threadNamesStream = threadNamesStream;

            if (_threadNamesStream.Entries.Count == 0)
            {
                this.listView1.Items.Add("No data found for stream");
            }
            else
            {
                foreach (MiniDumpThreadName thread in _threadNamesStream.Entries)
                {
                    ListViewItem newItem = new ListViewItem("0x" + thread.ThreadId.ToString("x8") + " (" + thread.ThreadId + ")");
                    newItem.SubItems.Add(thread.Name);

                    newItem.Tag = thread;

                    this.listView1.Items.Add(newItem);
                }
            }
        }
    }
}
