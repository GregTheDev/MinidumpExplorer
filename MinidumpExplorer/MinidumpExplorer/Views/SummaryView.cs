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

            MiniDumpHeader header = _miniDumpFile.ReadHeader();

            if (header == null) return;

            lblNumberOfStreams.Text = header.NumberOfStreams.ToString();
            lblDateTime.Text = header.TimeDateStamp.ToString();
            lblFlags.Text = header.Flags.ToString();

            foreach (MiniDumpDirectory directoryEntry in header.DirectoryEntries.OrderBy(entry => entry.StreamType.ToString()))
            {
                ListViewItem newItem = new ListViewItem(directoryEntry.StreamType.ToString());
                newItem.Tag = directoryEntry;
                newItem.SubItems.Add(Formatters.FormatAsMemoryAddress(directoryEntry.Location.Rva));
                newItem.SubItems.Add(directoryEntry.Location.DataSizePretty);

                listView1.Items.Add(newItem);
            }

            MiniDumpModule[] modules = _miniDumpFile.ReadModuleList();

            if (modules.Length > 1)
            {
                this.lblMainModule.Text = modules[0].PathAndFileName;
            }
        }
    }
}
