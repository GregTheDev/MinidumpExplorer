using DbgHelp.MinidumpFiles.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// Specifies a date and time.
    /// </summary>
    /// <remarks>
    /// <para>
    /// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms724950%28v=vs.85%29.aspx for additional information.
    /// </para>
    /// </remarks>
    public sealed class Win32SystemTime
    {
        private SYSTEMTIME _systemTime;

        internal Win32SystemTime(SYSTEMTIME systemTime)
        {
            _systemTime = systemTime;
        }

        public override string ToString()
        {
            return String.Format("wYear: {0}, wMonth: {1}, wDayOfWeek: {2}, wDay: {3}, wHour: {4}, wMinute: {5}, wSecond: {6}, wMilliseconds: {7}",
                Year, Month, DayOfWeek, Day, Hour, Minute, Second, Milliseconds);
        }

        public ushort Year { get { return _systemTime.wYear; } }
        public ushort Month { get { return _systemTime.wMonth; } }
        public ushort DayOfWeek { get { return _systemTime.wDayOfWeek; } }
        public ushort Day { get { return _systemTime.wDay; } }
        public ushort Hour { get { return _systemTime.wHour; } }
        public ushort Minute { get { return _systemTime.wMinute; } }
        public ushort Second { get { return _systemTime.wSecond; } }
        public ushort Milliseconds { get { return _systemTime.wMilliseconds; } }
    }
}
