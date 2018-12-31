using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains information about a thread's name/description.
    /// </summary>
    public class MiniDumpThreadName
    {
        private MINIDUMP_THREAD_NAME _threadName;
        private MiniDumpFile _owner;

        internal MiniDumpThreadName(MINIDUMP_THREAD_NAME threadName, MiniDumpFile owner)
        {
            this._threadName = threadName;
            this._owner = owner;
        }

        public uint ThreadId => _threadName.ThreadId;
        public string Name => _owner.ReadString(_threadName.RvaOfThreadName);
    }
}
