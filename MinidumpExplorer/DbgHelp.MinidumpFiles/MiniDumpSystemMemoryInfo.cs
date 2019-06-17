using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpSystemMemoryInfo
    {
        private MINIDUMP_SYSTEM_MEMORY_INFO_1 _systemMemoryInfo;
        private MiniDumpSystemBasicInformation _systemBasicInformation;
        private MiniDumpSystemFileCacheInformation _systemFileCacheInformation;
        private MiniDumpSystemBasicPerformanceInformation _systemBasicPerformanceInformation;
        private MiniDumpSystemPerformanceInformation _systemPerformanceInformation;
        private MiniDumpFile _owner;

        internal MiniDumpSystemMemoryInfo(MINIDUMP_SYSTEM_MEMORY_INFO_1 systemMemoryInfo, MiniDumpFile owner)
        {
            _systemMemoryInfo = systemMemoryInfo;
            _owner = owner;

            _systemBasicInformation = new MiniDumpSystemBasicInformation(systemMemoryInfo.BasicInfo, owner);
            _systemFileCacheInformation = new MiniDumpSystemFileCacheInformation(systemMemoryInfo.FileCacheInfo, owner);
            _systemBasicPerformanceInformation = new MiniDumpSystemBasicPerformanceInformation(systemMemoryInfo.BasicPerfInfo, owner);
            _systemPerformanceInformation = new MiniDumpSystemPerformanceInformation(systemMemoryInfo.PerfInfo, owner);
        }

        public ushort Revision { get { return _systemMemoryInfo.Revision; } }
        public ushort Flags { get { return _systemMemoryInfo.Flags; } }
        public MiniDumpSystemBasicInformation SystemBasicInformation { get { return _systemBasicInformation; } }
        public MiniDumpSystemFileCacheInformation SystemFileCacheInformation { get { return _systemFileCacheInformation; } }
        public MiniDumpSystemBasicPerformanceInformation SystemBasicPerformanceInformation { get { return _systemBasicPerformanceInformation; } }
        public MiniDumpSystemPerformanceInformation SystemPerformanceInformation { get { return _systemPerformanceInformation; } }
    }
}
