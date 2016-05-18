using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpSystemPerformanceInformation
    {
        private MINIDUMP_SYSTEM_PERFORMANCE_INFORMATION _systemPerformanceInformation;
        private MiniDumpFile _owner;

        internal MiniDumpSystemPerformanceInformation(MINIDUMP_SYSTEM_PERFORMANCE_INFORMATION systemPerformanceInformation, MiniDumpFile owner)
        {
            _systemPerformanceInformation = systemPerformanceInformation;
            _owner = owner;
        }

        public UInt64 IdleProcessTime { get { return _systemPerformanceInformation.IdleProcessTime; } }
        public UInt64 IoReadTransferCount { get { return _systemPerformanceInformation.IoReadTransferCount; } }
        public UInt64 IoWriteTransferCount { get { return _systemPerformanceInformation.IoWriteTransferCount; } }
        public UInt64 IoOtherTransferCount { get { return _systemPerformanceInformation.IoOtherTransferCount; } }
        public UInt32 IoReadOperationCount { get { return _systemPerformanceInformation.IoReadOperationCount; } }
        public UInt32 IoWriteOperationCount { get { return _systemPerformanceInformation.IoWriteOperationCount; } }
        public UInt32 IoOtherOperationCount { get { return _systemPerformanceInformation.IoOtherOperationCount; } }
        public UInt32 AvailablePages { get { return _systemPerformanceInformation.AvailablePages; } }
        public UInt32 CommittedPages { get { return _systemPerformanceInformation.CommittedPages; } }
        public UInt32 CommitLimit { get { return _systemPerformanceInformation.CommitLimit; } }
        public UInt32 PeakCommitment { get { return _systemPerformanceInformation.PeakCommitment; } }
        public UInt32 PageFaultCount { get { return _systemPerformanceInformation.PageFaultCount; } }
        public UInt32 CopyOnWriteCount { get { return _systemPerformanceInformation.CopyOnWriteCount; } }
        public UInt32 TransitionCount { get { return _systemPerformanceInformation.TransitionCount; } }
        public UInt32 CacheTransitionCount { get { return _systemPerformanceInformation.CacheTransitionCount; } }
        public UInt32 DemandZeroCount { get { return _systemPerformanceInformation.DemandZeroCount; } }
        public UInt32 PageReadCount { get { return _systemPerformanceInformation.PageReadCount; } }
        public UInt32 PageReadIoCount { get { return _systemPerformanceInformation.PageReadIoCount; } }
        public UInt32 CacheReadCount { get { return _systemPerformanceInformation.CacheReadCount; } }
        public UInt32 CacheIoCount { get { return _systemPerformanceInformation.CacheIoCount; } }
        public UInt32 DirtyPagesWriteCount { get { return _systemPerformanceInformation.DirtyPagesWriteCount; } }
        public UInt32 DirtyWriteIoCount { get { return _systemPerformanceInformation.DirtyWriteIoCount; } }
        public UInt32 MappedPagesWriteCount { get { return _systemPerformanceInformation.MappedPagesWriteCount; } }
        public UInt32 MappedWriteIoCount { get { return _systemPerformanceInformation.MappedWriteIoCount; } }
        public UInt32 PagedPoolPages { get { return _systemPerformanceInformation.PagedPoolPages; } }
        public UInt32 NonPagedPoolPages { get { return _systemPerformanceInformation.NonPagedPoolPages; } }
        public UInt32 PagedPoolAllocs { get { return _systemPerformanceInformation.PagedPoolAllocs; } }
        public UInt32 PagedPoolFrees { get { return _systemPerformanceInformation.PagedPoolFrees; } }
        public UInt32 NonPagedPoolAllocs { get { return _systemPerformanceInformation.NonPagedPoolAllocs; } }
        public UInt32 NonPagedPoolFrees { get { return _systemPerformanceInformation.NonPagedPoolFrees; } }
        public UInt32 FreeSystemPtes { get { return _systemPerformanceInformation.FreeSystemPtes; } }
        public UInt32 ResidentSystemCodePage { get { return _systemPerformanceInformation.ResidentSystemCodePage; } }
        public UInt32 TotalSystemDriverPages { get { return _systemPerformanceInformation.TotalSystemDriverPages; } }
        public UInt32 TotalSystemCodePages { get { return _systemPerformanceInformation.TotalSystemCodePages; } }
        public UInt32 NonPagedPoolLookasideHits { get { return _systemPerformanceInformation.NonPagedPoolLookasideHits; } }
        public UInt32 PagedPoolLookasideHits { get { return _systemPerformanceInformation.PagedPoolLookasideHits; } }
        public UInt32 AvailablePagedPoolPages { get { return _systemPerformanceInformation.AvailablePagedPoolPages; } }
        public UInt32 ResidentSystemCachePage { get { return _systemPerformanceInformation.ResidentSystemCachePage; } }
        public UInt32 ResidentPagedPoolPage { get { return _systemPerformanceInformation.ResidentPagedPoolPage; } }
        public UInt32 ResidentSystemDriverPage { get { return _systemPerformanceInformation.ResidentSystemDriverPage; } }
        public UInt32 CcFastReadNoWait { get { return _systemPerformanceInformation.CcFastReadNoWait; } }
        public UInt32 CcFastReadWait { get { return _systemPerformanceInformation.CcFastReadWait; } }
        public UInt32 CcFastReadResourceMiss { get { return _systemPerformanceInformation.CcFastReadResourceMiss; } }
        public UInt32 CcFastReadNotPossible { get { return _systemPerformanceInformation.CcFastReadNotPossible; } }
        public UInt32 CcFastMdlReadNoWait { get { return _systemPerformanceInformation.CcFastMdlReadNoWait; } }
        public UInt32 CcFastMdlReadWait { get { return _systemPerformanceInformation.CcFastMdlReadWait; } }
        public UInt32 CcFastMdlReadResourceMiss { get { return _systemPerformanceInformation.CcFastMdlReadResourceMiss; } }
        public UInt32 CcFastMdlReadNotPossible { get { return _systemPerformanceInformation.CcFastMdlReadNotPossible; } }
        public UInt32 CcMapDataNoWait { get { return _systemPerformanceInformation.CcMapDataNoWait; } }
        public UInt32 CcMapDataWait { get { return _systemPerformanceInformation.CcMapDataWait; } }
        public UInt32 CcMapDataNoWaitMiss { get { return _systemPerformanceInformation.CcMapDataNoWaitMiss; } }
        public UInt32 CcMapDataWaitMiss { get { return _systemPerformanceInformation.CcMapDataWaitMiss; } }
        public UInt32 CcPinMappedDataCount { get { return _systemPerformanceInformation.CcPinMappedDataCount; } }
        public UInt32 CcPinReadNoWait { get { return _systemPerformanceInformation.CcPinReadNoWait; } }
        public UInt32 CcPinReadWait { get { return _systemPerformanceInformation.CcPinReadWait; } }
        public UInt32 CcPinReadNoWaitMiss { get { return _systemPerformanceInformation.CcPinReadNoWaitMiss; } }
        public UInt32 CcPinReadWaitMiss { get { return _systemPerformanceInformation.CcPinReadWaitMiss; } }
        public UInt32 CcCopyReadNoWait { get { return _systemPerformanceInformation.CcCopyReadNoWait; } }
        public UInt32 CcCopyReadWait { get { return _systemPerformanceInformation.CcCopyReadWait; } }
        public UInt32 CcCopyReadNoWaitMiss { get { return _systemPerformanceInformation.CcCopyReadNoWaitMiss; } }
        public UInt32 CcCopyReadWaitMiss { get { return _systemPerformanceInformation.CcCopyReadWaitMiss; } }
        public UInt32 CcMdlReadNoWait { get { return _systemPerformanceInformation.CcMdlReadNoWait; } }
        public UInt32 CcMdlReadWait { get { return _systemPerformanceInformation.CcMdlReadWait; } }
        public UInt32 CcMdlReadNoWaitMiss { get { return _systemPerformanceInformation.CcMdlReadNoWaitMiss; } }
        public UInt32 CcMdlReadWaitMiss { get { return _systemPerformanceInformation.CcMdlReadWaitMiss; } }
        public UInt32 CcReadAheadIos { get { return _systemPerformanceInformation.CcReadAheadIos; } }
        public UInt32 CcLazyWriteIos { get { return _systemPerformanceInformation.CcLazyWriteIos; } }
        public UInt32 CcLazyWritePages { get { return _systemPerformanceInformation.CcLazyWritePages; } }
        public UInt32 CcDataFlushes { get { return _systemPerformanceInformation.CcDataFlushes; } }
        public UInt32 CcDataPages { get { return _systemPerformanceInformation.CcDataFlushes; } }
        public UInt32 ContextSwitches { get { return _systemPerformanceInformation.ContextSwitches; } }
        public UInt32 FirstLevelTbFills { get { return _systemPerformanceInformation.FirstLevelTbFills; } }
        public UInt32 SecondLevelTbFills { get { return _systemPerformanceInformation.SecondLevelTbFills; } }
        public UInt32 SystemCalls { get { return _systemPerformanceInformation.SystemCalls; } }

        public UInt64 CcTotalDirtyPages { get { return _systemPerformanceInformation.CcTotalDirtyPages; } }
        public UInt64 CcDirtyPageThreshold { get { return _systemPerformanceInformation.CcDirtyPageThreshold; } }

        public Int64 ResidentAvailablePages { get { return _systemPerformanceInformation.ResidentAvailablePages; } } //LONG64
        public UInt64 SharedCommittedPages { get { return _systemPerformanceInformation.SharedCommittedPages; } }
    }
}
