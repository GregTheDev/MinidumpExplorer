using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    public class MiniDumpModule
    {
        private MINIDUMP_MODULE _module;
        private MiniDumpFile _owner;

        internal MiniDumpModule(MINIDUMP_MODULE module, MiniDumpFile owner)
        {
            _owner = owner;
            _module = module;
        }

        /// <summary>
        /// Returns the file name and extension of the module.
        /// </summary>
        public string FileName 
        { 
            get { return System.IO.Path.GetFileName(this.PathAndFileName); } 
        }

        /// <summary>
        /// Returns the directory information for the module.
        /// </summary>
        public string DirectoryName 
        { 
            get { return System.IO.Path.GetDirectoryName(this.PathAndFileName); } 
        }

        /// <summary>
        /// Returns the absolute path for the module (e.g. "C:\MyFile.txt").
        /// </summary>
        public string PathAndFileName 
        { 
            get { return _owner.ReadString(_module.ModuleNameRva); } 
        }

        /// <summary>
        /// The base address of the module executable image in memory.
        /// </summary>
        public ulong BaseOfImage 
        { 
            get { return _module.BaseOfImage; } 
        }

        /// <summary>
        /// The base address of the module executable image in memory formatted as "0x12345678".
        /// </summary>
        public string BaseOfImageFormatted
        {
            get { return String.Concat("0x", _module.BaseOfImage.ToString("x8")); }
        }

        /// <summary>
        /// The size of the module executable image in memory, in bytes.
        /// </summary>
        public int SizeOfImage
        {
            get { return (int)_module.SizeOfImage; }
        }

        /// <summary>
        /// The size of the module executable image in memory, in bytes, formatted as e.g. "32 KB", "15.8 MB" etc
        /// </summary>
        public string SizeOfImageFormatted
        {
            get
            {
                string[] sizes = { "B", "KB", "MB", "GB" };
                double len = this.SizeOfImage;
                int order = 0;
                while (len >= 1024 && order + 1 < sizes.Length)
                {
                    order++;
                    len = len / 1024;
                }

                return String.Format("{0:0.#} {1}", len, sizes[order]);
            }
        }

        /// <summary>
        /// The checksum value of the module executable image.
        /// </summary>
        public int CheckSum
        {
            get { return (int)_module.CheckSum; }
        }

        /// <summary>
        /// The timestamp value of the module executable image.
        /// </summary>
        public DateTime TimeDateStamp
        {
            get { return MiniDumpFile.TimeTToDateTime(_module.TimeDateStamp); }
        }

        /// <summary>
        /// The timestamp value of the module executable image, in time_t format.
        /// </summary>
        public uint TimeDateStampRaw { get { return _module.TimeDateStamp; } }

        /// <summary>
        /// The file's binary version number.
        /// </summary>
        public string FileVersion
        {
            get
            {
                return String.Format("{0}.{1}.{2}.{3}",
                    windows.HiWord(_module.VersionInfo.dwFileVersionMS),
                    windows.LoWord(_module.VersionInfo.dwFileVersionMS),
                    windows.HiWord(_module.VersionInfo.dwFileVersionLS),
                    windows.LoWord(_module.VersionInfo.dwFileVersionLS));
            }
        }

        /// <summary>
        /// The binary version number of the product with which this file was distributed. 
        /// </summary>
        public string ProductVersion
        {
            get
            {
                return String.Format("{0}.{1}.{2}.{3}",
                    windows.HiWord(_module.VersionInfo.dwProductVersionMS),
                    windows.LoWord(_module.VersionInfo.dwProductVersionMS),
                    windows.HiWord(_module.VersionInfo.dwProductVersionLS),
                    windows.LoWord(_module.VersionInfo.dwProductVersionLS));
            }
        }

        /// <summary>
        /// The file contains debugging information or is compiled with debugging features enabled.
        /// </summary>
        public bool IsDebug
        {
            get
            {
                return (_module.VersionInfo.dwFileFlags & windows.VS_FF_DEBUG) > 0;
            }
        }

        /// <summary>
        /// The file's version structure was created dynamically; therefore, some of the members in this structure may be empty or incorrect.
        /// </summary>
        public bool IsInfoInferred
        {
            get
            {
                return (_module.VersionInfo.dwFileFlags & windows.VS_FF_INFOINFERRED) > 0;
            }
        }

        /// <summary>
        /// The file has been modified and is not identical to the original shipping file of the same version number.
        /// </summary>
        public bool IsPatched
        {
            get
            {
                return (_module.VersionInfo.dwFileFlags & windows.VS_FF_PATCHED) > 0;
            }
        }

        /// <summary>
        /// The file is a development version, not a commercially released product.
        /// </summary>
        public bool IsPreRelease
        {
            get
            {
                return (_module.VersionInfo.dwFileFlags & windows.VS_FF_PRERELEASE) > 0;
            }
        }

        /// <summary>
        /// The file was not built using standard release procedures.
        /// </summary>
        public bool IsPrivateBuild
        {
            get
            {
                return (_module.VersionInfo.dwFileFlags & windows.VS_FF_PRIVATEBUILD) > 0;
            }
        }

        /// <summary>
        /// The file was built by the original company using standard release procedures but is a variation of the normal file of the same version number.
        /// </summary>
        public bool IsSpecialBuild
        {
            get
            {
                return (_module.VersionInfo.dwFileFlags & windows.VS_FF_SPECIALBUILD) > 0;
            }
        }

        /// <summary>
        /// The operating system for which this file was designed.
        /// </summary>
        public uint FileOS { get { return _module.VersionInfo.dwFileOS; } }

        /// <summary>
        /// The operating system for which this file was designed formatted as a user friendly string.
        /// </summary>
        /// <remarks>Examples include: MS-DOS, Windows NT, 16-bit Windows, 32-bit Windows etc.</remarks>
        /// <exception cref="NotSupportedException">Thrown if the FileOS is not recognised. This does not mean FileOS is invalid, merely that a description for it not known.</exception>
        public string FileOSFormatted
        {
            get
            {
                // Technically these values can be combined
                switch (_module.VersionInfo.dwFileOS)
                {
                    case windows.VOS_DOS: return "MS-DOS";
                    case windows.VOS_NT: return "Windows NT";
                    case windows.VOS__WINDOWS16: return "16-bit Windows";
                    case windows.VOS__WINDOWS32: return "32-bit Windows";
                    case windows.VOS_OS216: return "16-bit OS/2";
                    case windows.VOS_OS232: return "32-bit OS/2";
                    case windows.VOS__PM16: return "16-bit Presentation Manager";
                    case windows.VOS__PM32: return "32-bit Presentation Manager";

                    case windows.VOS_DOS_WINDOWS16: return "16-bit Windows running on MS-DOS";
                    case windows.VOS_DOS_WINDOWS32: return "32-bit Windows running on MS-DOS";
                    case windows.VOS_NT_WINDOWS32: return "Windows NT";
                    case windows.VOS_OS216_PM16: return "16-bit Presentation Manager running on 16-bit OS/2";
                    case windows.VOS_OS232_PM32: return "32-bit Presentation Manager running on 32-bit OS/2";

                    case windows.VOS_UNKNOWN: return "Unknown";
                    default:
                        throw new NotSupportedException("Unknown dwFileOS: '" + _module.VersionInfo.dwFileOS + "'.");
                }
            }
        }

        /// <summary>
        /// The general type of file.
        /// </summary>
        public uint FileType { get { return _module.VersionInfo.dwFileType; } }

        /// <summary>
        /// The general type of file formatted as a user friendly string.
        /// </summary>
        /// <remarks>Examples include: Application, DLL, Device driver, Font, Static-link library, Unknown and Virtual device.</remarks>
        /// <exception cref="NotSupportedException">Thrown if the FileType is not recognised. This does not mean FileType is invalid, merely that a description for it is not known.</exception>
        public string FileTypeFormatted
        {
            get
            {
                switch (_module.VersionInfo.dwFileType)
                {
                    case windows.VFT_APP: return "Application";
                    case windows.VFT_DLL: return "DLL";
                    case windows.VFT_DRV: return "Device driver";
                    case windows.VFT_FONT: return "Font";
                    case windows.VFT_STATIC_LIB: return "Static-link library";
                    case windows.VFT_UNKNOWN: return "Unknown";
                    case windows.VFT_VXD: return "Virtual device";
                    default:
                        throw new NotSupportedException("Unknown dwFileType: '" + _module.VersionInfo.dwFileType + "'.");
                }
            }
        }

        /// <summary>
        /// The function of the file. The possible values depend on the value of dwFileType.
        /// </summary>
        public uint FileSubType { get { return _module.VersionInfo.dwFileSubtype; } }

        /// <summary>
        /// The function of the file formatted as a user friendly string.
        /// </summary>
        /// <remarks>Examples include: Communications driver, Display driver, Raster font etc.</remarks>
        /// <exception cref="NotSupportedException">Thrown if the FileSubType is not recognised. This does not mean FileSubType is invalid, merely that a description for it is not known.</exception>
        public string FileSubTypeFormatted
        {
            get
            {
                if (_module.VersionInfo.dwFileType == windows.VFT_DRV)
                {
                    switch (_module.VersionInfo.dwFileSubtype)
                    {
                        case windows.VFT2_DRV_COMM: return "Communications driver";
                        case windows.VFT2_DRV_DISPLAY: return "Display driver";
                        case windows.VFT2_DRV_INSTALLABLE: return "Installable driver";
                        case windows.VFT2_DRV_KEYBOARD: return "Keyboard driver";
                        case windows.VFT2_DRV_LANGUAGE: return "Language driver";
                        case windows.VFT2_DRV_MOUSE: return "Mouse driver";
                        case windows.VFT2_DRV_NETWORK: return "Network driver";
                        case windows.VFT2_DRV_PRINTER: return "Printer driver";
                        case windows.VFT2_DRV_SOUND: return "Sound driver";
                        case windows.VFT2_DRV_SYSTEM: return "System driver";
                        case windows.VFT2_DRV_VERSIONED_PRINTER: return "Versioned printer driver";
                        case windows.VFT2_UNKNOWN: return "unknown ";
                        default:
                            throw new NotSupportedException("Unknown dwFileSubtype: '" + _module.VersionInfo.dwFileSubtype + "'.");
                    }
                }
                else if (_module.VersionInfo.dwFileType == windows.VFT_FONT)
                {
                    switch (_module.VersionInfo.dwFileSubtype)
                    {
                        case windows.VFT2_FONT_RASTER: return "Raster font";
                        case windows.VFT2_FONT_TRUETYPE: return "TrueType font";
                        case windows.VFT2_FONT_VECTOR: return "Vector font";
                        default:
                            throw new NotSupportedException("Lookup failed. Unknown dwFileSubtype: '" + _module.VersionInfo.dwFileSubtype + "'.");
                    }
                }
                else
                    return "";
            }
        }
    }
}
