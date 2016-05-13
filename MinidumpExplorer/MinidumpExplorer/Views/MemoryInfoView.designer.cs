namespace MinidumpExplorer.Views
{
    partial class MemoryInfoView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryInfoView));
            this.listView1 = new MinidumpExplorer.Controls.MinidumpListView();
            this.BaseAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AllocationBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AllocationProtect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RegionSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Protect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BaseAddress,
            this.AllocationBase,
            this.AllocationProtect,
            this.RegionSize,
            this.State,
            this.Protect,
            this.Type});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(919, 334);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.MemoryInfoView_DoubleClick);
            this.listView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView1_KeyPress);
            // 
            // BaseAddress
            // 
            this.BaseAddress.Text = "BaseAddress";
            this.BaseAddress.Width = 92;
            // 
            // AllocationBase
            // 
            this.AllocationBase.Text = "AllocationBase";
            this.AllocationBase.Width = 92;
            // 
            // AllocationProtect
            // 
            this.AllocationProtect.Text = "AllocationProtect";
            this.AllocationProtect.Width = 164;
            // 
            // RegionSize
            // 
            this.RegionSize.Text = "RegionSize";
            this.RegionSize.Width = 74;
            // 
            // State
            // 
            this.State.Text = "State";
            this.State.Width = 98;
            // 
            // Protect
            // 
            this.Protect.Text = "Protect";
            this.Protect.Width = 126;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 98;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 26);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "asc.png");
            this.imageList1.Images.SetKeyName(1, "desc.png");
            this.imageList1.Images.SetKeyName(2, "fltr_asc.png");
            this.imageList1.Images.SetKeyName(3, "fltr_desc.png");
            this.imageList1.Images.SetKeyName(4, "fltr.png");
            // 
            // MemoryInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "MemoryInfoView";
            this.Size = new System.Drawing.Size(919, 334);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MinidumpListView listView1;
        private System.Windows.Forms.ColumnHeader BaseAddress;
        private System.Windows.Forms.ColumnHeader AllocationBase;
        private System.Windows.Forms.ColumnHeader AllocationProtect;
        private System.Windows.Forms.ColumnHeader RegionSize;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Protect;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    }
}
