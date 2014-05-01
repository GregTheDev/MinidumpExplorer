using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpThread
    {
        public const uint MAXIMUM_SUSPEND_COUNT = 0x7f;

        private MINIDUMP_THREAD _thread;
        private MiniDumpMemoryDescriptor _stack;
        private MiniDumpLocationDescriptor _threadContext;

        internal MiniDumpThread(MINIDUMP_THREAD thread)
        {
            this._thread = thread;

            this._stack = new MiniDumpMemoryDescriptor(thread.Stack);
            this._threadContext = new MiniDumpLocationDescriptor(thread.ThreadContext);
        }

        public uint ThreadId
        {
            get { return _thread.ThreadId; }
        }

        public uint SuspendCount
        {
            get { return _thread.SuspendCount; }
        }

        public uint PriorityClass
        {
            get { return _thread.PriorityClass; }
        }

        public uint PriorityRaw
        {
            get { return _thread.Priority; }
        }

        public System.Diagnostics.ThreadPriorityLevel Priority
        {
            get { return (System.Diagnostics.ThreadPriorityLevel)_thread.Priority; }
        }

        public UInt64 Teb
        {
            get { return _thread.Teb; }
        }

        public MiniDumpMemoryDescriptor Stack
        {
            get { return _stack; }
        }

        public MiniDumpLocationDescriptor ThreadContext
        {
            get { return _threadContext; }
        }
    }
}
