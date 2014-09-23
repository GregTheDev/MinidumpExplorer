using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    public class Formatters
    {
        public static string FormatAsSizeString(UInt32 size)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = size;
            int order = 0;

            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }

            return String.Format("{0:0.#} {1}", len, sizes[order]);
        }

        public static string FormatAsMemoryAddress(UInt64 address)
        {
            return String.Concat("0x", address.ToString("X8"));
        }
    }
}
