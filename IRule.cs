using System.IO;

namespace FileManager
{
    interface IRule
    {
        /// <summary>
        /// Check if rule can be applied to the file
        /// </summary>
        /// <param name="file">File which will be checked</param>
        /// <returns></returns>
        bool IsAppliable(FileInfo file);
        /// <summary>
        /// Apply rule to the file
        /// </summary>
        /// <param name="file">File which will be affected</param>
        void Execute(FileInfo file);
    }

    /// <summary>
    /// Soft rule have to not delete the file, only move or rename,
    /// in other words the action during soft rule have to be revertable
    /// </summary>
    interface ISoftRule : IRule
    {
    }
    /// <summary>
    /// Hard rule could delete file, change the content
    /// in other words the action could be not revertable
    /// </summary>
    interface IHardRule : IRule
    {
    }
}