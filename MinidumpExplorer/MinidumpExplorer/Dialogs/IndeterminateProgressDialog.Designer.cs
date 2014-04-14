namespace MinidumpExplorer.Dialogs
{
    partial class IndeterminateProgressDialog
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
            this.lblCaptureProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblCaptureProgress
            // 
            this.lblCaptureProgress.Location = new System.Drawing.Point(42, 82);
            this.lblCaptureProgress.Name = "lblCaptureProgress";
            this.lblCaptureProgress.Size = new System.Drawing.Size(405, 28);
            this.lblCaptureProgress.TabIndex = 8;
            this.lblCaptureProgress.Text = "Capturing minidump ...";
            this.lblCaptureProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(42, 43);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(405, 27);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Value = 100;
            // 
            // IndeterminateProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 149);
            this.ControlBox = false;
            this.Controls.Add(this.lblCaptureProgress);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "IndeterminateProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processing ...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaptureProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}