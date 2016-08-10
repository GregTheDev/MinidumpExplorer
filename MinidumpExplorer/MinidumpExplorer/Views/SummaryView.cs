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
using MinidumpExplorer.Dialogs;

namespace MinidumpExplorer.Views
{
    public partial class SummaryView : BaseViewControl
    {
        private MiniDumpFile _miniDumpFile;

        public SummaryView()
        {
            InitializeComponent();
        }

        public SummaryView(MiniDumpFile miniDumpFile)
            : this()
        {
            _miniDumpFile = miniDumpFile;

            #region Header data

            MiniDumpHeader header = _miniDumpFile.ReadHeader();

            if (header == null) return;

            txtDateTime.Text = header.TimeDateStamp.ToString();
            txtFlags.Text = header.Flags.ToString();
            lblAvailableStreamsHeading.Text = $"Available Streams ({header.DirectoryEntries.Count} items)";

            foreach (MiniDumpDirectory directoryEntry in header.DirectoryEntries.OrderBy(entry => entry.StreamType.ToString()))
            {
                ListViewItem newItem = new ListViewItem(directoryEntry.StreamType.ToString());
                newItem.Tag = directoryEntry;
                newItem.SubItems.Add(Formatters.FormatAsMemoryAddress(directoryEntry.Location.Rva));
                newItem.SubItems.Add(directoryEntry.Location.DataSizePretty);

                listView1.Items.Add(newItem);
            }
            #endregion

            #region Module stream
            MiniDumpModule[] modules = _miniDumpFile.ReadModuleList();

            if (modules.Length > 1)
            {
                this.txtMainModule.Text = modules[0].PathAndFileName;
            }
            #endregion

            #region SystemInfo stream
            MiniDumpSystemInfoStream systemInfoStream = _miniDumpFile.ReadSystemInfo();

            if (systemInfoStream != null)
            {
                this.txtOperatingSystem.Text = systemInfoStream.OperatingSystemDescription;

                if (!string.IsNullOrEmpty(systemInfoStream.CSDVersion))
                    this.txtOperatingSystem.Text += $" ({systemInfoStream.CSDVersion})";
            }
            #endregion
        }
    }
}
