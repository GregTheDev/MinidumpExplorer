using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Dialogs
{
    partial class HexViewerDialog : Form
    {
        private ReadOnlyArrayByteProvider _byteProvider;
        public HexViewerDialog()
        {
            InitializeComponent();
        }

        public HexViewerDialog(byte[] data)
            : this()
        {
            this.Text = $"Displaying {DbgHelp.MinidumpFiles.Formatters.FormatAsSizeString((uint)data.Length)} ({data.Length} bytes)";

            _byteProvider = new ReadOnlyArrayByteProvider(data);

            hexBox1.ByteProvider = _byteProvider;
        }

        class ReadOnlyArrayByteProvider : IByteProvider
        {
            private byte[] _data;

            public ReadOnlyArrayByteProvider(byte[] data)
            {
                _data = data;
            }
            public long Length { get { return _data.LongLength; } }

            // Disable never used warning
            #pragma warning disable CS0067
            public event EventHandler Changed;
            #pragma warning disable CS0067
            public event EventHandler LengthChanged;

            public void ApplyChanges()
            {
                // This is ReadOnly, so no need to apply anything
                return;
            }

            public void DeleteBytes(long index, long length)
            {
                // This is ReadOnly, so no need to delete anything
                return;
            }

            public bool HasChanges()
            {
                // ReadOnly, so nothing can change
                return false;
            }

            public void InsertBytes(long index, byte[] bs)
            {
                // This is ReadOnly, so no need to insert anything
                return;
            }

            public byte ReadByte(long index)
            {
                return _data[index];
            }

            public bool SupportsDeleteBytes()
            {
                // This is ReadOnly
                return false;
            }

            public bool SupportsInsertBytes()
            {
                // This is ReadOnly
                return false;
            }

            public bool SupportsWriteByte()
            {
                // This is ReadOnly
                return false;
            }

            public void WriteByte(long index, byte value)
            {
                // This is ReadOnly, so no need to write anything
                return;
            }
        }
    }
}
