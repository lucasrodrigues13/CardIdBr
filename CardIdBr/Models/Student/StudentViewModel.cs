using System.ComponentModel.DataAnnotations;

namespace CardIdBr.Models.Student
{
    public class StudentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(500), Display(Name = "Nome Completo")]
        public string FullName { get; set; }

        [Required, EmailAddress, StringLength(500)]
        public string Email { get; set; }

        [Required, StringLength(15)]
        public string Cpf { get; set; }

        [Required, StringLength(15)]
        public string Rg { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required, StringLength(500)]
        public string InstituitionName { get; set; }

        [Required, StringLength(500)]
        public string Course { get; set; }

        [Required, StringLength(30)]
        public string SchoolLevel { get; set; }

        [Required, StringLength(15)]
        public string UseCode { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        public string? QrCode { get; set; }
    }
}
