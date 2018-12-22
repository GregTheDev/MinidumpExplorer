using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbgHelp.MinidumpFiles;

namespace MinidumpExplorer.Views
{
    public partial class CommentStreamWView : BaseViewControl
    {
        private MiniDumpCommentStreamW _commentWStream;

        public CommentStreamWView()
        {
            InitializeComponent();
        }

        public CommentStreamWView(MiniDumpCommentStreamW commentWStream)
            : this()
        {
            _commentWStream = commentWStream;

            if (commentWStream.Comment == null)
                AddInfoNode("No data found for stream", "");
            else
                AddInfoNode("Comment", _commentWStream.Comment);
        }

        private void AddInfoNode(string label, string value)
        {
            ListViewItem newItem;
            newItem = new ListViewItem(label);
            newItem.SubItems.Add(value);
            this.listView1.Items.Add(newItem);
        }
    }
}
