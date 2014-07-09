using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains a list of memory regions.
    /// </summary>
    public class MiniDumpMemoryInfoStream
    {
        private MINIDUMP_MEMORY_INFO_LIST _memoryInfoList;
        private List<MiniDumpMemoryInfo> _memoryInfoEntries;

        internal MiniDumpMemoryInfoStream(MINIDUMP_MEMORY_INFO_LIST memoryInfoList, MINIDUMP_MEMORY_INFO[] memoryInfoEntries)
        {
            _memoryInfoList = memoryInfoList;
            _memoryInfoEntries = new List<MiniDumpMemoryInfo>(memoryInfoEntries.Select(x => new MiniDumpMemoryInfo(x)));
        }

        /// <summary>
        /// The size of the header data for the stream, in bytes.
        /// </summary>
        public uint SizeOfHeader { get { return this._memoryInfoList.SizeOfHeader; } }

        /// <summary>
        /// The size of each entry following the header, in bytes.
        /// </summary>
        public uint SizeOfEntry { get { return this._memoryInfoList.SizeOfEntry; } }

        /// <summary>
        /// The number of entries in the stream.
        /// </summary>
        public UInt64 NumberOfEntries { get { return this._memoryInfoList.NumberOfEntries; } }

        public MiniDumpMemoryInfo[] Entries { get { return _memoryInfoEntries.ToArray(); } }
    }
}
