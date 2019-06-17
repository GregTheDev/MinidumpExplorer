using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpLocationDescriptor
    {
        private MINIDUMP_LOCATION_DESCRIPTOR _locationDescriptor;

        internal MiniDumpLocationDescriptor(MINIDUMP_LOCATION_DESCRIPTOR locationDescriptor)
        {
            _locationDescriptor = locationDescriptor;
        }

        public uint DataSize { get { return _locationDescriptor.DataSize; } }
        public string DataSizeFormatted { get { return String.Concat("0x", this.DataSize.ToString("x8")); } }
        public string DataSizePretty
        {
            get
            {
                string[] sizes = { "B", "KB", "MB", "GB" };
                double len = this.DataSize;
                int order = 0;
                while (len >= 1024 && order + 1 < sizes.Length)
                {
                    order++;
                    len = len / 1024;
                }

                return String.Format("{0:0.#} {1}", len, sizes[order]);
            }
        }
        public uint Rva { get { return _locationDescriptor.Rva; } }
    }
}
