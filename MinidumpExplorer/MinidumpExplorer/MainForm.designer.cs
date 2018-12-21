namespace MinidumpExplorer
{
    partial class MainForm
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
                if (_miniDumpFile != null)
                    _miniDumpFile.Dispose();

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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Exception", 6, 6);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Handles", 4, 4);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Memory", 3, 3);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Memory64", 3, 3);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MemoryInfo", 3, 3);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("MiscInfo", 5, 5);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Modules", 2, 2);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("SystemInfo");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("SystemMemoryInfo", 3, 3);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Threads", 1, 1);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("ThreadInfo", 1, 1);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("ThreadNames", 1, 1);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("UnloadedModules", 2, 2);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("<No minidump loaded>", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureMinidumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 705);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.treeViewImageList;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 6;
            treeNode1.Name = "Node0";
            treeNode1.SelectedImageIndex = 6;
            treeNode1.Tag = "Exception";
            treeNode1.Text = "Exception";
            treeNode2.ImageIndex = 4;
            treeNode2.Name = "Node0";
            treeNode2.SelectedImageIndex = 4;
            treeNode2.Tag = "Handles";
            treeNode2.Text = "Handles";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "Node0";
            treeNode3.SelectedImageIndex = 3;
            treeNode3.Tag = "Memory";
            treeNode3.Text = "Memory";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "Node0";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Tag = "Memory64";
            treeNode4.Text = "Memory64";
            treeNode5.ImageIndex = 3;
            treeNode5.Name = "Node0";
            treeNode5.SelectedImageIndex = 3;
            treeNode5.Tag = "MemoryInfo";
            treeNode5.Text = "MemoryInfo";
            treeNode6.ImageIndex = 5;
            treeNode6.Name = "Node0";
            treeNode6.SelectedImageIndex = 5;
            treeNode6.Tag = "MiscInfo";
            treeNode6.Text = "MiscInfo";
            treeNode7.ImageIndex = 2;
            treeNode7.Name = "Node2";
            treeNode7.SelectedImageIndex = 2;
            treeNode7.Tag = "Modules";
            treeNode7.Text = "Modules";
            treeNode8.ImageIndex = 5;
            treeNode8.Name = "Node0";
            treeNode8.SelectedImageKey = "DialogID_6220_16x.png";
            treeNode8.Tag = "SystemInfo";
            treeNode8.Text = "SystemInfo";
            treeNode9.ImageIndex = 3;
            treeNode9.Name = "Node0";
            treeNode9.SelectedImageIndex = 3;
            treeNode9.Tag = "SystemMemoryInfo";
            treeNode9.Text = "SystemMemoryInfo";
            treeNode10.ImageIndex = 1;
            treeNode10.Name = "Node1";
            treeNode10.SelectedImageIndex = 1;
            treeNode10.Tag = "Threads";
            treeNode10.Text = "Threads";
            treeNode11.ImageIndex = 1;
            treeNode11.Name = "Node0";
            treeNode11.SelectedImageIndex = 1;
            treeNode11.Tag = "ThreadInfo";
            treeNode11.Text = "ThreadInfo";
            treeNode12.ImageIndex = 1;
            treeNode12.Name = "Node0";
            treeNode12.SelectedImageIndex = 1;
            treeNode12.Tag = "ThreadNames";
            treeNode12.Text = "ThreadNames";
            treeNode13.ImageIndex = 2;
            treeNode13.Name = "Node0";
            treeNode13.SelectedImageIndex = 2;
            treeNode13.Tag = "UnloadedModules";
            treeNode13.Text = "UnloadedModules";
            treeNode14.ImageIndex = 0;
            treeNode14.Name = "Node0";
            treeNode14.Tag = "Summary";
            treeNode14.Text = "<No minidump loaded>";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(238, 705);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImageList.Images.SetKeyName(0, "ActiveDocumentHost_6234.png");
            this.treeViewImageList.Images.SetKeyName(1, "thread_16xLG.png");
            this.treeViewImageList.Images.SetKeyName(2, "Assembly_6212.png");
            this.treeViewImageList.Images.SetKeyName(3, "MemoryWindow_6537.png");
            this.treeViewImageList.Images.SetKeyName(4, "Map_624.png");
            this.treeViewImageList.Images.SetKeyName(5, "DialogID_6220_16x.png");
            this.treeViewImageList.Images.SetKeyName(6, "Exception.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::MinidumpExplorer.Properties.Resources.Open_6529;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureMinidumpToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // captureMinidumpToolStripMenuItem
            // 
            this.captureMinidumpToolStripMenuItem.Name = "captureMinidumpToolStripMenuItem";
            this.captureMinidumpToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.captureMinidumpToolStripMenuItem.Text = "Capture Minidump";
            this.captureMinidumpToolStripMenuItem.Click += new System.EventHandler(this.captureMinidumpToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1008, 705);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1008, 729);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Dump files|*.dmp;*.hdmp|All files|*.*";
            this.openFileDialog1.Title = "Open Minidump File";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Minidump Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList treeViewImageList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureMinidumpToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

