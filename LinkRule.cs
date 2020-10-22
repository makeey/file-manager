using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    /// <summary>
    /// Remove link from the soft directories, the link rule mark as soft on purpose
    /// because you can create a new link at any time 
    /// </summary>
    class LinkRule : ISoftRule
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