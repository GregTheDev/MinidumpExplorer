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
    public partial class UnloadedModulesView : BaseViewControl
    {
        private MiniDumpUnloadedModulesStream _unloadedModulesStream;

        public UnloadedModulesView()
        {
            InitializeComponent();
        }

        public UnloadedModulesView(MiniDumpUnloadedModulesStream unloadedModulesStream)
            : this()
        {
            _unloadedModulesStream = unloadedModulesStream;

            if (unloadedModulesStream.NumberOfEntries == 0)
            {
                this.listView1.Items.Add("No data found for stream");
                return;
            }

            foreach (MiniDumpUnloadedModule unloadedModule in _unloadedModulesStream.Entries)
            {
                ListViewItem newItem = new ListViewItem(unloadedModule.ModuleName);
                newItem.SubItems.Add(Formatters.FormatAsSizeString(unloadedModule.SizeOfImage));
                newItem.SubItems.Add(unloadedModule.TimeDateStamp.ToString());
                newItem.SubItems.Add(Formatters.FormatAsMemoryAddress(unloadedModule.BaseOfImage));

                newItem.Tag = unloadedModule;

                this.listView1.Items.Add(newItem);
            }
        }
    }
}
