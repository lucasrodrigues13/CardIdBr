using CardIdBr.Entities;
using CardIdBr.Models.Student;

namespace CardIdBr.Util.Image
{
    public class ImageManager : IImageManager
    {
        private readonly string _webRootPath;
        public ImageManager(IWebHostEnvironment env)
        {
            _webRootPath = env.WebRootPath;
        }
        public byte[] GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public string SaveUserImage(StudentViewModel student)
        {
            var name = $"{student.Email}_{student.Id}";
            var path = $"{_webRootPath}\\photos";
            var fullPath = $"{path}\\{name}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            using (var stream = File.Create(fullPath))
            {
                student.Photo.CopyToAsync(stream);
            }

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
