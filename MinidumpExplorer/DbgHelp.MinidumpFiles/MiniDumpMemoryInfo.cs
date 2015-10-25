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
    /// Describes a region of memory.
    /// </summary>
    public class MiniDumpMemoryInfo
    {
        private MINIDUMP_MEMORY_INFO _memoryInfo;

        internal MiniDumpMemoryInfo(MINIDUMP_MEMORY_INFO memoryInfo)
        {
            _memoryInfo = memoryInfo;
        }

        /// <summary>
        /// The base address of the region of pages.
        /// </summary>
        public UInt64 BaseAddress { get { return this._memoryInfo.BaseAddress; } }

        /// <summary>
        /// The base address of a range of pages in this region. The page is contained within this memory region.
        /// </summary>
        public UInt64 AllocationBase { get { return this._memoryInfo.AllocationBase; } }

        /// <summary>
        /// The memory protection when the region was initially allocated. This member can be one of the memory protection options, along with PAGE_GUARD or PAGE_NOCACHE, as needed.
        /// </summary>
        public MemoryProtection AllocationProtect { get { return (MemoryProtection)this._memoryInfo.AllocationProtect; } }

        /// <summary>
        /// The size of the region beginning at the base address in which all pages have identical attributes, in bytes.
        /// </summary>
        public UInt64 RegionSize { get { return this._memoryInfo.RegionSize; } }

        /// <summary>
        /// The size of the region (formatted for user friendly display) beginning at the base address in which all pages have identical attributes, in bytes.
        /// </summary>
        public string RegionSizePretty
        {
            get
            {
                string[] sizes = { "B", "KB", "MB", "GB" };
                double len = this.RegionSize;
                int order = 0;
                while (len >= 1024 && order + 1 < sizes.Length)
                {
                    order++;
                    len = len / 1024;
                }

                return String.Format("{0:0.#} {1}", len, sizes[order]);
            }
        }

        /// <summary>
        /// The state of the pages in the region.
        /// </summary>
        public MemoryState State { get { return (MemoryState)this._memoryInfo.State; } }

        /// <summary>
        /// The access protection of the pages in the region. This member is one of the values listed for the AllocationProtect member.
        /// </summary>
        public MemoryProtection Protect { get { return (MemoryProtection)this._memoryInfo.Protect; } }

        /// <summary>
        /// The type of pages in the region. The following types are defined.
        /// </summary>
        public MemoryType Type { get { return (MemoryType)this._memoryInfo.Type; } }
    }

    /// <summary>
    /// Memory-protection options.
    /// </summary>
    [Flags]
    public enum MemoryProtection
    {
        /// <summary>
        /// Enables execute access to the committed region of pages. An attempt to read from or write to the committed region results in an access violation.
        /// </summary>
        PAGE_EXECUTE = 0x10,
        /// <summary>
        /// Enables execute or read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation.
        /// </summary>
        PAGE_EXECUTE_READ = 0x20,
        /// <summary>
        /// Enables execute, read-only, or read/write access to the committed region of pages.
        /// </summary>
        PAGE_EXECUTE_READWRITE = 0x40,
        /// <summary>
        /// Enables execute, read-only, or copy-on-write access to a mapped view of a file mapping object.
        /// </summary>
        PAGE_EXECUTE_WRITECOPY = 0x80,
        /// <summary>
        /// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation.
        /// </summary>
        PAGE_NOACCESS = 0x01,
        /// <summary>
        /// Enables read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation. If Data Execution Prevention is enabled, an attempt to execute code in the committed region results in an access violation.
        /// </summary>
        PAGE_READONLY = 0x02,
        /// <summary>
        /// Enables read-only or read/write access to the committed region of pages. If Data Execution Prevention is enabled, attempting to execute code in the committed region results in an access violation.
        /// </summary>
        PAGE_READWRITE = 0x04,
        /// <summary>
        /// Enables read-only or copy-on-write access to a mapped view of a file mapping object. An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process.
        /// </summary>
        PAGE_WRITECOPY = 0x08,

        /// <summary>
        /// Pages in the region become guard pages. Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and turn off the guard page status.
        /// </summary>
        PAGE_GUARD = 0x100,
        /// <summary>
        /// Sets all pages to be non-cachable. Applications should not use this attribute except when explicitly required for a device.
        /// </summary>
        PAGE_NOCACHE = 0x200,
        /// <summary>
        /// Sets all pages to be write-combined. Applications should not use this attribute except when explicitly required for a device.
        /// </summary>
        PAGE_WRITECOMBINE = 0x400
    }

    /// <summary>
    /// The state of the pages in the region.
    /// </summary>
    public enum MemoryState
    {
        /// <summary>
        /// Indicates committed pages for which physical storage has been allocated, either in memory or in the paging file on disk.
        /// </summary>
        MEM_COMMIT = 0x1000,
        /// <summary>
        /// Indicates free pages not accessible to the calling process and available to be allocated.
        /// </summary>
        MEM_FREE = 0x10000,
        /// <summary>
        /// Indicates reserved pages where a range of the process's virtual address space is reserved without any physical storage being allocated.
        /// </summary>
        MEM_RESERVE = 0x2000
    }

    /// <summary>
    /// The type of pages in the region.
    /// </summary>
    public enum MemoryType
    {
        /// <summary>
        /// Indicates that the memory pages within the region are mapped into the view of an image section.
        /// </summary>
        MEM_IMAGE = 0x1000000,
        /// <summary>
        /// Indicates that the memory pages within the region are mapped into the view of a section.
        /// </summary>
        MEM_MAPPED = 0x40000,
        /// <summary>
        /// Indicates that the memory pages within the region are private (that is, not shared by other processes).
        /// </summary>
        MEM_PRIVATE = 0x20000
    }
}
