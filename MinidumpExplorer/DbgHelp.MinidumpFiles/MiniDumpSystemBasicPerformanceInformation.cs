using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpSystemBasicPerformanceInformation
    {
        private MINIDUMP_SYSTEM_BASIC_PERFORMANCE_INFORMATION _systemBasicPerformanceInformation;
        private MiniDumpFile _owner;

        internal MiniDumpSystemBasicPerformanceInformation(MINIDUMP_SYSTEM_BASIC_PERFORMANCE_INFORMATION systemBasicPerformanceInformation, MiniDumpFile owner)
        {
            _systemBasicPerformanceInformation = systemBasicPerformanceInformation;
            _owner = owner;
        }

        public UInt64 AvailablePages { get { return _systemBasicPerformanceInformation.AvailablePages; } }
        public UInt64 CommittedPages { get { return _systemBasicPerformanceInformation.CommittedPages; } }
        public UInt64 CommitLimit { get { return _systemBasicPerformanceInformation.CommitLimit; } }
        public UInt64 PeakCommitment { get { return _systemBasicPerformanceInformation.PeakCommitment; } }
    }
}
