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
    public partial class SystemMemoryInfoView : BaseViewControl
    {
        private MiniDumpSystemMemoryInfo _systemMemoryInfo;

        private const int LVG_SYSTEM_MEMORY_INFO = 0;
        private const int LVG_SYSTEM_BASIC_INFO = 1;
        private const int LVG_SYSTEM_FILE_CACHE_INFO = 2;
        private const int LVG_SYSTEM_BASIC_PERFORMANCE_INFO = 3;
        private const int LVG_SYSTEM_PERFORMANCE_INFO = 4;

        public SystemMemoryInfoView()
        {
            InitializeComponent();
        }

        public SystemMemoryInfoView(MiniDumpSystemMemoryInfo systemMemoryInfo)
            : this()
        {
            _systemMemoryInfo = systemMemoryInfo;

            AddGroupedNode("Revision", _systemMemoryInfo.Revision, LVG_SYSTEM_MEMORY_INFO);
            AddGroupedNode("Flags", _systemMemoryInfo.Flags, LVG_SYSTEM_MEMORY_INFO);

            #region System basic info
            AddGroupedNode("TimerResolution", _systemMemoryInfo.SystemBasicInformation.TimerResolution, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("PageSize", _systemMemoryInfo.SystemBasicInformation.PageSize, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("NumberOfPhysicalPages", _systemMemoryInfo.SystemBasicInformation.NumberOfPhysicalPages, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("LowestPhysicalPageNumber", _systemMemoryInfo.SystemBasicInformation.LowestPhysicalPageNumber, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("HighestPhysicalPageNumber", _systemMemoryInfo.SystemBasicInformation.HighestPhysicalPageNumber, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("AllocationGranularity", _systemMemoryInfo.SystemBasicInformation.AllocationGranularity, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("MinimumUserModeAddress", _systemMemoryInfo.SystemBasicInformation.MinimumUserModeAddress, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("MaximumUserModeAddress", _systemMemoryInfo.SystemBasicInformation.MaximumUserModeAddress, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("ActiveProcessorsAffinityMask", _systemMemoryInfo.SystemBasicInformation.ActiveProcessorsAffinityMask, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("NumberOfProcessors", _systemMemoryInfo.SystemBasicInformation.NumberOfProcessors, LVG_SYSTEM_BASIC_INFO);
            #endregion

            #region System file cache info
            AddGroupedNode("CurrentSize", _systemMemoryInfo.SystemFileCacheInformation.CurrentSize, LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("PeakSize", _systemMemoryInfo.SystemFileCacheInformation.PeakSize, LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("PageFaultCount", _systemMemoryInfo.SystemFileCacheInformation.PageFaultCount, LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("MinimumWorkingSet", _systemMemoryInfo.SystemFileCacheInformation.MinimumWorkingSet, LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("MaximumWorkingSet", _systemMemoryInfo.SystemFileCacheInformation.MaximumWorkingSet, LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("CurrentSizeIncludingTransitionInPages", _systemMemoryInfo.SystemFileCacheInformation.CurrentSizeIncludingTransitionInPages, LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("PeakSizeIncludingTransitionInPages", _systemMemoryInfo.SystemFileCacheInformation.PeakSizeIncludingTransitionInPages, LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("TransitionRePurposeCount", _systemMemoryInfo.SystemFileCacheInformation.TransitionRePurposeCount, LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("Flags", _systemMemoryInfo.SystemFileCacheInformation.Flags, LVG_SYSTEM_FILE_CACHE_INFO);
            #endregion

            #region System basic performance info
            AddGroupedNode("AvailablePages", _systemMemoryInfo.SystemBasicPerformanceInformation.AvailablePages, LVG_SYSTEM_BASIC_PERFORMANCE_INFO);
            AddGroupedNode("CommittedPages", _systemMemoryInfo.SystemBasicPerformanceInformation.CommittedPages, LVG_SYSTEM_BASIC_PERFORMANCE_INFO);
            AddGroupedNode("CommitLimit", _systemMemoryInfo.SystemBasicPerformanceInformation.CommitLimit, LVG_SYSTEM_BASIC_PERFORMANCE_INFO);
            AddGroupedNode("PeakCommitment", _systemMemoryInfo.SystemBasicPerformanceInformation.PeakCommitment, LVG_SYSTEM_BASIC_PERFORMANCE_INFO);
            #endregion

            #region System performance info
            AddGroupedNode("IdleProcessTime", _systemMemoryInfo.SystemPerformanceInformation.IdleProcessTime, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoReadTransferCount", _systemMemoryInfo.SystemPerformanceInformation.IoReadTransferCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoWriteTransferCount", _systemMemoryInfo.SystemPerformanceInformation.IoWriteTransferCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoOtherTransferCount", _systemMemoryInfo.SystemPerformanceInformation.IoOtherTransferCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoReadOperationCount", _systemMemoryInfo.SystemPerformanceInformation.IoReadOperationCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoWriteOperationCount", _systemMemoryInfo.SystemPerformanceInformation.IoWriteOperationCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoOtherOperationCount", _systemMemoryInfo.SystemPerformanceInformation.IoOtherOperationCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("AvailablePages", _systemMemoryInfo.SystemPerformanceInformation.AvailablePages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CommittedPages", _systemMemoryInfo.SystemPerformanceInformation.CommittedPages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CommitLimit", _systemMemoryInfo.SystemPerformanceInformation.CommitLimit, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PeakCommitment", _systemMemoryInfo.SystemPerformanceInformation.PeakCommitment, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PageFaultCount", _systemMemoryInfo.SystemPerformanceInformation.PageFaultCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CopyOnWriteCount", _systemMemoryInfo.SystemPerformanceInformation.CopyOnWriteCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("TransitionCount", _systemMemoryInfo.SystemPerformanceInformation.TransitionCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CacheTransitionCount", _systemMemoryInfo.SystemPerformanceInformation.CacheTransitionCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("DemandZeroCount", _systemMemoryInfo.SystemPerformanceInformation.DemandZeroCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PageReadCount", _systemMemoryInfo.SystemPerformanceInformation.PageReadCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PageReadIoCount", _systemMemoryInfo.SystemPerformanceInformation.PageReadIoCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CacheReadCount", _systemMemoryInfo.SystemPerformanceInformation.CacheReadCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CacheIoCount", _systemMemoryInfo.SystemPerformanceInformation.CacheIoCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("DirtyPagesWriteCount", _systemMemoryInfo.SystemPerformanceInformation.DirtyPagesWriteCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("DirtyWriteIoCount", _systemMemoryInfo.SystemPerformanceInformation.DirtyWriteIoCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("MappedPagesWriteCount", _systemMemoryInfo.SystemPerformanceInformation.MappedPagesWriteCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("MappedWriteIoCount", _systemMemoryInfo.SystemPerformanceInformation.MappedWriteIoCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PagedPoolPages", _systemMemoryInfo.SystemPerformanceInformation.PagedPoolPages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("NonPagedPoolPages", _systemMemoryInfo.SystemPerformanceInformation.NonPagedPoolPages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PagedPoolAllocs", _systemMemoryInfo.SystemPerformanceInformation.PagedPoolAllocs, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PagedPoolFrees", _systemMemoryInfo.SystemPerformanceInformation.PagedPoolFrees, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("NonPagedPoolAllocs", _systemMemoryInfo.SystemPerformanceInformation.NonPagedPoolAllocs, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("NonPagedPoolFrees", _systemMemoryInfo.SystemPerformanceInformation.NonPagedPoolFrees, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("FreeSystemPtes", _systemMemoryInfo.SystemPerformanceInformation.FreeSystemPtes, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ResidentSystemCodePage", _systemMemoryInfo.SystemPerformanceInformation.ResidentSystemCodePage, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("TotalSystemDriverPages", _systemMemoryInfo.SystemPerformanceInformation.TotalSystemDriverPages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("TotalSystemCodePages", _systemMemoryInfo.SystemPerformanceInformation.TotalSystemCodePages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("NonPagedPoolLookasideHits", _systemMemoryInfo.SystemPerformanceInformation.NonPagedPoolLookasideHits, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PagedPoolLookasideHits", _systemMemoryInfo.SystemPerformanceInformation.PagedPoolLookasideHits, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("AvailablePagedPoolPages", _systemMemoryInfo.SystemPerformanceInformation.AvailablePagedPoolPages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ResidentSystemCachePage", _systemMemoryInfo.SystemPerformanceInformation.ResidentSystemCachePage, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ResidentPagedPoolPage", _systemMemoryInfo.SystemPerformanceInformation.ResidentPagedPoolPage, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ResidentSystemDriverPage", _systemMemoryInfo.SystemPerformanceInformation.ResidentSystemDriverPage, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcFastReadNoWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcFastReadWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastReadResourceMiss", _systemMemoryInfo.SystemPerformanceInformation.CcFastReadResourceMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastReadNotPossible", _systemMemoryInfo.SystemPerformanceInformation.CcFastReadNotPossible, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastMdlReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcFastMdlReadNoWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastMdlReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcFastMdlReadWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastMdlReadResourceMiss", _systemMemoryInfo.SystemPerformanceInformation.CcFastMdlReadResourceMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastMdlReadNotPossible", _systemMemoryInfo.SystemPerformanceInformation.CcFastMdlReadNotPossible, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMapDataNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcMapDataNoWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMapDataWait", _systemMemoryInfo.SystemPerformanceInformation.CcMapDataWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMapDataNoWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcMapDataNoWaitMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMapDataWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcMapDataWaitMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinMappedDataCount", _systemMemoryInfo.SystemPerformanceInformation.CcPinMappedDataCount, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcPinReadNoWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcPinReadWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinReadNoWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcPinReadNoWaitMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinReadWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcPinReadWaitMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcCopyReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcCopyReadNoWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcCopyReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcCopyReadWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcCopyReadNoWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcCopyReadNoWaitMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcCopyReadWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcCopyReadWaitMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMdlReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcMdlReadNoWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMdlReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcMdlReadWait, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMdlReadNoWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcMdlReadNoWaitMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMdlReadWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcMdlReadWaitMiss, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcReadAheadIos", _systemMemoryInfo.SystemPerformanceInformation.CcReadAheadIos, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcLazyWriteIos", _systemMemoryInfo.SystemPerformanceInformation.CcLazyWriteIos, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcLazyWritePages", _systemMemoryInfo.SystemPerformanceInformation.CcLazyWritePages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcDataFlushes", _systemMemoryInfo.SystemPerformanceInformation.CcDataFlushes, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcDataPages", _systemMemoryInfo.SystemPerformanceInformation.CcDataPages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ContextSwitches", _systemMemoryInfo.SystemPerformanceInformation.ContextSwitches, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("FirstLevelTbFills", _systemMemoryInfo.SystemPerformanceInformation.FirstLevelTbFills, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("SecondLevelTbFills", _systemMemoryInfo.SystemPerformanceInformation.SecondLevelTbFills, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("SystemCalls", _systemMemoryInfo.SystemPerformanceInformation.SystemCalls, LVG_SYSTEM_PERFORMANCE_INFO);

            AddGroupedNode("CcTotalDirtyPages", _systemMemoryInfo.SystemPerformanceInformation.CcTotalDirtyPages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcDirtyPageThreshold", _systemMemoryInfo.SystemPerformanceInformation.CcDirtyPageThreshold, LVG_SYSTEM_PERFORMANCE_INFO);

            AddGroupedNode("ResidentAvailablePages", _systemMemoryInfo.SystemPerformanceInformation.ResidentAvailablePages, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("SharedCommittedPages", _systemMemoryInfo.SystemPerformanceInformation.SharedCommittedPages, LVG_SYSTEM_PERFORMANCE_INFO);
            #endregion
        }

        private void AddGroupedNode(string description, long value, int groupIndex)
        {
            AddGroupedNode(description, value, groupIndex);
        }

        private void AddGroupedNode(string description, ulong value, int groupIndex)
        {
            AddGroupedNode(description, value, groupIndex);
        }

        private void AddGroupedNode(string description, uint value, int groupIndex)
        {
            AddGroupedNode(description, value, groupIndex);
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
