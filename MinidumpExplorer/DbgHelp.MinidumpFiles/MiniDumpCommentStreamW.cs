namespace DbgHelp.MinidumpFiles
{
    /// <summary>
    /// The comment string that was written to the dump file.
    /// </summary>
    public class MiniDumpCommentStreamW
    {
        internal MiniDumpCommentStreamW()
        {
            this.Comment = null;
        }

        internal MiniDumpCommentStreamW(string comment)
        {
            this.Comment = comment;
        }

        public string Comment { get; private set; }
    }
}
