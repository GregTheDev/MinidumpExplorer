using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles.Native
{
    /*
    typedef struct _TIME_ZONE_INFORMATION {
        LONG Bias;
        WCHAR StandardName[ 32 ];
        SYSTEMTIME StandardDate;
        LONG StandardBias;
        WCHAR DaylightName[ 32 ];
        SYSTEMTIME DaylightDate;
        LONG DaylightBias;
    } TIME_ZONE_INFORMATION, *PTIME_ZONE_INFORMATION, *LPTIME_ZONE_INFORMATION;
     */
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet=CharSet.Unicode)]
    internal struct TIME_ZONE_INFORMATION
    {
        public int Bias;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
        public string StandardName; //WCHAR StandardName[ 32 ];
        public SYSTEMTIME StandardDate;
        public int StandardBias;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DaylightName; //WCHAR DaylightName[ 32 ];
        public SYSTEMTIME DaylightDate;
        public int DaylightBias;
    }
}
