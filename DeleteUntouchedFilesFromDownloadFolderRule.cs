using System;
using System.IO;

namespace FileManager
{
    class DeleteUntouchedFilesFromDownloadFolderRule : IHardRule
    {
        public bool IsAppliable(FileInfo file)
        {
            return file != null && file.Directory?.Name == "Downloads" &&
                   Math.Abs((DateTime.Now - file.LastAccessTime).TotalDays) > 30.0;
        }

        public void Execute(FileInfo file)
        {
            File.Delete(file.FullName);
        }
    }
}
