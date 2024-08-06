using CardIdBr.Entities;
using CardIdBr.Models.Student;
using System.Collections;

namespace CardIdBr.Util.Image
{
    public class ImageManager : IImageManager
    {
        private readonly string _webRootPath;
        public ImageManager(IWebHostEnvironment env)
        {
            _webRootPath = env.WebRootPath;
        }
        public string GetByPath(string path)
        {
            var file = File.ReadAllBytes(path);
            return Convert.ToBase64String(file);
        }

        public string SaveUserImage(StudentViewModel student)
        {
            var name = $"{student.Id}.{student.Image.FileName.Split('.').Last()}";
            var path = $"{_webRootPath}\\photos\\{student.Email}";
            var fullPath = $"{path}\\{name}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            var base64Data = student.ImageCroppedBase64.Substring(student.ImageCroppedBase64.IndexOf(',') + 1);
            var imageBytes = Convert.FromBase64String(base64Data);

            File.WriteAllBytes(fullPath, imageBytes);

            return fullPath;
        }

        public bool ValidImage(IFormFile formFile)
        {
            switch (formFile.ContentType)
            {
                case "image/jpeg":
                case "image/png":
                    return true;
                default:
                    return false;
            }
        }
    }
}
