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

            if (_systemMemoryInfo ==  null)
            {
                AddGroupedNode("Stream not found", _systemMemoryInfo.Revision, LVG_SYSTEM_MEMORY_INFO);
            }

            AddGroupedNode("Revision", _systemMemoryInfo.Revision, LVG_SYSTEM_MEMORY_INFO);
            AddGroupedNode("Flags", Formatters.FormatAsHex(_systemMemoryInfo.Flags), LVG_SYSTEM_MEMORY_INFO);

            // Unofficial field descriptions
            // http://masm32.com/board/index.php?topic=3402.0

            #region System basic info
            AddGroupedNode("TimerResolution", _systemMemoryInfo.SystemBasicInformation.TimerResolution, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("PageSize", _systemMemoryInfo.SystemBasicInformation.PageSize, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("NumberOfPhysicalPages", _systemMemoryInfo.SystemBasicInformation.NumberOfPhysicalPages.ToString("N0"), LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("LowestPhysicalPageNumber", _systemMemoryInfo.SystemBasicInformation.LowestPhysicalPageNumber.ToString("N0"), LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("HighestPhysicalPageNumber", _systemMemoryInfo.SystemBasicInformation.HighestPhysicalPageNumber.ToString("N0"), LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("AllocationGranularity", _systemMemoryInfo.SystemBasicInformation.AllocationGranularity, LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("MinimumUserModeAddress", Formatters.FormatAsMemoryAddress(_systemMemoryInfo.SystemBasicInformation.MinimumUserModeAddress), LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("MaximumUserModeAddress", Formatters.FormatAsMemoryAddress(_systemMemoryInfo.SystemBasicInformation.MaximumUserModeAddress), LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("ActiveProcessorsAffinityMask", Formatters.FormatAsHex(_systemMemoryInfo.SystemBasicInformation.ActiveProcessorsAffinityMask), LVG_SYSTEM_BASIC_INFO);
            AddGroupedNode("NumberOfProcessors", _systemMemoryInfo.SystemBasicInformation.NumberOfProcessors, LVG_SYSTEM_BASIC_INFO);
            #endregion

            #region System file cache info
            string tempDisplayValue = String.Format("{0} ({1:N0} bytes)", Formatters.FormatAsSizeString(_systemMemoryInfo.SystemFileCacheInformation.CurrentSize), _systemMemoryInfo.SystemFileCacheInformation.CurrentSize);
            AddGroupedNode("CurrentSize", tempDisplayValue, LVG_SYSTEM_FILE_CACHE_INFO);

            tempDisplayValue = String.Format("{0} ({1:N0} bytes)", Formatters.FormatAsSizeString(_systemMemoryInfo.SystemFileCacheInformation.PeakSize), _systemMemoryInfo.SystemFileCacheInformation.PeakSize);
            AddGroupedNode("PeakSize", tempDisplayValue, LVG_SYSTEM_FILE_CACHE_INFO);

            AddGroupedNode("PageFaultCount", _systemMemoryInfo.SystemFileCacheInformation.PageFaultCount.ToString("N0"), LVG_SYSTEM_FILE_CACHE_INFO);

            tempDisplayValue = String.Format("{0} ({1:N0} bytes)", Formatters.FormatAsSizeString(_systemMemoryInfo.SystemFileCacheInformation.MinimumWorkingSet), _systemMemoryInfo.SystemFileCacheInformation.MinimumWorkingSet);
            AddGroupedNode("MinimumWorkingSet", tempDisplayValue, LVG_SYSTEM_FILE_CACHE_INFO);

            tempDisplayValue = String.Format("{0} ({1:N0} bytes)", Formatters.FormatAsSizeString(_systemMemoryInfo.SystemFileCacheInformation.MaximumWorkingSet), _systemMemoryInfo.SystemFileCacheInformation.MaximumWorkingSet);
            AddGroupedNode("MaximumWorkingSet", tempDisplayValue, LVG_SYSTEM_FILE_CACHE_INFO);

            tempDisplayValue = String.Format("{0} ({1:N0} bytes)", Formatters.FormatAsSizeString(_systemMemoryInfo.SystemFileCacheInformation.CurrentSizeIncludingTransitionInPages), _systemMemoryInfo.SystemFileCacheInformation.CurrentSizeIncludingTransitionInPages);
            AddGroupedNode("CurrentSizeIncludingTransitionInPages", tempDisplayValue, LVG_SYSTEM_FILE_CACHE_INFO);

            tempDisplayValue = String.Format("{0} ({1:N0} bytes)", Formatters.FormatAsSizeString(_systemMemoryInfo.SystemFileCacheInformation.PeakSizeIncludingTransitionInPages), _systemMemoryInfo.SystemFileCacheInformation.PeakSizeIncludingTransitionInPages);
            AddGroupedNode("PeakSizeIncludingTransitionInPages", tempDisplayValue, LVG_SYSTEM_FILE_CACHE_INFO);

            AddGroupedNode("TransitionRePurposeCount", _systemMemoryInfo.SystemFileCacheInformation.TransitionRePurposeCount.ToString("N0"), LVG_SYSTEM_FILE_CACHE_INFO);
            AddGroupedNode("Flags", Formatters.FormatAsHex(_systemMemoryInfo.SystemFileCacheInformation.Flags), LVG_SYSTEM_FILE_CACHE_INFO);
            #endregion

            #region System basic performance info
            AddGroupedNode("AvailablePages", _systemMemoryInfo.SystemBasicPerformanceInformation.AvailablePages.ToString("N0"), LVG_SYSTEM_BASIC_PERFORMANCE_INFO);
            AddGroupedNode("CommittedPages", _systemMemoryInfo.SystemBasicPerformanceInformation.CommittedPages.ToString("N0"), LVG_SYSTEM_BASIC_PERFORMANCE_INFO);
            AddGroupedNode("CommitLimit", _systemMemoryInfo.SystemBasicPerformanceInformation.CommitLimit.ToString("N0"), LVG_SYSTEM_BASIC_PERFORMANCE_INFO);
            AddGroupedNode("PeakCommitment", _systemMemoryInfo.SystemBasicPerformanceInformation.PeakCommitment.ToString("N0"), LVG_SYSTEM_BASIC_PERFORMANCE_INFO);
            #endregion

            #region System performance info
            AddGroupedNode("IdleProcessTime", _systemMemoryInfo.SystemPerformanceInformation.IdleProcessTime, LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoReadTransferCount", _systemMemoryInfo.SystemPerformanceInformation.IoReadTransferCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoWriteTransferCount", _systemMemoryInfo.SystemPerformanceInformation.IoWriteTransferCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoOtherTransferCount", _systemMemoryInfo.SystemPerformanceInformation.IoOtherTransferCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoReadOperationCount", _systemMemoryInfo.SystemPerformanceInformation.IoReadOperationCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoWriteOperationCount", _systemMemoryInfo.SystemPerformanceInformation.IoWriteOperationCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("IoOtherOperationCount", _systemMemoryInfo.SystemPerformanceInformation.IoOtherOperationCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("AvailablePages", _systemMemoryInfo.SystemPerformanceInformation.AvailablePages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CommittedPages", _systemMemoryInfo.SystemPerformanceInformation.CommittedPages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CommitLimit", _systemMemoryInfo.SystemPerformanceInformation.CommitLimit.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PeakCommitment", _systemMemoryInfo.SystemPerformanceInformation.PeakCommitment.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PageFaultCount", _systemMemoryInfo.SystemPerformanceInformation.PageFaultCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CopyOnWriteCount", _systemMemoryInfo.SystemPerformanceInformation.CopyOnWriteCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("TransitionCount", _systemMemoryInfo.SystemPerformanceInformation.TransitionCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CacheTransitionCount", _systemMemoryInfo.SystemPerformanceInformation.CacheTransitionCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("DemandZeroCount", _systemMemoryInfo.SystemPerformanceInformation.DemandZeroCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PageReadCount", _systemMemoryInfo.SystemPerformanceInformation.PageReadCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PageReadIoCount", _systemMemoryInfo.SystemPerformanceInformation.PageReadIoCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CacheReadCount", _systemMemoryInfo.SystemPerformanceInformation.CacheReadCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CacheIoCount", _systemMemoryInfo.SystemPerformanceInformation.CacheIoCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("DirtyPagesWriteCount", _systemMemoryInfo.SystemPerformanceInformation.DirtyPagesWriteCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("DirtyWriteIoCount", _systemMemoryInfo.SystemPerformanceInformation.DirtyWriteIoCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("MappedPagesWriteCount", _systemMemoryInfo.SystemPerformanceInformation.MappedPagesWriteCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("MappedWriteIoCount", _systemMemoryInfo.SystemPerformanceInformation.MappedWriteIoCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PagedPoolPages", _systemMemoryInfo.SystemPerformanceInformation.PagedPoolPages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("NonPagedPoolPages", _systemMemoryInfo.SystemPerformanceInformation.NonPagedPoolPages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PagedPoolAllocs", _systemMemoryInfo.SystemPerformanceInformation.PagedPoolAllocs.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PagedPoolFrees", _systemMemoryInfo.SystemPerformanceInformation.PagedPoolFrees.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("NonPagedPoolAllocs", _systemMemoryInfo.SystemPerformanceInformation.NonPagedPoolAllocs.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("NonPagedPoolFrees", _systemMemoryInfo.SystemPerformanceInformation.NonPagedPoolFrees.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("FreeSystemPtes", _systemMemoryInfo.SystemPerformanceInformation.FreeSystemPtes.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ResidentSystemCodePage", _systemMemoryInfo.SystemPerformanceInformation.ResidentSystemCodePage.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("TotalSystemDriverPages", _systemMemoryInfo.SystemPerformanceInformation.TotalSystemDriverPages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("TotalSystemCodePages", _systemMemoryInfo.SystemPerformanceInformation.TotalSystemCodePages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("NonPagedPoolLookasideHits", _systemMemoryInfo.SystemPerformanceInformation.NonPagedPoolLookasideHits.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("PagedPoolLookasideHits", _systemMemoryInfo.SystemPerformanceInformation.PagedPoolLookasideHits.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("AvailablePagedPoolPages", _systemMemoryInfo.SystemPerformanceInformation.AvailablePagedPoolPages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ResidentSystemCachePage", _systemMemoryInfo.SystemPerformanceInformation.ResidentSystemCachePage.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ResidentPagedPoolPage", _systemMemoryInfo.SystemPerformanceInformation.ResidentPagedPoolPage.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ResidentSystemDriverPage", _systemMemoryInfo.SystemPerformanceInformation.ResidentSystemDriverPage.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcFastReadNoWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcFastReadWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastReadResourceMiss", _systemMemoryInfo.SystemPerformanceInformation.CcFastReadResourceMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastReadNotPossible", _systemMemoryInfo.SystemPerformanceInformation.CcFastReadNotPossible.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastMdlReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcFastMdlReadNoWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastMdlReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcFastMdlReadWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastMdlReadResourceMiss", _systemMemoryInfo.SystemPerformanceInformation.CcFastMdlReadResourceMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcFastMdlReadNotPossible", _systemMemoryInfo.SystemPerformanceInformation.CcFastMdlReadNotPossible.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMapDataNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcMapDataNoWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMapDataWait", _systemMemoryInfo.SystemPerformanceInformation.CcMapDataWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMapDataNoWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcMapDataNoWaitMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMapDataWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcMapDataWaitMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinMappedDataCount", _systemMemoryInfo.SystemPerformanceInformation.CcPinMappedDataCount.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcPinReadNoWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcPinReadWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinReadNoWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcPinReadNoWaitMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcPinReadWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcPinReadWaitMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcCopyReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcCopyReadNoWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcCopyReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcCopyReadWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcCopyReadNoWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcCopyReadNoWaitMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcCopyReadWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcCopyReadWaitMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMdlReadNoWait", _systemMemoryInfo.SystemPerformanceInformation.CcMdlReadNoWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMdlReadWait", _systemMemoryInfo.SystemPerformanceInformation.CcMdlReadWait.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMdlReadNoWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcMdlReadNoWaitMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcMdlReadWaitMiss", _systemMemoryInfo.SystemPerformanceInformation.CcMdlReadWaitMiss.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcReadAheadIos", _systemMemoryInfo.SystemPerformanceInformation.CcReadAheadIos.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcLazyWriteIos", _systemMemoryInfo.SystemPerformanceInformation.CcLazyWriteIos.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcLazyWritePages", _systemMemoryInfo.SystemPerformanceInformation.CcLazyWritePages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcDataFlushes", _systemMemoryInfo.SystemPerformanceInformation.CcDataFlushes.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcDataPages", _systemMemoryInfo.SystemPerformanceInformation.CcDataPages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("ContextSwitches", _systemMemoryInfo.SystemPerformanceInformation.ContextSwitches.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("FirstLevelTbFills", _systemMemoryInfo.SystemPerformanceInformation.FirstLevelTbFills.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("SecondLevelTbFills", _systemMemoryInfo.SystemPerformanceInformation.SecondLevelTbFills.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("SystemCalls", _systemMemoryInfo.SystemPerformanceInformation.SystemCalls.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);

            AddGroupedNode("CcTotalDirtyPages", _systemMemoryInfo.SystemPerformanceInformation.CcTotalDirtyPages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("CcDirtyPageThreshold", _systemMemoryInfo.SystemPerformanceInformation.CcDirtyPageThreshold.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);

            AddGroupedNode("ResidentAvailablePages", _systemMemoryInfo.SystemPerformanceInformation.ResidentAvailablePages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            AddGroupedNode("SharedCommittedPages", _systemMemoryInfo.SystemPerformanceInformation.SharedCommittedPages.ToString("N0"), LVG_SYSTEM_PERFORMANCE_INFO);
            #endregion
        }

        private void AddGroupedNode(string description, ulong value, int groupIndex)
        {
            AddGroupedNode(description, value.ToString(), groupIndex);
        }

        private void AddGroupedNode(string description, uint value, int groupIndex)
        {
            AddGroupedNode(description, value.ToString(), groupIndex);
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
