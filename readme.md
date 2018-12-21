Minidump files contain a wealth of information allowing you to diagnose application crashes, thread deadlocks, performance problems, memory leaks etc.

Unfortunately there are not a lot of tools that provide access to the information stored in the dump files and those that do exist can be challenging to use at the best of times.

This application is the first step in creating a tool that provides a rich and powerful environment for visualizing and analyzing minidumps of processes running the CLR. The first step is getting access to the different data streams inside the file. The next step is interpreting that data and presenting it in a way that allows easy visualization and interaction in order to make problem solving intuitive and easy.

Follow [https://gregsplaceontheweb.wordpress.com](https://gregsplaceontheweb.wordpress.com) for details on PInvoke, using the DbgHelp library and more.

![Viewing the ModuleListStream](https://github.com/GregTheDev/MinidumpExplorer/blob/master/Images/Home_mde_main_window.png)

## Features
* Capture a customizable minidump of any running process
* View stream data contained within a minidump

## Stream availability (as at 18 December 2018)
| Stream | Progress |
| ----- | ----- |
| CommentStreamA | Not planned * |
| CommentStreamW | Planned for v0.7 |
| ExceptionStream | Released (v0.3) |
| FunctionTableStream | Not planned * |
| HandleDataStream | Released (v0.2) |
| HandleOperationListStream | Not planned * |
| [Memory64ListStream](http://gregsplaceontheweb.wordpress.com/2014/05/30/minidump-explorer-v0-2-reading-minidump-memoryliststream-and-memory64liststream) | Released (v0.2) |
| MemoryInfoListStream | Released (v0.3) |
| [MemoryListStream](http://gregsplaceontheweb.wordpress.com/2014/05/30/minidump-explorer-v0-2-reading-minidump-memoryliststream-and-memory64liststream) | Released (v0.2) |
| MiscInfoStream | Released (v0.4) |
| [ModuleListStream](http://gregsplaceontheweb.wordpress.com/2014/04/08/reading-minidump-files-part-3-of-4-reading-stream-data-returned-from-minidumpreaddumpstream/) | Released (v0.1) |
| SystemInfoStream | Released (v0.3) |
| SystemMemoryInfoView | Released (v0.6) |
| ThreadExListStream | Pending |
| ThreadInfoListStream | Released (v0.3) |
| ThreadListStream | Released (v0.2) |
| ThreadNamesList | Planned for v0.7 |
| UnloadedModuleListStream | Released (v0.4) |

*The following streams will not be added for now due to lack of available test data: CommentStreamA, FunctionTableStream and HandleOperationListStream. If any body has crash dumps containing any of these streams please tweet "greg_nagel".

