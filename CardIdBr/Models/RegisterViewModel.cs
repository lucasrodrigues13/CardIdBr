using CardIdBr.Util;
using System.ComponentModel.DataAnnotations;

namespace CardIdBr.Models
{
    public class RegisterViewModel
    {
        [DefaultRequired, EmailAddress(ErrorMessage = "Email Inválido")]
        public string? Email { get; set; }
        [DefaultRequired, DataType(DataType.Password)]
        public string? Password { get; set; }

        [DefaultRequired, DataType(DataType.Password),
            Compare("Password", ErrorMessage = "As senhas não conferem"),
            Display(Name = "Confirme a Senha")]
        public string? ConfirmPassword { get; set; }
    }
}
