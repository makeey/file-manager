using System.Collections.Generic;

namespace FileManager
{
    /// <summary>
    /// Files with extension .pdf .doc .ptt .txt will be moved to the target directory
    /// </summary>
    class DocumentRule : Rule
    {
        public DocumentRule(string targetDir) : base(targetDir) { }

        protected override IEnumerable<string> GetExtension()
        {
            return new[] { ".pdf", ".doc", ".ptt", ".txt" };
        }
    }
}