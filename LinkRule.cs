using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    class LinkRule : IRule
    {
        private IEnumerable<string> GetExtension()
        {
            return new[] { ".lnk", ".url", };
        }

        public bool IsAppliable(FileInfo file)
        {
            return GetExtension().Contains(file.Extension);
        }

        public void Execute(FileInfo file)
        {
            File.Delete(file.FullName);
        }

    }
}