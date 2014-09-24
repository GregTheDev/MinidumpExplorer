namespace MinidumpExplorer.Dialogs
{
    partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.okButton = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picLinkedin = new System.Windows.Forms.PictureBox();
            this.picTwitter = new System.Windows.Forms.PictureBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLinkedin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(311, 216);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 27);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(158, 181);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(241, 15);
            this.linkLabel2.TabIndex = 30;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://gregsplaceontheweb.wordpress.com/";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(158, 25);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 20);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(84, 15);
            this.labelProductName.TabIndex = 25;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(158, 47);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 20);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(46, 15);
            this.labelVersion.TabIndex = 26;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(158, 69);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 20);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(60, 15);
            this.labelCopyright.TabIndex = 27;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(157, 159);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(185, 15);
            this.linkLabel1.TabIndex = 29;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://minidumps.codeplex.com/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picLinkedin);
            this.panel1.Controls.Add(this.picTwitter);
            this.panel1.Location = new System.Drawing.Point(161, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 39);
            this.panel1.TabIndex = 28;
            // 
            // picLinkedin
            // 
            this.picLinkedin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLinkedin.Image = global::MinidumpExplorer.Properties.Resources.InBug_30px_R;
            this.picLinkedin.Location = new System.Drawing.Point(42, 4);
            this.picLinkedin.Name = "picLinkedin";
            this.picLinkedin.Size = new System.Drawing.Size(51, 32);
            this.picLinkedin.TabIndex = 29;
            this.picLinkedin.TabStop = false;
            this.picLinkedin.Click += new System.EventHandler(this.picLinkedin_Click);
            // 
            // picTwitter
            // 
            this.picTwitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTwitter.Image = global::MinidumpExplorer.Properties.Resources.bird_blue_32;
            this.picTwitter.Location = new System.Drawing.Point(3, 4);
            this.picTwitter.Name = "picTwitter";
            this.picTwitter.Size = new System.Drawing.Size(32, 32);
            this.picTwitter.TabIndex = 28;
            this.picTwitter.TabStop = false;
            this.picTwitter.Click += new System.EventHandler(this.picTwitter_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(14, -1);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(134, 150);
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.label1.MaximumSize = new System.Drawing.Size(0, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "Contact me:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 256);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLinkedin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picLinkedin;
        private System.Windows.Forms.PictureBox picTwitter;
        private System.Windows.Forms.Label label1;
    }
}
