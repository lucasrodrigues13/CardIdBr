using CardIdBr.Util.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CardIdBr.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(500)]
        public string FullName { get; set; }

        [Required, ValidEmail, StringLength(500)]
        public string Email { get; set; }

        [Required, StringLength(15)]
        public string Cpf { get; set; }

        [Required, StringLength(15)]
        public string Rg { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Validate { get; set; }

        [Required, StringLength(500)]
        public string InstituitionName { get; set; }

        [Required, StringLength(500)]
        public string Course { get; set; }

        [Required, StringLength(30)]
        public string SchoolLevel { get; set; }

        [Required, StringLength(15)]
        public string UseCode { get; set; }

        [Required, StringLength(500)]
        public string ImagePath { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }
    }
}
