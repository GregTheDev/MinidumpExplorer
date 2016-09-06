using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Controls
{
    // Adapted from http://stackoverflow.com/questions/7705381/adding-filter-boxes-to-the-column-headers-of-a-listview-in-c-sharp-and-winforms
    class ListViewEx : ListView
    {
        public enum SortImage
        {
            None = 0x0,
            Descending = 0x200,
            Ascending = 0x400
        }

        private List<bool> HeaderDropdowns = new List<bool>();

        public class HeaderDropdownArgs : EventArgs
        {
            public int Column { get; set; }
            public Control Control { get; set; }
        }
        public event EventHandler<HeaderDropdownArgs> HeaderDropdown;

        public void DisplaySortImageOnColumn(int column, SortImage image)
        {
            HDITEM.Format format = GetColumnFormat(column);

            // Reset any existing sort images
            format &= ~HDITEM.Format.SortDown;
            format &= ~HDITEM.Format.SortUp;

            // Set new image (if any)
            if (image == SortImage.Ascending)
                format |= HDITEM.Format.SortUp;
            else if (image == SortImage.Descending)
                format |= HDITEM.Format.SortDown;

            SetColumnFormat(column, format);
        }

        protected void SetHeaderDropdown(int column, bool enable)
        {
            if (column < 0 || column >= this.Columns.Count)
                throw new ArgumentOutOfRangeException(nameof(column));

            while (HeaderDropdowns.Count < this.Columns.Count)
                HeaderDropdowns.Add(false);

            HeaderDropdowns[column] = enable;

            if (this.IsHandleCreated)
                EnableSplitButtonOnColumnHeader(column, enable);
        }

        protected void OnHeaderDropdown(int column)
        {
            var handler = HeaderDropdown;
            if (handler == null) return;
            var args = new HeaderDropdownArgs() { Column = column };
            handler(this, args);
            if (args.Control == null) return;
            //var frm = new Form();
            //frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            //frm.ShowInTaskbar = false;
            //frm.ControlBox = false;
            //args.Control.Location = Point.Empty;
            //frm.Controls.Add(args.Control);
            //frm.Load += delegate { frm.MinimumSize = new Size(1, 1); frm.Size = frm.Controls[0].Size; };
            //frm.Deactivate += delegate { frm.Dispose(); };
            //frm.StartPosition = FormStartPosition.Manual;
            //var rc = GetHeaderRect(column);
            //frm.Location = this.PointToScreen(new Point(rc.Right - SystemInformation.MenuButtonSize.Width, rc.Bottom));
            //frm.Show(this.FindForm());
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.Columns.Count == 0 || Environment.OSVersion.Version.Major < 6 || HeaderDropdowns == null) return;
            for (int col = 0; col < HeaderDropdowns.Count; ++col)
            {
                if (HeaderDropdowns[col]) EnableSplitButtonOnColumnHeader(col, true);
            }
        }

        protected Rectangle GetHeaderRect(int column)
        {
            IntPtr hHeader = SendMessage(this.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            RECT rc;
            SendMessage(hHeader, HDM_GETITEMRECT, (IntPtr)column, out rc);
            return new Rectangle(rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
        }

        protected Rectangle GetSplitButtonRect(int column)
        {
            IntPtr hHeader = SendMessage(this.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            RECT rc;
            SendMessage(hHeader, HDM_GETITEMDROPDOWNRECT, (IntPtr)column, out rc);
            return new Rectangle(rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
        }

        protected void EnableSplitButtonOnColumnHeader(int column, bool enable)
        {
            HDITEM headerItem = new HDITEM();
            headerItem.mask = HDITEM.Mask.Format;

            IntPtr columnHeader = SendMessage(this.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            SendMessage(columnHeader, HDM_GETITEM, (IntPtr)column, ref headerItem);

            if (enable)
                headerItem.fmt |= HDITEM.Format.SplitButton;
            else
                headerItem.fmt &= ~HDITEM.Format.SplitButton;

            IntPtr res = SendMessage(columnHeader, HDM_SETITEM, (IntPtr)column, ref headerItem);
        }

        private HDITEM.Format GetColumnFormat(int column)
        {
            IntPtr hresult;
            IntPtr columnHeader = SendMessage(this.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);

            HDITEM item = new HDITEM();
            item.mask = HDITEM.Mask.Format;

            hresult = SendMessage(columnHeader, HDM_GETITEM, (IntPtr)column, ref item);
            if (hresult != TRUE)
                throw new Win32Exception();
            else
                return item.fmt;
        }

        private void SetColumnFormat(int column, HDITEM.Format format)
        {
            IntPtr hresult;
            IntPtr columnHeader = SendMessage(this.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);

            HDITEM item = new HDITEM();
            item.mask = HDITEM.Mask.Format;
            item.fmt = format;

            //hresult = SendMessage(columnHeader, HDM_GETITEM, (IntPtr) column, ref item);
            //if (hresult != TRUE) return;

            //item.fmt |= format;
            hresult = SendMessage(columnHeader, HDM_SETITEM, (IntPtr)column, ref item);
        }

        protected override void WndProc(ref Message m)
        {
            //Console.WriteLine(m);
            if (m.Msg == WM_NOTIFY)
            {
                var hdr = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
                if (hdr.code == LVN_COLUMNDROPDOWN)
                {
                    var info = (NMLISTVIEW)Marshal.PtrToStructure(m.LParam, typeof(NMLISTVIEW));
                    OnHeaderDropdown(info.iSubItem);
                    return;
                }
            }
            base.WndProc(ref m);
        }

        // Pinvoke
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, ref LVCOLUMN lvc);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, out RECT rc);
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWnd, IntPtr hParent);

        private readonly IntPtr TRUE = new IntPtr(1);
        private readonly IntPtr FALSE = new IntPtr(0);
        private const int LVM_FIRST = 0x1000;
        private const int LVM_GETCOLUMN = LVM_FIRST + 95;
        private const int LVM_SETCOLUMN = LVM_FIRST + 96;
        private const int LVCF_FMT = 1;
        private const int LVCFMT_LEFT = 0x0000;
        private const int LVCF_IMAGE = 0x0010;
        private const int LVCFMT_IMAGE = 2048; // 0x800
        private const int LVCFMT_SPLITBUTTON = 0x1000000;
        private const int LVCFMT_COL_HAS_IMAGES = 0x8000;
        private const int WM_NOTIFY = 0x204e;
        private const int LVN_COLUMNDROPDOWN = -100 - 64;
        private const int LVM_GETHEADER = 0x1000 + 31;
        private const int HDI_FORMAT = 0x0004;
        private const int HDI_IMAGE = 0x0020;
        private const int HDI_ORDER = 0x0080;
        private const int HDM_FIRST = 0x1200;
        private const int HDM_GETITEMRECT = HDM_FIRST + 7;
        private const int HDM_SETIMAGELIST = HDM_FIRST + 8;
        private const int HDM_GETITEM = HDM_FIRST + 11;
        private const int HDM_SETITEM = HDM_FIRST + 12;
        private const int HDM_GETITEMDROPDOWNRECT = HDM_FIRST + 25;
        private const int HDF_SPLITBUTTON = 0x1000000;
        private const int BCSIF_GLYPH = 0x0001;
        private const int BCSIF_IMAGE = 0x0002;
        private const int BCSIF_STYLE = 0x0004;
        private const int BCSIF_SIZE = 0x0008;
        private const int HDSIL_NORMAL = 0;
        private const int HDSIL_STATE = 1;
        private const int I_IMAGENONE = -2;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct LVCOLUMN
        {
            public uint mask;
            public int fmt;
            public int cx;
            public string pszText;
            public int cchTextMax;
            public int iSubItem;
            public int iImage;
            public int iOrder;
            public int cxMin;
            public int cxDefault;
            public int cxIdeal;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct POINT
        {
            public int x, y;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct RECT
        {
            public int left, top, right, bottom;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct NMLISTVIEW
        {
            public NMHDR hdr;
            public int iItem;
            public int iSubItem;
            public uint uNewState;
            public uint uOldState;
            public uint uChanged;
            public POINT ptAction;
            public IntPtr lParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HDITEM
        {
            public Mask mask;
            public int cxy;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public IntPtr hbm;
            public int cchTextMax;
            public Format fmt;
            public IntPtr lParam;
            // _WIN32_IE >= 0x0300 
            public int iImage;
            public int iOrder;
            // _WIN32_IE >= 0x0500
            public uint type;
            public IntPtr pvFilter;
            // _WIN32_WINNT >= 0x0600
            public uint state;

            [Flags]
            public enum Mask
            {
                Format = 0x4,       // HDI_FORMAT
                Image = 0x0020,     // HDI_IMAGE
                Order = 0x0080  // HDI_ORDER 
            };

            [Flags]
            public enum Format
            {
                Left = 0x0000,          // HDF_LEFT
                Right = 0x0001,         // HDF_RIGHT
                Center = 0x0002,        // HDF_CENTER
                JustifyMask = 0x0003,   // HDF_JUSTIFYMASK
                RtlReading = 0x0004,    // HDF_RTLREADING
                Bitmap = 0x2000,        // HDF_BITMAP
                String = 0x4000,        // HDF_STRING
                OwnderDraw = 0x8000,    // HDF_OWNERDRAW
                Image = 0x0800,         // HDF_IMAGE
                BitmapOnRight = 0x1000, // HDF_BITMAP_ON_RIGHT
                SortDown = 0x200,       // HDF_SORTDOWN
                SortUp = 0x400,         // HDF_SORTUP
                Checkbox = 0x0040,      // HDF_CHECKBOX
                Checked = 0x0080,       // HDF_CHECKED
                FixedWidth = 0x0100,    // HDF_FIXEDWIDTH
                SplitButton = 0x1000000 // HDF_SPLITBUTTON
            };
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct SIZE
        {
            public int cx;
            public int cy;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BUTTON_SPLITINFO
        {
            public uint mask;
            public IntPtr himlGlyph; // HIMAGELIST
            public uint uSplitStyle;
            public SIZE size;
        }
    }
}
