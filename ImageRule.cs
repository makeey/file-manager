using System.Collections.Generic;

namespace FileManager
{
    /// <summary>
    /// Move files with extensions: .jpg .png .gif to the target dirrectory
    /// </summary>
    class ImageRule : Rule
    {
        public ImageRule(string imageDir) : base(imageDir) { }

        protected override IEnumerable<string> GetExtension()
        {
            return new[] { ".jpg", ".png", ".gif" };
        }
    }
}