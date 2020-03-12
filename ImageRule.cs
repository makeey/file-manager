using System.Collections.Generic;

namespace FileManager
{
    class ImageRule : Rule
    {
        public ImageRule(string imageDir) : base(imageDir) { }

        protected override IEnumerable<string> GetExtension()
        {
            return new string[] { ".jpg", ".png", ".gif" };
        }
    }
}