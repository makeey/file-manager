using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    abstract class Rule : IRule
    {
        private readonly string targetDir;

        protected Rule(string targetDir)
        {
            this.targetDir = targetDir;
        }

        protected abstract IEnumerable<string> GetExtension();

        public bool IsAppliable(FileInfo file)
        {
            return GetExtension().Contains(file.Extension);
        }

        public virtual void Execute(FileInfo file)
        {
            File.Move(file.FullName, targetDir +
                                     "\\" +
                                     DateTime.Now.ToString("MM-dd-yyyy") +
                                     file.Name);
        }
    }
}