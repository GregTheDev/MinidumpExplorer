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
    public partial class MiscInfoView : BaseViewControl
    {
        private MiniDumpMiscInfo _miscInfo;

        public MiscInfoView()
        {
            InitializeComponent();
        }

        public MiscInfoView(MiniDumpMiscInfo miscInfo)
            : this()
        {
            _miscInfo = miscInfo;

            AddInfoNode("Flags", _miscInfo.Flags1.ToString());

            if (_miscInfo.Flags1.HasFlag(MiscInfoFlags.MINIDUMP_MISC1_PROCESS_ID))
            {
                AddInfoNode("ProcessId", _miscInfo.ProcessId.ToString());
            }
            else
            {
                AddInfoNode("MINIDUMP_MISC1_PROCESS_ID", "Not available");
            }

            if (_miscInfo.Flags1.HasFlag(MiscInfoFlags.MINIDUMP_MISC1_PROCESS_TIMES))
            {
                AddInfoNode("ProcessCreateTime", _miscInfo.ProcessCreateTime.ToString());
                AddInfoNode("ProcessUserTime", _miscInfo.ProcessUserTime.ToString());
                AddInfoNode("ProcessKernelTime", _miscInfo.ProcessKernelTime.ToString());
            }
            else
            {
                AddInfoNode("MINIDUMP_MISC1_PROCESS_TIMES", "Not available");
            }

            // Check what other level of information is available
            if (_miscInfo.MiscInfoLevel == MiniDumpMiscInfoLevel.MiscInfo4)
            {
                AddMiscInfo2Data((MiniDumpMiscInfo2)miscInfo);
                AddMiscInfo3Data((MiniDumpMiscInfo3)miscInfo);
                AddMiscInfo4Data((MiniDumpMiscInfo4)miscInfo);
            }
            else if (_miscInfo.MiscInfoLevel == MiniDumpMiscInfoLevel.MiscInfo3)
            {
                AddMiscInfo2Data((MiniDumpMiscInfo2)miscInfo);
                AddMiscInfo3Data((MiniDumpMiscInfo3)miscInfo);
            }
            else if (_miscInfo.MiscInfoLevel == MiniDumpMiscInfoLevel.MiscInfo2)
            {
                AddMiscInfo2Data((MiniDumpMiscInfo2)miscInfo);
            }
        }

        private void AddMiscInfo2Data(MiniDumpMiscInfo2 miscInfo2)
        {
            if (miscInfo2.Flags1.HasFlag(MiscInfoFlags.MINIDUMP_MISC1_PROCESSOR_POWER_INFO))
            {
                AddInfoNode("ProcessorMaxMhz", miscInfo2.ProcessorMaxMhz.ToString());
                AddInfoNode("ProcessorCurrentMhz", miscInfo2.ProcessorCurrentMhz.ToString());
                AddInfoNode("ProcessorMhzLimit", miscInfo2.ProcessorMhzLimit.ToString());
                AddInfoNode("ProcessorMaxIdleState", miscInfo2.ProcessorMaxIdleState.ToString());
                AddInfoNode("ProcessorCurrentIdleState", miscInfo2.ProcessorCurrentIdleState.ToString());
            }
            else
            {
                AddInfoNode("MINIDUMP_MISC1_PROCESSOR_POWER_INFO", "Not available");
            }
        }

        private void AddMiscInfo3Data(MiniDumpMiscInfo3 miscInfo3)
        {
            // MINIDUMP_MISC3_PROCESS_INTEGRITY isn't actually documented, so I'm assuming it covers ProcessIntegrityLevel
            if (miscInfo3.Flags1.HasFlag(MiscInfoFlags.MINIDUMP_MISC3_PROCESS_INTEGRITY))
            {
                AddInfoNode("ProcessIntegrityLevel", miscInfo3.ProcessIntegrityLevel.ToString());
            }
            else
            {
                AddInfoNode("MINIDUMP_MISC3_PROCESS_INTEGRITY", "Not available");
            }

            // MINIDUMP_MISC3_PROCESS_EXECUTE_FLAGS isn't actually documented, so I'm assuming it covers ProcessExecuteFlags
            if (miscInfo3.Flags1.HasFlag(MiscInfoFlags.MINIDUMP_MISC3_PROCESS_EXECUTE_FLAGS))
            {
                AddInfoNode("ProcessExecuteFlags", miscInfo3.ProcessExecuteFlags.ToString());
            }
            else
            {
                AddInfoNode("MINIDUMP_MISC3_PROCESS_EXECUTE_FLAGS", "Not available");
            }
            
            // MINIDUMP_MISC3_PROTECTED_PROCESS isn't actually documented, so I'm assuming it covers ProtectedProcess
            if (miscInfo3.Flags1.HasFlag(MiscInfoFlags.MINIDUMP_MISC3_PROTECTED_PROCESS))
            {
                AddInfoNode("ProtectedProcess", miscInfo3.ProtectedProcess.ToString());
            }
            else
            {
                AddInfoNode("MINIDUMP_MISC3_PROTECTED_PROCESS", "Not available");
            }

            // MINIDUMP_MISC3_TIMEZONE isn't actually documented, so I'm assuming it covers TimeZoneId & TimeZoneId
            if (miscInfo3.Flags1.HasFlag(MiscInfoFlags.MINIDUMP_MISC3_TIMEZONE))
            {
                AddInfoNode("TimeZoneId", miscInfo3.TimeZoneId.ToString());
                AddInfoNode("TimeZone.Bias", miscInfo3.TimeZone.Bias.ToString());
                AddInfoNode("TimeZone.StandardName", miscInfo3.TimeZone.StandardName);

                if (miscInfo3.TimeZone.StandardDate == DateTime.MinValue)
                    AddInfoNode("TimeZone.StandardDate", "Daylight saving time not supported for this time zone");
                else
                    AddInfoNode("TimeZone.StandardDate", miscInfo3.TimeZone.StandardDate.ToString());

                AddInfoNode("TimeZone.StandardBias", miscInfo3.TimeZone.StandardBias.ToString());
                AddInfoNode("TimeZone.DaylightName", miscInfo3.TimeZone.DaylightName);

                if (miscInfo3.TimeZone.DaylightDate == DateTime.MinValue)
                    AddInfoNode("TimeZone.DaylightDate", miscInfo3.TimeZone.DaylightDate.ToString());
                else
                    AddInfoNode("TimeZone.DaylightDate", "Daylight saving time not supported for this time zone");

                AddInfoNode("TimeZone.DaylightBias", miscInfo3.TimeZone.DaylightBias.ToString());
            }
            else
            {
                AddInfoNode("MINIDUMP_MISC3_TIMEZONE", "Not available");
            }
        }

        private void AddMiscInfo4Data(MiniDumpMiscInfo4 miscInfo4)
        {
            // MINIDUMP_MISC4_BUILDSTRING isn't actually documented, so I'm assuming it covers BuildString & DbgBldStr
            if (miscInfo4.Flags1.HasFlag(MiscInfoFlags.MINIDUMP_MISC4_BUILDSTRING))
            {
                AddInfoNode("BuildString", miscInfo4.BuildString);
                AddInfoNode("DbgBldStr", miscInfo4.DbgBldStr);
            }
            else
            {
                AddInfoNode("MINIDUMP_MISC4_BUILDSTRING", "Not available");
            }
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
