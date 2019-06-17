using System;
using System.Collections.Generic;
using System.Linq;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains header information for the minidump file.
    /// </summary>
    public class MiniDumpHeader
    {
        private MINIDUMP_HEADER _header;
        private MiniDumpFile _owner;
        private List<MiniDumpDirectory> _directoryEntries;

        internal MiniDumpHeader(MINIDUMP_HEADER header, MINIDUMP_DIRECTORY[] directoryEntries, MiniDumpFile miniDumpFile)
        {
            _header = header;
            _owner = miniDumpFile;

            _directoryEntries = new List<MiniDumpDirectory>(directoryEntries.Select(x => new MiniDumpDirectory(x)));
        }

        /// <summary>
        /// The signature.
        /// </summary>
        public UInt32 Signature { get { return _header.Signature; } }
        /// <summary>
        /// The version of the minidump format.
        /// </summary>
        public UInt32 Version { get { return _header.Version; } }
        /// <summary>
        /// The number of streams in the minidump directory.
        /// </summary>
        public UInt32 NumberOfStreams { get { return _header.NumberOfStreams; } }
        /// <summary>
        /// The base RVA of the minidump directory.
        /// </summary>
        public uint StreamDirectoryRva { get { return _header.StreamDirectoryRva; } }
        /// <summary>
        /// Time and date.
        /// </summary>
        public DateTime TimeDateStamp{ get { return MiniDumpFile.TimeTToDateTime(_header.TimeDateStamp); } }
        /// <summary>
        /// One or more values from the <see cref="MiniDumpType"/> enumeration type.
        /// </summary>
        public MiniDumpType Flags { get { return (MiniDumpType) _header.Flags; } }

        public IReadOnlyList<MiniDumpDirectory> DirectoryEntries { get { return _directoryEntries; } }
    }
}
