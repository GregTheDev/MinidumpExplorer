using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpDirectory
    {
        private MINIDUMP_DIRECTORY _directory;
        private MiniDumpLocationDescriptor _location;

        internal MiniDumpDirectory(MINIDUMP_DIRECTORY directory)
        {
            _directory = directory;
            _location = new MiniDumpLocationDescriptor(directory.Location);
        }

        public MiniDumpStreamType StreamType { get { return (MiniDumpStreamType)_directory.StreamType; } }
        public MiniDumpLocationDescriptor Location { get { return _location; } }
    }
}
