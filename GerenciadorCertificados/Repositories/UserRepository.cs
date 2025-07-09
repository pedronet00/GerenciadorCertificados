using GerenciadorCertificados.Repositories.Contracts;
using System;
using GerenciadorCertificados.Data;
using GerenciadorCertificados.Models;
using GerenciadorCertificados.Repositories.Contracts;

namespace GerenciadorCertificados.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AtualizarUsuario(string uuid, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscaPorEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public void ExcluirUsuario(string uuid)
        {
            var usuario = this.FindUsuario(uuid);

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public Usuario FindUsuario(string uuid)
        {
            return _context.Usuario.FirstOrDefault(x => x.Uuid == uuid);
        }

        public void InserirUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            return _context.Usuario.ToList();
        }
    }
}
