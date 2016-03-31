using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Controls
{
    internal class ListViewSubItemEx : ListViewItem.ListViewSubItem
    {
        public ListViewSubItemEx(ListViewItem owner, string text, object tag)
             : base(owner, text)
        {
            this.Tag = tag;
        }
    }
}
