namespace MinidumpExplorer.Dialogs
{
    partial class ModuleDetailsDialog
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
            this.btnOk = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTimestamp = new System.Windows.Forms.TextBox();
            this.moduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBaseAddress = new System.Windows.Forms.TextBox();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblLine3 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProductVersion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFileVersion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileOS = new System.Windows.Forms.TextBox();
            this.txtFileSubType = new System.Windows.Forms.TextBox();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(287, 444);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(74, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(355, 432);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtTimestamp);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtBaseAddress);
            this.tabPage1.Controls.Add(this.lblLine1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtSize);
            this.tabPage1.Controls.Add(this.txtPath);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(347, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 15);
            this.label13.TabIndex = 75;
            this.label13.Text = "Timestamp:";
            // 
            // txtTimestamp
            // 
            this.txtTimestamp.BackColor = System.Drawing.Color.White;
            this.txtTimestamp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimestamp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "TimeDateStamp", true));
            this.txtTimestamp.Location = new System.Drawing.Point(106, 166);
            this.txtTimestamp.Name = "txtTimestamp";
            this.txtTimestamp.ReadOnly = true;
            this.txtTimestamp.Size = new System.Drawing.Size(235, 16);
            this.txtTimestamp.TabIndex = 74;
            this.txtTimestamp.Text = "txtTimestamp";
            // 
            // moduleBindingSource
            // 
            this.moduleBindingSource.DataSource = typeof(DbgHelp.MinidumpFiles.MiniDumpModule);
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(8, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(331, 2);
            this.label12.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 69;
            this.label8.Text = "Base address:";
            // 
            // txtBaseAddress
            // 
            this.txtBaseAddress.BackColor = System.Drawing.Color.White;
            this.txtBaseAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBaseAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "BaseOfImageFormatted", true));
            this.txtBaseAddress.Location = new System.Drawing.Point(106, 120);
            this.txtBaseAddress.Name = "txtBaseAddress";
            this.txtBaseAddress.ReadOnly = true;
            this.txtBaseAddress.Size = new System.Drawing.Size(235, 16);
            this.txtBaseAddress.TabIndex = 68;
            this.txtBaseAddress.Text = "txtBaseAddress";
            // 
            // lblLine1
            // 
            this.lblLine1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine1.Location = new System.Drawing.Point(10, 105);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(332, 2);
            this.lblLine1.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Path:";
            // 
            // txtSize
            // 
            this.txtSize.BackColor = System.Drawing.Color.White;
            this.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSize.Location = new System.Drawing.Point(106, 75);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(235, 16);
            this.txtSize.TabIndex = 18;
            this.txtSize.Text = "txtSize";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "DirectoryName", true));
            this.txtPath.Location = new System.Drawing.Point(106, 45);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(235, 16);
            this.txtPath.TabIndex = 16;
            this.txtPath.Text = "txtPath";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "FileName", true));
            this.txtName.Location = new System.Drawing.Point(106, 15);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(235, 16);
            this.txtName.TabIndex = 19;
            this.txtName.Text = "txtName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblLine3);
            this.tabPage2.Controls.Add(this.lblLine2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtProductVersion);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtFileVersion);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.checkBox6);
            this.tabPage2.Controls.Add(this.checkBox5);
            this.tabPage2.Controls.Add(this.checkBox4);
            this.tabPage2.Controls.Add(this.checkBox3);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtFileOS);
            this.tabPage2.Controls.Add(this.txtFileSubType);
            this.tabPage2.Controls.Add(this.txtFileType);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(347, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fixed File Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblLine3
            // 
            this.lblLine3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine3.Location = new System.Drawing.Point(9, 180);
            this.lblLine3.Name = "lblLine3";
            this.lblLine3.Size = new System.Drawing.Size(331, 2);
            this.lblLine3.TabIndex = 90;
            // 
            // lblLine2
            // 
            this.lblLine2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine2.Location = new System.Drawing.Point(9, 105);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(331, 2);
            this.lblLine2.TabIndex = 89;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 15);
            this.label10.TabIndex = 88;
            this.label10.Text = "Product version:";
            // 
            // txtProductVersion
            // 
            this.txtProductVersion.BackColor = System.Drawing.Color.White;
            this.txtProductVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "ProductVersion", true));
            this.txtProductVersion.Location = new System.Drawing.Point(105, 150);
            this.txtProductVersion.Name = "txtProductVersion";
            this.txtProductVersion.ReadOnly = true;
            this.txtProductVersion.Size = new System.Drawing.Size(235, 16);
            this.txtProductVersion.TabIndex = 87;
            this.txtProductVersion.Text = "txtProductVersion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 86;
            this.label9.Text = "File version:";
            // 
            // txtFileVersion
            // 
            this.txtFileVersion.BackColor = System.Drawing.Color.White;
            this.txtFileVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "FileVersion", true));
            this.txtFileVersion.Location = new System.Drawing.Point(105, 120);
            this.txtFileVersion.Name = "txtFileVersion";
            this.txtFileVersion.ReadOnly = true;
            this.txtFileVersion.Size = new System.Drawing.Size(235, 16);
            this.txtFileVersion.TabIndex = 85;
            this.txtFileVersion.Text = "txtFileVersion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 84;
            this.label7.Text = "File sub-type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 83;
            this.label6.Text = "File type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 82;
            this.label5.Text = "FileOS:";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.moduleBindingSource, "IsSpecialBuild", true));
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(201, 240);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(98, 19);
            this.checkBox6.TabIndex = 81;
            this.checkBox6.Text = "IsSpecialBuild";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.moduleBindingSource, "IsPrivateBuild", true));
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(201, 215);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(97, 19);
            this.checkBox5.TabIndex = 80;
            this.checkBox5.Text = "IsPrivateBuild";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.moduleBindingSource, "IsPreRelease", true));
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(105, 215);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(90, 19);
            this.checkBox4.TabIndex = 79;
            this.checkBox4.Text = "IsPreRelease";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.moduleBindingSource, "IsPatched", true));
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(105, 240);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(77, 19);
            this.checkBox3.TabIndex = 78;
            this.checkBox3.Text = "IsPatched";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.moduleBindingSource, "IsInfoInferred", true));
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(201, 189);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 19);
            this.checkBox2.TabIndex = 77;
            this.checkBox2.Text = "IsInfoInferred";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.moduleBindingSource, "IsDebug", true));
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(105, 189);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 19);
            this.checkBox1.TabIndex = 76;
            this.checkBox1.Text = "IsDebug";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 75;
            this.label3.Text = "Flags:";
            // 
            // txtFileOS
            // 
            this.txtFileOS.BackColor = System.Drawing.Color.White;
            this.txtFileOS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileOS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "FileOSFormatted", true));
            this.txtFileOS.Location = new System.Drawing.Point(105, 15);
            this.txtFileOS.Name = "txtFileOS";
            this.txtFileOS.ReadOnly = true;
            this.txtFileOS.Size = new System.Drawing.Size(235, 16);
            this.txtFileOS.TabIndex = 72;
            this.txtFileOS.Text = "txtFileOS";
            // 
            // txtFileSubType
            // 
            this.txtFileSubType.BackColor = System.Drawing.Color.White;
            this.txtFileSubType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileSubType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "FileSubTypeFormatted", true));
            this.txtFileSubType.Location = new System.Drawing.Point(105, 75);
            this.txtFileSubType.Name = "txtFileSubType";
            this.txtFileSubType.ReadOnly = true;
            this.txtFileSubType.Size = new System.Drawing.Size(235, 16);
            this.txtFileSubType.TabIndex = 74;
            this.txtFileSubType.Text = "txtFileSubType";
            // 
            // txtFileType
            // 
            this.txtFileType.BackColor = System.Drawing.Color.White;
            this.txtFileType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "FileTypeFormatted", true));
            this.txtFileType.Location = new System.Drawing.Point(105, 45);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.ReadOnly = true;
            this.txtFileType.Size = new System.Drawing.Size(235, 16);
            this.txtFileType.TabIndex = 73;
            this.txtFileType.Text = "txtFileType";
            // 
            // ModuleDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 473);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOk);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleBindingSource, "FileName", true));
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuleDetailsDialog";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource moduleBindingSource;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBaseAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTimestamp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLine3;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProductVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFileVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileOS;
        private System.Windows.Forms.TextBox txtFileSubType;
        private System.Windows.Forms.TextBox txtFileType;
    }
}