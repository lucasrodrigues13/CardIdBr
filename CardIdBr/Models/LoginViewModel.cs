using CardIdBr.Util;
using System.ComponentModel.DataAnnotations;

namespace CardIdBr.Models
{
    public class LoginViewModel
    {
        [DefaultRequired, EmailAddress(ErrorMessage = "Email Inválido")]
        public string? Email { get; set; }
        [DefaultRequired, DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
