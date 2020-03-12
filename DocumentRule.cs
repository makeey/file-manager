using System.Collections.Generic;

namespace FileManager
{
    class DocumentRule : Rule
    {
        public DocumentRule(string targetDir) : base(targetDir) { }

        protected override IEnumerable<string> GetExtension()
        {
            return new string[] { ".pdf", ".doc", ".ptt", ".txt" };
        }
    }
}