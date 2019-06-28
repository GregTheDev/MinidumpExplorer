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
    public partial class CommentStreamAView : BaseViewControl
    {
        private MiniDumpCommentStreamA _commentAStream;

        public CommentStreamAView()
        {
            InitializeComponent();
        }

        public CommentStreamAView(MiniDumpCommentStreamA commentAStream)
            : this()
        {
            _commentAStream = commentAStream;

            if (commentAStream.Comment == null)
                AddInfoNode("No data found for stream");
            else
                AddInfoNode(_commentAStream.Comment);
        }

        private void AddInfoNode(string value)
        {
            textBox1.Text = value;
        }
    }
}
