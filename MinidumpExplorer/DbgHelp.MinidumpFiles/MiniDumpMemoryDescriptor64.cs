using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Describes a range of memory.
    /// </summary>
    /// <remarks>
    /// This class represents a MINIDUMP_MEMORY_DESCRIPTOR64 structure.
    /// </remarks>
    public class MiniDumpMemoryDescriptor64
    {
        private MINIDUMP_MEMORY_DESCRIPTOR64 _memoryDescriptor;

        internal MiniDumpMemoryDescriptor64(MINIDUMP_MEMORY_DESCRIPTOR64 memoryDescriptor)
        {
            _memoryDescriptor = memoryDescriptor;
        }

        /// <summary>
        /// The starting address of the memory range.
        /// </summary>
        public UInt64 StartOfMemoryRange { get { return _memoryDescriptor.StartOfMemoryRange; } }
        /// <summary>
        /// The starting address of the memory range formatted as a hex string e.g. 0x00ABCDEF
        /// </summary>
        public string StartOfMemoryRangeFormatted { get { return Formatters.FormatAsMemoryAddress(_memoryDescriptor.StartOfMemoryRange); } }
        /// <summary>
        /// The ending address of the memory range.
        /// </summary>
        public UInt64 EndOfMemoryRange { get { return _memoryDescriptor.StartOfMemoryRange + _memoryDescriptor.DataSize - 1; } }
        /// <summary>
        /// The ending address of the memory range formatted as a hex string e.g. 0x00ABCDEF
        /// </summary>
        public string EndOfMemoryRangeFormatted { get { return Formatters.FormatAsMemoryAddress(EndOfMemoryRange); } }
        /// <summary>
        /// The size of the memory range.
        /// </summary>
        public UInt64 DataSize { get { return _memoryDescriptor.DataSize; } }
        /// <summary>
        /// The size of the memory range formatted as a hex string.
        /// </summary>
        public string DataSizeFormatted { get { return String.Concat("0x", this.DataSize.ToString("x8")); } }
        /// <summary>
        /// The size of the memory range formatted as human friednly string e.g. "4 KB"
        /// </summary>
        public string DataSizePretty { get { return Formatters.FormatAsSizeString(DataSize); } }
        /// <summary>
        /// The size of the underlying MINIDUMP_MEMORY_DESCRIPTOR64 structure.
        /// </summary>
        public static int DescriptorSize { get { return System.Runtime.InteropServices.Marshal.SizeOf(typeof(MINIDUMP_MEMORY_DESCRIPTOR64)); } }
    }
}
