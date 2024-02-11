
namespace Core.Utilities.Helpers.FileHelper.Constants
{
    public static class FilePath
    {
        public static string Full(string path, string root = FileType.root, string fileType = FileType.images)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), root + fileType, path);
        }
    }
}
