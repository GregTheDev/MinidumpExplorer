using DbgHelp.MinidumpFiles.Native;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpFile : IDisposable
    {
        private bool disposed = false;
        private MemoryMappedFile _minidumpMappedFile;
        private SafeMemoryMappedViewHandle _mappedFileView;

        internal MiniDumpFile(MemoryMappedFile minidumpMappedFile, SafeMemoryMappedViewHandle mappedFileView)
        {
            this._minidumpMappedFile = minidumpMappedFile;
            this._mappedFileView = mappedFileView;
        }

        /// <summary>
        /// Opens an existing minidump file on the specified path.
        /// </summary>
        /// <param name="path">The file to open.</param>
        /// <returns></returns>
        public static MiniDumpFile OpenExisting(string path)
        {
            MemoryMappedFile minidumpMappedFile = MemoryMappedFile.CreateFromFile(path, System.IO.FileMode.Open);

            SafeMemoryMappedViewHandle mappedFileView = NativeMethods.MapViewOfFile(minidumpMappedFile.SafeMemoryMappedFileHandle, NativeMethods.FILE_MAP_READ, 0, 0, IntPtr.Zero);

            if (mappedFileView.IsInvalid)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            MEMORY_BASIC_INFORMATION memoryInformation = default(MEMORY_BASIC_INFORMATION);

            if (NativeMethods.VirtualQuery(mappedFileView, ref memoryInformation, (IntPtr)Marshal.SizeOf(memoryInformation)) == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            mappedFileView.Initialize((ulong)memoryInformation.RegionSize);

            return new MiniDumpFile(minidumpMappedFile, mappedFileView);
        }

        public static bool Create(IntPtr hProcess, UInt32 ProcessId, SafeHandle hFile, MiniDumpType DumpType, IntPtr ExceptionParam, IntPtr UserStreamParam, IntPtr CallbackParam)
        {
            return NativeMethods.MiniDumpWriteDump(hProcess, ProcessId, hFile, DumpType, ExceptionParam, UserStreamParam, CallbackParam);
        }

        public MiniDumpModule[] ReadModuleList()
        {
            MINIDUMP_MODULE_LIST moduleList;
            IntPtr streamPointer;
            uint streamSize;

            moduleList = this.ReadStream<MINIDUMP_MODULE_LIST>(MINIDUMP_STREAM_TYPE.ModuleListStream, out streamPointer, out streamSize);
            //4 == skip the NumberOfModules field (4 bytes)
            MINIDUMP_MODULE[] modules = ReadArray<MINIDUMP_MODULE>(streamPointer + 4, (int) moduleList.NumberOfModules);

            List<MiniDumpModule> returnList = new List<MiniDumpModule>(modules.Select(x => new MiniDumpModule(x, this)));

            return returnList.ToArray();
        }

        protected unsafe T ReadStream<T>(MINIDUMP_STREAM_TYPE streamToRead)
        {
            IntPtr streamPointer;
            uint streamSize;

            return ReadStream<T>(streamToRead, out streamPointer, out streamSize);
        }

        protected unsafe T ReadStream<T>(MINIDUMP_STREAM_TYPE streamToRead, out IntPtr streamPointer, out uint streamSize)
        {
            MINIDUMP_DIRECTORY directory = new MINIDUMP_DIRECTORY();
            streamPointer = IntPtr.Zero;
            streamSize = 0;

            try
            {
                byte* baseOfView = null;
                _mappedFileView.AcquirePointer(ref baseOfView);

                if (baseOfView == null)
                    throw new Exception("Unable to aquire pointer to memory mapped view");

                if (!NativeMethods.MiniDumpReadDumpStream((IntPtr)baseOfView, streamToRead, ref directory, ref streamPointer, ref streamSize))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            finally
            {
                _mappedFileView.ReleasePointer();
            }

            return (T)Marshal.PtrToStructure(streamPointer, typeof(T));
        }

        /// <summary>
        /// Reads the specified number of value types from memory starting at the address, and writes them into an array.
        /// </summary>
        /// <typeparam name="T">The value type to read</typeparam>
        /// <param name="absoluteStreamReadAddress">The absolute (not offset) location in the stream from which to start reading.</param>
        /// <param name="count">The number of value types to read from the input array and to write to the output array.</param>
        /// <returns>A populated array of the value type.</returns>
        protected internal unsafe T[] ReadArray<T>(IntPtr absoluteStreamReadAddress, int count) where T: struct
        {
            T[] readItems = new T[count];

            try
            {
                byte* baseOfView = null;

                _mappedFileView.AcquirePointer(ref baseOfView);

                ulong offset = (ulong)absoluteStreamReadAddress - (ulong)baseOfView;

                _mappedFileView.ReadArray<T>(offset, readItems, 0, count);
            }
            finally
            {
                _mappedFileView.ReleasePointer();
            }

            return readItems;
        }

        /// <summary>
        /// Reads a MINIDUMP_STRING at the offset (RVA) specified.
        /// </summary>
        /// <param name="rva">Offset of the string from the beginning of the stream (RVA).</param>
        /// <returns>The string at the offset (RVA) specified.</returns>
        protected internal unsafe string ReadString(uint rva)
        {
            try
            {
                byte* baseOfView = null;

                _mappedFileView.AcquirePointer(ref baseOfView);

                IntPtr positionToReadFrom = new IntPtr(baseOfView + rva);

                // First 32bits is the legnth field, which is the number of bytes, not number of chars. Divide it by 2 to get number of chars (WCHAR is 2 bytes - unicode)
                int len = Marshal.ReadInt32(positionToReadFrom) / 2;

                // "advance" the pointer 4 bytes (to jump over the "Length" field);
                positionToReadFrom += 4; 

                // Read and marshal the string
                return Marshal.PtrToStringUni(positionToReadFrom, len);
            }
            finally
            {
                _mappedFileView.ReleasePointer();
            }
        }

        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms724290%28v=vs.85%29.aspx
        // http://blogs.msdn.com/b/joshpoley/archive/2007/12/19/date-time-formats-and-conversions.aspx (Time Management functions)
        // http://msdn.microsoft.com/en-us/library/w4ddyt9h.aspx
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms724280%28v=vs.85%29.aspx

        // http://blogs.msdn.com/b/jmstall/archive/2007/01/18/timestamps.aspx
        // http://blogs.msdn.com/b/brada/archive/2003/07/30/50205.aspx
        // http://blogs.msdn.com/b/oldnewthing/archive/2003/09/05/54806.aspx
        // http://support.microsoft.com/kb/167296
        public static DateTime TimeTToDateTime(UInt32 time_t)
        {
            // 10 000 000 * january 1st 1970
            long win32FileTime = 10000000 * (long)time_t + 116444736000000000;

            return DateTime.FromFileTime(win32FileTime); // FromFileTimeUtc is the UCT time, FromFileTime adjusts for the local timezone
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                _mappedFileView.Dispose();
                _mappedFileView = null;

                _minidumpMappedFile.Dispose();
                _minidumpMappedFile = null;
            }

            // Free any unmanaged objects here. 
        }
    }
}
