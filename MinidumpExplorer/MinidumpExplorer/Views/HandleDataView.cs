using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbgHelp.MinidumpFiles;
using MinidumpExplorer.Controls;

namespace MinidumpExplorer.Views
{
    public partial class HandleDataView : BaseViewControl
    {
        private const int COL_ID = 0;
        private const int COL_HANDLE_TYPE = 1;
        private const int COL_OBJECT = 2;

        public HandleDataView()
        {
            InitializeComponent();

            listView1.SetFilteringForColumn(COL_HANDLE_TYPE, true);

            listView1.ColumnSorter.SortColumn(COL_ID, listViewItem => (listViewItem.Tag as MiniDumpHandleDescriptor).HandleId);
        }

        public HandleDataView(MiniDumpHandleDescriptor[] handles)
            : this()
        {
            List<ListViewItem> listItems = new List<ListViewItem>();

            foreach (MiniDumpHandleDescriptor handle in handles)
            {
                ListViewItem newItem = new ListViewItem(Formatters.FormatAsHex(handle.HandleId));
                newItem.Tag = handle;

                newItem.SubItems.Add(handle.TypeName);
                newItem.SubItems.Add(handle.ObjectName);

                listItems.Add(newItem);
            }

            listView1.AddItemsForFiltering(listItems);
        }
    }
}
