using CardIdBr.Models.Student;

namespace CardIdBr.Util.Image
{
    public interface IImageManager
    {
        public byte[] GetByEmail(string email);
        public string SaveUserImage(StudentViewModel student);
        public bool ValidImage(IFormFile formFile);
    }
}
