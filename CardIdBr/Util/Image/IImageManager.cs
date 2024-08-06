using CardIdBr.Models.Student;

namespace CardIdBr.Util.Image
{
    public interface IImageManager
    {
        public string GetByPath(string path);
        public string SaveUserImage(StudentViewModel student);
        public bool ValidImage(IFormFile formFile);
    }
}
