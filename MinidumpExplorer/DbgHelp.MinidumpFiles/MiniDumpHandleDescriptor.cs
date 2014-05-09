using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Describes the state of an individual system handle at the time the minidump was written.
    /// </summary>
    public class MiniDumpHandleDescriptor
    {
        private MiniDumpFile _owner;
        private MINIDUMP_HANDLE_DESCRIPTOR _handleDescriptor;
        private MINIDUMP_HANDLE_DESCRIPTOR_2 _handleDescriptor2;
        private bool _isHandleType2;

        internal MiniDumpHandleDescriptor(MINIDUMP_HANDLE_DESCRIPTOR handleDescriptor, MiniDumpFile owner)
        {
            _handleDescriptor = handleDescriptor;
            _owner = owner;
            _isHandleType2 = false;
        }

        internal MiniDumpHandleDescriptor(Native.MINIDUMP_HANDLE_DESCRIPTOR_2 handleDescriptor, MiniDumpFile owner)
        {
            _handleDescriptor2 = handleDescriptor;
            _owner = owner;
            _isHandleType2 = true;
        }

        /// <summary>
        /// The operating system handle value.
        /// </summary>
        public ulong HandleId
        {
            get { if (_isHandleType2) return _handleDescriptor2.Handle; else return _handleDescriptor.Handle; }
        }

        /// <summary>
        /// The object type of the handle.
        /// </summary>
        public string TypeName
        {
            get 
            { 
                if (_isHandleType2) 
                    return (_handleDescriptor2.TypeNameRva == 0) ? String.Empty : _owner.ReadString(_handleDescriptor2.TypeNameRva); 
                else 
                    return (_handleDescriptor.TypeNameRva == 0) ? String.Empty : _owner.ReadString(_handleDescriptor.TypeNameRva); 
            }
        }

        /// <summary>
        /// The object name of the handle.
        /// </summary>
        public string ObjectName
        {
            get 
            { 
                if (_isHandleType2) 
                    return (_handleDescriptor2.ObjectNameRva == 0) ? String.Empty : _owner.ReadString(_handleDescriptor2.ObjectNameRva); 
                else
                    return (_handleDescriptor.ObjectNameRva == 0) ? String.Empty : _owner.ReadString(_handleDescriptor.ObjectNameRva); 
            }
        }

        /// <summary>
        /// The meaning of this member depends on the handle type and the operating system.
        /// </summary>
        public uint Attributes
        {
            get { if (_isHandleType2) return _handleDescriptor2.Attributes; else return _handleDescriptor.Attributes; }
        }

        /// <summary>
        /// The meaning of this member depends on the handle type and the operating system.
        /// </summary>
        public uint GrantedAccess
        {
            get { if (_isHandleType2) return _handleDescriptor2.GrantedAccess; else return _handleDescriptor.GrantedAccess; }
        }

        /// <summary>
        /// The meaning of this member depends on the handle type and the operating system.
        /// </summary>
        public uint HandleCount
        {
            get { if (_isHandleType2) return _handleDescriptor2.HandleCount; else return _handleDescriptor.HandleCount; }
        }

        /// <summary>
        /// The meaning of this member depends on the handle type and the operating system.
        /// </summary>
        public uint PointerCount
        {
            get { if (_isHandleType2) return _handleDescriptor2.PointerCount; else return _handleDescriptor.PointerCount; }
        }

        /// <summary>
        /// An RVA to a MINIDUMP_HANDLE_OBJECT_INFORMATION structure that specifies object-specific information. This member can be 0 if there is no extra information.
        /// </summary>
        public uint ObjectInfoRva
        {
            get 
            {
                if (_isHandleType2 == false)
                    throw new InvalidOperationException("Handle does not support 'ObjectInfoRva'. 'IsHandleDescriptor2' must be 'true' to use this property.");

                return _handleDescriptor2.ObjectInfoRva;
            }
        }

        /// <summary>
        /// Object-specific information. This member can be null if there is no extra information.
        /// </summary>
        public MiniDumpHandleObjectInformation ObjectInfo
        {
            get
            {
                if (_isHandleType2 == false)
                    throw new InvalidOperationException("Handle does not support 'ObjectInfo'. 'IsHandleDescriptor2' must be 'true' to use this property.");

                if (_handleDescriptor2.ObjectInfoRva == 0)
                    return null;
                else
                    return new MiniDumpHandleObjectInformation(_handleDescriptor2.ObjectInfoRva, _owner);
            }
        }

        public bool IsHandleDescriptor2 { get { return _isHandleType2; } }
    }
}
