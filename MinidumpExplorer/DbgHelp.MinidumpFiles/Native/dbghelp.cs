using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles.Native
{
    /*
        typedef struct _MINIDUMP_LOCATION_DESCRIPTOR {
            ULONG32 DataSize;
            RVA Rva;
        } MINIDUMP_LOCATION_DESCRIPTOR;
     */
    internal struct MINIDUMP_LOCATION_DESCRIPTOR
    {
        public UInt32 DataSize;
        public uint Rva;
    }

    /*
        typedef struct _MINIDUMP_DIRECTORY {
            ULONG32 StreamType;
            MINIDUMP_LOCATION_DESCRIPTOR Location;
    } */
    internal struct MINIDUMP_DIRECTORY
    {
        public UInt32 StreamType;
        public MINIDUMP_LOCATION_DESCRIPTOR Location;
    }

    /*
        typedef struct _MINIDUMP_MODULE_LIST 
        {
            ULONG32 NumberOfModules;  
            MINIDUMP_MODULE Modules[];
        } MINIDUMP_MODULE_LIST;
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_MODULE_LIST
    {
        public UInt32 NumberOfModules;
        public IntPtr Modules;
    }

    /*
        typedef struct _MINIDUMP_MODULE {  
            ULONG64 BaseOfImage;  
            ULONG32 SizeOfImage;  
            ULONG32 CheckSum;  
            ULONG32 TimeDateStamp;  
            RVA ModuleNameRva;  
            VS_FIXEDFILEINFO VersionInfo;  
            MINIDUMP_LOCATION_DESCRIPTOR CvRecord;  
            MINIDUMP_LOCATION_DESCRIPTOR MiscRecord;  
            ULONG64 Reserved0;  
            ULONG64 Reserved1;
        } MINIDUMP_MODULE,
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_MODULE
    {
        public UInt64 BaseOfImage;
        public UInt32 SizeOfImage;
        public UInt32 CheckSum;
        public UInt32 TimeDateStamp;
        public uint ModuleNameRva;
        public VS_FIXEDFILEINFO VersionInfo;
        public MINIDUMP_LOCATION_DESCRIPTOR CvRecord;
        public MINIDUMP_LOCATION_DESCRIPTOR MiscRecord;
        public UInt64 Reserved0;
        public UInt64 Reserved1;
    }


    /*
        typedef struct _MINIDUMP_STRING {  
            ULONG32 Length;  
            WCHAR Buffer[];
        } MINIDUMP_STRING,
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_STRING
    {
        public UInt32 Length;
        public char[] Buffer;
    }

    public enum MINIDUMP_STREAM_TYPE : uint
    {
        UnusedStream = 0,
        ReservedStream0 = 1,
        ReservedStream1 = 2,
        ThreadListStream = 3,
        ModuleListStream = 4,
        MemoryListStream = 5,
        ExceptionStream = 6,
        SystemInfoStream = 7,
        ThreadExListStream = 8,
        Memory64ListStream = 9,
        CommentStreamA = 10,
        CommentStreamW = 11,
        HandleDataStream = 12,
        FunctionTableStream = 13,
        UnloadedModuleListStream = 14,
        MiscInfoStream = 15,
        MemoryInfoListStream = 16,
        ThreadInfoListStream = 17,
        HandleOperationListStream = 18,
        LastReservedStream = 0xffff
    }

    // Error codes
    internal class DbgHelpErrors
    {
        public const int ERR_ELEMENT_NOT_FOUND = 1168;
    }
}
