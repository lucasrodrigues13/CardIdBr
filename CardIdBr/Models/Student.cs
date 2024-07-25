using System.ComponentModel.DataAnnotations;

namespace CardIdBr.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Rg { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string InstituitionName { get; set; }
        [Required]
        public string Course { get; set; }
        [Required]
        public string SchoolLevel { get; set; }
    }
}
