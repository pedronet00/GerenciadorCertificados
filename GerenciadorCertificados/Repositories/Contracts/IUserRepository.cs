using GerenciadorCertificados.Models;

namespace GerenciadorCertificados.Repositories.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<Usuario> ListarUsuarios();

        void InserirUsuario(Usuario usuario);

        Usuario FindUsuario(string uuid);

        void AtualizarUsuario(string uuid, Usuario usuario);

        void ExcluirUsuario(string uuid);

        Usuario BuscaPorEmail(string email);
    }
}
