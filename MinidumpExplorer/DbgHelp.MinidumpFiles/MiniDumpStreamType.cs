using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbgHelp.MinidumpFiles
{
    public enum MiniDumpStreamType
    {
        UnusedStream = 0,
        ReservedStream0 = 1,
        ReservedStream1 = 2,
        ThreadListStream = 3,
        ModuleListStream = 4,
        MemoryListStream = 5,
        ExceptionStream = 6,
        SystemInfoStream = 7,
        ThreadExListStream = 8,
        Memory64ListStream = 9,
        CommentStreamA = 10,
        CommentStreamW = 11,
        HandleDataStream = 12,
        FunctionTableStream = 13,
        UnloadedModuleListStream = 14,
        MiscInfoStream = 15,
        MemoryInfoListStream = 16,
        ThreadInfoListStream = 17,
        HandleOperationListStream = 18,

        TokenStream = 19,
        JavaScriptDataStream = 20,
        SystemMemoryInfoStream = 21,
        ProcessVmCountersStream = 22,

        ThreadNamesStream = 24,

        LastReservedStream = 0xffff
    }
}
