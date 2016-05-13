using DbgHelp.MinidumpFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinidumpExplorer.Utilities
{
    internal class MiniDumpHelper
    {
        /// <summary>
        /// Scans the Memory64Stream looking for a single descriptor that contains a range of memory.
        /// </summary>
        /// <param name="memory64Stream">The Memory64Stream to search.</param>
        /// <param name="startAddress">Start address of the range being searched for.</param>
        /// <param name="endAddress">End address of the range being searched for.</param>
        /// <returns>The offset (relative to the start of the minidump) to start reading from if a descriptor was found, 0 otherwise.</returns>
        /// <remarks>
        /// This function searches for memory descriptors that contain the entire range of memory being searched for. If
        /// the range being searched for spans more than one descriptor then 0 will be returned.
        /// </remarks>
        public static ulong FindInclusiveMemory64Block(MiniDumpMemory64Stream memory64Stream, ulong startAddress, ulong endAddress)
        {
            ulong offsetToReadFrom = memory64Stream.BaseRva;
            ulong descriptorSize = (ulong)MiniDumpMemoryDescriptor64.DescriptorSize;
            bool matchFound = false;

            foreach (var memoryDescriptor in memory64Stream.MemoryRanges)
            {
                if ((startAddress >= memoryDescriptor.StartOfMemoryRange) && (endAddress <= memoryDescriptor.EndOfMemoryRange))
                {
                    // This can be used later for memory ranges that span more than one descriptor.
                    //if (endOfSearchedForBlock > memoryDescriptor.EndOfMemoryRange)
                    //{
                    //    System.Diagnostics.Debug.Fail($"Found descriptor for {memoryDescriptor.DataSize} bytes starting at {memoryDescriptor.StartOfMemoryRange}, but needed {selectedMemoryBlock.RegionSize} bytes.");
                    //}

                    offsetToReadFrom += (startAddress - memoryDescriptor.StartOfMemoryRange);

                    matchFound = true;
                    break;
                }

                offsetToReadFrom += descriptorSize;
            }

            if (matchFound)
                return offsetToReadFrom;
            else
                return 0;
        }
    }
}
