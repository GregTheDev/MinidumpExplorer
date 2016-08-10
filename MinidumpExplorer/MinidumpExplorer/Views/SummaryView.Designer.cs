namespace MinidumpExplorer.Views
{
    partial class SummaryView
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAvailableStreamsHeading = new System.Windows.Forms.Label();
            this.txtMainModule = new System.Windows.Forms.TextBox();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOperatingSystem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Target Process:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Target Date/Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dump Flags:";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(7, 143);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(905, 424);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stream";
            this.columnHeader1.Width = 305;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Location (RVA)";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 138;
            // 
            // lblAvailableStreamsHeading
            // 
            this.lblAvailableStreamsHeading.AutoSize = true;
            this.lblAvailableStreamsHeading.Location = new System.Drawing.Point(6, 127);
            this.lblAvailableStreamsHeading.Name = "lblAvailableStreamsHeading";
            this.lblAvailableStreamsHeading.Size = new System.Drawing.Size(150, 13);
            this.lblAvailableStreamsHeading.TabIndex = 11;
            this.lblAvailableStreamsHeading.Text = "lblAvailableStreamsHeading";
            // 
            // txtMainModule
            // 
            this.txtMainModule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMainModule.Location = new System.Drawing.Point(148, 10);
            this.txtMainModule.Name = "txtMainModule";
            this.txtMainModule.ReadOnly = true;
            this.txtMainModule.Size = new System.Drawing.Size(771, 15);
            this.txtMainModule.TabIndex = 12;
            this.txtMainModule.Text = "<unknown>";
            // 
            // txtDateTime
            // 
            this.txtDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateTime.Location = new System.Drawing.Point(148, 33);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(100, 15);
            this.txtDateTime.TabIndex = 13;
            this.txtDateTime.Text = "<unknown>";
            // 
            // txtFlags
            // 
            this.txtFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFlags.Location = new System.Drawing.Point(146, 79);
            this.txtFlags.Multiline = true;
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.ReadOnly = true;
            this.txtFlags.Size = new System.Drawing.Size(756, 35);
            this.txtFlags.TabIndex = 15;
            this.txtFlags.Text = "<unknown>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Target Operating System:";
            // 
            // txtOperatingSystem
            // 
            this.txtOperatingSystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOperatingSystem.Location = new System.Drawing.Point(148, 56);
            this.txtOperatingSystem.Name = "txtOperatingSystem";
            this.txtOperatingSystem.ReadOnly = true;
            this.txtOperatingSystem.Size = new System.Drawing.Size(400, 15);
            this.txtOperatingSystem.TabIndex = 17;
            this.txtOperatingSystem.Text = "<unknown>";
            // 
            // SummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOperatingSystem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFlags);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.txtMainModule);
            this.Controls.Add(this.lblAvailableStreamsHeading);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Name = "SummaryView";
            this.Size = new System.Drawing.Size(919, 575);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblAvailableStreamsHeading;
        private System.Windows.Forms.TextBox txtMainModule;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.TextBox txtFlags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOperatingSystem;
    }
}
