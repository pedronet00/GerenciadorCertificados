using GerenciadorCertificados.Models;
using GerenciadorCertificados.Models.DTOs;

namespace GerenciadorCertificados.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<Usuario> ListarUsuarios();

        void InserirUsuario(UserRegisterDTO usuario);

        Usuario BuscaPorEmail(string email);

        string GerarToken(Usuario usuario);

        string GerarUuid();
    }
}
