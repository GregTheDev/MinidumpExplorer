using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Indicates what level of miscellaneous information is contained by a <see cref="MiniDumpMiscInfo"/> instance.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this type to determine what other versions of MiniDumpMiscInfo* an instance of MiniDumpMiscInfo can be cast up to.
    /// </para>
    /// <para>
    /// Example: if MiniDumpMiscInfoLevel.MiscInfo3 is set then an instance of MiniDumpMiscInfo can be cast up to <see cref="MiniDumpMiscInfo3"/>.
    /// </para>
    /// </remarks>
    public enum MiniDumpMiscInfoLevel
    {
        /// <summary>
        /// MiniDumpMiscInfo is available.
        /// </summary>
        MiscInfo,
        /// <summary>
        /// MiniDumpMiscInfo2 is available.
        /// </summary>
        MiscInfo2,
        /// <summary>
        /// MiniDumpMiscInfo3 is available.
        /// </summary>
        MiscInfo3,
        /// <summary>
        /// MiniDumpMiscInfo4 is available.
        /// </summary>
        MiscInfo4
    }

    [Flags]
    /// <summary>
    /// The flags that indicate the valid members of the MiniDumpMiscInfo and it's derived classes.
    /// </summary>
    public enum MiscInfoFlags
    {
        /// <summary>
        /// ProcessId is used.
        /// </summary>
        MINIDUMP_MISC1_PROCESS_ID = 0x00000001,
        /// <summary>
        /// ProcessCreateTime, ProcessKernelTime, and ProcessUserTime are used.
        /// </summary>
        MINIDUMP_MISC1_PROCESS_TIMES = 0x00000002,
        /// <summary>
        /// ProcessorMaxMhz, ProcessorCurrentMhz, ProcessorMhzLimit, ProcessorMaxIdleState, and ProcessorCurrentIdleState are used.
        /// </summary>
        MINIDUMP_MISC1_PROCESSOR_POWER_INFO = 0x00000004,
        MINIDUMP_MISC3_PROCESS_INTEGRITY = 0x00000010,
        MINIDUMP_MISC3_PROCESS_EXECUTE_FLAGS = 0x00000020,
        MINIDUMP_MISC3_TIMEZONE = 0x00000040,
        MINIDUMP_MISC3_PROTECTED_PROCESS = 0x00000080,
        MINIDUMP_MISC4_BUILDSTRING = 0x00000100
    }

    /// <summary>
    /// Contains a variety of information.
    /// </summary>
    /// <remarks>
    /// <para>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms680389%28v=vs.85%29.aspx for additional detailed information.
    /// </para>
    /// <para>
    /// Use <see cref="MiscInfoLevel"/> to determine what level of additional information is available and in turn what other versions of
    /// MiniDumpMiscInfo this class can be cast up to. <see cref="MiniDumpMiscInfoLevel"/> for more information.
    /// </para>
    /// </remarks>
    /// <seealso cref="MiniDumpMiscInfoLevel"/>
    /// <seealso cref="MiniDumpMiscInfo2"/>
    /// <seealso cref="MiniDumpMiscInfo3"/>
    /// <seealso cref="MiniDumpMiscInfo4"/>
    public class MiniDumpMiscInfo
    {
        private MINIDUMP_MISC_INFO _miscInfo;

        internal MiniDumpMiscInfo()
        {
        }

        internal MiniDumpMiscInfo(MINIDUMP_MISC_INFO miscInfo) : this()
        {
            this.MiscInfoLevel = MiniDumpMiscInfoLevel.MiscInfo;

            this._miscInfo = miscInfo;
        }

        /// <summary>
        /// The size of the unmanaged structure, in bytes.
        /// </summary>
        public UInt32 SizeOfInfo { get { return this._miscInfo.SizeOfInfo; } }

        /// <summary>
        /// The flags that indicate the valid members of the MiniDumpMiscInfo and it's derived classes.
        /// </summary>
        public MiscInfoFlags Flags1 { get { return (MiscInfoFlags) this._miscInfo.Flags1; } }

        /// <summary>
        /// The identifier of the process. If Flags1 does not specify MINIDUMP_MISC1_PROCESS_ID, this member is unused.
        /// </summary>
        public UInt32 ProcessId { get { return this._miscInfo.ProcessId; } }

        /// <summary>
        /// The creation time of the process. If Flags1 does not specify MINIDUMP_MISC1_PROCESS_TIMES, this member is unused.
        /// </summary>
        public DateTime ProcessCreateTime { get { return MiniDumpFile.TimeTToDateTime(this._miscInfo.ProcessCreateTime); } }

        /// <summary>
        /// The time the process has executed in user mode, in seconds. The time that each of the threads of the process has executed in user mode is determined, then all these times are summed to obtain this value. If Flags1 does not specify MINIDUMP_MISC1_PROCESS_TIMES, this member is unused.
        /// </summary>
        public UInt32 ProcessUserTime { get { return this._miscInfo.ProcessUserTime; } }

        /// <summary>
        /// The time the process has executed in kernel mode, in seconds. The time that each of the threads of the process has executed in kernel mode is determined, then all these times are summed to obtain this value. If Flags1 does not specify MINIDUMP_MISC1_PROCESS_TIMES, this member is unused.
        /// </summary>
        public UInt32 ProcessKernelTime { get { return this._miscInfo.ProcessKernelTime; } }

        /// <summary>
        /// Indicates what level of additional miscellaneous information is available.
        /// </summary>
        public MiniDumpMiscInfoLevel MiscInfoLevel { get; protected set; }
    }

    /// <summary>
    /// Represents information in the miscellaneous information stream.
    /// </summary>
    /// <remarks>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms680388%28v=vs.85%29.aspx for additional detailed information.
    /// </remarks>
    public class MiniDumpMiscInfo2 : MiniDumpMiscInfo
    {
        private MINIDUMP_MISC_INFO_2 _miscInfo2;

        internal MiniDumpMiscInfo2(MINIDUMP_MISC_INFO_2 miscInfo2)
            : base ((MINIDUMP_MISC_INFO) miscInfo2)
        {
            this.MiscInfoLevel = MiniDumpMiscInfoLevel.MiscInfo2;

            this._miscInfo2 = miscInfo2;
        }

        /// <summary>
        /// The maximum specified clock frequency of the system processor, in MHz. If Flags1 does not specify MINIDUMP_MISC1_PROCESSOR_POWER_INFO, this member is unused.
        /// </summary>
        public UInt32 ProcessorMaxMhz { get { return this._miscInfo2.ProcessorMaxMhz; } }
        /// <summary>
        /// The processor clock frequency, in MHz. This number is the maximum specified processor clock frequency multiplied by the current processor throttle. If Flags1 does not specify MINIDUMP_MISC1_PROCESSOR_POWER_INFO, this member is unused.
        /// </summary>
        public UInt32 ProcessorCurrentMhz { get { return this._miscInfo2.ProcessorCurrentMhz; } }
        /// <summary>
        /// The limit on the processor clock frequency, in MHz. This number is the maximum specified processor clock frequency multiplied by the current processor thermal throttle limit. If Flags1 does not specify MINIDUMP_MISC1_PROCESSOR_POWER_INFO, this member is unused.
        /// </summary>
        public UInt32 ProcessorMhzLimit { get { return this._miscInfo2.ProcessorMhzLimit; } }
        /// <summary>
        /// The maximum idle state of the processor. If Flags1 does not specify MINIDUMP_MISC1_PROCESSOR_POWER_INFO, this member is unused.
        /// </summary>
        public UInt32 ProcessorMaxIdleState { get { return this._miscInfo2.ProcessorMaxIdleState; } }
        /// <summary>
        /// The current idle state of the processor. If Flags1 does not specify MINIDUMP_MISC1_PROCESSOR_POWER_INFO, this member is unused.
        /// </summary>
        public UInt32 ProcessorCurrentIdleState { get { return this._miscInfo2.ProcessorCurrentIdleState; } }
    }

    /// <summary>
    /// Represents information in the miscellaneous information stream.
    /// </summary>
    /// <remarks>
    /// MINIDUMP_MISC_INFO_3 is not documented in the MSDN. As a result no documentation is available for MiniDumpMiscInfo3.
    /// </remarks>
    public class MiniDumpMiscInfo3 : MiniDumpMiscInfo2
    {
        private MINIDUMP_MISC_INFO_3 _miscInfo3;
        private Win32TimeZoneInformation _timeZoneInformation;

        internal MiniDumpMiscInfo3(MINIDUMP_MISC_INFO_3 miscInfo3)
            : base((MINIDUMP_MISC_INFO_2)miscInfo3)
        {
            this.MiscInfoLevel = MiniDumpMiscInfoLevel.MiscInfo3;

            this._miscInfo3 = miscInfo3;
            this._timeZoneInformation = new Win32TimeZoneInformation(miscInfo3.TimeZone);
        }

        public UInt32 ProcessIntegrityLevel { get { return this._miscInfo3.ProcessIntegrityLevel; } }
        public UInt32 ProcessExecuteFlags { get { return this._miscInfo3.ProcessExecuteFlags; } }
        public UInt32 ProtectedProcess { get { return this._miscInfo3.ProtectedProcess; } }
        public UInt32 TimeZoneId { get { return this._miscInfo3.TimeZoneId; } }
        public Win32TimeZoneInformation TimeZone { get { return this._timeZoneInformation; } }
    }

    /// <summary>
    /// Represents information in the miscellaneous information stream.
    /// </summary>
    /// <remarks>
    /// MINIDUMP_MISC_INFO_4 is not documented in the MSDN. As a result no documentation is available for MiniDumpMiscInfo4.
    /// </remarks>
    public class MiniDumpMiscInfo4 : MiniDumpMiscInfo3
    {
        private MINIDUMP_MISC_INFO_4 _miscInfo4;

        internal MiniDumpMiscInfo4(MINIDUMP_MISC_INFO_4 miscInfo4)
            : base((MINIDUMP_MISC_INFO_3)miscInfo4)
        {
            this.MiscInfoLevel = MiniDumpMiscInfoLevel.MiscInfo4;
            this._miscInfo4 = miscInfo4;
        }

        public string BuildString { get { return _miscInfo4.BuildString; } }
        public string DbgBldStr { get { return _miscInfo4.DbgBldStr; } }
    }
}
