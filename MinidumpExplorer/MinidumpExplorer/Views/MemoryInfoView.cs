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
        private ListViewColumnSorter lvwColumnSorter;
        private List<ListViewItem> _originalItems;

        public MemoryInfoView()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            lvwColumnSorter.Order = SortOrder.Ascending;

            listView1.SetHeaderDropdown(2, true);
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            this.listView1.HeaderDropdown += ListView1_HeaderDropdown;
        }

        private void ListView1_HeaderDropdown(object sender, ListViewEx.HeaderDropdownArgs e)
        {
            ContextMenuStrip lala = new ContextMenuStrip();

            var distinctValues = _originalItems
                .Select(item => item.SubItems[e.Column].Text)
                .Distinct();

            foreach (var item in distinctValues)
            {
                ToolStripCheckBoxMenuItem newItem = new ToolStripCheckBoxMenuItem(String.IsNullOrEmpty(item) ? "(blank)" : item);
                newItem.Click += NewItem_Click1;
                lala.Items.Add(newItem);
            }

            lala.Closing += Lala_Closing;

            Rectangle columnHeader = listView1.GetHeaderRect(e.Column);
            Rectangle splitButtonRect = listView1.GetSplitButtonRect(e.Column);
            Point lele = new Point(columnHeader.Right - splitButtonRect.Width, columnHeader.Bottom);

            lala.Show(listView1, lele);

        }

        private void NewItem_Click1(object sender, EventArgs e)
        {
            ToolStripCheckBoxMenuItem menuItem = (ToolStripCheckBoxMenuItem)sender;

            // This line creates an array containing the text of all
            // menu items inside a context menu that are checked.
            var selectedFilters = menuItem.Owner.Items.Cast<ToolStripCheckBoxMenuItem>().Where(item => item.Checked).Select(item => item.Text).ToArray();

            listView1.SuspendLayout();

            try
            {
                // This line says look at the master list of items and select any item where 
                // the text of the 3rd column (item.SubItems[2].Text) matches one of the
                // entries that were checked in the context menu.
                var itemsToAdd = _originalItems.Where(item => Array.IndexOf(selectedFilters, item.SubItems[2].Text) >= 0);

                listView1.Items.Clear();
                listView1.Items.AddRange(itemsToAdd.ToArray());
            }
            finally
            {
                listView1.ResumeLayout();
            }
        }

        private void NewItem_Click(object sender, EventArgs e)
        {
            ToolStripCheckBoxMenuItem menuItem = (ToolStripCheckBoxMenuItem)sender;

            menuItem.Checked = !menuItem.Checked;

            System.Diagnostics.Debug.WriteLine(menuItem.ToString() + ".Checked = " + menuItem.Checked);
        }

        private void Lala_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
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
                _originalItems = new List<ListViewItem>();

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

                    //this.listView1.Items.Add(newItem);
                    _originalItems.Add(newItem);
                }

                listView1.Items.AddRange(_originalItems.ToArray());
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }
    }
}
