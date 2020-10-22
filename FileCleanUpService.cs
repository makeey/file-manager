using System;
using System.IO;
using System.Linq;

namespace FileManager
{
    class FileCleanUpService
    {
        private readonly ISoftRule[] softRules;
        private readonly IHardRule[] hardRules;
        public FileCleanUpService(ISoftRule[] rules, IHardRule[] hardRules)
        {
            this.hardRules = hardRules;
            softRules = rules;
        }

        /// <summary>
        /// Soft clean up means that files which are in the directories will be moved somewhere else, renamed, or untouched
        /// </summary>
        /// <param name="targetDirectories"> Array of directories which will be cleaned</param>
        public void SoftCleanUp(string[] targetDirectories)
        {
            var files = (
                    from directory in targetDirectories
                    select new DirectoryInfo(directory).GetFiles()).
                SelectMany(x => x);

            foreach (var fileInfo in files)
            {
                foreach (var rule in softRules)
                {
                    if (rule.IsAppliable(fileInfo))
                    {
                        try
                        {
                            rule.Execute(fileInfo);
                            break;
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Console.WriteLine($"Current process doesn't have access  {e.Message} \n File full path is {fileInfo.FullName}");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Hard clean up means that file in the directories could be deleted
        /// </summary>
        /// <param name="targetDirectories">Array of directories which will be cleaned</param>
        public void HardCleanUp(string[] targetDirectories)
        {
            var files = (from directory in targetDirectories
                         select new DirectoryInfo(directory).GetFiles()).SelectMany(x => x);
            foreach (var fileInfo in files)
            {
                foreach (var hardRule in hardRules)
                {
                    if (hardRule.IsAppliable(fileInfo))
                    {
                        try
                        {
                            hardRule.Execute(fileInfo);
                            break;
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
        }
    }
}