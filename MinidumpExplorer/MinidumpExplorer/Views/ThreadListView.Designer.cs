﻿namespace MinidumpExplorer.Views
{
    partial class ThreadListView
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.idHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.suspendCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priorityClassHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priorityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tebHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stackHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idHeader,
            this.suspendCountHeader,
            this.priorityClassHeader,
            this.priorityHeader,
            this.tebHeader,
            this.stackHeader,
            this.contextHeader});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(919, 334);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // idHeader
            // 
            this.idHeader.Text = "Id";
            this.idHeader.Width = 120;
            // 
            // suspendCountHeader
            // 
            this.suspendCountHeader.Text = "SuspendCount";
            this.suspendCountHeader.Width = 98;
            // 
            // priorityClassHeader
            // 
            this.priorityClassHeader.Text = "PriorityClass";
            this.priorityClassHeader.Width = 81;
            // 
            // priorityHeader
            // 
            this.priorityHeader.Text = "Priority";
            this.priorityHeader.Width = 90;
            // 
            // tebHeader
            // 
            this.tebHeader.Text = "Teb";
            this.tebHeader.Width = 128;
            // 
            // stackHeader
            // 
            this.stackHeader.Text = "Stack";
            this.stackHeader.Width = 128;
            // 
            // contextHeader
            // 
            this.contextHeader.Text = "Context";
            // 
            // ThreadListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "ThreadListView";
            this.Size = new System.Drawing.Size(919, 334);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader idHeader;
        private System.Windows.Forms.ColumnHeader suspendCountHeader;
        private System.Windows.Forms.ColumnHeader priorityClassHeader;
        private System.Windows.Forms.ColumnHeader priorityHeader;
        private System.Windows.Forms.ColumnHeader tebHeader;
        private System.Windows.Forms.ColumnHeader stackHeader;
        private System.Windows.Forms.ColumnHeader contextHeader;
    }
}