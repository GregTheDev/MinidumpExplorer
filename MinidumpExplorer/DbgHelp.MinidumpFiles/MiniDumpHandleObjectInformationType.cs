using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    public enum MiniDumpHandleObjectInformationType
    {
        MiniHandleObjectInformationNone,
        MiniThreadInformation1,
        MiniMutantInformation1,
        MiniMutantInformation2,
        MiniProcessInformation1,
        MiniProcessInformation2,
        MiniEventInformation1,
        MiniSectionInformation1,
        MiniHandleObjectInformationTypeMax
    }
}
