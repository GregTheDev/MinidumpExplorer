using DbgHelp.MinidumpFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinidumpExplorer.Dialogs
{
    public partial class ModuleDetailsDialog : Form
    {
        private MiniDumpModule _module;

        public ModuleDetailsDialog()
        {
            InitializeComponent();
        }

        public ModuleDetailsDialog(MiniDumpModule module)
            : this()
        {
            _module = module;

            this.moduleBindingSource.DataSource = _module;
            this.txtSize.Text = String.Concat(_module.SizeOfImageFormatted, " (", _module.SizeOfImage.ToString("N0"), " bytes)");
        }
    }
}
