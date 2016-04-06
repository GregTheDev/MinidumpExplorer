using MinidumpExplorer.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Controls
{
    class MinidumpListView : ListViewEx
    {
        private ListViewColumnSorter _lvwColumnSorter;
        private List<ListViewItem> _originalItems;
        private Dictionary<int, ContextMenuStrip> _filterMenus;

        public MinidumpListView()
            : base ()
        {
            _lvwColumnSorter = new ListViewColumnSorter();
            _lvwColumnSorter.Order = SortOrder.Ascending;

            _filterMenus = new Dictionary<int, ContextMenuStrip>();

            this.ListViewItemSorter = _lvwColumnSorter;
            this.HeaderDropdown += DisplayColumnHeaderDropdown;
        }

        public void SetFilteringForColumn(int columnIndex, bool enabled)
        {
            if (enabled)
            {
                if (!_filterMenus.ContainsKey(columnIndex))
                    _filterMenus[columnIndex] = null;
            }
            else
            {
                if (_filterMenus.ContainsKey(columnIndex))
                    _filterMenus.Remove(columnIndex);
            }

            SetHeaderDropdown(columnIndex, enabled);
        }

        public void AddItemsForFiltering(List<ListViewItem> items)
        {
            _originalItems = items;

            this.Items.AddRange(_originalItems.ToArray());

            BuildFilterMenu();
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    _lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    _lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwColumnSorter.SortColumn = e.Column;
                _lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.Sort();
            this.SetSortIcon(e.Column, _lvwColumnSorter.Order);

            base.OnColumnClick(e);
        }

        private void BuildFilterMenu()
        {
            foreach (int columnIndex in _filterMenus.Keys.ToList())
            {
                ContextMenuStrip filterMenu = new ContextMenuStrip();

                var distinctValues = _originalItems
                    .Select(item => item.SubItems[columnIndex].Text)
                    .Distinct();

                foreach (var item in distinctValues)
                {
                    ToolStripCheckBoxMenuItem newItem = new ToolStripCheckBoxMenuItem(String.IsNullOrEmpty(item) ? "(blank)" : item);
                    newItem.Click += FilterMenuItem_Click;
                    filterMenu.Items.Add(newItem);
                }

                filterMenu.Closing += FitlerMenu_Closing;

                _filterMenus[columnIndex] = filterMenu;
            }
        }

        private void FitlerMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }

        private void FilterMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripCheckBoxMenuItem menuItem = (ToolStripCheckBoxMenuItem)sender;

            // This line creates an array containing the text of all
            // menu items inside a context menu that are checked.
            var selectedFilters = menuItem.Owner.Items.Cast<ToolStripCheckBoxMenuItem>().Where(item => item.Checked).Select(item => item.Text).ToArray();

            this.SuspendLayout();

            try
            {
                // This line says look at the master list of items and select any item where 
                // the text of the 3rd column (item.SubItems[2].Text) matches one of the
                // entries that were checked in the context menu.
                var itemsToAdd = _originalItems.Where(item => Array.IndexOf(selectedFilters, item.SubItems[2].Text) >= 0);

                this.Items.Clear();
                this.Items.AddRange(itemsToAdd.ToArray());
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void DisplayColumnHeaderDropdown(object sender, ListViewEx.HeaderDropdownArgs e)
        {
            ContextMenuStrip menuToDisplay = _filterMenus[e.Column];

            Rectangle columnHeader = this.GetHeaderRect(e.Column);
            Rectangle splitButtonRect = this.GetSplitButtonRect(e.Column);
            Point displayPoint = new Point(columnHeader.Right - splitButtonRect.Width, columnHeader.Bottom);

            menuToDisplay.Show(this, displayPoint);
        }
    }
}
