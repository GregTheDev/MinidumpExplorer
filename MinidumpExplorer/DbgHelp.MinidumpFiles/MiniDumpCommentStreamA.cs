namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// The comment string that was written to the dump file.
    /// </summary>
    public class MiniDumpCommentStreamA
    {
        internal MiniDumpCommentStreamA()
        {
            this.Comment = null;
        }

        internal MiniDumpCommentStreamA(string comment)
        {
            this.Comment = comment;
        }

        public string Comment { get; private set; }
    }
}