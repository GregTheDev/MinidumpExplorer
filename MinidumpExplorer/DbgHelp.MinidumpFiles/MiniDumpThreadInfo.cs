using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains thread state information.
    /// </summary>
    public class MiniDumpThreadInfo
    {
        private MINIDUMP_THREAD_INFO _threadInfo;
        private TimeSpan _kernelTime;
        private TimeSpan _userTime;

        public const uint STILL_ACTIVE = windows.STILL_ACTIVE;

        internal MiniDumpThreadInfo(MINIDUMP_THREAD_INFO threadInfo)
        {
            this._threadInfo = threadInfo;

            // Kernel time is in 100-nanosecond intervals, 10 intervals = 1000 nanoseconds = 1 millisecond
            this._kernelTime = TimeSpan.FromMilliseconds(_threadInfo.KernelTime / 10 / 1000);

            // User time is in 100-nanosecond intervals, 10 intervals = 1000 nanoseconds = 1 millisecond
            this._userTime = TimeSpan.FromMilliseconds(_threadInfo.UserTime / 10 / 1000);
        }

        /// <summary>
        /// The identifier of the thread.
        /// </summary>
        public uint ThreadId { get { return _threadInfo.ThreadId; } }

        /// <summary>
        /// The flags that indicate the thread state.
        /// </summary>
        public MiniDumpThreadInfoDumpFlags DumpFlags { get { return (MiniDumpThreadInfoDumpFlags)_threadInfo.DumpFlags; } }

        /// <summary>
        /// An HRESULT value that indicates the dump status.
        /// </summary>
        public UInt32 DumpError { get { return _threadInfo.DumpError; } }

        /// <summary>
        /// The thread termination status code.
        /// </summary>
        public UInt32 ExitStatus { get { return _threadInfo.ExitStatus; } }

        /// <summary>
        /// The time when the thread was created.
        /// </summary>
        public DateTime CreateTime { get { return DateTime.FromFileTime((long)_threadInfo.CreateTime); } }

        /// <summary>
        /// The time when the thread exited (DateTime.MinValue if not applicable).
        /// </summary>
        public DateTime ExitTime { get { return (_threadInfo.ExitTime == 0) ? DateTime.MinValue : DateTime.FromFileTime((long)_threadInfo.ExitTime); } }
        
        /// <summary>
        /// The time executed in kernel mode.
        /// </summary>
        public TimeSpan KernelTime { get { return this._kernelTime; } }

        /// <summary>
        /// The time executed in user mode.
        /// </summary>
        public TimeSpan UserTime { get { return this._userTime; } }

        /// <summary>
        /// The starting address of the thread.
        /// </summary>
        public UInt64 StartAddress { get { return _threadInfo.StartAddress; } }

        /// <summary>
        /// The processor affinity mask.
        /// </summary>
        public UInt64 Affinity { get { return _threadInfo.Affinity; } }
    }

    /// <summary>
    /// The flags that indicate the thread state.
    /// </summary>
    public enum MiniDumpThreadInfoDumpFlags
    {
        /// <summary>
        /// No specific dumps flags.
        /// </summary>
        None = 0,
        /// <summary>
        /// A placeholder thread due to an error accessing the thread. No thread information exists beyond the thread identifier.
        /// </summary>
        MINIDUMP_THREAD_INFO_ERROR_THREAD = 0x00000001,
        /// <summary>
        /// The thread has exited (not running any code) at the time of the dump.
        /// </summary>
        MINIDUMP_THREAD_INFO_EXITED_THREAD = 0x00000004,
        /// <summary>
        /// Thread context could not be retrieved.
        /// </summary>
        MINIDUMP_THREAD_INFO_INVALID_CONTEXT = 0x00000010,
        /// <summary>
        /// Thread information could not be retrieved.
        /// </summary>
        MINIDUMP_THREAD_INFO_INVALID_INFO = 0x00000008,
        /// <summary>
        /// TEB information could not be retrieved.
        /// </summary>
        MINIDUMP_THREAD_INFO_INVALID_TEB = 0x00000020,
        /// <summary>
        /// This is the thread that called MiniDumpWriteDump.
        /// </summary>
        MINIDUMP_THREAD_INFO_WRITING_THREAD = 0x00000002
    }
}
