using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains exception information.
    /// </summary>
    public class MiniDumpExceptionStream
    {
        private MINIDUMP_EXCEPTION_STREAM _exceptionStream;
        private MiniDumpFile _owner;
        private MiniDumpException _exceptionRecord;
        private MiniDumpLocationDescriptor _threadContext;

        internal MiniDumpExceptionStream(MINIDUMP_EXCEPTION_STREAM exceptionStream, MiniDumpFile owner)
        {
            _exceptionStream = exceptionStream;
            _owner = owner;

            _exceptionRecord = new MiniDumpException(exceptionStream.ExceptionRecord, owner);
            _threadContext = new MiniDumpLocationDescriptor(exceptionStream.ThreadContext);
        }

        /// <summary>
        /// The identifier of the thread that caused the exception.
        /// </summary>
        public UInt32 ThreadId { get { return this._exceptionStream.ThreadId; } }

        /// <summary>
        /// Contains exception information.
        /// </summary>
        public MiniDumpException ExceptionRecord { get { return this._exceptionRecord; } }

        /// <summary>
        /// The context of the thread that caused the exception.
        /// </summary>
        public MiniDumpLocationDescriptor ThreadContext { get { return this._threadContext; } }
    }
}
