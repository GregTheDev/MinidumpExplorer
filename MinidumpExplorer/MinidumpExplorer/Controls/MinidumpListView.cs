using MinidumpExplorer.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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

            IEnumerable<ListViewItem> items = null;

            foreach (var fitlerOption in _filterMenus)
            {
                var selectedFiltersForThisColumn = fitlerOption.Value.Items.Cast<ToolStripCheckBoxMenuItem>().Where(item => item.Checked).Select(item => item.Text).ToArray();

                if (selectedFiltersForThisColumn.Length == 0) continue;

                if (items == null)
                    items = _originalItems.Where(item => Array.IndexOf(selectedFiltersForThisColumn, item.SubItems[fitlerOption.Key].Text) >= 0);
                else
                    items = items.Where(item => Array.IndexOf(selectedFiltersForThisColumn, item.SubItems[fitlerOption.Key].Text) >= 0);
            }

            this.SuspendLayout();

            try
            {
                this.Items.Clear();
                this.Items.AddRange(items.ToArray());
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
