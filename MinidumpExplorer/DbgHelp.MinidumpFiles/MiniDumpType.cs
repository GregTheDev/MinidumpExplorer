using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Identifies the type of information that will be written to the minidump file by the MiniDumpWriteDump function.
    /// </summary>
    [Flags]
    public enum MiniDumpType
    {
        /// <summary>
        /// Include just the information necessary to capture stack traces for all existing threads in a process.
        /// </summary>
        MiniDumpNormal = 0x00000000,
        /// <summary>
        /// Include the data sections from all loaded modules. This results in the inclusion of global variables, which can make the minidump file significantly larger.
        /// </summary>
        MiniDumpWithDataSegs = 0x00000001,
        /// <summary>
        /// Include all accessible memory in the process. The raw memory data is included at the end, so that the initial structures can be mapped directly without the raw memory information. This option can result in a very large file.
        /// </summary>
        MiniDumpWithFullMemory = 0x00000002,
        /// <summary>
        /// Include high-level information about the operating system handles that are active when the minidump is made.
        /// </summary>
        MiniDumpWithHandleData = 0x00000004,
        /// <summary>
        /// Stack and backing store memory written to the minidump file should be filtered to remove all but the pointer values necessary to reconstruct a stack trace.
        /// </summary>
        MiniDumpFilterMemory = 0x00000008,
        /// <summary>
        /// Stack and backing store memory should be scanned for pointer references to modules in the module list. 
        /// </summary>
        MiniDumpScanMemory = 0x00000010,
        /// <summary>
        /// Include information from the list of modules that were recently unloaded, if this information is maintained by the operating system. 
        /// </summary>
        /// <remarks>
        /// Windows Server 2003 and Windows XP:  The operating system does not maintain information for unloaded modules until Windows Server 2003 with SP1 and Windows XP with SP2.
        /// DbgHelp 5.1:  This value is not supported.
        /// </remarks>
        MiniDumpWithUnloadedModules = 0x00000020,
        /// <summary>
        /// Include pages with data referenced by locals or other stack memory. This option can increase the size of the minidump file significantly. 
        /// </summary>
        /// <remarks>DbgHelp 5.1:  This value is not supported.</remarks>
        MiniDumpWithIndirectlyReferencedMemory = 0x00000040,
        /// <summary>
        /// Filter module paths for information such as user names or important directories. This option may prevent the system from locating the image file and should be used only in special situations. 
        /// </summary>
        /// <remarks>DbgHelp 5.1:  This value is not supported.</remarks>
        MiniDumpFilterModulePaths = 0x00000080,
        /// <summary>
        /// Include complete per-process and per-thread information from the operating system. 
        /// </summary>
        /// <remarks>DbgHelp 5.1:  This value is not supported.</remarks>
        MiniDumpWithProcessThreadData = 0x00000100,
        /// <summary>
        /// Scan the virtual address space for PAGE_READWRITE memory to be included. 
        /// </summary>
        /// <remarks>DbgHelp 5.1:  This value is not supported.</remarks>
        MiniDumpWithPrivateReadWriteMemory = 0x00000200,
        /// <summary>
        /// Reduce the data that is dumped by eliminating memory regions that are not essential to meet criteria specified for the dump. This can avoid dumping memory that may contain data that is private to the user. However, it is not a guarantee that no private information will be present. 
        /// </summary>
        /// <remarks>DbgHelp 6.1 and earlier:  This value is not supported.</remarks>
        MiniDumpWithoutOptionalData = 0x00000400,
        /// <summary>
        /// Include memory region information. 
        /// </summary>
        /// <remarks>DbgHelp 6.1 and earlier:  This value is not supported.</remarks>
        MiniDumpWithFullMemoryInfo = 0x00000800,
        /// <summary>
        /// Include thread state information. 
        /// </summary>
        /// <remarks>DbgHelp 6.1 and earlier:  This value is not supported.</remarks>
        MiniDumpWithThreadInfo = 0x00001000,
        /// <summary>
        /// Include all code and code-related sections from loaded modules to capture executable content.
        /// </summary>
        /// <remarks>DbgHelp 6.1 and earlier:  This value is not supported.</remarks>
        MiniDumpWithCodeSegs = 0x00002000,
        /// <summary>
        /// Turns off secondary auxiliary-supported memory gathering.
        /// </summary>
        MiniDumpWithoutAuxiliaryState = 0x00004000,
        /// <summary>
        /// Requests that auxiliary data providers include their state in the dump image; the state data that is included is provider dependent. This option can result in a large dump image.
        /// </summary>
        MiniDumpWithFullAuxiliaryState = 0x00008000,
        /// <summary>
        /// Scans the virtual address space for PAGE_WRITECOPY memory to be included. 
        /// </summary>
        /// <remarks>Prior to DbgHelp 6.1:  This value is not supported.</remarks>
        MiniDumpWithPrivateWriteCopyMemory = 0x00010000,
        /// <summary>
        /// If you specify MiniDumpWithFullMemory, the MiniDumpWriteDump function will fail if the function cannot read the memory regions; however, if you include MiniDumpIgnoreInaccessibleMemory, the MiniDumpWriteDump function will ignore the memory read failures and continue to generate the dump. Note that the inaccessible memory regions are not included in the dump.
        /// </summary>
        /// <remarks>Prior to DbgHelp 6.1:  This value is not supported.</remarks>
        MiniDumpIgnoreInaccessibleMemory = 0x00020000,
        /// <summary>
        /// Adds security token related data. This will make the "!token" extension work when processing a user-mode dump. 
        /// </summary>
        /// <remarks>Prior to DbgHelp 6.1:  This value is not supported.</remarks>
        MiniDumpWithTokenInformation = 0x00040000,
        /// <summary>
        /// Adds module header related data. 
        /// </summary>
        /// <remarks>Prior to DbgHelp 6.1:  This value is not supported.</remarks>
        MiniDumpWithModuleHeaders = 0x00080000,
        /// <summary>
        /// Adds filter triage related data. 
        /// </summary>
        /// <remarks>Prior to DbgHelp 6.1:  This value is not supported.</remarks>
        MiniDumpFilterTriage = 0x00100000,

        MiniDumpWithAvxXStateContext = 0x00200000,
        MiniDumpValidTypeFlags = 0x003fffff

    }
}
