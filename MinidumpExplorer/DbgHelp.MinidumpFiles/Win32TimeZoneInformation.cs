using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbgHelp.MinidumpFiles.Native;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Specifies settings for a time zone.
    /// </summary>
    /// <remarks>
    /// <para>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms725481%28v=vs.85%29.aspx for additional information.
    /// </para>
    /// <para>
    /// This class represents similar information to that contained in <see cref="System.TimeZoneInfo"/>. <see cref="System.TimeZoneInfo"/> does not 
    /// provide an easy (and public) way to be instantiated with the information available in TIME_ZONE_INFORMATION. As a 
    /// result Win32TimeZoneInformation was created as a wrapper for TIME_ZONE_INFORMATION instead of reusing <see cref="System.TimeZoneInfo"/>.
    /// </para>
    /// </remarks>
    public sealed class Win32TimeZoneInformation
    {
        private TIME_ZONE_INFORMATION _timeZoneInformation;
        private Win32SystemTime _standardDate;
        private Win32SystemTime _daylightDate;

        internal Win32TimeZoneInformation(TIME_ZONE_INFORMATION timeZoneInformation)
        {
            _timeZoneInformation = timeZoneInformation;

            // StandardDate & DaylightDate are not simple date/time structures. They actually encode a relative
            // or absolute date/time when the switch to/from daylight savings occurs (if the timezone even
            // supports day light savings). As such don't try and convert them to System.DateTime's.
            _standardDate = new Win32SystemTime(_timeZoneInformation.StandardDate);
            _daylightDate = new Win32SystemTime(_timeZoneInformation.DaylightDate);
        }

        /// <summary>
        /// The current bias for local time translation on this computer, in minutes.
        /// </summary>
        /// <remarks>
        /// The bias is the difference, in minutes, between Coordinated Universal Time (UTC) and local time. All translations between UTC and 
        /// local time are based on the following formula:
        /// <para>
        /// UTC = local time + bias
        /// </para>
        /// <para>
        /// This member is required.
        /// </para>
        public int Bias { get { return _timeZoneInformation.Bias; } }
        /// <summary>
        /// A description for standard time. For example, "EST" could indicate Eastern Standard Time. The string will be returned unchanged by the GetTimeZoneInformation function. This string can be empty.
        /// </summary>
        public string StandardName { get { return _timeZoneInformation.StandardName; } }

        /// <summary>
        /// A <see cref="DbgHelp.MinidumpFiles.Win32SystemTime"/> that contains a date and local time when the transition from daylight saving time to standard time occurs on this operating system. 
        /// </summary>
        /// <remarks>
        /// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms725481%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396 for details on how to decode this value.
        /// </remarks>
        public Win32SystemTime StandardDate { get { return _standardDate; } }

        /// <summary>
        /// The bias value to be used during local time translations that occur during standard time. 
        /// </summary>
        /// <remarks>
        /// This value is added to the value of the Bias member to form the bias used during standard time. In most time zones, the value of this member is zero.
        /// </remarks>
        public int StandardBias { get { return _timeZoneInformation.StandardBias; } }
        /// <summary>
        /// A description for daylight saving time. For example, "PDT" could indicate Pacific Daylight Time.
        /// </summary>
        /// <remarks>
        ///  The string will be returned unchanged by the GetTimeZoneInformation function. This string can be empty.
        ///  </remarks>
        public string DaylightName { get { return _timeZoneInformation.DaylightName; } }

        /// <summary>
        /// A <see cref="DbgHelp.MinidumpFiles.Win32SystemTime"/> that contains a date and local time when the transition from standard time to daylight saving time occurs on this operating system. 
        /// </summary>
        /// <remarks>
        /// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms725481%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396 for details on how to decode this value.
        /// </remarks>
        public Win32SystemTime DaylightDate { get { return _daylightDate; } }
        
        /// <summary>
        /// The bias value to be used during local time translations that occur during daylight saving time.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This member is ignored if a value for the DaylightDate member is not supplied.
        /// </para>
        /// <para>
        /// This value is added to the value of the Bias member to form the bias used during daylight saving time. In most time zones, the value of this member is –60.
        /// </para>
        /// </remarks>
        public int DaylightBias { get { return _timeZoneInformation.DaylightBias; } }
    }
}
