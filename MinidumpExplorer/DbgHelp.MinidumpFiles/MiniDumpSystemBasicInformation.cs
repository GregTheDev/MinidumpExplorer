using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpSystemBasicInformation
    {
        private MINIDUMP_SYSTEM_BASIC_INFORMATION _systemBasicInformation;
        private MiniDumpFile _owner;

        internal MiniDumpSystemBasicInformation(MINIDUMP_SYSTEM_BASIC_INFORMATION systemBasicInformation, MiniDumpFile owner)
        {
            _systemBasicInformation = systemBasicInformation;
            _owner = owner;
        }

        public UInt32 TimerResolution { get { return _systemBasicInformation.TimerResolution; } }
        public UInt32 PageSize { get { return _systemBasicInformation.PageSize; } }
        public UInt32 NumberOfPhysicalPages { get { return _systemBasicInformation.NumberOfPhysicalPages; } }
        public UInt32 LowestPhysicalPageNumber { get { return _systemBasicInformation.LowestPhysicalPageNumber; } }
        public UInt32 HighestPhysicalPageNumber { get { return _systemBasicInformation.HighestPhysicalPageNumber; } }
        public UInt32 AllocationGranularity { get { return _systemBasicInformation.AllocationGranularity; } }
        public UInt64 MinimumUserModeAddress { get { return _systemBasicInformation.MinimumUserModeAddress; } }
        public UInt64 MaximumUserModeAddress { get { return _systemBasicInformation.MaximumUserModeAddress; } }
        public UInt64 ActiveProcessorsAffinityMask { get { return _systemBasicInformation.ActiveProcessorsAffinityMask; } }
        public UInt32 NumberOfProcessors { get { return _systemBasicInformation.NumberOfProcessors; } }
    }
}
