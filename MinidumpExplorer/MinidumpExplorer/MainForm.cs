using DbgHelp.MinidumpFiles;
using MinidumpExplorer.Dialogs;
using MinidumpExplorer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer
{
    public partial class MainForm : Form
    {
        private MiniDumpFile _miniDumpFile;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_miniDumpFile == null)
                return;

            UserControl viewToDisplay = null;
            int numberOfItems = 0;

            switch ((string)e.Node.Tag)
            {
                case "Modules":
                    MiniDumpModule[] moduleData = this._miniDumpFile.ReadModuleList();
                    numberOfItems = moduleData.Length;
                    viewToDisplay = new ModulesView(moduleData);
                    break;
                case "Threads":
                    MiniDumpThread[] threadData = this._miniDumpFile.ReadThreadList();
                    numberOfItems = threadData.Length;
                    viewToDisplay = new ThreadListView(threadData);
                    break;
                case "Memory":
                    MiniDumpMemoryDescriptor[] memoryData = this._miniDumpFile.ReadMemoryList();
                    numberOfItems = memoryData.Length;
                    viewToDisplay = new MemoryListView(memoryData);
                    break;
            }

            if (viewToDisplay != null)
            {
                e.Node.Text += " (" + numberOfItems + " items)";

                if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);

                viewToDisplay.Dock = DockStyle.Fill;

                this.splitContainer1.Panel2.Controls.Add(viewToDisplay);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CloseExistingSession();

                _miniDumpFile = MiniDumpFile.OpenExisting(this.openFileDialog1.FileName);

                this.treeView1.Nodes[0].Text = this.openFileDialog1.SafeFileName;
                this.treeView1.Nodes[0].ToolTipText = this.openFileDialog1.FileName;
            }
        }

        private void CloseExistingSession()
        {
            if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);

            if (_miniDumpFile != null) _miniDumpFile.Dispose();

            this.treeView1.Nodes[0].Text = "<No minidump loaded>";
        }

        private void captureMinidumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MinidumpCaptureDialog captureDialog = new MinidumpCaptureDialog();

            captureDialog.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog();
        }
    }
}
