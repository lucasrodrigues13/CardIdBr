using CardIdBr.Util.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CardIdBr.Models.Student
{
    public class StudentViewModel
    {
        [Key]
        public int Id { get; set; }

        [DefaultRequired, StringLength(500), Display(Name = "Nome Completo")]
        public string FullName { get; set; }

        [DefaultRequired, EmailAddress(ErrorMessage = "Email Inválido"), StringLength(500)]
        public string Email { get; set; }

        [DefaultRequired, StringLength(15)]
        public string Cpf { get; set; }

        [DefaultRequired, StringLength(15)]
        public string Rg { get; set; }

        [DefaultRequired, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        //public string? BirthDateText { get { return BirthDate.ToString("dd/MM/yyyy"); } }

        [DataType(DataType.Date)]
        public DateTime? Validate { get; set; }
        //public string? ValidateText { get { return Validate.Value.ToString("dd/MM/yyyy"); } }

        [DefaultRequired, StringLength(500)]
        public string InstituitionName { get; set; }

        [DefaultRequired, StringLength(500)]
        public string Course { get; set; }

        [DefaultRequired, StringLength(30)]
        public string SchoolLevel { get; set; }

        [DefaultRequired, StringLength(15)]
        public string UseCode { get; set; }

        [DefaultRequired]
        public IFormFile Image { get; set; }
        public string ImageCroppedBase64 { get; set; }

        public string? QrCode { get; set; }
        public string? ImagePath { get; set; }
    }
}
