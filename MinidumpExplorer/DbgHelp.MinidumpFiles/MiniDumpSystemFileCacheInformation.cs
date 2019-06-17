using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpSystemFileCacheInformation
    {
        private MINIDUMP_SYSTEM_FILECACHE_INFORMATION _systemFileCacheInformation;
        private MiniDumpFile _owner;

        internal MiniDumpSystemFileCacheInformation(MINIDUMP_SYSTEM_FILECACHE_INFORMATION systemFileCacheInformation, MiniDumpFile owner)
        {
            _systemFileCacheInformation = systemFileCacheInformation;
            _owner = owner;
        }

        public UInt64 CurrentSize { get { return _systemFileCacheInformation.CurrentSize; } }
        public UInt64 PeakSize { get { return _systemFileCacheInformation.PeakSize; } }
        public UInt32 PageFaultCount { get { return _systemFileCacheInformation.PageFaultCount; } }
        public UInt64 MinimumWorkingSet { get { return _systemFileCacheInformation.MinimumWorkingSet; } }
        public UInt64 MaximumWorkingSet { get { return _systemFileCacheInformation.MaximumWorkingSet; } }
        public UInt64 CurrentSizeIncludingTransitionInPages { get { return _systemFileCacheInformation.CurrentSizeIncludingTransitionInPages; } }
        public UInt64 PeakSizeIncludingTransitionInPages { get { return _systemFileCacheInformation.PeakSizeIncludingTransitionInPages; } }
        public UInt32 TransitionRePurposeCount { get { return _systemFileCacheInformation.TransitionRePurposeCount; } }
        public UInt32 Flags { get { return _systemFileCacheInformation.Flags; } }
    }
}
