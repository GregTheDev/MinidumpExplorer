using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// The thread names stream in a minidump, containing information about each thread's name/description (if available).
    /// </summary>
    public class MiniDumpThreadNamesStream
    {
        private MINIDUMP_THREAD_NAME_LIST _threadNamesList;
        private List<MiniDumpThreadName> _threadNameEntries;

        internal MiniDumpThreadNamesStream()
        {
            _threadNamesList = new MINIDUMP_THREAD_NAME_LIST();
            _threadNameEntries = new List<MiniDumpThreadName>();
        }

        internal MiniDumpThreadNamesStream(MINIDUMP_THREAD_NAME_LIST threadNamesList, MINIDUMP_THREAD_NAME[] threadNameEntries, MiniDumpFile owner)
        {
            _threadNamesList = threadNamesList;
            _threadNameEntries = new List<MiniDumpThreadName>(threadNameEntries.Select(x => new MiniDumpThreadName(x, owner)));
        }

        public IReadOnlyCollection<MiniDumpThreadName> Entries => _threadNameEntries;
    }
}
