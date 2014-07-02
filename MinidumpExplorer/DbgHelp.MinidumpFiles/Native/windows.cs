using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace DbgHelp.MinidumpFiles.Native
{
    internal class windows
    {
        // http://msdn.microsoft.com/en-us/library/ms646997%28v=vs.85%29.aspx
        public const uint VS_FF_DEBUG = 0x00000001;
        public const uint VS_FF_INFOINFERRED = 0x00000010;
        public const uint VS_FF_PATCHED = 0x00000004;
        public const uint VS_FF_PRERELEASE = 0x00000002;
        public const uint VS_FF_PRIVATEBUILD = 0x00000008;
        public const uint VS_FF_SPECIALBUILD = 0x00000020;

        public const uint VOS_DOS = 0x00010000;
        public const uint VOS_NT = 0x00040000;
        public const uint VOS__WINDOWS16 = 0x00000001;
        public const uint VOS__WINDOWS32 = 0x00000004;
        public const uint VOS_OS216 = 0x00020000;
        public const uint VOS_OS232 = 0x00030000;
        public const uint VOS__PM16 = 0x00000002;
        public const uint VOS__PM32 = 0x00000003;
        public const uint VOS_UNKNOWN = 0x00000000;

        public const uint VOS_DOS_WINDOWS16 = 0x00010001;
        public const uint VOS_DOS_WINDOWS32 = 0x00010004;
        public const uint VOS_NT_WINDOWS32 = 0x00040004;
        public const uint VOS_OS216_PM16 = 0x00020002;
        public const uint VOS_OS232_PM32 = 0x00030003;

        public const uint VFT_APP = 0x00000001;
        public const uint VFT_DLL = 0x00000002;
        public const uint VFT_DRV = 0x00000003;
        public const uint VFT_FONT = 0x00000004;
        public const uint VFT_STATIC_LIB = 0x00000007;
        public const uint VFT_UNKNOWN = 0x00000000;
        public const uint VFT_VXD = 0x00000005;

        public const uint VFT2_DRV_COMM = 0x0000000A;
        public const uint VFT2_DRV_DISPLAY = 0x00000004;
        public const uint VFT2_DRV_INSTALLABLE = 0x00000008;
        public const uint VFT2_DRV_KEYBOARD = 0x00000002;
        public const uint VFT2_DRV_LANGUAGE = 0x00000003;
        public const uint VFT2_DRV_MOUSE = 0x00000005;
        public const uint VFT2_DRV_NETWORK = 0x00000006;
        public const uint VFT2_DRV_PRINTER = 0x00000001;
        public const uint VFT2_DRV_SOUND = 0x00000009;
        public const uint VFT2_DRV_SYSTEM = 0x00000007;
        public const uint VFT2_DRV_VERSIONED_PRINTER = 0x0000000C;
        public const uint VFT2_UNKNOWN = 0x00000000;

        public const uint VFT2_FONT_RASTER = 0x00000001;
        public const uint VFT2_FONT_TRUETYPE = 0x00000003;
        public const uint VFT2_FONT_VECTOR = 0x00000002;

        // Used by MINIDUMP_SYSTEM_INFO.SuiteMask
        public const ushort VER_SUITE_SMALLBUSINESS = 0x00000001;
        public const ushort VER_SUITE_ENTERPRISE = 0x00000002;
        public const ushort VER_SUITE_BACKOFFICE = 0x00000004;
        public const ushort VER_SUITE_COMMUNICATIONS = 0x00000008;
        public const ushort VER_SUITE_TERMINAL = 0x00000010;
        public const ushort VER_SUITE_SMALLBUSINESS_RESTRICTED = 0x00000020;
        public const ushort VER_SUITE_EMBEDDEDNT = 0x00000040;
        public const ushort VER_SUITE_DATACENTER = 0x00000080;
        public const ushort VER_SUITE_SINGLEUSERTS = 0x00000100;
        public const ushort VER_SUITE_PERSONAL = 0x00000200;
        public const ushort VER_SUITE_BLADE = 0x00000400;
        public const ushort VER_SUITE_EMBEDDED_RESTRICTED = 0x00000800;
        public const ushort VER_SUITE_SECURITY_APPLIANCE = 0x00001000;
        public const ushort VER_SUITE_STORAGE_SERVER = 0x00002000;
        public const ushort VER_SUITE_COMPUTE_SERVER = 0x00004000;
        public const ushort VER_SUITE_WH_SERVER = 0x00008000;

        public const uint STILL_ACTIVE = 259;

        public const int EXCEPTION_MAXIMUM_PARAMETERS = 15; // maximum number of exception parameters


    }

    // http://www.pinvoke.net/default.aspx/Enums/PageProtection.html
    [Flags]
    public enum PageProtection : uint
    {
        NoAccess = 0x01,
        Readonly = 0x02,
        ReadWrite = 0x04,
        WriteCopy = 0x08,
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        Guard = 0x100,
        NoCache = 0x200,
        WriteCombine = 0x400,
    }

    // http://www.pinvoke.net/default.aspx/Structures.SECURITY_ATTRIBUTES
    /*
            SECURITY_ATTRIBUTES lpSecurityAttributes = new SECURITY_ATTRIBUTES();
            DirectorySecurity security = new DirectorySecurity();
            lpSecurityAttributes.nLength = Marshal.SizeOf(lpSecurityAttributes);
            byte[] src = security.GetSecurityDescriptorBinaryForm();
            IntPtr dest = Marshal.AllocHGlobal(src.Length);
            Marshal.Copy(src, 0, dest, src.Length);
            lpSecurityAttributes.lpSecurityDescriptor = dest;
            string path = @"C:\Test";
            CreateDirectory(path, lpSecurityAttributes);
     */
    [StructLayout(LayoutKind.Sequential)]
    internal struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public IntPtr lpSecurityDescriptor;
        public int bInheritHandle;
    }

    internal struct VS_FIXEDFILEINFO
    {
        public UInt32 dwSignature;
        public UInt32 dwStrucVersion;
        public UInt32 dwFileVersionMS;
        public UInt32 dwFileVersionLS;
        public UInt32 dwProductVersionMS;
        public UInt32 dwProductVersionLS;
        public UInt32 dwFileFlagsMask;
        public UInt32 dwFileFlags;
        public UInt32 dwFileOS;
        public UInt32 dwFileType;
        public UInt32 dwFileSubtype;
        public UInt32 dwFileDateMS;
        public UInt32 dwFileDateLS;
    };

    internal struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public UIntPtr RegionSize;
        public uint State;
        public uint Protect;
        public uint Type;
    }
}
