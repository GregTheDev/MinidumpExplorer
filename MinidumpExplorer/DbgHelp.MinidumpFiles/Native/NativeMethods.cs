using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32.SafeHandles;

namespace DbgHelp.MinidumpFiles.Native
{
    internal class NativeMethods
    {
        /*
        BOOL WINAPI MiniDumpWriteDump(
          _In_  HANDLE hProcess,
          _In_  DWORD ProcessId,
          _In_  HANDLE hFile,
          _In_  MINIDUMP_TYPE DumpType,
          _In_  PMINIDUMP_EXCEPTION_INFORMATION ExceptionParam,
          _In_  PMINIDUMP_USER_STREAM_INFORMATION UserStreamParam,
          _In_  PMINIDUMP_CALLBACK_INFORMATION CallbackParam
        );
         */

        [DllImport("DbgHelp.dll", SetLastError = true)]
        public extern static bool MiniDumpWriteDump(
            IntPtr hProcess,
            UInt32 ProcessId, // DWORD is a 32 bit unsigned integer
            SafeHandle hFile,
            MiniDumpType DumpType,
            IntPtr ExceptionParam,
            IntPtr UserStreamParam,
            IntPtr CallbackParam);

        /*
        BOOL WINAPI MiniDumpReadDumpStream(
          _In_   PVOID BaseOfDump,
          _In_   ULONG StreamNumber,
          _Out_  PMINIDUMP_DIRECTORY *Dir,
          _Out_  PVOID *StreamPointer,
          _Out_  ULONG *StreamSize
        );
         */
        [DllImport("dbghelp.dll", SetLastError = true)]
        public static extern bool MiniDumpReadDumpStream(IntPtr BaseOfDump,
                MINIDUMP_STREAM_TYPE StreamNumber,
                ref MINIDUMP_DIRECTORY Dir,
                ref IntPtr StreamPointer,
                ref uint StreamSize);

        /*
            LPVOID MapViewOfFile(
              HANDLE hFileMappingObject,
              DWORD dwDesiredAccess,
              DWORD dwFileOffsetHigh,
              DWORD dwFileOffsetLow,
              SIZE_T dwNumberOfBytesToMap
            );
         */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeMemoryMappedViewHandle MapViewOfFile(SafeMemoryMappedFileHandle hFileMappingObject,
            uint dwDesiredAccess,
            uint dwFileOffsetHigh,
            uint dwFileOffsetLow,
            IntPtr dwNumberOfBytesToMap);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr VirtualQuery(SafeMemoryMappedViewHandle address, ref MEMORY_BASIC_INFORMATION buffer, IntPtr sizeOfBuffer);

        public const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        public const uint SECTION_QUERY = 0x0001;
        public const uint SECTION_MAP_WRITE = 0x0002;
        public const uint SECTION_MAP_READ = 0x0004;
        public const uint SECTION_MAP_EXECUTE = 0x0008;
        public const uint SECTION_EXTEND_SIZE = 0x0010;
        public const uint SECTION_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SECTION_QUERY |
            SECTION_MAP_WRITE |
            SECTION_MAP_READ |
            SECTION_MAP_EXECUTE |
            SECTION_EXTEND_SIZE);

        public const uint FILE_MAP_COPY = SECTION_QUERY;
        public const uint FILE_MAP_WRITE = SECTION_MAP_WRITE;
        public const uint FILE_MAP_READ = SECTION_MAP_READ;
        public const uint FILE_MAP_EXECUTE = SECTION_MAP_EXECUTE;
        public const uint FILE_MAP_ALL_ACCESS = SECTION_ALL_ACCESS;
    }
}
