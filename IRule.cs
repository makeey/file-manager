using System.IO;

namespace FileManager
{
    interface IRule
    {
        bool IsAppliable(FileInfo file);
        void Execute(FileInfo file);
    }
}