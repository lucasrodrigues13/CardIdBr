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

        [DefaultRequired, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [DefaultRequired, StringLength(500)]
        public string InstituitionName { get; set; }

        [DefaultRequired, StringLength(500)]
        public string Course { get; set; }

        [DefaultRequired, StringLength(30)]
        public string SchoolLevel { get; set; }

        [DefaultRequired, StringLength(15)]
        public string UseCode { get; set; }

        [DefaultRequired]
        public IFormFile Photo { get; set; }

        public string? QrCode { get; set; }
    }
}
