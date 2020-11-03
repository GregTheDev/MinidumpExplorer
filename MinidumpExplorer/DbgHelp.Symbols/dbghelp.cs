using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

using Microsoft.Win32.SafeHandles;

namespace DbgHelp.Symbols
{
    internal static class dbghelp
    {

        // BOOL WINAPI SymInitialize(__in HANDLE hProcess, __in_opt  PCTSTR UserSearchPath, __in      BOOL fInvadeProcess );
        [SuppressMessage("Microsoft.Design", "CA1060")]
        [DllImport("dbghelp.dll", SetLastError = true, BestFitMapping =false, ThrowOnUnmappableChar = true)]
        internal static extern bool SymInitialize(
          IntPtr hProcess,
          string UserSearchPath,
          bool fInvadeProcess);

        // BOOL WINAPI SymFindFileInPath(__in      HANDLE hProcess, __in_opt  PCTSTR SearchPath, __in PCTSTR FileName, __in_opt  PVOID id, __in DWORD two, __in DWORD three, __in DWORD flags, __out PTSTR FilePath, __in_opt  PFINDFILEINPATHCALLBACK callback, __in_opt  PVOID context);
        [SuppressMessage("Microsoft.Design", "CA1060")]
        [DllImport("dbghelp.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern bool SymFindFileInPath(
          IntPtr hProcess,
          [MarshalAs(UnmanagedType.LPStr)] string SearchPath,
          [MarshalAs(UnmanagedType.LPStr)] string FileName,
          IntPtr id,
          UInt32 two,
          UInt32 three,
          UInt32 flags,
          [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder filePath,
          IntPtr callback,
          IntPtr context);

        [SuppressMessage("Microsoft.Design", "CA1060")]
        [DllImport("dbghelp.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern bool SymFindFileInPathW(
            IntPtr hprocess,
            [MarshalAs(UnmanagedType.LPWStr)] string SearchPath,
            [MarshalAs(UnmanagedType.LPWStr)] string FileName,
            IntPtr id,
            UInt32 two,
            UInt32 three,
            UInt32 flags,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FoundFile,
            IntPtr callback,
            IntPtr context
        );

        //BOOL WINAPI SymCleanup(__in  HANDLE hProcess);
        [SuppressMessage("Microsoft.Design", "CA1060")]
        [DllImport("dbghelp.dll", SetLastError = true)]
        public static extern bool SymCleanup(IntPtr hProcess);


        // BOOL CALLBACK SymRegisterCallbackProc64(__in HANDLE hProcess, __in ULONG ActionCode, __in_opt  ULONG64 CallbackData, __in_opt  ULONG64 UserContext);
        public delegate bool SymRegisterCallbackProc64(
            IntPtr hProcess,
            SymAction ActionCode,
            UInt64 CallbackData, //IntPtr???
            UInt64 UserContext
            );


        // BOOL WINAPI SymRegisterCallback64(__in  HANDLE hProcess, __in  PSYMBOL_REGISTERED_CALLBACK64 CallbackFunction, __in  ULONG64 UserContext);
        [SuppressMessage("Microsoft.Design", "CA1060")]
        [DllImport("dbghelp.dll", SetLastError = true)]
        public static extern bool SymRegisterCallback64(
            IntPtr hProcess,
            SymRegisterCallbackProc64 CallbackFunction,
            UInt64 UserContext
            );


        // DWORD WINAPI SymGetOptions(void);
        [SuppressMessage("Microsoft.Design", "CA1060")]
        [DllImport("dbghelp.dll", SetLastError = true)]
        public static extern uint SymGetOptions();

        // DWORD WINAPI SymSetOptions(__in  DWORD SymOptions);
        [SuppressMessage("Microsoft.Design", "CA1060")]
        [DllImport("dbghelp.dll", SetLastError = true)]
        public static extern bool SymSetOptions(
            SymOptions symOptions
            );

    }

    // Symbol server

    [Flags]
    public enum SymOptions : uint
    {
        SYMOPT_CASE_INSENSITIVE = 0x00000001,
        SYMOPT_UNDNAME = 0x00000002,
        SYMOPT_DEFERRED_LOADS = 0x00000004,
        SYMOPT_NO_CPP = 0x00000008,
        SYMOPT_LOAD_LINES = 0x00000010,
        SYMOPT_OMAP_FIND_NEAREST = 0x00000020,
        SYMOPT_LOAD_ANYTHING = 0x00000040,
        SYMOPT_IGNORE_CVREC = 0x00000080,
        SYMOPT_NO_UNQUALIFIED_LOADS = 0x00000100,
        SYMOPT_FAIL_CRITICAL_ERRORS = 0x00000200,
        SYMOPT_EXACT_SYMBOLS = 0x00000400,
        SYMOPT_ALLOW_ABSOLUTE_SYMBOLS = 0x00000800,
        SYMOPT_IGNORE_NT_SYMPATH = 0x00001000,
        SYMOPT_INCLUDE_32BIT_MODULES = 0x00002000,
        SYMOPT_PUBLICS_ONLY = 0x00004000,
        SYMOPT_NO_PUBLICS = 0x00008000,
        SYMOPT_AUTO_PUBLICS = 0x00010000,
        SYMOPT_NO_IMAGE_SEARCH = 0x00020000,
        SYMOPT_SECURE = 0x00040000,
        SYMOPT_NO_PROMPTS = 0x00080000,
        SYMOPT_OVERWRITE = 0x00100000,
        SYMOPT_IGNORE_IMAGEDIR = 0x00200000,
        SYMOPT_FLAT_DIRECTORY = 0x00400000,
        SYMOPT_FAVOR_COMPRESSED = 0x00800000,
        SYMOPT_ALLOW_ZERO_ADDRESS = 0x01000000,
        SYMOPT_DISABLE_SYMSRV_AUTODETECT = 0x02000000,
        SYMOPT_READONLY_CACHE = 0x04000000,
        SYMOPT_SYMPATH_LAST = 0x08000000,
        SYMOPT_DISABLE_FAST_SYMBOLS = 0x10000000,
        SYMOPT_DISABLE_SYMSRV_TIMEOUT = 0x20000000,
        SYMOPT_DISABLE_SRVSTAR_ON_STARTUP = 0x40000000,
        SYMOPT_DEBUG = 0x80000000
    }

    public enum SymAction : uint
    {
        CBA_DEFERRED_SYMBOL_LOAD_START = 0x00000001,
        CBA_DEFERRED_SYMBOL_LOAD_COMPLETE = 0x00000002,
        CBA_DEFERRED_SYMBOL_LOAD_FAILURE = 0x00000003,
        CBA_SYMBOLS_UNLOADED = 0x00000004,
        CBA_DUPLICATE_SYMBOL = 0x00000005,
        CBA_READ_MEMORY = 0x00000006,
        CBA_DEFERRED_SYMBOL_LOAD_CANCEL = 0x00000007,
        CBA_SET_OPTIONS = 0x00000008,
        CBA_EVENT = 0x00000010,
        CBA_DEFERRED_SYMBOL_LOAD_PARTIAL = 0x00000020,
        CBA_DEBUG_INFO = 0x10000000,
        CBA_SRCSRV_INFO = 0x20000000,
        CBA_SRCSRV_EVENT = 0x40000000,
        CBA_UPDATE_STATUS_BAR = 0x50000000,
        CBA_ENGINE_PRESENT = 0x60000000,
        CBA_CHECK_ENGOPT_DISALLOW_NETWORK_PATHS = 0x70000000,
        CBA_CHECK_ARM_MACHINE_THUMB_TYPE_OVERRIDE = 0x80000000,
        CBA_XML_LOG = 0x90000000
    }

    /*
typedef struct _IMAGEHLP_CBA_EVENT {
DWORD  severity;
DWORD  code;
PCTSTR desc;
PVOID  object;
} IMAGEHLP_CBA_EVENT, *PIMAGEHLP_CBA_EVENT;
     */
    public struct IMAGEHLP_CBA_EVENT
    {
        public uint severity;
        public uint code;
        [MarshalAs(UnmanagedType.LPStr)]
        public string desc;
        public IntPtr reserved;
    }

}
