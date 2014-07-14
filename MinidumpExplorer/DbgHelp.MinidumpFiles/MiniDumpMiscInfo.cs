using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains a variety of information.
    /// </summary>
    public class MiniDumpMiscInfo
    {
        private UInt32 _sizeOfInfo;
        private UInt32 _flags1;
        private UInt32 _processId;
        private UInt32 _processCreateTime;
        private UInt32 _processUserTime;
        private UInt32 _processKernelTime;
        private UInt32 _processorMaxMhz;
        private UInt32 _processorCurrentMhz;
        private UInt32 _processorMhzLimit;
        private UInt32 _processorMaxIdleState;
        private UInt32 _processorCurrentIdleState;
        private UInt32 _processIntegrityLevel;
        private UInt32 _processExecuteFlags;
        private UInt32 _protectedProcess;
        private UInt32 _timeZoneId;
        private TIME_ZONE_INFORMATION _timeZone;
        private string _buildString;
        private string _dbgBldStr;

        internal MiniDumpMiscInfo()
        {
            this.IsMiscInfo = false;
            this.IsMiscInfo2 = false;
            this.IsMiscInfo3 = false;
            this.IsMiscInfo4 = false;
        }

        internal MiniDumpMiscInfo(MINIDUMP_MISC_INFO miscInfo) : this()
        {
            this.IsMiscInfo = true;

            this._sizeOfInfo = miscInfo.SizeOfInfo;
            this._flags1 = miscInfo.Flags1;
            this._processId = miscInfo.ProcessId;
            this._processCreateTime = miscInfo.ProcessCreateTime;
            this._processUserTime = miscInfo.ProcessUserTime;
            this._processKernelTime = miscInfo.ProcessKernelTime;
        }

        internal MiniDumpMiscInfo(MINIDUMP_MISC_INFO_2 miscInfo)
        {
            this.IsMiscInfo2 = true;

            this._sizeOfInfo = miscInfo.SizeOfInfo;
            this._flags1 = miscInfo.Flags1;
            this._processId = miscInfo.ProcessId;
            this._processCreateTime = miscInfo.ProcessCreateTime;
            this._processUserTime = miscInfo.ProcessUserTime;
            this._processKernelTime = miscInfo.ProcessKernelTime;
            this._processorMaxMhz = miscInfo.ProcessorMaxMhz;
            this._processorCurrentMhz = miscInfo.ProcessorCurrentMhz;
            this._processorMhzLimit = miscInfo.ProcessorMhzLimit;
            this._processorMaxIdleState = miscInfo.ProcessorMaxIdleState;
            this._processorCurrentIdleState = miscInfo.ProcessorCurrentIdleState;
        }

        internal MiniDumpMiscInfo(MINIDUMP_MISC_INFO_3 miscInfo)
        {
            this.IsMiscInfo3 = true;

            this._sizeOfInfo = miscInfo.SizeOfInfo;
            this._flags1 = miscInfo.Flags1;
            this._processId = miscInfo.ProcessId;
            this._processCreateTime = miscInfo.ProcessCreateTime;
            this._processUserTime = miscInfo.ProcessUserTime;
            this._processKernelTime = miscInfo.ProcessKernelTime;
            this._processorMaxMhz = miscInfo.ProcessorMaxMhz;
            this._processorCurrentMhz = miscInfo.ProcessorCurrentMhz;
            this._processorMhzLimit = miscInfo.ProcessorMhzLimit;
            this._processorMaxIdleState = miscInfo.ProcessorMaxIdleState;
            this._processorCurrentIdleState = miscInfo.ProcessorCurrentIdleState;
            this._processIntegrityLevel = miscInfo.ProcessIntegrityLevel;
            this._processExecuteFlags = miscInfo.ProcessExecuteFlags;
            this._protectedProcess = miscInfo.ProtectedProcess;
            this._timeZoneId = miscInfo.TimeZoneId;
            this._timeZone = miscInfo.TimeZone;
        }

        internal MiniDumpMiscInfo(MINIDUMP_MISC_INFO_4 miscInfo)
        {
            this.IsMiscInfo4 = true;

            this._sizeOfInfo = miscInfo.SizeOfInfo;
            this._flags1 = miscInfo.Flags1;
            this._processId = miscInfo.ProcessId;
            this._processCreateTime = miscInfo.ProcessCreateTime;
            this._processUserTime = miscInfo.ProcessUserTime;
            this._processKernelTime = miscInfo.ProcessKernelTime;
            this._processorMaxMhz = miscInfo.ProcessorMaxMhz;
            this._processorCurrentMhz = miscInfo.ProcessorCurrentMhz;
            this._processorMhzLimit = miscInfo.ProcessorMhzLimit;
            this._processorMaxIdleState = miscInfo.ProcessorMaxIdleState;
            this._processorCurrentIdleState = miscInfo.ProcessorCurrentIdleState;
            this._processIntegrityLevel = miscInfo.ProcessIntegrityLevel;
            this._processExecuteFlags = miscInfo.ProcessExecuteFlags;
            this._protectedProcess = miscInfo.ProtectedProcess;
            this._timeZoneId = miscInfo.TimeZoneId;
            this._timeZone = miscInfo.TimeZone;
            this._buildString = miscInfo.BuildString;
            this._dbgBldStr = miscInfo.DbgBldStr;
        }

        public UInt32 SizeOfInfo { get { return this._sizeOfInfo; } }
        public UInt32 Flags1 { get { return this._flags1; } }
        public UInt32 ProcessId { get { return this._processId; } }
        public UInt32 ProcessCreateTime { get { return this._processCreateTime; } }
        public UInt32 ProcessUserTime { get { return this._processUserTime; } }
        public UInt32 ProcessKernelTime { get { return this._processKernelTime; } }
        
        public bool IsMiscInfo { get; private set; }
        public bool IsMiscInfo2 { get; private set; }
        public bool IsMiscInfo3 { get; private set; }
        public bool IsMiscInfo4 { get; private set; }
    }
}
