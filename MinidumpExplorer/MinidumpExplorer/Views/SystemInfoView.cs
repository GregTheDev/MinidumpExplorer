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
    public partial class SystemInfoView : BaseViewControl
    {
        private MiniDumpSystemInfoStream _systemInfo;

        private const int LVG_SYSTEM_INFO = 0;
        private const int LVG_CPU_INFO = 1;

        public SystemInfoView()
        {
            InitializeComponent();
        }

        public SystemInfoView(MiniDumpSystemInfoStream systemInfo)
            : this()
        {
            _systemInfo = systemInfo;

            AddGroupedNode("ProcessorArchitecture", systemInfo.ProcessorArchitecture.ToString(), LVG_SYSTEM_INFO);

            if (systemInfo.ProcessorArchitecture == MiniDumpProcessorArchitecture.PROCESSOR_ARCHITECTURE_INTEL)
            {
                switch (systemInfo.ProcessorLevel)
                {
                    case 3: AddGroupedNode("ProcessorLevel", "Intel 80386", LVG_SYSTEM_INFO); break;
                    case 4: AddGroupedNode("ProcessorLevel", "Intel 80486", LVG_SYSTEM_INFO); break;
                    case 5: AddGroupedNode("ProcessorLevel", "Intel Pentium", LVG_SYSTEM_INFO); break;
                    case 6: AddGroupedNode("ProcessorLevel", "Intel Pentium Pro or Pentium II", LVG_SYSTEM_INFO); break;
                    default: AddGroupedNode("ProcessorLevel", systemInfo.ProcessorLevel.ToString(), LVG_SYSTEM_INFO); break;
                }
            }
            else
                AddGroupedNode("ProcessorLevel", systemInfo.ProcessorLevel.ToString(), LVG_SYSTEM_INFO);
            
            AddGroupedNode("ProcessorRevision", String.Format("0x{0:X8}", systemInfo.ProcessorRevision), LVG_SYSTEM_INFO);
            AddGroupedNode("NumberOfProcessors", systemInfo.NumberOfProcessors.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("ProductType", systemInfo.ProductType.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("MajorVersion", systemInfo.MajorVersion.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("MinorVersion", systemInfo.MinorVersion.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("BuildNumber", systemInfo.BuildNumber.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("PlatformId", systemInfo.PlatformId.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("CSDVersion", systemInfo.CSDVersion, LVG_SYSTEM_INFO);

            AddGroupedNode("SuiteMask", systemInfo.SuiteMask.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteBackOffice", systemInfo.HasSuiteBackOffice.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteBlade", systemInfo.HasSuiteBlade.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteComputeServer", systemInfo.HasSuiteComputeServer.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteDataCenter", systemInfo.HasSuiteDataCenter.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteEnterprise", systemInfo.HasSuiteEnterprise.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteEmbeddedNt", systemInfo.HasSuiteEmbeddedNt.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuitePersonal", systemInfo.HasSuitePersonal.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteSingleUserTerminalServices", systemInfo.HasSuiteSingleUserTerminalServices.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteSmallBusiness", systemInfo.HasSuiteSmallBusiness.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteSmallBusinessRestricted", systemInfo.HasSuiteSmallBusinessRestricted.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteStorageServer", systemInfo.HasSuiteStorageServer.ToString(), LVG_SYSTEM_INFO);
            AddGroupedNode("HasSuiteTerminal", systemInfo.HasSuiteTerminal.ToString(), LVG_SYSTEM_INFO);

            if (systemInfo.ProcessorArchitecture == MiniDumpProcessorArchitecture.PROCESSOR_ARCHITECTURE_INTEL)
            {
                AddGroupedNode("VendorId", systemInfo.CpuInfoX86.VendorId, LVG_CPU_INFO);
                AddGroupedNode("VersionInformation", String.Format("0x{0:X8}", systemInfo.CpuInfoX86.VersionInformation), LVG_CPU_INFO);
                AddGroupedNode("FeatureInformation",
                    String.Format("0x{0:X8} ({1})", systemInfo.CpuInfoX86.FeatureInformation, Convert.ToString(systemInfo.CpuInfoX86.FeatureInformation, 2)), 
                    LVG_CPU_INFO);

                if (systemInfo.CpuInfoX86.VendorId == "AuthenticAMD")
                    AddGroupedNode("AMDExtendedCpuFeatures ", String.Format("0x{0:X8}", systemInfo.CpuInfoX86.AMDExtendedCpuFeatures), LVG_CPU_INFO);
            }
            else
            {
                AddGroupedNode("ProcessorFeatures ", 
                    String.Format("0x{0:X8}", systemInfo.CpuInfoOther.ProcessorFeatures[0]) + 
                    " " +
                    String.Format("0x{0:X8}", systemInfo.CpuInfoOther.ProcessorFeatures[1]), LVG_CPU_INFO);
            }
        }

        private void AddGroupedNode(string description, string value, int groupIndex)
        {
            ListViewItem newItem;
            newItem = new ListViewItem(description, listView1.Groups[groupIndex]);
            newItem.SubItems.Add(value);
            this.listView1.Items.Add(newItem);
        }
    }
}
