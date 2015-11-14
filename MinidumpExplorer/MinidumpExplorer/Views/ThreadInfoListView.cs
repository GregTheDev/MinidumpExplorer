using DbgHelp.MinidumpFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinidumpExplorer.Views
{
    public partial class ThreadInfoListView : BaseViewControl
    {
        private MiniDumpThreadInfo[] _threadInfoList;

        public ThreadInfoListView()
        {
            InitializeComponent();
        }

        public ThreadInfoListView(MiniDumpThreadInfo[] threadInfoList)
            : this()
        {
            _threadInfoList = threadInfoList;

            if (_threadInfoList.Length == 0)
            {
                this.listView1.Items.Add("No data found for stream");
            }
            else
            {
                foreach (MiniDumpThreadInfo thread in _threadInfoList)
                {
                    ListViewItem newItem = new ListViewItem("0x" + thread.ThreadId.ToString("x8") + " (" + thread.ThreadId + ")");
                    newItem.SubItems.Add(thread.DumpFlags.ToString());
                    newItem.SubItems.Add("0x" + thread.DumpError.ToString("x8"));
                    newItem.SubItems.Add((thread.ExitStatus == MiniDumpThreadInfo.STILL_ACTIVE) ? "STILL_ACTIVE" : thread.ExitStatus.ToString());
                    newItem.SubItems.Add(thread.CreateTime.ToString());

                    if (thread.ExitTime == DateTime.MinValue)
                        newItem.SubItems.Add("");
                    else
                        newItem.SubItems.Add(thread.ExitTime.ToString());

                    newItem.SubItems.Add(FormattedTimeSpan(thread.KernelTime));
                    newItem.SubItems.Add(FormattedTimeSpan(thread.UserTime));
                    newItem.SubItems.Add("0x" + thread.StartAddress.ToString("x8"));
                    newItem.SubItems.Add(thread.Affinity.ToString());

                    newItem.Tag = thread;

                    this.listView1.Items.Add(newItem);
                }
            }
        }

        private string FormattedTimeSpan(TimeSpan timeSpan)
        {
            return timeSpan.ToString();

            //if (timeSpan.TotalMilliseconds < 1000)
            //    return String.Format("{0}ms", timeSpan.TotalMilliseconds);
            //else if (timeSpan.TotalSeconds < 60)
            //    return String.Format("{0}.{1}s", timeSpan.Seconds, timeSpan.Milliseconds);
            //else if (timeSpan.TotalMinutes < 60)
            //    return String.Format("{0}:{1}min", timeSpan.Minutes, timeSpan.Seconds);
            //else
            //    return timeSpan.ToString();
        }
    }
}
