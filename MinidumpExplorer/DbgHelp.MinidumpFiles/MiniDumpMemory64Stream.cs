using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpMemory64Stream
    {
        private UInt64 _baseRva;
        private MiniDumpMemoryDescriptor64[] _memoryRanges;

        // TODO: Create "...Stream" classes for all of the streams
        internal MiniDumpMemory64Stream()
        {
            _baseRva = 0;
            _memoryRanges = new MiniDumpMemoryDescriptor64[0];
        }

        internal MiniDumpMemory64Stream(UInt64 baseRva, MiniDumpMemoryDescriptor64[] memoryRanges)
        {
            _baseRva = baseRva;
            _memoryRanges = memoryRanges;
        }

        public UInt64 BaseRva { get { return _baseRva; } }
        public MiniDumpMemoryDescriptor64[] MemoryRanges { get { return _memoryRanges; } }
    }
}
