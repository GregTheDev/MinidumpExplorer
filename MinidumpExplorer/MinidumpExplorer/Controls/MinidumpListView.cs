﻿using MinidumpExplorer.Utilities;
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
        private ImageList _smallImages;

        private const int IMG_ASC = 0;
        private const int IMG_DESC = 1;
        private const int IMG_FLTR_ASC = 2;
        private const int IMG_FLTR_DESC = 3;
        private const int IMG_FLTR = 4;

        public MinidumpListView()
            : base ()
        {
            _lvwColumnSorter = new ListViewColumnSorter();
            _lvwColumnSorter.Order = SortOrder.Ascending;

            _filterMenus = new Dictionary<int, ContextMenuStrip>();

            _smallImages = new ImageList();
            _smallImages.Images.Add(Properties.Resources.asc);
            _smallImages.Images.Add(Properties.Resources.desc);
            _smallImages.Images.Add(Properties.Resources.fltr_asc);
            _smallImages.Images.Add(Properties.Resources.fltr_desc);
            _smallImages.Images.Add(Properties.Resources.fltr);
            this.SmallImageList = _smallImages;

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
                int originalColumn = _lvwColumnSorter.SortColumn;

                // Set the column number that is to be sorted; default to ascending.
                _lvwColumnSorter.SortColumn = e.Column;
                _lvwColumnSorter.Order = SortOrder.Ascending;

                // Remove previous sort icon
                UpdateColumnImage(originalColumn);
            }

            // Perform the sort with these new sort options.
            this.Sort();
            //this.SetSortIcon(e.Column, _lvwColumnSorter.Order);
            UpdateColumnImage(e.Column);

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

            foreach (var filterOption in _filterMenus)
            {
                var selectedFiltersForThisColumn = filterOption.Value.Items.Cast<ToolStripCheckBoxMenuItem>().Where(item => item.Checked).Select(item => item.Text).ToArray();

                if (selectedFiltersForThisColumn.Length == 0)
                {
                    //this.Columns[fitlerOption.Key].ImageIndex = -1;
                    //SetImageOnColumnHeader(filterOption.Key, false);
                    UpdateColumnImage(filterOption.Key, false);

                    continue;
                }

                //this.Columns[fitlerOption.Key].ImageIndex = 0;
                //SetImageOnColumnHeader(filterOption.Key, true);
                UpdateColumnImage(filterOption.Key, true);

                if (items == null)
                    items = _originalItems.Where(item => Array.IndexOf(selectedFiltersForThisColumn, item.SubItems[filterOption.Key].Text) >= 0);
                else
                    items = items.Where(item => Array.IndexOf(selectedFiltersForThisColumn, item.SubItems[filterOption.Key].Text) >= 0);
            }

            this.SuspendLayout();

            try
            {
                this.Items.Clear();
                this.Items.AddRange((items == null) ? _originalItems.ToArray() : items.ToArray());
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void UpdateColumnImage(int column)
        {
            if (_filterMenus.ContainsKey(column))
            {
                var firstFilterForThisColumn = _filterMenus[column].Items.Cast<ToolStripCheckBoxMenuItem>().Where(item => item.Checked).Select(item => item.Text).FirstOrDefault();

                UpdateColumnImage(column, firstFilterForThisColumn != null);
            }
            else
            {
                UpdateColumnImage(column, false);
            }
        }

        private void UpdateColumnImage(int column, bool filtered)
        {
            // Is the column sorted?
            if (_lvwColumnSorter.SortColumn == column)
            {
                if ((_lvwColumnSorter.Order == SortOrder.Ascending) && (filtered)) SetImageOnColumnHeader(column, IMG_FLTR_ASC);
                else if ((_lvwColumnSorter.Order == SortOrder.Descending) && (filtered)) SetImageOnColumnHeader(column, IMG_FLTR_DESC);
                else if ((_lvwColumnSorter.Order == SortOrder.Ascending) && (!filtered)) SetImageOnColumnHeader(column, IMG_ASC);
                else if ((_lvwColumnSorter.Order == SortOrder.Descending) && (!filtered)) SetImageOnColumnHeader(column, IMG_DESC);
            }
            else
            {
                if (filtered) SetImageOnColumnHeader(column, IMG_FLTR);
                else SetImageOnColumnHeader(column, -1);

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