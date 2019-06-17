using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DbgHelp.MinidumpFiles;

using MinidumpExplorer.Dialogs;

namespace MinidumpExplorer.Views
{
    public partial class ModulesView : BaseViewControl
    {
        private MiniDumpModule[] _modulesList;

        public ModulesView()
        {
            InitializeComponent();
        }

        public ModulesView(MiniDumpModule[] modulesList)
            : this()
        {
            _modulesList = modulesList;

            foreach (MiniDumpModule loadedModule in _modulesList)
            {
                ListViewItem newItem = new ListViewItem(loadedModule.PathAndFileName);
                newItem.SubItems.Add(loadedModule.SizeOfImageFormatted);
                newItem.SubItems.Add(loadedModule.TimeDateStamp.ToString());
                newItem.SubItems.Add(loadedModule.FileVersion);
                newItem.SubItems.Add(loadedModule.ProductVersion);
                newItem.SubItems.Add(loadedModule.BaseOfImageFormatted);

                newItem.Tag = loadedModule;

                this.listView1.Items.Add(newItem);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ModuleDetailsDialog detailDialog = new ModuleDetailsDialog((MiniDumpModule)this.listView1.SelectedItems[0].Tag);

            detailDialog.ShowDialog();
        }
    }
}
