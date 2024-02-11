using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Add(IFormFile file);
        void Delete(string path);
        void Update(IFormFile file, string imagePath);
    }
}
