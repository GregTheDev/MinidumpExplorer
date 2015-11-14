using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpMemoryDescriptor64
    {
        private MINIDUMP_MEMORY_DESCRIPTOR64 _memoryDescriptor;

        internal MiniDumpMemoryDescriptor64(MINIDUMP_MEMORY_DESCRIPTOR64 memoryDescriptor)
        {
            _memoryDescriptor = memoryDescriptor;
        }

        public UInt64 StartOfMemoryRange { get { return _memoryDescriptor.StartOfMemoryRange; } }
        public string StartOfMemoryRangeFormatted { get { return String.Concat("0x", _memoryDescriptor.StartOfMemoryRange.ToString("x8")); } }
        public UInt64 EndOfMemoryRange { get { return _memoryDescriptor.StartOfMemoryRange + _memoryDescriptor.DataSize - 1; } }
        public string EndOfMemoryRangeFormatted { get { return String.Concat("0x", EndOfMemoryRange.ToString("x8")); } }
        public UInt64 DataSize { get { return _memoryDescriptor.DataSize; } }
        public string DataSizeFormatted { get { return String.Concat("0x", this.DataSize.ToString("x8")); } }
        public string DataSizePretty
        {
            get
            {
                string[] sizes = { "B", "KB", "MB", "GB" };
                double len = this.DataSize;
                int order = 0;
                while (len >= 1024 && order + 1 < sizes.Length)
                {
                    order++;
                    len = len / 1024;
                }

                return String.Format("{0:0.#} {1}", len, sizes[order]);
            }
        }
    }
}
