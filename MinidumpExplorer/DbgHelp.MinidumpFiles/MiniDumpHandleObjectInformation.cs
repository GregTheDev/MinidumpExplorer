using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains object-specific information for a handle.
    /// </summary>
    public class MiniDumpHandleObjectInformation
    {
        private MINIDUMP_HANDLE_OBJECT_INFORMATION _handleObjectInformation;
        private uint _objectInfoRva;
        private MiniDumpFile _owner;
        private MiniDumpHandleObjectInformation _nextInfo;

        internal MiniDumpHandleObjectInformation(uint objectInfoRva, MiniDumpFile owner)
        {
            _objectInfoRva = objectInfoRva;
            _handleObjectInformation = owner.ReadStructure<MINIDUMP_HANDLE_OBJECT_INFORMATION>(objectInfoRva);
            _owner = owner;

            _nextInfo = null;
        }

        /// <summary>
        /// An RVA to a MINIDUMP_HANDLE_OBJECT_INFORMATION structure that specifies additional object-specific information. This member is 0 if there are no more elements in the list.
        /// </summary>
        public uint NextInfoRva { get { return _handleObjectInformation.NextInfoRva; } }

        /// <summary>
        /// Additional object-specific information. This member is null if there are no more elements in the list.
        /// </summary>
        public MiniDumpHandleObjectInformation NextInfo
        { 
            get 
            {
                if ((_nextInfo == null) && (_handleObjectInformation.NextInfoRva != 0))
                    _nextInfo = new MiniDumpHandleObjectInformation(this.NextInfoRva, _owner);

                return _nextInfo; 
            }
        }

        /// <summary>
        /// The object information type.
        /// </summary>
        public MiniDumpHandleObjectInformationType InfoType { get { return (MiniDumpHandleObjectInformationType) _handleObjectInformation.InfoType; } }
        
        /// <summary>
        /// The size of the information that follows this member, in bytes.
        /// </summary>
        public UInt32 SizeOfInfo { get { return _handleObjectInformation.SizeOfInfo; } }

    }
}
