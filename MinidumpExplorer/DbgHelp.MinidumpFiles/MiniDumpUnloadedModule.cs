using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains information about a module that has been unloaded.
    /// </summary>
    public class MiniDumpUnloadedModule
    {
        private MINIDUMP_UNLOADED_MODULE _unloadedModule;
        private MiniDumpFile _owner;

        internal MiniDumpUnloadedModule(MINIDUMP_UNLOADED_MODULE unloadedModule, MiniDumpFile owner)
        {
            _unloadedModule = unloadedModule;
            _owner = owner;
        }

        /// <summary>
        /// The base address of the module executable image in memory.
        /// </summary>
        public UInt64 BaseOfImage { get { return _unloadedModule.BaseOfImage; } }
        /// <summary>
        /// The size of the module executable image in memory, in bytes.
        /// </summary>
        public UInt32 SizeOfImage { get { return _unloadedModule.SizeOfImage; } }
        /// <summary>
        /// The checksum value of the module executable image.
        /// </summary>
        public UInt32 CheckSum { get { return _unloadedModule.CheckSum; } }
        /// <summary>
        /// The timestamp value of the module executable image, in time_t format.
        /// </summary>
        public UInt32 TimeDateStampRaw { get { return _unloadedModule.TimeDateStamp; } }
        /// <summary>
        /// The timestamp value of the module executable image.
        /// </summary>
        public DateTime TimeDateStamp { get { return MiniDumpFile.TimeTToDateTime(_unloadedModule.TimeDateStamp); } }
        /// <summary>
        /// An RVA to a MINIDUMP_STRING structure that specifies the name of the module.
        /// </summary>
        public uint ModuleNameRva { get { return _unloadedModule.ModuleNameRva; } }
        /// <summary>
        /// The name of the module.
        /// </summary>
        public string ModuleName { get { return _owner.ReadString(_unloadedModule.ModuleNameRva); } }

    }
}
