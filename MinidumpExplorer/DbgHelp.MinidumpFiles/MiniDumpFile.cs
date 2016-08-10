using DbgHelp.MinidumpFiles.Native;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            MemoryMappedFile minidumpMappedFile = null;
            SafeMemoryMappedViewHandle mappedFileView = null;

            // MemoryMappedFile will close the FileStream when it gets Disposed.
            FileStream fileStream = File.Open(path, System.IO.FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {
                minidumpMappedFile = MemoryMappedFile.CreateFromFile(fileStream, Path.GetFileName(path), 0, MemoryMappedFileAccess.Read, null, HandleInheritability.None, false);

                mappedFileView = NativeMethods.MapViewOfFile(minidumpMappedFile.SafeMemoryMappedFileHandle, NativeMethods.FILE_MAP_READ, 0, 0, IntPtr.Zero);

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
            }
            catch
            {
                // Cleanup whatever didn't work and rethrow
                if ((minidumpMappedFile != null) && (!mappedFileView.IsInvalid)) minidumpMappedFile.Dispose();
                if ((mappedFileView != null) && (!mappedFileView.IsInvalid)) mappedFileView.Dispose();
                if (minidumpMappedFile == null) fileStream?.Close();

                throw;
            }

            return new MiniDumpFile(minidumpMappedFile, mappedFileView);
        }

        public static bool Create(IntPtr hProcess, UInt32 ProcessId, SafeHandle hFile, MiniDumpType DumpType, IntPtr ExceptionParam, IntPtr UserStreamParam, IntPtr CallbackParam)
        {
            return NativeMethods.MiniDumpWriteDump(hProcess, ProcessId, hFile, DumpType, ExceptionParam, UserStreamParam, CallbackParam);
        }

        public MiniDumpHeader ReadHeader()
        {
            // Both SIGNATURE & VERSION are from minidumpapiset.h
            const UInt32 MINIDUMP_SIGNATURE = 0x504d444d; // PMDM, P = 0x50, M = 0x4d, D = 0x44, M = 0x4d
            const UInt32 MINIDUMP_VERSION = 42899;

            using (var viewAccessor = _minidumpMappedFile.CreateViewAccessor(0, Marshal.SizeOf(typeof(MINIDUMP_HEADER)), MemoryMappedFileAccess.Read))
            {
                MINIDUMP_HEADER header;

                viewAccessor.Read<MINIDUMP_HEADER>(0, out header);

                if (header.Signature != MINIDUMP_SIGNATURE) return null;
                if (windows.LoWord(header.Version) != MINIDUMP_VERSION) return null;

                MINIDUMP_DIRECTORY[] directoryEntries = new MINIDUMP_DIRECTORY[header.NumberOfStreams];

                _mappedFileView.ReadArray<MINIDUMP_DIRECTORY>(header.StreamDirectoryRva, directoryEntries, 0, (int) header.NumberOfStreams);

                return new MiniDumpHeader(header, directoryEntries, this);
            }
        }

        public MiniDumpModule[] ReadModuleList()
        {
            MINIDUMP_MODULE_LIST moduleList;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_MODULE_LIST>(MINIDUMP_STREAM_TYPE.ModuleListStream, out moduleList, out streamPointer, out streamSize))
            {
                return new MiniDumpModule[0];
            }
                
            //4 == skip the NumberOfModules field (4 bytes)
            MINIDUMP_MODULE[] modules = ReadArray<MINIDUMP_MODULE>(streamPointer + 4, (int) moduleList.NumberOfModules);

            List<MiniDumpModule> returnList = new List<MiniDumpModule>(modules.Select(x => new MiniDumpModule(x, this)));

            return returnList.ToArray();
        }

        public MiniDumpThread[] ReadThreadList()
        {
            MINIDUMP_THREAD_LIST threadList;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_THREAD_LIST>(MINIDUMP_STREAM_TYPE.ThreadListStream, out threadList, out streamPointer, out streamSize))
            {
                return new MiniDumpThread[0];
            }

            // 4 == skip the NumberOfThreads field (4 bytes)
            MINIDUMP_THREAD[] threads = ReadArray<MINIDUMP_THREAD>(streamPointer + 4, (int)threadList.NumberOfThreads);

            List<MiniDumpThread> returnList = new List<MiniDumpThread>(threads.Select(x => new MiniDumpThread(x)));

            return returnList.ToArray();
        }

        public MiniDumpMemoryDescriptor[] ReadMemoryList()
        {
            MINIDUMP_MEMORY_LIST memoryList;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_MEMORY_LIST>(MINIDUMP_STREAM_TYPE.MemoryListStream, out memoryList, out streamPointer, out streamSize))
            {
                return new MiniDumpMemoryDescriptor[0];
            }

            // 4 == skip the NumberOfMemoryRanges field (4 bytes)
            MINIDUMP_MEMORY_DESCRIPTOR[] memoryDescriptors = ReadArray<MINIDUMP_MEMORY_DESCRIPTOR>(streamPointer + 4, (int)memoryList.NumberOfMemoryRanges);

            List<MiniDumpMemoryDescriptor> returnList = new List<MiniDumpMemoryDescriptor>(memoryDescriptors.Select(x => new MiniDumpMemoryDescriptor(x)));

            return returnList.ToArray();
        }

        public MiniDumpMemory64Stream ReadMemory64List()
        {
            MINIDUMP_MEMORY64_LIST memoryList;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_MEMORY64_LIST>(MINIDUMP_STREAM_TYPE.Memory64ListStream, out memoryList, out streamPointer, out streamSize))
            {
                return new MiniDumpMemory64Stream();
            }

            // 4 == skip the NumberOfMemoryRanges field (4 bytes) and BaseRva field
            streamPointer += 8 + 8;
            MINIDUMP_MEMORY_DESCRIPTOR64[] memoryDescriptors = ReadArray<MINIDUMP_MEMORY_DESCRIPTOR64>(streamPointer, (int)memoryList.NumberOfMemoryRanges);

            // TODO: stop using List<> and just for a for...do loop, the List<> is a waste of resources
            List<MiniDumpMemoryDescriptor64> memoryRanges = new List<MiniDumpMemoryDescriptor64>(memoryDescriptors.Select(x => new MiniDumpMemoryDescriptor64(x)));

            MiniDumpMemory64Stream returnData = new MiniDumpMemory64Stream(memoryList.BaseRva, memoryRanges.ToArray());

            return returnData;
        }

        public MiniDumpHandleDescriptor[] ReadHandleData()
        {
            MINIDUMP_HANDLE_DATA_STREAM handleData;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_HANDLE_DATA_STREAM>(MINIDUMP_STREAM_TYPE.HandleDataStream, out handleData, out streamPointer, out streamSize))
            {
                return new MiniDumpHandleDescriptor[0];
            }

            // Advance the stream pointer past the header
            streamPointer = streamPointer + (int) handleData.SizeOfHeader;

            List<MiniDumpHandleDescriptor> returnList;

            // Now read the handles
            if (handleData.SizeOfDescriptor == Marshal.SizeOf(typeof(MINIDUMP_HANDLE_DESCRIPTOR)))
            {
                MINIDUMP_HANDLE_DESCRIPTOR[] handles = ReadArray<MINIDUMP_HANDLE_DESCRIPTOR>(streamPointer, (int) handleData.NumberOfDescriptors);

                returnList = new List<MiniDumpHandleDescriptor>(handles.Select(x => new MiniDumpHandleDescriptor(x, this)));
            }
            else if (handleData.SizeOfDescriptor == Marshal.SizeOf(typeof(MINIDUMP_HANDLE_DESCRIPTOR_2)))
            {
                MINIDUMP_HANDLE_DESCRIPTOR_2[] handles = ReadArray<MINIDUMP_HANDLE_DESCRIPTOR_2>(streamPointer, (int) handleData.NumberOfDescriptors);

                returnList = new List<MiniDumpHandleDescriptor>(handles.Select(x => new MiniDumpHandleDescriptor(x, this)));
            }
            else
                throw new Exception("Unexpected 'SizeOfDescriptor' when reading HandleDataStream. The unexpected value was: '" + handleData.SizeOfDescriptor + "'");

            return returnList.ToArray();
        }

        /// <summary>
        /// Reads the MINIDUMP_STREAM_TYPE.SystemInfoStream stream.
        /// </summary>
        /// <returns><see cref="MiniDumpSystemInfoStream"/> containing general system information or null if stream data is not present.</returns>
        public MiniDumpSystemInfoStream ReadSystemInfo()
        {
            MINIDUMP_SYSTEM_INFO systemInfo;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_SYSTEM_INFO>(MINIDUMP_STREAM_TYPE.SystemInfoStream, out systemInfo, out streamPointer, out streamSize))
            {
                return null;
            }

            return new MiniDumpSystemInfoStream(systemInfo, this);
        }

        /// <summary>
        /// Reads the MINIDUMP_STREAM_TYPE.ThreadInfoListStream stream.
        /// </summary>
        /// <returns><see cref="MiniDumpThreadInfo"/>[] containing thread state information or empty array if stream data is not present.</returns>
        public MiniDumpThreadInfo[] ReadThreadInfoList()
        {
            MINIDUMP_THREAD_INFO_LIST threadInfoList;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_THREAD_INFO_LIST>(MINIDUMP_STREAM_TYPE.ThreadInfoListStream, out threadInfoList, out streamPointer, out streamSize))
            {
                return new MiniDumpThreadInfo[0];
            }

            // Advance the stream pointer past the header
            streamPointer += (int)threadInfoList.SizeOfHeader;

            List<MiniDumpThreadInfo> returnList;

            // Now read the threads
            MINIDUMP_THREAD_INFO[] threadInfos = ReadArray<MINIDUMP_THREAD_INFO>(streamPointer, (int)threadInfoList.NumberOfEntries);

            returnList = new List<MiniDumpThreadInfo>(threadInfos.Select(x => new MiniDumpThreadInfo(x)));

            return returnList.ToArray();
        }

        /// <summary>
        /// Reads the MINIDUMP_STREAM_TYPE.ExceptionStream stream.
        /// </summary>
        /// <returns><see cref="MiniDumpExceptionStream"/> containing exception information or null if stream data is not present.</returns>
        public MiniDumpExceptionStream ReadExceptionStream()
        {
            MINIDUMP_EXCEPTION_STREAM exceptionStream;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_EXCEPTION_STREAM>(MINIDUMP_STREAM_TYPE.ExceptionStream, out exceptionStream, out streamPointer, out streamSize))
            {
                return null;
            }

            return new MiniDumpExceptionStream(exceptionStream, this);
        }

        public MiniDumpMemoryInfoStream ReadMemoryInfoList()
        {
            MINIDUMP_MEMORY_INFO_LIST memoryInfoList;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_MEMORY_INFO_LIST>(MINIDUMP_STREAM_TYPE.MemoryInfoListStream, out memoryInfoList, out streamPointer, out streamSize))
            {
                return new MiniDumpMemoryInfoStream();
            }

            // Advance the stream pointer past the header
            streamPointer += (int)memoryInfoList.SizeOfHeader;

            // Now read the region information
            MINIDUMP_MEMORY_INFO[] memoryInfos = ReadArray<MINIDUMP_MEMORY_INFO>(streamPointer, (int)memoryInfoList.NumberOfEntries);

            return new MiniDumpMemoryInfoStream(memoryInfoList, memoryInfos);
        }

        /// <summary>
        /// Reads the MINIDUMP_STREAM_TYPE.MiscInfoStream stream stream.
        /// </summary>
        /// <returns><see cref="MiniDumpMiscInfo"/> containing miscellaneous information or null if stream data is not present.</returns>
        public MiniDumpMiscInfo ReadMiscInfo()
        {
            // We can't use Marshal.SizeOf() on the locally defined MINIDUMP_MISC_INFO* interop structures
            // as MINIDUMP_MISC_INFO_3 & MINIDUMP_MISC_INFO_4 have strings which obviously don't have a 
            // size until after marshalled. Unless we switch to fixed byte[] if the marshalling doesn't
            // work in the fist place.
            uint SIZEOF_INFO_1 = 24;
            uint SIZEOF_INFO_2 = 44;
            uint SIZEOF_INFO_3 = 232;
            uint SIZEOF_INFO_4 = 832;
 
            MINIDUMP_MISC_INFO miscInfo;
            MINIDUMP_MISC_INFO_2 miscInfo2;
            MINIDUMP_MISC_INFO_3 miscInfo3;
            MINIDUMP_MISC_INFO_4 miscInfo4;

            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_MISC_INFO>(MINIDUMP_STREAM_TYPE.MiscInfoStream, out miscInfo, out streamPointer, out streamSize))
            {
                return null;
            }

            MiniDumpMiscInfo retVal = null;

            if (miscInfo.SizeOfInfo == SIZEOF_INFO_1)
            {
                retVal = new MiniDumpMiscInfo(miscInfo);
            }
            else if (miscInfo.SizeOfInfo == SIZEOF_INFO_2)
            {
                miscInfo2 = (MINIDUMP_MISC_INFO_2) Marshal.PtrToStructure(streamPointer, typeof(MINIDUMP_MISC_INFO_2));

                retVal = new MiniDumpMiscInfo2(miscInfo2);
            }
            else if (miscInfo.SizeOfInfo == SIZEOF_INFO_3)
            {
                miscInfo3 = (MINIDUMP_MISC_INFO_3)Marshal.PtrToStructure(streamPointer, typeof(MINIDUMP_MISC_INFO_3));

                retVal = new MiniDumpMiscInfo3(miscInfo3);
            }
            else if (miscInfo.SizeOfInfo >= SIZEOF_INFO_4)
            {
                miscInfo4 = (MINIDUMP_MISC_INFO_4)Marshal.PtrToStructure(streamPointer, typeof(MINIDUMP_MISC_INFO_4));

                retVal = new MiniDumpMiscInfo4(miscInfo4);
            }

            // GN, 25 Oct 2015.
            // Code used to throw an exception when SizeOfInfo didn't match any known sizes. Decided that this
            // condition should not be a error condition: additional versions of MISC_INFO could be added at any
            // time and a new version should not caused the call to fail e.g. Windows 10 added MISC_INFO_5.
            if (miscInfo.SizeOfInfo > SIZEOF_INFO_4)
            {
                System.Diagnostics.Debug.WriteLine("Data returned from reading MiscInfoStream has an unrecognised SizeOfInfo field: " + miscInfo.SizeOfInfo + " bytes. Maybe a new MINIDUMP_MISC_INFO_? structure has been added?");
            }

            return retVal;
        }

        /// <summary>
        /// Reads the MINIDUMP_STREAM_TYPE.UnloadedModuleListStream stream.
        /// </summary>
        /// <returns><see cref="MiniDumpUnloadedModulesStream"/> containing unloaded module information. If stream data was not present <see cref="MiniDumpUnloadedModulesStream.NumberOfEntries"/> will be 0 (all other fields are undefined).</returns>
        public MiniDumpUnloadedModulesStream ReadUnloadedModuleList()
        {
            MINIDUMP_UNLOADED_MODULE_LIST unloadedModuleList;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_UNLOADED_MODULE_LIST>(MINIDUMP_STREAM_TYPE.UnloadedModuleListStream, out unloadedModuleList, out streamPointer, out streamSize))
            {
                return new MiniDumpUnloadedModulesStream(); // Return empty result
            }

            // Advance the stream pointer past the header
            streamPointer += (int)unloadedModuleList.SizeOfHeader;

            // Now read the information
            MINIDUMP_UNLOADED_MODULE[] unloadedModules = ReadArray<MINIDUMP_UNLOADED_MODULE>(streamPointer, (int)unloadedModuleList.NumberOfEntries);

            return new MiniDumpUnloadedModulesStream(unloadedModuleList, unloadedModules, this);
        }

        public MiniDumpSystemMemoryInfo ReadSystemMemoryInfo()
        {
            MINIDUMP_SYSTEM_MEMORY_INFO_1 systemMemoryInfo;
            IntPtr streamPointer;
            uint streamSize;

            if (!this.ReadStream<MINIDUMP_SYSTEM_MEMORY_INFO_1>(MINIDUMP_STREAM_TYPE.SystemMemoryInfoStream, out systemMemoryInfo, out streamPointer, out streamSize))
            {
                return null;
            }

            return new MiniDumpSystemMemoryInfo(systemMemoryInfo, this);
        }

        public unsafe void CopyMemoryFromOffset(ulong rva, IntPtr destination, uint size)
        {
            try
            {
                byte* baseOfView = null;

                _mappedFileView.AcquirePointer(ref baseOfView);

                IntPtr readAddress = new IntPtr(baseOfView + rva);

                windows.RtlMoveMemory(destination, readAddress, new IntPtr(size));
            }
            finally
            {
                _mappedFileView.ReleasePointer();
            }
        }

        public unsafe void CopyMemoryFromOffset(ulong rva, byte[] destination, uint size)
        {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (destination.Length < size) throw new ArgumentException($"'{nameof(destination)}' must be at least {size} bytes long");

            GCHandle dataHandle = GCHandle.Alloc(destination, GCHandleType.Pinned);

            try
            {
                CopyMemoryFromOffset(rva, dataHandle.AddrOfPinnedObject(), size);
            }
            finally
            {
                dataHandle.Free();
            }
        }

        protected unsafe bool ReadStream<T>(MINIDUMP_STREAM_TYPE streamToRead, out T streamData)
        {
            IntPtr streamPointer;
            uint streamSize;

            return ReadStream<T>(streamToRead, out streamData, out streamPointer, out streamSize);
        }

        protected unsafe bool ReadStream<T>(MINIDUMP_STREAM_TYPE streamToRead, out T streamData, out IntPtr streamPointer, out uint streamSize)
        {
            MINIDUMP_DIRECTORY directory = new MINIDUMP_DIRECTORY();
            streamData = default(T);
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
                    int lastError = Marshal.GetLastWin32Error();

                    if (lastError == DbgHelpErrors.ERR_ELEMENT_NOT_FOUND)
                    {
                        return false;
                    }
                    else
                        throw new Win32Exception(lastError);
                }

                streamData = (T)Marshal.PtrToStructure(streamPointer, typeof(T));

            }
            finally
            {
                _mappedFileView.ReleasePointer();
            }

            return true;
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

        protected internal unsafe T ReadStructure<T>(uint rva) where T: struct
        {
            try
            {
                byte* baseOfView = null;

                _mappedFileView.AcquirePointer(ref baseOfView);

                ulong positionToReadFrom = (ulong) baseOfView + rva;
                //IntPtr positionToReadFrom = new IntPtr(baseOfView + rva);

                T readStructure = default(T);

                readStructure = _mappedFileView.Read<T>((ulong) positionToReadFrom);

                return readStructure;
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
