﻿using Microsoft.Win32.SafeHandles;
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


    /*
        typedef struct _MINIDUMP_MEMORY_DESCRIPTOR {
            ULONG64 StartOfMemoryRange;
            MINIDUMP_LOCATION_DESCRIPTOR Memory;
        } MINIDUMP_MEMORY_DESCRIPTOR, *PMINIDUMP_MEMORY_DESCRIPTOR;
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_MEMORY_DESCRIPTOR
    {
        public UInt64 StartOfMemoryRange;
        public MINIDUMP_LOCATION_DESCRIPTOR Memory;
    }

    /*
        typedef struct _MINIDUMP_THREAD_LIST {  
            ULONG32 NumberOfThreads;
            MINIDUMP_THREAD Threads [0];
        } MINIDUMP_THREAD_LIST,
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_THREAD_LIST
    {
        public UInt32 NumberOfThreads;
        public IntPtr Threads; // MINIDUMP_THREAD[] 
    }

    /*
        typedef struct _MINIDUMP_THREAD {  
            ULONG32 ThreadId;
            ULONG32 SuspendCount;
            ULONG32 PriorityClass;
            ULONG32 Priority;
            ULONG64 Teb;
            MINIDUMP_MEMORY_DESCRIPTOR Stack;
            MINIDUMP_LOCATION_DESCRIPTOR ThreadContext;
        } MINIDUMP_THREAD,
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_THREAD
    {
        public UInt32 ThreadId;
        public UInt32 SuspendCount;
        public UInt32 PriorityClass;
        public UInt32 Priority;
        public UInt64 Teb;
        public MINIDUMP_MEMORY_DESCRIPTOR Stack;
        public MINIDUMP_LOCATION_DESCRIPTOR ThreadContext;
    }

    /*
        typedef struct _MINIDUMP_MEMORY_LIST {
            ULONG32 NumberOfMemoryRanges;
            MINIDUMP_MEMORY_DESCRIPTOR MemoryRanges [0];
        } MINIDUMP_MEMORY_LIST, *PMINIDUMP_MEMORY_LIST;
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_MEMORY_LIST
    {
        public UInt32 NumberOfMemoryRanges;
        public IntPtr MemoryRanges; // MINIDUMP_MEMORY_DESCRIPTOR[]
    }

    /*
        typedef struct _MINIDUMP_HANDLE_DATA_STREAM {  
            ULONG32 SizeOfHeader;  
            ULONG32 SizeOfDescriptor;  
            ULONG32 NumberOfDescriptors;  
            ULONG32 Reserved;
        } MINIDUMP_HANDLE_DATA_STREAM,
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_HANDLE_DATA_STREAM
    {
        public UInt32 SizeOfHeader;
        public UInt32 SizeOfDescriptor;
        public UInt32 NumberOfDescriptors;
        public UInt32 Reserved;
    }


    /*
        typedef struct _MINIDUMP_HANDLE_DESCRIPTOR {  
            ULONG64 Handle;  
            RVA TypeNameRva;  
            RVA ObjectNameRva;  
            ULONG32 Attributes;  
            ULONG32 GrantedAccess;  
            ULONG32 HandleCount;  
            ULONG32 PointerCount;
        } MINIDUMP_HANDLE_DESCRIPTOR,
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_HANDLE_DESCRIPTOR
    {
        public UInt64 Handle;
        public uint TypeNameRva;
        public uint ObjectNameRva;
        public UInt32 Attributes;
        public UInt32 GrantedAccess;
        public UInt32 HandleCount;
        public UInt32 PointerCount;
    }

    /*
        typedef struct _MINIDUMP_HANDLE_DESCRIPTOR_2 {  
            ULONG64 Handle;  
            RVA TypeNameRva;  
            RVA ObjectNameRva;  
            ULONG32 Attributes;  
            ULONG32 GrantedAccess;  
            ULONG32 HandleCount;  
            ULONG32 PointerCount;  
            RVA ObjectInfoRva;  
            ULONG32 Reserved0;
        } MINIDUMP_HANDLE_DESCRIPTOR_2
    */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_HANDLE_DESCRIPTOR_2
    {
        public UInt64 Handle;
        public uint TypeNameRva;
        public uint ObjectNameRva;
        public UInt32 Attributes;
        public UInt32 GrantedAccess;
        public UInt32 HandleCount;
        public UInt32 PointerCount;
        public uint ObjectInfoRva;
        public UInt32 Reserved0;
    }

    /*
    typedef struct _MINIDUMP_HANDLE_OBJECT_INFORMATION {
        RVA NextInfoRva;
        ULONG32 InfoType;
        ULONG32 SizeOfInfo;
        // Raw information follows.
    } MINIDUMP_HANDLE_OBJECT_INFORMATION;
    */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_HANDLE_OBJECT_INFORMATION
    {
        public uint NextInfoRva;
        public UInt32 InfoType;
        public UInt32 SizeOfInfo;
        // Raw information follows.
    }

    /*
    typedef struct _MINIDUMP_MEMORY_DESCRIPTOR64 {
        ULONG64 StartOfMemoryRange;
        ULONG64 DataSize;
    } MINIDUMP_MEMORY_DESCRIPTOR64, *PMINIDUMP_MEMORY_DESCRIPTOR64;
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_MEMORY_DESCRIPTOR64
    {
        public UInt64 StartOfMemoryRange;
        public UInt64 DataSize;
    }

    /*
    typedef struct _MINIDUMP_MEMORY64_LIST {
        ULONG64 NumberOfMemoryRanges;
        RVA64 BaseRva; // == ULONG64
        MINIDUMP_MEMORY_DESCRIPTOR64 MemoryRanges [0];
    } MINIDUMP_MEMORY64_LIST, *PMINIDUMP_MEMORY64_LIST;
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct MINIDUMP_MEMORY64_LIST
    {
        public UInt64 NumberOfMemoryRanges;
        public UInt64 BaseRva;
        public IntPtr MemoryRanges; // MINIDUMP_MEMORY_DESCRIPTOR64[]
    }

    /*
    typedef struct _MINIDUMP_SYSTEM_INFO {
      USHORT  ProcessorArchitecture;
      USHORT  ProcessorLevel;
      USHORT  ProcessorRevision;
      union {
        USHORT Reserved0;
        struct {
          UCHAR NumberOfProcessors;
          UCHAR ProductType;
        };
      };
      ULONG32 MajorVersion;
      ULONG32 MinorVersion;
      ULONG32 BuildNumber;
      ULONG32 PlatformId;
      RVA     CSDVersionRva;
      union {
        ULONG32 Reserved1;
        struct {
          USHORT SuiteMask;
          USHORT Reserved2;
        };
      };
      union {
        struct {
          ULONG32 VendorId[3];
          ULONG32 VersionInformation;
          ULONG32 FeatureInformation;
          ULONG32 AMDExtendedCpuFeatures;
        } X86CpuInfo;
        struct {
          ULONG64 ProcessorFeatures[2];
        } OtherCpuInfo;
      } Cpu;
    } MINIDUMP_SYSTEM_INFO, *PMINIDUMP_SYSTEM_INFO;
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct MINIDUMP_SYSTEM_INFO
    {
        public ushort ProcessorArchitecture;
        public ushort ProcessorLevel;
        public ushort ProcessorRevision;
        public byte NumberOfProcessors;
        public byte ProductType;
        public UInt32 MajorVersion;
        public UInt32 MinorVersion;
        public UInt32 BuildNumber;
        public UInt32 PlatformId;
        public uint CSDVersionRva;
        public ushort SuiteMask;
        public ushort Reserved2;
        public CPU_INFORMATION Cpu;
    }

    /*
    typedef union _CPU_INFORMATION {
        struct {
            ULONG32 VendorId [ 3 ];
            ULONG32 VersionInformation;
            ULONG32 FeatureInformation;
            ULONG32 AMDExtendedCpuFeatures;

        } X86CpuInfo;

        struct {
            ULONG64 ProcessorFeatures [ 2 ];
        } OtherCpuInfo;

    } CPU_INFORMATION, *PCPU_INFORMATION; */

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct CPU_INFORMATION
    {
        // OtherCpuInfo
        [FieldOffset(0)]
        public fixed ulong ProcessorFeatures[2];
        // X86CpuInfo
        // Official VendorId is 3 * 32bit long's (EAX, EBX and ECX).
        // It actually stores a 12 byte ASCII string though, so it's easier for us
        // to treat it as a 12 byte array instead.
        //public fixed UInt32 VendorId[3];
        [FieldOffset(0)]
        public fixed byte VendorId[12];
        [FieldOffset(12)]
        public UInt32 VersionInformation;
        [FieldOffset(16)]
        public UInt32 FeatureInformation;
        [FieldOffset(20)]
        public UInt32 AMDExtendedCpuFeatures;       
    }

    /*
typedef struct _MINIDUMP_THREAD_INFO_LIST {
  ULONG SizeOfHeader;
  ULONG SizeOfEntry;
  ULONG NumberOfEntries;
} MINIDUMP_THREAD_INFO_LIST, *PMINIDUMP_THREAD_INFO_LIST;
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct MINIDUMP_THREAD_INFO_LIST
    {
        public UInt32 SizeOfHeader;
        public UInt32 SizeOfEntry;
        public UInt32 NumberOfEntries;
    }

    /*
    typedef struct _MINIDUMP_THREAD_INFO {
      ULONG32 ThreadId;
      ULONG32 DumpFlags;
      ULONG32 DumpError;
      ULONG32 ExitStatus;
      ULONG64 CreateTime;
      ULONG64 ExitTime;
      ULONG64 KernelTime;
      ULONG64 UserTime;
      ULONG64 StartAddress;
      ULONG64 Affinity;
    } MINIDUMP_THREAD_INFO, *PMINIDUMP_THREAD_INFO;
     */

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct MINIDUMP_THREAD_INFO
    {
        public UInt32 ThreadId;
        public UInt32 DumpFlags;
        public UInt32 DumpError;
        public UInt32 ExitStatus;
        public UInt64 CreateTime;
        public UInt64 ExitTime;
        public UInt64 KernelTime;
        public UInt64 UserTime;
        public UInt64 StartAddress;
        public UInt64 Affinity;
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
