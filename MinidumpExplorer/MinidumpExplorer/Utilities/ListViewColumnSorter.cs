using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Utilities
{
    internal class ListViewColumnSorter : IComparer
    {
        public int SortColumn { get; set; }
        public SortOrder Order { get; set; }

        public ListViewColumnSorter()
        {
            this.SortColumn = 0;
            this.Order = SortOrder.None;
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            object x1 = listviewX.SubItems[this.SortColumn].Tag;
            object y1 = listviewY.SubItems[this.SortColumn].Tag;

            if ((x1 == null) && (y1 == null))
                compareResult = 0;
            else if (x1 == null)
                compareResult = -1; // If x1 is null assume it's less than y1
            else if (y1 == null)
                compareResult = 1; // If y1 is null assume it's less than x1
            else
            {
                // Compare enums based on their text description, not value
                if (x1.GetType().IsEnum)
                    compareResult = Comparer.Default.Compare(x1.ToString(), y1.ToString());
                else
                    compareResult = Comparer.Default.Compare(x1, y1);
            }

            // Calculate correct return value based on object comparison
            if (this.Order == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (this.Order == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }
   }
}