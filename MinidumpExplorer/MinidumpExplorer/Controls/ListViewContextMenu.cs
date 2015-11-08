using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Controls
{
    public class ListViewContextMenu : ContextMenuStrip
    {
        ToolStripMenuItem _copyMenuItem;

        public ListViewContextMenu(System.ComponentModel.IContainer container)
            : base(container)
        {
            _copyMenuItem = new ToolStripMenuItem("Copy");
            _copyMenuItem.Name = "Reserved_Copy";

            this.Items.Add(_copyMenuItem);

            this.Opening += ListViewContextMenu_Opening;
        }

        void ListViewContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _copyMenuItem.DropDownItems.Clear();

            if (this.SourceControl is ListView)
            {
                ListView parent = (ListView)this.SourceControl;

                foreach (ColumnHeader columnHeader in parent.Columns)
                {
                    ToolStripMenuItem headingMenuItem = new ToolStripMenuItem(columnHeader.Text);
                    headingMenuItem.Tag = parent;
                    headingMenuItem.Click += copyMenuItem_Click;

                    _copyMenuItem.DropDownItems.Add(headingMenuItem);
                }
            }
        }

        void copyMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ListView parent = (ListView)menuItem.Tag;
            int columnIndex = -1;

            for (int i = 0; i < parent.Columns.Count; i++)
            {
                if (parent.Columns[i].Text == menuItem.Text)
                {
                    columnIndex = i;
                    continue;
                }
            }

            if (columnIndex == -1) return;
            if (parent.SelectedItems.Count != 1) return;

            if (columnIndex < parent.SelectedItems[0].SubItems.Count)
                Clipboard.SetText(parent.SelectedItems[0].SubItems[columnIndex].Text);
            else
                Clipboard.Clear();
        }
    }
}