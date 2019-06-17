using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpMemoryDescriptor
    {
        private MINIDUMP_MEMORY_DESCRIPTOR _memoryDescriptor;
        private MiniDumpLocationDescriptor _locationDescriptor;

        internal MiniDumpMemoryDescriptor(MINIDUMP_MEMORY_DESCRIPTOR memoryDescriptor)
        {
            _memoryDescriptor = memoryDescriptor;
            _locationDescriptor = new MiniDumpLocationDescriptor(_memoryDescriptor.Memory);
        }

        public UInt64 StartOfMemoryRange { get { return _memoryDescriptor.StartOfMemoryRange; } }
        public string StartOfMemoryRangeFormatted { get { return String.Concat("0x", _memoryDescriptor.StartOfMemoryRange.ToString("x8")); } }
        public UInt64 EndOfMemoryRange { get { return _memoryDescriptor.StartOfMemoryRange + _memoryDescriptor.Memory.DataSize - 1; } }
        public string EndOfMemoryRangeFormatted { get { return String.Concat("0x", EndOfMemoryRange.ToString("x8")); } }

        public MiniDumpLocationDescriptor Memory { get { return _locationDescriptor; } }
    }
}
