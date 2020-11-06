using DbgHelp.MinidumpFiles;
using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Dialogs
{
    public partial class MinidumpCaptureDialog : Form
    {
        public const int E_ACCESSDENIED = -2147467259; // Access denied (0x80070005). 

        private const int TP_PROCESS_LIST = 0;
        private const int TP_MINIDUMP_OPTIONS = 1;
        private const int TP_SAVE_LOCATION = 2;
        private const int TP_DONE = 3;

        private IndeterminateProgressDialog _progressDialog;

        public MinidumpCaptureDialog()
        {
            InitializeComponent();

            this.wizardControl1.SelectedIndex = 0;

            _progressDialog = new IndeterminateProgressDialog();
        }

        private void MinidumpCaptureDialog_Shown(object sender, EventArgs e)
        {
            RefreshProcesses();
        }

        private void RefreshProcesses()
        {
            this.lvProcesses.SuspendLayout();
            this.lvProcesses.Items.Clear();

            try
            {
                foreach (Process runningProcess in Process.GetProcesses().OrderBy(x => x.ProcessName))
                {
                    string memorySize = String.Format("{0:N0} K", runningProcess.PrivateMemorySize64 / 1024);

                    ListViewItem processItem = new ListViewItem(runningProcess.ProcessName);
                    processItem.SubItems.Add(runningProcess.Id.ToString());
                    processItem.SubItems.Add(runningProcess.HandleCount.ToString());
                    processItem.SubItems.Add(memorySize);
                    processItem.Tag = runningProcess;

                    this.lvProcesses.Items.Add(processItem);
                }
            }
            finally
            {
                this.lvProcesses.ResumeLayout();
            }
        }

        private void wizardControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set title hint
            switch (this.wizardControl1.SelectedIndex)
            {
                case TP_PROCESS_LIST: this.lblStepDescription.Text = "Select a process to generate a MiniDump for."; break;
                case TP_MINIDUMP_OPTIONS: this.lblStepDescription.Text = "Select the streams to include in the MiniDump."; break;
                case TP_SAVE_LOCATION: this.lblStepDescription.Text = "Choose a location to save the MiniDump."; break;
                case TP_DONE: this.lblStepDescription.Text = "Finished"; break;
            }

            // Enable / disable buttons
            if (this.wizardControl1.SelectedIndex == TP_PROCESS_LIST)
            {
                // Entered first page
                this.btnPrevious.Enabled = false;
                this.btnRefresh.Visible = true;
                this.btnCapture.Visible = false;
                this.btnNext.Visible = true;
                this.btnNext.Enabled = true;
            }
            else if (this.wizardControl1.SelectedIndex == TP_SAVE_LOCATION)
            {
                // Entered last page (well last before "Done")
                this.btnNext.Enabled = false;
                this.btnNext.Visible = false;
                this.btnCapture.Location = this.btnNext.Location;
                this.btnCapture.Visible = true;
            }
            else if (this.wizardControl1.SelectedIndex == TP_DONE)
            {
                // Entered "Done" page
                this.btnCapture.Visible = false;
                this.btnDone.Location = this.btnNext.Location;
                this.btnDone.Visible = true;
            }
            else
            {
                // Any other page
                this.btnCapture.Visible = false;
                this.btnNext.Visible = true;
                this.btnNext.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.btnRefresh.Visible = false;
                this.btnDone.Visible = false;
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            #region Validate user data
            if (this.TargetProcess == null)
            {
                MessageBox.Show("Please select a process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.wizardControl1.SelectedIndex = TP_PROCESS_LIST;

                return;
            }

            if (this.HasMiniDumpTypeSelected == false)
            {
                MessageBox.Show("Please select the data to include in the minidump.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.wizardControl1.SelectedIndex = TP_MINIDUMP_OPTIONS;

                return;
            }

            if (string.IsNullOrEmpty(this.txtSaveLocation.Text))
            {
                MessageBox.Show("Please enter a file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            CaptureArguments captureArguments = new CaptureArguments();

            // Remote process might be running with admin rights
            try
            {
                captureArguments.ProcessHandle = TargetProcess.Handle;
            }
            catch (Win32Exception w32ex)
            {
                if (w32ex.HResult == E_ACCESSDENIED) // access denied
                {
                    MessageBox.Show("'" + TargetProcess.ProcessName + "' is running with elevated privileges, please restart Minidump Explorer with elevated privileges and try again.",
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                throw;
            }

            captureArguments.ProcessId = this.TargetProcess.Id;
            captureArguments.FilePath = this.txtSaveLocation.Text;
            captureArguments.MiniDumpType = this.MiniDumpType;

            BackgroundWorker captureWorker = new BackgroundWorker();
            captureWorker.DoWork += captureWorker_DoWork;
            captureWorker.RunWorkerCompleted += captureWorker_RunWorkerCompleted;
            captureWorker.RunWorkerAsync(captureArguments);

            _progressDialog.ShowDialog(this);
        }

        void captureWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _progressDialog.Close();
            
            this.wizardControl1.SelectedIndex++;
        }

        void captureWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CaptureArguments captureArguments = (CaptureArguments)e.Argument;

            using (FileStream crashDumpFileStream = File.Create(captureArguments.FilePath))
            {
                bool success = MiniDumpFile.Create(
                    captureArguments.ProcessHandle,
                    (uint)captureArguments.ProcessId,
                    crashDumpFileStream.SafeFileHandle,
                    captureArguments.MiniDumpType,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero);

                if (!success)
                {
                    int lastError = Marshal.GetLastWin32Error();

                    // Neat way to avoid the pain of calling FormatMessage.
                    // You can create a new instance of Win32Exception without calling GetLast*Error first,
                    // but I prefer this way as it's more obvious what's happening
                    Win32Exception lastErrorException = new Win32Exception(lastError);

                    MessageBox.Show(lastErrorException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Minor event handlers (nothing to see here, move on)

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshProcesses();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.wizardControl1.SelectedIndex++;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.wizardControl1.SelectedIndex--;
        }

        private void lvProcesses_DoubleClick(object sender, EventArgs e)
        {
            btnNext_Click(sender, null);
        }

        private void btnBrowseSaveLocation_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtSaveLocation.Text = saveFileDialog1.FileName;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        public Process TargetProcess 
        { 
            get 
            {
                if (this.lvProcesses.SelectedItems.Count == 0)
                    return null;
                else
                    return (Process)this.lvProcesses.SelectedItems[0].Tag; 
            } 
        }
        public bool HasMiniDumpTypeSelected
        {
            get
            {
                foreach (Control control in this.tpMiniDumpSettings.Controls)
                {
                    if ((control is CheckBox) && (((CheckBox)control).Checked))
                        return true;
                }

                return false;
            }
        }
        public MiniDumpType MiniDumpType
        {
            get
            {
                UInt32 selectedOptions = 0;

                foreach (Control control in this.tpMiniDumpSettings.Controls)
                {
                    if (control is CheckBox)
                    {
                        CheckBox checkBoxControl = (CheckBox)control;

                        if (checkBoxControl.Checked)
                        {
                            UInt32 optionValue = UInt32.Parse((string)checkBoxControl.Tag, NumberStyles.AllowHexSpecifier);

                            selectedOptions = selectedOptions | optionValue;
                        }
                    }
                }

                return (MiniDumpType)selectedOptions;
            }
        }

        private class CaptureArguments
        {
            public IntPtr ProcessHandle { get; set; }
            public int ProcessId { get; set; }
            public string FilePath { get; set; }
            public MiniDumpType MiniDumpType { get; set; }
        }
    }
}
