using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbgHelp.MinidumpFiles;

namespace MinidumpExplorer.Views
{
    public partial class HandleDataView : BaseViewControl
    {
        public HandleDataView()
        {
            InitializeComponent();
        }

        public HandleDataView(MiniDumpHandleDescriptor[] handles)
            : this()
        {
            foreach (MiniDumpHandleDescriptor handle in handles)
            {
                ListViewItem newItem = new ListViewItem("0x" + handle.HandleId.ToString("X8"));
                newItem.SubItems.Add(handle.TypeName);
                newItem.SubItems.Add(handle.ObjectName);

                newItem.Tag = handle;

                this.listView1.Items.Add(newItem);
            }
        }
    }
}
