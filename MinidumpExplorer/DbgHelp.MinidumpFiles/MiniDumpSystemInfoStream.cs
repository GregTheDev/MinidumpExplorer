using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Contains processor and operating system information.
    /// </summary>
    public class MiniDumpSystemInfoStream
    {
        private MINIDUMP_SYSTEM_INFO _systemInfo;
        private MiniDumpFile _owner;
        private X86CpuInfo _x86CpuInfo;
        private OtherCpuInfo _otherCpuInfo;

        internal MiniDumpSystemInfoStream(MINIDUMP_SYSTEM_INFO systemInfo, MiniDumpFile owner)
        {
            _systemInfo = systemInfo;
            _owner = owner;

            if (this.ProcessorArchitecture == MiniDumpProcessorArchitecture.PROCESSOR_ARCHITECTURE_INTEL)
                this._x86CpuInfo = new X86CpuInfo(_systemInfo.Cpu);
            else
                this._otherCpuInfo = new OtherCpuInfo(_systemInfo.Cpu);
        }

        /// <summary>
        /// The system's processor architecture.
        /// </summary>
        /// <remarks>
        /// If the value is <see cref="ProcessorArchitecture.PROCESSOR_ARCHITECTURE_INTEL"/> then ProcessorLevel contains the system's architecture-dependent processor level.
        /// </remarks>
        public MiniDumpProcessorArchitecture ProcessorArchitecture { get { return (MiniDumpProcessorArchitecture)_systemInfo.ProcessorArchitecture; } }
        
        /// <summary>
        /// The system's architecture-dependent processor level.
        /// </summary>
        /// <remarks>
        /// If <see cref="ProcessorArchitecture"/> is PROCESSOR_ARCHITECTURE_INTEL, ProcessorLevel can be one of the specified values.
        /// </remarks>
        public MiniDumpProcessorLevel ProcessorLevel { get { return (MiniDumpProcessorLevel)_systemInfo.ProcessorLevel; } }

        /// <summary>
        /// The architecture-dependent processor revision.
        /// </summary>
        /// <remarks>
        /// <para>Intel 80386 or 80486: A value of the form xxyz.</para>
        /// <para>If xx is equal to 0xFF, y - 0xA is the model number, and z is the stepping identifier. For example, an Intel 80486-D0 system returns 0xFFD0.</para>
        /// <para>If xx is not equal to 0xFF, xx + 'A' is the stepping letter and yz is the minor stepping.</para>
        /// <para></para>
        /// <para>Intel Pentium, Cyrix, or NextGen 586</para>
        /// <para>A value of the form xxyy, where xx is the model number and yy is the stepping. Display this value of 0x0201 as follows: Model xx, Stepping yy</para>
        /// </remarks>
        public ushort ProcessorRevision { get { return _systemInfo.ProcessorRevision; } }

        /// <summary>
        /// The number of processors in the system.
        /// </summary>
        public byte NumberOfProcessors { get { return _systemInfo.NumberOfProcessors; } }

        /// <summary>
        /// Any additional information about the system.
        /// </summary>
        public MiniDumpProductType ProductType { get { return (MiniDumpProductType)_systemInfo.ProductType; } }

        /// <summary>
        /// The major version number of the operating system. This member can be 4, 5, or 6.
        /// </summary>
        public uint MajorVersion { get { return _systemInfo.MajorVersion; } }

        /// <summary>
        /// The minor version number of the operating system.
        /// </summary>
        public uint MinorVersion { get { return _systemInfo.MinorVersion; } }

        /// <summary>
        /// The build number of the operating system.
        /// </summary>
        public uint BuildNumber { get { return _systemInfo.BuildNumber; } }

        /// <summary>
        /// The operating system platform.
        /// </summary>
        public MiniDumpPlatform PlatformId { get { return (MiniDumpPlatform)_systemInfo.PlatformId; } }

        /// <summary>
        /// A string that describes the latest Service Pack installed on the system. If no Service Pack has been installed, the string is empty.
        /// </summary>
        public string CSDVersion { get { return _owner.ReadString(_systemInfo.CSDVersionRva); } }
        
        /// <summary>
        /// The bit flags that identify the product suites available on the system. See <see cref="MiniDumpSuite"/>
        /// </summary>
        public ushort SuiteMask { get { return _systemInfo.SuiteMask; } }
        
        /// <summary>
        /// Microsoft BackOffice components are installed.
        /// </summary>
        public bool HasSuiteBackOffice { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_BACKOFFICE) > 0; } }
        
        /// <summary>
        /// Windows Server 2003, Web Edition is installed.
        /// </summary>
        public bool HasSuiteBlade { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_BLADE) > 0; } }
        
        /// <summary>
        /// Windows Server 2003, Compute Cluster Edition is installed.
        /// </summary>
        public bool HasSuiteComputeServer { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_COMPUTE_SERVER) > 0; } }
        
        /// <summary>
        /// Windows Server 2008 R2 Datacenter, Windows Server 2008 Datacenter, or Windows Server 2003, Datacenter Edition is installed.
        /// </summary>
        public bool HasSuiteDataCenter { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_DATACENTER) > 0; } }
        
        /// <summary>
        /// Windows Server 2008 R2 Enterprise, Windows Server 2008 Enterprise, or Windows Server 2003, Enterprise Edition is installed.
        /// </summary>
        public bool HasSuiteEnterprise { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_ENTERPRISE) > 0; } }
        
        /// <summary>
        /// Windows Embedded is installed.
        /// </summary>
        public bool HasSuiteEmbeddedNt { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_EMBEDDEDNT) > 0; } }
        
        /// <summary>
        /// Windows XP Home Edition is installed.
        /// </summary>
        public bool HasSuitePersonal { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_PERSONAL) > 0; } }
        
        /// <summary>
        /// Remote Desktop is supported, but only one interactive session is supported. This value is set unless the system is running in application server mode.
        /// </summary>
        public bool HasSuiteSingleUserTerminalServices { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_SINGLEUSERTS) > 0; } }
        
        /// <summary>
        /// Microsoft Small Business Server was once installed on the system, but may have been upgraded to another version of Windows.
        /// </summary>
        public bool HasSuiteSmallBusiness { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_SMALLBUSINESS) > 0; } }
        
        /// <summary>
        /// Microsoft Small Business Server is installed with the restrictive client license in force.
        /// </summary>
        public bool HasSuiteSmallBusinessRestricted { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_SMALLBUSINESS_RESTRICTED) > 0; } }
        
        /// <summary>
        /// Windows Storage Server is installed.
        /// </summary>
        public bool HasSuiteStorageServer { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_STORAGE_SERVER) > 0; } }
        
        /// <summary>
        /// Terminal Services is installed. This value is always set.
        /// </summary>
        /// <remarks>
        /// If HasSuiteTerminal is set but HasSuiteSingleUserTerminalServices is not set, the system is running in application server mode.
        /// </remarks>
        public bool HasSuiteTerminal { get { return (_systemInfo.SuiteMask & windows.VER_SUITE_TERMINAL) > 0; } }

        /// <summary>
        /// The CPU information obtained from the CPUID instruction. This structure is supported only for x86 computers.
        /// </summary>
        public X86CpuInfo CpuInfoX86
        {
            get
            {
                if (this.ProcessorArchitecture != MiniDumpProcessorArchitecture.PROCESSOR_ARCHITECTURE_INTEL)
                    throw new InvalidOperationException("CpuInfoX86 is only supported for x86 computers.");

                return _x86CpuInfo;
            }
        }

        /// <summary>
        /// Other CPU information. This structure is supported only for non-x86 computers.
        /// </summary>
        public OtherCpuInfo CpuInfoOther
        {
            get
            {
                if (this.ProcessorArchitecture == MiniDumpProcessorArchitecture.PROCESSOR_ARCHITECTURE_INTEL)
                    throw new InvalidOperationException("CpuInfoOther is not supported for x86 computers.");

                return _otherCpuInfo;
            }
        }
    }

    /// <summary>
    /// The CPU information obtained from the CPUID instruction. This structure is supported only for x86 computers.
    /// </summary>
    public class X86CpuInfo
    {
        private CPU_INFORMATION _cpuInfo;
        private uint[] _vendorIdRaw;
        private string _vendorId;

        internal unsafe X86CpuInfo(CPU_INFORMATION cpuInfo)
        {
            _cpuInfo = cpuInfo;

            _vendorIdRaw = new uint[3];
            _vendorIdRaw[0] = cpuInfo.VendorId[0];
            _vendorIdRaw[1] = cpuInfo.VendorId[1];
            _vendorIdRaw[2] = cpuInfo.VendorId[2];

            char[] vendorId = new char[12];

            GCHandle handle = GCHandle.Alloc(vendorId, GCHandleType.Pinned);

            try
            {
                ASCIIEncoding.ASCII.GetChars(cpuInfo.VendorId, 12, (char*)handle.AddrOfPinnedObject(), 12);

                _vendorId = new String(vendorId);
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        /// CPUID subfunction 0.
        /// </summary>
        /// <remarks>
        /// The array elements are as follows:
        /// <list type="bullet">
        /// <item>VendorId[0] is EAX</item>
        /// <item>VendorId[1] is EBX</item>
        /// <item>VendorId[2] is ECX</item>
        /// </list>
        /// </remarks>
        public uint[] VendorIdRaw { get { return _vendorIdRaw; } }

        /// <summary>
        /// CPUID subfunction 0 (the CPU's manufacturer ID string – a twelve-character ASCII string).
        /// </summary>
        public string VendorId { get { return this._vendorId; } }
        
        /// <summary>
        /// CPUID subfunction 1. Value of EAX.
        /// </summary>
        public uint VersionInformation { get { return _cpuInfo.VersionInformation; } }
        
        /// <summary>
        /// CPUID subfunction 1. Value of EDX.
        /// </summary>
        public uint FeatureInformation { get { return _cpuInfo.FeatureInformation; } }
        
        /// <summary>
        /// CPUID subfunction 80000001. Value of EBX. This member is supported only if the vendor is "AuthenticAMD".
        /// </summary>
        public uint AMDExtendedCpuFeatures { get { return _cpuInfo.AMDExtendedCpuFeatures; } }
    }

    /// <summary>
    /// Other CPU information. This structure is supported only for non-x86 computers.
    /// </summary>
    public class OtherCpuInfo
    {
        private CPU_INFORMATION _cpuInfo;
        private UInt64[] _processorFeatures;

        internal unsafe OtherCpuInfo(CPU_INFORMATION cpuInfo)
        {
            _cpuInfo = cpuInfo;

            _processorFeatures = new UInt64[2];
            _processorFeatures[0] = cpuInfo.ProcessorFeatures[0];
            _processorFeatures[1] = cpuInfo.ProcessorFeatures[1];
        }

        public UInt64[] ProcessorFeatures { get { return this._processorFeatures; } }
    }

    /// <summary>
    /// The system's processor architecture.
    /// </summary>
    public enum MiniDumpProcessorArchitecture
    {
        /// <summary>
        /// x86
        /// </summary>
        PROCESSOR_ARCHITECTURE_INTEL  = 0,
        /// <summary>
        /// Intel Itanium
        /// </summary>
        PROCESSOR_ARCHITECTURE_IA64  = 6,
        /// <summary>
        /// x64 (AMD or Intel)
        /// </summary>
        PROCESSOR_ARCHITECTURE_AMD64 = 9,
        /// <summary>
        /// Unknown processor
        /// </summary>
        PROCESSOR_ARCHITECTURE_UNKNOWN = 0xfff
    }

    /// <summary>
    /// The system's architecture-dependent processor level.
    /// </summary>
    public enum MiniDumpProcessorLevel 
    {
        /// <summary>
        /// Intel 80386
        /// </summary>
        Intel_80386 = 3,
        /// <summary>
        /// Intel 80486
        /// </summary>
        Intel_80486 = 4,
        /// <summary>
        /// Intel Pentium
        /// </summary>
        Intel_Pentium = 5,
        /// <summary>
        /// Intel Pentium Pro or Pentium II
        /// </summary>
        Intel_Pentium_Pro_or_Pentium_II = 6
    }

    /// <summary>
    /// Any additional information about the system.
    /// </summary>
    public enum MiniDumpProductType
    {
        /// <summary>
        /// The system is running Windows XP, Windows Vista, Windows 7, or Windows 8.
        /// </summary>
        VER_NT_WORKSTATION = 0x0000001,
        /// <summary>
        /// The system is a domain controller.
        /// </summary>
        VER_NT_DOMAIN_CONTROLLER = 0x0000002,
        /// <summary>
        /// The system is a server.
        /// </summary>
        VER_NT_SERVER = 0x0000003
    }

    /// <summary>
    /// The operating system platform.
    /// </summary>
    public enum MiniDumpPlatform
    {
        /// <summary>
        /// Not supported.
        /// </summary>
        VER_PLATFORM_WIN32s = 0,
        /// <summary>
        /// Not supported.
        /// </summary>
        VER_PLATFORM_WIN32_WINDOWS = 1,
        /// <summary>
        /// The operating system platform is Windows.
        /// </summary>
        VER_PLATFORM_WIN32_NT = 2
    }
}
