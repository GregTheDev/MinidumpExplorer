using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains a list of unloaded modules.
    /// </summary>
    public class MiniDumpUnloadedModulesStream
    {
        private MINIDUMP_UNLOADED_MODULE_LIST _unloadedModuleList;
        private List<MiniDumpUnloadedModule> _entries;

        /// <summary>
        /// Initialise a new MiniDumpUnloadedModulesStream instance with no entries.
        /// </summary>
        internal MiniDumpUnloadedModulesStream()
        {
            _unloadedModuleList = new MINIDUMP_UNLOADED_MODULE_LIST();
            _unloadedModuleList.NumberOfEntries = 0;

            _entries = new List<MiniDumpUnloadedModule>();
        }

        /// <summary>
        /// Initialise a new MiniDumpUnloadedModulesStream instance with the unloaded module information provided.
        /// </summary>
        /// <param name="unloadedModuleList">Unloaded modules minidump stream header.</param>
        /// <param name="unloadedModules">An array of the unloaded module information.</param>
        /// <param name="owner">Minidump file this stream was read from.</param>
        internal MiniDumpUnloadedModulesStream(MINIDUMP_UNLOADED_MODULE_LIST unloadedModuleList, MINIDUMP_UNLOADED_MODULE[] unloadedModules, MiniDumpFile owner)
        {
            _unloadedModuleList = unloadedModuleList;
            _entries = new List<MiniDumpUnloadedModule>(unloadedModules.Select(x => new MiniDumpUnloadedModule(x, owner)));
        }

        /// <summary>
        /// The size of the header data for the stream, in bytes.
        /// </summary>
        public UInt32 SizeOfHeader { get { return _unloadedModuleList.SizeOfHeader; } }
        /// <summary>
        /// The size of each entry following the header, in bytes.
        /// </summary>
        public UInt32 SizeOfEntry { get { return _unloadedModuleList.SizeOfEntry; } }
        /// <summary>
        /// The number of entries in the stream.
        /// </summary>
        public UInt32 NumberOfEntries { get { return _unloadedModuleList.NumberOfEntries; } }
        /// <summary>
        /// The data for the entries.
        /// </summary>
        public MiniDumpUnloadedModule[] Entries { get { return _entries.ToArray(); } }
    }
}
