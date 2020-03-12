using System.IO;
using System.Linq;

namespace FileManager
{
    class FileCleanUpService
    {
        private readonly IRule[] rules;

        public FileCleanUpService(IRule[] rules)
        {
            this.rules = rules;
        }

        public void CleanUp(string[] targetDirectories)
        {
            var files = (
                    from directory in targetDirectories
                    select new DirectoryInfo(directory).GetFiles()).
                SelectMany(x => x);

            foreach (var fileInfo in files)
            {
                foreach (var rule in rules)
                {
                    if (rule.IsAppliable(fileInfo))
                    {
                        rule.Execute(fileInfo);
                        break;
                    }
                }
            }
        }
    }
}