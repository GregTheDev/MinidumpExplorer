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
            string nodeText = String.Empty; // Quick fix for duplicated item counts in node text

            switch ((string)e.Node.Tag)
            {
                case "Handles":
                    nodeText = "Handles";
                    MiniDumpHandleDescriptor[] handleData = this._miniDumpFile.ReadHandleData();
                    numberOfItems = handleData.Length;
                    viewToDisplay = new HandleDataView(handleData);
                    break;
                case "Modules":
                    nodeText = "Modules";
                    MiniDumpModule[] moduleData = this._miniDumpFile.ReadModuleList();
                    numberOfItems = moduleData.Length;
                    viewToDisplay = new ModulesView(moduleData);
                    break;
                case "Threads":
                    nodeText = "Threads";
                    MiniDumpThread[] threadData = this._miniDumpFile.ReadThreadList();
                    numberOfItems = threadData.Length;
                    viewToDisplay = new ThreadListView(threadData);
                    break;
                case "ThreadInfo":
                    nodeText = "ThreadInfo";
                    MiniDumpThreadInfo[] threadInfoData = this._miniDumpFile.ReadThreadInfoList();
                    numberOfItems = threadInfoData.Length;
                    viewToDisplay = new ThreadInfoListView(threadInfoData);
                    break;
                case "Memory":
                    nodeText = "Memory";
                    MiniDumpMemoryDescriptor[] memoryData = this._miniDumpFile.ReadMemoryList();
                    numberOfItems = memoryData.Length;
                    viewToDisplay = new MemoryListView(memoryData);
                    break;
                case "Memory64":
                    nodeText = "Memory64";
                    MiniDumpMemory64Stream memory64Data = this._miniDumpFile.ReadMemory64List();
                    numberOfItems = memory64Data.MemoryRanges.Length;
                    viewToDisplay = new MemoryList64View(memory64Data.MemoryRanges);
                    break;
                case "MemoryInfo":
                    nodeText = "MemoryInfo";
                    MiniDumpMemoryInfoStream memoryInfo = this._miniDumpFile.ReadMemoryInfoList();
                    numberOfItems = memoryInfo.Entries.Length;
                    viewToDisplay = new MemoryInfoView(memoryInfo);
                    break;
                case "MiscInfo":
                    nodeText = "MiscInfo";
                    MiniDumpMiscInfo miscInfo = this._miniDumpFile.ReadMiscInfo();
                    numberOfItems = 1;
                    viewToDisplay = new MiscInfoView(miscInfo);
                    break;
                case "SystemInfo":
                    nodeText = "SystemInfo";
                    MiniDumpSystemInfoStream systemInfo = this._miniDumpFile.ReadSystemInfo();
                    numberOfItems = 1;
                    viewToDisplay = new SystemInfoView(systemInfo);
                    break;
                case "Exception":
                    nodeText = "Exception";
                    MiniDumpExceptionStream exceptionStream = this._miniDumpFile.ReadExceptionStream();

                    if (exceptionStream == null)
                        numberOfItems = 0;
                    else
                        numberOfItems = 1;

                    viewToDisplay = new ExceptionStreamView(exceptionStream);
                    break;
                case "UnloadedModules":
                    nodeText = "UnloadedModules";
                    MiniDumpUnloadedModulesStream unloadedModulesStream = this._miniDumpFile.ReadUnloadedModuleList();
                    numberOfItems = (int) unloadedModulesStream.NumberOfEntries;
                    viewToDisplay = new UnloadedModulesView(unloadedModulesStream);
                    break;
            }

            if (viewToDisplay != null)
            {
                e.Node.Text = nodeText + " (" + numberOfItems + (numberOfItems == 1 ? " item" : " items" ) + ")";

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
