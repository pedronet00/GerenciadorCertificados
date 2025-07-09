using System.ComponentModel.DataAnnotations;

namespace GerenciadorCertificados.Models.DTOs

{
    public class UserRegisterDTO
    {
        public string Nome { get; set; }

        public DateOnly DataNascimento { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
