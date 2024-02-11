using Core.Utilities.Helpers.FileHelper.Constants;
using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Add(IFormFile file)
        {
            //Dosyanın uzantısını al
            string fileExtension = Path.GetExtension(file.FileName);
            //Guid ile uzantıyı birleştir
            string uniqueFileName = GuidHelper_.Create() + fileExtension;
            //Kaydetmek istenilen yerin tam yolunu al
            var imagePath = FilePath.Full(uniqueFileName);
            using FileStream fileStream = new FileStream(imagePath, FileMode.Create); //FileMode.Create => İşletim sisteminin yeni bir dosya oluşturması gerektiğini belirtir. Dosya zaten mevcutsa, üzerine yazılacaktır.
            file.CopyTo(fileStream); //yola kopyala
            fileStream.Flush(); //ara belleği temizle
            return uniqueFileName;
        }

        public void Delete(string path)
        {
            //Klasörde dosyanın olup olmadığı kontrolü
            if (File.Exists(FilePath.Full(path)))
            {
                File.Delete(FilePath.Full(path));
            }
            else
            {
                throw new DirectoryNotFoundException(Messages.FileNotFound);
            }
        }

        public void Update(IFormFile file, string imagePath)
        {
            //Bu kısımda var olan guid i silip eklemek yerine guid yapısı aynı kalıp dosya değiştirilmekte.
            var fullPath = FilePath.Full(imagePath);
            if (File.Exists(fullPath))
            {
                using FileStream fileStream = new FileStream(fullPath, FileMode.Create); //FileMode.Create burada üzerine yazma işlemi yapar.
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            else
            {
                throw new DirectoryNotFoundException(Messages.FileNotFound);
            }
        }
    }
}