namespace MinidumpExplorer.Dialogs
{
    partial class MinidumpCaptureDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStepDescription = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.wizardControl1 = new MinidumpExplorer.Controls.WizardControl();
            this.tpSelectProcess = new System.Windows.Forms.TabPage();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pidHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.handleCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memoryHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpMiniDumpSettings = new System.Windows.Forms.TabPage();
            this.chkMiniDumpFilterTriage = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithModuleHeaders = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithTokenInformation = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpIgnoreInaccessibleMemory = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithPrivateWriteCopyMemory = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithFullAuxiliaryState = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithoutAuxiliaryState = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithCodeSegs = new System.Windows.Forms.CheckBox();
            this.MiniDumpWithThreadInfo = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithFullMemoryInfo = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithoutOptionalData = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithPrivateReadWriteMemory = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithProcessThreadData = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpFilterModulePaths = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithIndirectlyReferencedMemory = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithUnloadedModules = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpScanMemory = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpFilterMemory = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithHandleData = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithFullMemory = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpWithDataSegs = new System.Windows.Forms.CheckBox();
            this.chkMiniDumpNormal = new System.Windows.Forms.CheckBox();
            this.tpChooseOutput = new System.Windows.Forms.TabPage();
            this.chkOpenWhenCaptured = new System.Windows.Forms.CheckBox();
            this.btnBrowseSaveLocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaveLocation = new System.Windows.Forms.TextBox();
            this.tpDone = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.wizardControl1.SuspendLayout();
            this.tpSelectProcess.SuspendLayout();
            this.tpMiniDumpSettings.SuspendLayout();
            this.tpChooseOutput.SuspendLayout();
            this.tpDone.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Location = new System.Drawing.Point(448, 419);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 27;
            this.btnPrevious.Text = "< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(529, 419);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 28;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "dmp";
            this.saveFileDialog1.Filter = "MiniDump files|*.dmp;*.hdmp";
            this.saveFileDialog1.Title = "Save MiniDump As";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblStepDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 56);
            this.panel1.TabIndex = 29;
            // 
            // lblStepDescription
            // 
            this.lblStepDescription.AutoSize = true;
            this.lblStepDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepDescription.Location = new System.Drawing.Point(12, 19);
            this.lblStepDescription.Name = "lblStepDescription";
            this.lblStepDescription.Size = new System.Drawing.Size(257, 15);
            this.lblStepDescription.TabIndex = 0;
            this.lblStepDescription.Text = "Select a process to generate a MiniDump for.";
            // 
            // lblLine1
            // 
            this.lblLine1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine1.Location = new System.Drawing.Point(0, 56);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(610, 2);
            this.lblLine1.TabIndex = 30;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(367, 419);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 31;
            this.btnCapture.Text = "Catpure";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Visible = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(610, 2);
            this.label2.TabIndex = 33;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(22, 419);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 34;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(286, 419);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 31;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Visible = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.tpSelectProcess);
            this.wizardControl1.Controls.Add(this.tpMiniDumpSettings);
            this.wizardControl1.Controls.Add(this.tpChooseOutput);
            this.wizardControl1.Controls.Add(this.tpDone);
            this.wizardControl1.Location = new System.Drawing.Point(15, 61);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.SelectedIndex = 0;
            this.wizardControl1.Size = new System.Drawing.Size(583, 343);
            this.wizardControl1.TabIndex = 32;
            this.wizardControl1.SelectedIndexChanged += new System.EventHandler(this.wizardControl1_SelectedIndexChanged);
            // 
            // tpSelectProcess
            // 
            this.tpSelectProcess.BackColor = System.Drawing.SystemColors.Control;
            this.tpSelectProcess.Controls.Add(this.lvProcesses);
            this.tpSelectProcess.Location = new System.Drawing.Point(4, 24);
            this.tpSelectProcess.Name = "tpSelectProcess";
            this.tpSelectProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelectProcess.Size = new System.Drawing.Size(575, 315);
            this.tpSelectProcess.TabIndex = 0;
            this.tpSelectProcess.Text = "Choose Process";
            // 
            // lvProcesses
            // 
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.pidHeader,
            this.handleCountHeader,
            this.memoryHeader});
            this.lvProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.Location = new System.Drawing.Point(3, 3);
            this.lvProcesses.MultiSelect = false;
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.ShowGroups = false;
            this.lvProcesses.Size = new System.Drawing.Size(569, 309);
            this.lvProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProcesses.TabIndex = 2;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            this.lvProcesses.DoubleClick += new System.EventHandler(this.lvProcesses_DoubleClick);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 318;
            // 
            // pidHeader
            // 
            this.pidHeader.Text = "Pid";
            this.pidHeader.Width = 57;
            // 
            // handleCountHeader
            // 
            this.handleCountHeader.Text = "Handles";
            this.handleCountHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.handleCountHeader.Width = 70;
            // 
            // memoryHeader
            // 
            this.memoryHeader.Text = "Memory (private working set)";
            this.memoryHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.memoryHeader.Width = 94;
            // 
            // tpMiniDumpSettings
            // 
            this.tpMiniDumpSettings.BackColor = System.Drawing.SystemColors.Control;
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpFilterTriage);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithModuleHeaders);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithTokenInformation);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpIgnoreInaccessibleMemory);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithPrivateWriteCopyMemory);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithFullAuxiliaryState);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithoutAuxiliaryState);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithCodeSegs);
            this.tpMiniDumpSettings.Controls.Add(this.MiniDumpWithThreadInfo);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithFullMemoryInfo);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithoutOptionalData);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithPrivateReadWriteMemory);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithProcessThreadData);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpFilterModulePaths);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithIndirectlyReferencedMemory);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithUnloadedModules);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpScanMemory);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpFilterMemory);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithHandleData);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithFullMemory);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpWithDataSegs);
            this.tpMiniDumpSettings.Controls.Add(this.chkMiniDumpNormal);
            this.tpMiniDumpSettings.Location = new System.Drawing.Point(4, 24);
            this.tpMiniDumpSettings.Name = "tpMiniDumpSettings";
            this.tpMiniDumpSettings.Padding = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.tpMiniDumpSettings.Size = new System.Drawing.Size(575, 315);
            this.tpMiniDumpSettings.TabIndex = 1;
            this.tpMiniDumpSettings.Text = "Select MiniDump Options";
            // 
            // chkMiniDumpFilterTriage
            // 
            this.chkMiniDumpFilterTriage.AutoSize = true;
            this.chkMiniDumpFilterTriage.Location = new System.Drawing.Point(274, 273);
            this.chkMiniDumpFilterTriage.Name = "chkMiniDumpFilterTriage";
            this.chkMiniDumpFilterTriage.Size = new System.Drawing.Size(142, 19);
            this.chkMiniDumpFilterTriage.TabIndex = 45;
            this.chkMiniDumpFilterTriage.Tag = "100000";
            this.chkMiniDumpFilterTriage.Text = "MiniDumpFilterTriage";
            this.chkMiniDumpFilterTriage.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithModuleHeaders
            // 
            this.chkMiniDumpWithModuleHeaders.AutoSize = true;
            this.chkMiniDumpWithModuleHeaders.Location = new System.Drawing.Point(275, 247);
            this.chkMiniDumpWithModuleHeaders.Name = "chkMiniDumpWithModuleHeaders";
            this.chkMiniDumpWithModuleHeaders.Size = new System.Drawing.Size(192, 19);
            this.chkMiniDumpWithModuleHeaders.TabIndex = 44;
            this.chkMiniDumpWithModuleHeaders.Tag = "80000";
            this.chkMiniDumpWithModuleHeaders.Text = "MiniDumpWithModuleHeaders";
            this.chkMiniDumpWithModuleHeaders.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithTokenInformation
            // 
            this.chkMiniDumpWithTokenInformation.AutoSize = true;
            this.chkMiniDumpWithTokenInformation.Location = new System.Drawing.Point(275, 221);
            this.chkMiniDumpWithTokenInformation.Name = "chkMiniDumpWithTokenInformation";
            this.chkMiniDumpWithTokenInformation.Size = new System.Drawing.Size(204, 19);
            this.chkMiniDumpWithTokenInformation.TabIndex = 43;
            this.chkMiniDumpWithTokenInformation.Tag = "40000";
            this.chkMiniDumpWithTokenInformation.Text = "MiniDumpWithTokenInformation";
            this.chkMiniDumpWithTokenInformation.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpIgnoreInaccessibleMemory
            // 
            this.chkMiniDumpIgnoreInaccessibleMemory.AutoSize = true;
            this.chkMiniDumpIgnoreInaccessibleMemory.Location = new System.Drawing.Point(274, 195);
            this.chkMiniDumpIgnoreInaccessibleMemory.Name = "chkMiniDumpIgnoreInaccessibleMemory";
            this.chkMiniDumpIgnoreInaccessibleMemory.Size = new System.Drawing.Size(225, 19);
            this.chkMiniDumpIgnoreInaccessibleMemory.TabIndex = 42;
            this.chkMiniDumpIgnoreInaccessibleMemory.Tag = "20000";
            this.chkMiniDumpIgnoreInaccessibleMemory.Text = "MiniDumpIgnoreInaccessibleMemory";
            this.chkMiniDumpIgnoreInaccessibleMemory.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithPrivateWriteCopyMemory
            // 
            this.chkMiniDumpWithPrivateWriteCopyMemory.AutoSize = true;
            this.chkMiniDumpWithPrivateWriteCopyMemory.Location = new System.Drawing.Point(275, 168);
            this.chkMiniDumpWithPrivateWriteCopyMemory.Name = "chkMiniDumpWithPrivateWriteCopyMemory";
            this.chkMiniDumpWithPrivateWriteCopyMemory.Size = new System.Drawing.Size(245, 19);
            this.chkMiniDumpWithPrivateWriteCopyMemory.TabIndex = 41;
            this.chkMiniDumpWithPrivateWriteCopyMemory.Tag = "10000";
            this.chkMiniDumpWithPrivateWriteCopyMemory.Text = "MiniDumpWithPrivateWriteCopyMemory";
            this.chkMiniDumpWithPrivateWriteCopyMemory.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithFullAuxiliaryState
            // 
            this.chkMiniDumpWithFullAuxiliaryState.AutoSize = true;
            this.chkMiniDumpWithFullAuxiliaryState.Location = new System.Drawing.Point(275, 143);
            this.chkMiniDumpWithFullAuxiliaryState.Name = "chkMiniDumpWithFullAuxiliaryState";
            this.chkMiniDumpWithFullAuxiliaryState.Size = new System.Drawing.Size(198, 19);
            this.chkMiniDumpWithFullAuxiliaryState.TabIndex = 40;
            this.chkMiniDumpWithFullAuxiliaryState.Tag = "8000";
            this.chkMiniDumpWithFullAuxiliaryState.Text = "MiniDumpWithFullAuxiliaryState";
            this.chkMiniDumpWithFullAuxiliaryState.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithoutAuxiliaryState
            // 
            this.chkMiniDumpWithoutAuxiliaryState.AutoSize = true;
            this.chkMiniDumpWithoutAuxiliaryState.Location = new System.Drawing.Point(275, 117);
            this.chkMiniDumpWithoutAuxiliaryState.Name = "chkMiniDumpWithoutAuxiliaryState";
            this.chkMiniDumpWithoutAuxiliaryState.Size = new System.Drawing.Size(197, 19);
            this.chkMiniDumpWithoutAuxiliaryState.TabIndex = 39;
            this.chkMiniDumpWithoutAuxiliaryState.Tag = "4000";
            this.chkMiniDumpWithoutAuxiliaryState.Text = "MiniDumpWithoutAuxiliaryState";
            this.chkMiniDumpWithoutAuxiliaryState.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithCodeSegs
            // 
            this.chkMiniDumpWithCodeSegs.AutoSize = true;
            this.chkMiniDumpWithCodeSegs.Location = new System.Drawing.Point(275, 91);
            this.chkMiniDumpWithCodeSegs.Name = "chkMiniDumpWithCodeSegs";
            this.chkMiniDumpWithCodeSegs.Size = new System.Drawing.Size(160, 19);
            this.chkMiniDumpWithCodeSegs.TabIndex = 38;
            this.chkMiniDumpWithCodeSegs.Tag = "2000";
            this.chkMiniDumpWithCodeSegs.Text = "MiniDumpWithCodeSegs";
            this.chkMiniDumpWithCodeSegs.UseVisualStyleBackColor = true;
            // 
            // MiniDumpWithThreadInfo
            // 
            this.MiniDumpWithThreadInfo.AutoSize = true;
            this.MiniDumpWithThreadInfo.Location = new System.Drawing.Point(275, 65);
            this.MiniDumpWithThreadInfo.Name = "MiniDumpWithThreadInfo";
            this.MiniDumpWithThreadInfo.Size = new System.Drawing.Size(166, 19);
            this.MiniDumpWithThreadInfo.TabIndex = 37;
            this.MiniDumpWithThreadInfo.Tag = "1000";
            this.MiniDumpWithThreadInfo.Text = "MiniDumpWithThreadInfo";
            this.MiniDumpWithThreadInfo.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithFullMemoryInfo
            // 
            this.chkMiniDumpWithFullMemoryInfo.AutoSize = true;
            this.chkMiniDumpWithFullMemoryInfo.Location = new System.Drawing.Point(275, 39);
            this.chkMiniDumpWithFullMemoryInfo.Name = "chkMiniDumpWithFullMemoryInfo";
            this.chkMiniDumpWithFullMemoryInfo.Size = new System.Drawing.Size(193, 19);
            this.chkMiniDumpWithFullMemoryInfo.TabIndex = 36;
            this.chkMiniDumpWithFullMemoryInfo.Tag = "800";
            this.chkMiniDumpWithFullMemoryInfo.Text = "MiniDumpWithFullMemoryInfo";
            this.chkMiniDumpWithFullMemoryInfo.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithoutOptionalData
            // 
            this.chkMiniDumpWithoutOptionalData.AutoSize = true;
            this.chkMiniDumpWithoutOptionalData.Location = new System.Drawing.Point(275, 12);
            this.chkMiniDumpWithoutOptionalData.Name = "chkMiniDumpWithoutOptionalData";
            this.chkMiniDumpWithoutOptionalData.Size = new System.Drawing.Size(196, 19);
            this.chkMiniDumpWithoutOptionalData.TabIndex = 35;
            this.chkMiniDumpWithoutOptionalData.Tag = "400";
            this.chkMiniDumpWithoutOptionalData.Text = "MiniDumpWithoutOptionalData";
            this.chkMiniDumpWithoutOptionalData.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithPrivateReadWriteMemory
            // 
            this.chkMiniDumpWithPrivateReadWriteMemory.AutoSize = true;
            this.chkMiniDumpWithPrivateReadWriteMemory.Location = new System.Drawing.Point(6, 272);
            this.chkMiniDumpWithPrivateReadWriteMemory.Name = "chkMiniDumpWithPrivateReadWriteMemory";
            this.chkMiniDumpWithPrivateReadWriteMemory.Size = new System.Drawing.Size(243, 19);
            this.chkMiniDumpWithPrivateReadWriteMemory.TabIndex = 34;
            this.chkMiniDumpWithPrivateReadWriteMemory.Tag = "200";
            this.chkMiniDumpWithPrivateReadWriteMemory.Text = "MiniDumpWithPrivateReadWriteMemory";
            this.chkMiniDumpWithPrivateReadWriteMemory.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithProcessThreadData
            // 
            this.chkMiniDumpWithProcessThreadData.AutoSize = true;
            this.chkMiniDumpWithProcessThreadData.Location = new System.Drawing.Point(6, 246);
            this.chkMiniDumpWithProcessThreadData.Name = "chkMiniDumpWithProcessThreadData";
            this.chkMiniDumpWithProcessThreadData.Size = new System.Drawing.Size(209, 19);
            this.chkMiniDumpWithProcessThreadData.TabIndex = 33;
            this.chkMiniDumpWithProcessThreadData.Tag = "100";
            this.chkMiniDumpWithProcessThreadData.Text = "MiniDumpWithProcessThreadData";
            this.chkMiniDumpWithProcessThreadData.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpFilterModulePaths
            // 
            this.chkMiniDumpFilterModulePaths.AutoSize = true;
            this.chkMiniDumpFilterModulePaths.Location = new System.Drawing.Point(6, 220);
            this.chkMiniDumpFilterModulePaths.Name = "chkMiniDumpFilterModulePaths";
            this.chkMiniDumpFilterModulePaths.Size = new System.Drawing.Size(179, 19);
            this.chkMiniDumpFilterModulePaths.TabIndex = 32;
            this.chkMiniDumpFilterModulePaths.Tag = "80";
            this.chkMiniDumpFilterModulePaths.Text = "MiniDumpFilterModulePaths";
            this.chkMiniDumpFilterModulePaths.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithIndirectlyReferencedMemory
            // 
            this.chkMiniDumpWithIndirectlyReferencedMemory.AutoSize = true;
            this.chkMiniDumpWithIndirectlyReferencedMemory.Location = new System.Drawing.Point(6, 194);
            this.chkMiniDumpWithIndirectlyReferencedMemory.Name = "chkMiniDumpWithIndirectlyReferencedMemory";
            this.chkMiniDumpWithIndirectlyReferencedMemory.Size = new System.Drawing.Size(261, 19);
            this.chkMiniDumpWithIndirectlyReferencedMemory.TabIndex = 31;
            this.chkMiniDumpWithIndirectlyReferencedMemory.Tag = "40";
            this.chkMiniDumpWithIndirectlyReferencedMemory.Text = "MiniDumpWithIndirectlyReferencedMemory";
            this.chkMiniDumpWithIndirectlyReferencedMemory.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithUnloadedModules
            // 
            this.chkMiniDumpWithUnloadedModules.AutoSize = true;
            this.chkMiniDumpWithUnloadedModules.Location = new System.Drawing.Point(6, 168);
            this.chkMiniDumpWithUnloadedModules.Name = "chkMiniDumpWithUnloadedModules";
            this.chkMiniDumpWithUnloadedModules.Size = new System.Drawing.Size(205, 19);
            this.chkMiniDumpWithUnloadedModules.TabIndex = 30;
            this.chkMiniDumpWithUnloadedModules.Tag = "20";
            this.chkMiniDumpWithUnloadedModules.Text = "MiniDumpWithUnloadedModules";
            this.chkMiniDumpWithUnloadedModules.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpScanMemory
            // 
            this.chkMiniDumpScanMemory.AutoSize = true;
            this.chkMiniDumpScanMemory.Location = new System.Drawing.Point(6, 142);
            this.chkMiniDumpScanMemory.Name = "chkMiniDumpScanMemory";
            this.chkMiniDumpScanMemory.Size = new System.Drawing.Size(153, 19);
            this.chkMiniDumpScanMemory.TabIndex = 29;
            this.chkMiniDumpScanMemory.Tag = "10";
            this.chkMiniDumpScanMemory.Text = "MiniDumpScanMemory";
            this.chkMiniDumpScanMemory.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpFilterMemory
            // 
            this.chkMiniDumpFilterMemory.AutoSize = true;
            this.chkMiniDumpFilterMemory.Location = new System.Drawing.Point(6, 116);
            this.chkMiniDumpFilterMemory.Name = "chkMiniDumpFilterMemory";
            this.chkMiniDumpFilterMemory.Size = new System.Drawing.Size(154, 19);
            this.chkMiniDumpFilterMemory.TabIndex = 28;
            this.chkMiniDumpFilterMemory.Tag = "8";
            this.chkMiniDumpFilterMemory.Text = "MiniDumpFilterMemory";
            this.chkMiniDumpFilterMemory.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithHandleData
            // 
            this.chkMiniDumpWithHandleData.AutoSize = true;
            this.chkMiniDumpWithHandleData.Location = new System.Drawing.Point(6, 90);
            this.chkMiniDumpWithHandleData.Name = "chkMiniDumpWithHandleData";
            this.chkMiniDumpWithHandleData.Size = new System.Drawing.Size(170, 19);
            this.chkMiniDumpWithHandleData.TabIndex = 27;
            this.chkMiniDumpWithHandleData.Tag = "4";
            this.chkMiniDumpWithHandleData.Text = "MiniDumpWithHandleData";
            this.chkMiniDumpWithHandleData.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithFullMemory
            // 
            this.chkMiniDumpWithFullMemory.AutoSize = true;
            this.chkMiniDumpWithFullMemory.Location = new System.Drawing.Point(6, 64);
            this.chkMiniDumpWithFullMemory.Name = "chkMiniDumpWithFullMemory";
            this.chkMiniDumpWithFullMemory.Size = new System.Drawing.Size(172, 19);
            this.chkMiniDumpWithFullMemory.TabIndex = 26;
            this.chkMiniDumpWithFullMemory.Tag = "2";
            this.chkMiniDumpWithFullMemory.Text = "MiniDumpWithFullMemory";
            this.chkMiniDumpWithFullMemory.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpWithDataSegs
            // 
            this.chkMiniDumpWithDataSegs.AutoSize = true;
            this.chkMiniDumpWithDataSegs.Location = new System.Drawing.Point(6, 38);
            this.chkMiniDumpWithDataSegs.Name = "chkMiniDumpWithDataSegs";
            this.chkMiniDumpWithDataSegs.Size = new System.Drawing.Size(156, 19);
            this.chkMiniDumpWithDataSegs.TabIndex = 25;
            this.chkMiniDumpWithDataSegs.Tag = "1";
            this.chkMiniDumpWithDataSegs.Text = "MiniDumpWithDataSegs";
            this.chkMiniDumpWithDataSegs.UseVisualStyleBackColor = true;
            // 
            // chkMiniDumpNormal
            // 
            this.chkMiniDumpNormal.AutoSize = true;
            this.chkMiniDumpNormal.Location = new System.Drawing.Point(6, 12);
            this.chkMiniDumpNormal.Name = "chkMiniDumpNormal";
            this.chkMiniDumpNormal.Size = new System.Drawing.Size(123, 19);
            this.chkMiniDumpNormal.TabIndex = 24;
            this.chkMiniDumpNormal.Tag = "0";
            this.chkMiniDumpNormal.Text = "MiniDumpNormal";
            this.chkMiniDumpNormal.UseVisualStyleBackColor = true;
            // 
            // tpChooseOutput
            // 
            this.tpChooseOutput.BackColor = System.Drawing.SystemColors.Control;
            this.tpChooseOutput.Controls.Add(this.chkOpenWhenCaptured);
            this.tpChooseOutput.Controls.Add(this.btnBrowseSaveLocation);
            this.tpChooseOutput.Controls.Add(this.label1);
            this.tpChooseOutput.Controls.Add(this.txtSaveLocation);
            this.tpChooseOutput.Location = new System.Drawing.Point(4, 24);
            this.tpChooseOutput.Name = "tpChooseOutput";
            this.tpChooseOutput.Padding = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.tpChooseOutput.Size = new System.Drawing.Size(575, 315);
            this.tpChooseOutput.TabIndex = 2;
            this.tpChooseOutput.Text = "Choose Output";
            // 
            // chkOpenWhenCaptured
            // 
            this.chkOpenWhenCaptured.AutoSize = true;
            this.chkOpenWhenCaptured.Location = new System.Drawing.Point(120, 35);
            this.chkOpenWhenCaptured.Name = "chkOpenWhenCaptured";
            this.chkOpenWhenCaptured.Size = new System.Drawing.Size(142, 19);
            this.chkOpenWhenCaptured.TabIndex = 7;
            this.chkOpenWhenCaptured.Text = "Open when captured?";
            this.chkOpenWhenCaptured.UseVisualStyleBackColor = true;
            // 
            // btnBrowseSaveLocation
            // 
            this.btnBrowseSaveLocation.Location = new System.Drawing.Point(473, 6);
            this.btnBrowseSaveLocation.Name = "btnBrowseSaveLocation";
            this.btnBrowseSaveLocation.Size = new System.Drawing.Size(84, 23);
            this.btnBrowseSaveLocation.TabIndex = 2;
            this.btnBrowseSaveLocation.Text = "Browse ...";
            this.btnBrowseSaveLocation.UseVisualStyleBackColor = true;
            this.btnBrowseSaveLocation.Click += new System.EventHandler(this.btnBrowseSaveLocation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Save minidump to:";
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.Location = new System.Drawing.Point(120, 6);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.Size = new System.Drawing.Size(347, 23);
            this.txtSaveLocation.TabIndex = 0;
            // 
            // tpDone
            // 
            this.tpDone.BackColor = System.Drawing.SystemColors.Control;
            this.tpDone.Controls.Add(this.label3);
            this.tpDone.Location = new System.Drawing.Point(4, 24);
            this.tpDone.Name = "tpDone";
            this.tpDone.Padding = new System.Windows.Forms.Padding(3);
            this.tpDone.Size = new System.Drawing.Size(575, 315);
            this.tpDone.TabIndex = 3;
            this.tpDone.Text = "Done";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "MiniDump successfully created";
            // 
            // MinidumpCaptureDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 454);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wizardControl1);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MinidumpCaptureDialog";
            this.Text = "Capture Minidump";
            this.Shown += new System.EventHandler(this.MinidumpCaptureDialog_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.wizardControl1.ResumeLayout(false);
            this.tpSelectProcess.ResumeLayout(false);
            this.tpMiniDumpSettings.ResumeLayout(false);
            this.tpMiniDumpSettings.PerformLayout();
            this.tpChooseOutput.ResumeLayout(false);
            this.tpChooseOutput.PerformLayout();
            this.tpDone.ResumeLayout(false);
            this.tpDone.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblStepDescription;
        private System.Windows.Forms.Button btnCapture;
        private Controls.WizardControl wizardControl1;
        private System.Windows.Forms.TabPage tpSelectProcess;
        private System.Windows.Forms.ListView lvProcesses;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader pidHeader;
        private System.Windows.Forms.ColumnHeader handleCountHeader;
        private System.Windows.Forms.ColumnHeader memoryHeader;
        private System.Windows.Forms.TabPage tpMiniDumpSettings;
        private System.Windows.Forms.CheckBox chkMiniDumpFilterTriage;
        private System.Windows.Forms.CheckBox chkMiniDumpWithModuleHeaders;
        private System.Windows.Forms.CheckBox chkMiniDumpWithTokenInformation;
        private System.Windows.Forms.CheckBox chkMiniDumpIgnoreInaccessibleMemory;
        private System.Windows.Forms.CheckBox chkMiniDumpWithPrivateWriteCopyMemory;
        private System.Windows.Forms.CheckBox chkMiniDumpWithFullAuxiliaryState;
        private System.Windows.Forms.CheckBox chkMiniDumpWithoutAuxiliaryState;
        private System.Windows.Forms.CheckBox chkMiniDumpWithCodeSegs;
        private System.Windows.Forms.CheckBox MiniDumpWithThreadInfo;
        private System.Windows.Forms.CheckBox chkMiniDumpWithFullMemoryInfo;
        private System.Windows.Forms.CheckBox chkMiniDumpWithoutOptionalData;
        private System.Windows.Forms.CheckBox chkMiniDumpWithPrivateReadWriteMemory;
        private System.Windows.Forms.CheckBox chkMiniDumpWithProcessThreadData;
        private System.Windows.Forms.CheckBox chkMiniDumpFilterModulePaths;
        private System.Windows.Forms.CheckBox chkMiniDumpWithIndirectlyReferencedMemory;
        private System.Windows.Forms.CheckBox chkMiniDumpWithUnloadedModules;
        private System.Windows.Forms.CheckBox chkMiniDumpScanMemory;
        private System.Windows.Forms.CheckBox chkMiniDumpFilterMemory;
        private System.Windows.Forms.CheckBox chkMiniDumpWithHandleData;
        private System.Windows.Forms.CheckBox chkMiniDumpWithFullMemory;
        private System.Windows.Forms.CheckBox chkMiniDumpWithDataSegs;
        private System.Windows.Forms.CheckBox chkMiniDumpNormal;
        private System.Windows.Forms.TabPage tpChooseOutput;
        private System.Windows.Forms.Button btnBrowseSaveLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaveLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkOpenWhenCaptured;
        private System.Windows.Forms.TabPage tpDone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDone;
    }
}
