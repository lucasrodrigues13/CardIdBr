using CardIdBr.Util.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CardIdBr.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [DefaultRequired, StringLength(500)]
        public string FullName { get; set; }

        [DefaultRequired, ValidEmail, StringLength(500)]
        public string Email { get; set; }

        [DefaultRequired, StringLength(15)]
        public string Cpf { get; set; }

        [DefaultRequired, StringLength(15)]
        public string Rg { get; set; }

        [DefaultRequired, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DefaultRequired, StringLength(500)]
        public string InstituitionName { get; set; }

        [DefaultRequired, StringLength(500)]
        public string Course { get; set; }

        [DefaultRequired, StringLength(30)]
        public string SchoolLevel { get; set; }

        [DefaultRequired, StringLength(15)]
        public string UseCode { get; set; }

        [DefaultRequired, StringLength(500)]
        public string ImagePath { get; set; }
    }
}
