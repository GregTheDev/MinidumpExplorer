using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.Symbols
{
    public class SymbolDownloader //: IDisposable
    {
        public const string MSDN_SYMBOL_SERVER = @"*http://msdl.microsoft.com/download/symbols";
        private const int MAX_PATH = 260;

        private IntPtr _processId;
        private bool disposed = false; // Track whether Dispose has been called. 
        private dbghelp.SymRegisterCallbackProc64 _symCallback;
        private string _userSearchPath;
        private static SymbolDownloader _instance;

        static SymbolDownloader()
        {
            IsOpen = false;
        }

        private SymbolDownloader(string userSearchPath)
        {
            _userSearchPath = userSearchPath;

            _symCallback = new dbghelp.SymRegisterCallbackProc64(CallBack);

            InitSymbolServer(_userSearchPath);

            IsOpen = true;
        }

        //public static void Open()
        //{
        //    if (IsOpen)
        //        throw new InvalidOperationException("Open() can only be called once");

        //    Open(null, null);
        //}

        public static SymbolDownloader Open(string userSearchPath)
        {
            if (IsOpen)
            {
                if (userSearchPath != _instance._userSearchPath)
                    throw new InvalidOperationException($"Open() can not be called more than once with a different '{nameof(userSearchPath)}'");
                else
                    return _instance;
            }

            _instance = new SymbolDownloader(userSearchPath);

            return _instance;
        }

        //public static void Open(string symbolServer, string localSymbolFolder)
        //{
        //    if (IsOpen)
        //        throw new InvalidOperationException("Open() can only be called once");

        //    _symCallback = new dbghelp.SymRegisterCallbackProc64(CallBack);

        //    InitSymbolServer(symbolServer, localSymbolFolder);

        //    IsOpen = true;
        //}

        // private static void InitSymbolServer(string symbolServer, string localSymbolFolder)
        private void InitSymbolServer(string symbolServer)
        {
            _processId = System.Diagnostics.Process.GetCurrentProcess().Handle;
            bool success = false;
            string symbolPath = symbolServer; // GenerateSymbolPath(symbolServer, localSymbolFolder);

            success = dbghelp.SymSetOptions(SymOptions.SYMOPT_UNDNAME | SymOptions.SYMOPT_DEFERRED_LOADS | SymOptions.SYMOPT_DEBUG);

            if (!success)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            success = dbghelp.SymInitialize(_processId, symbolPath, false);

            if (!success)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            success = dbghelp.SymRegisterCallback64(_processId, _symCallback, 0);

            if (!success)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        //private static string GenerateSymbolPath(string symbolServer, string localSymbolFolder)
        //{
        //    if (symbolServer == null && localSymbolFolder == null)
        //        return null;
        //}

        public void Close()
        {
            if (IsOpen)
                dbghelp.SymCleanup(_processId);
        }

        public string DownloadImage(string imageName, uint timeStamp, uint imageSize)
        {
            if (!IsOpen)
                throw new Exception("Symbol store not opened, please call SymbolDownloader.Open() first.");

            bool success = false;

            StringBuilder outPath = new StringBuilder(MAX_PATH);

            success = dbghelp.SymFindFileInPath(_processId,
                null,
                imageName,
                (IntPtr)timeStamp,
                (uint) imageSize,
                0,
                2, //SSRVOPT_DWORD
                outPath,
                (IntPtr)0,
                (IntPtr)0);

            if (!success)
            {
                int hr = Marshal.GetLastWin32Error();

                if (hr == 2) // 2 seems to mean file not found...
                    return String.Empty;
                else
                    throw new Win32Exception(hr);
            }

            return outPath.ToString();
        }

        private bool CallBack(IntPtr hProcess, SymAction ActionCode, UInt64 CallbackData, UInt64 UserContext)
        {
            switch (ActionCode)
            {
                case SymAction.CBA_DEBUG_INFO:
                    string message = Marshal.PtrToStringAnsi((IntPtr)CallbackData);

                    System.Diagnostics.Debug.WriteLine("CBA_DEBUG_INFO: " + message);

                    return true;
                case SymAction.CBA_EVENT:
                    IMAGEHLP_CBA_EVENT eventData = (IMAGEHLP_CBA_EVENT)Marshal.PtrToStructure((IntPtr)CallbackData, typeof(IMAGEHLP_CBA_EVENT));

                    //this.textBox1.AppendText(eventData.desc + "\r\n"); TBD make this an event
                    System.Diagnostics.Debug.WriteLine("CBA_EVENT: " + eventData.desc);

                    return true;
                case SymAction.CBA_DEFERRED_SYMBOL_LOAD_CANCEL:
                    return false; // don't cancel the operation
                case SymAction.CBA_CHECK_ENGOPT_DISALLOW_NETWORK_PATHS:
                    return false;
                default:
                    System.Diagnostics.Debug.WriteLine(ActionCode.ToString());
                    break;
            }

            return false;
        }

        private static string SymbolServer { get; set; }
        private static string LocalSymbolFolder { get; set; }
        private static string FullSymbolServerPath { get { return String.Concat("SRV*", LocalSymbolFolder, SymbolServer); } }
        public static bool IsOpen { get; internal set; }

        #region Disposal
/*
        // Implement IDisposable. 
        // Do not make this method virtual. 
        // A derived class should not be able to override this method. 
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios. 
        // If disposing equals true, the method has been called directly 
        // or indirectly by a user's code. Managed and unmanaged resources 
        // can be disposed. 
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed. 
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing)
                {
                    // Dispose managed resources.
                    //component.Dispose();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here. 
                // If disposing is false, 
                // only the following code is executed.
                dbghelp.SymCleanup(_processId);

                // Note disposing has been done.
                disposed = true;

            }
        }
*/
        #endregion
    }
}
