using System.ComponentModel.DataAnnotations;

namespace GerenciadorCertificados.Models.DTOs

{
    public class LoginDTO
    {

        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
