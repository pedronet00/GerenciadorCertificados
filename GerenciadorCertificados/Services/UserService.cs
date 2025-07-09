using BCrypt.Net;
using GerenciadorCertificados.Repositories.Contracts;
using GerenciadorCertificados.Services.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GerenciadorCertificados.Models;
using GerenciadorCertificados.Repositories.Contracts;
using GerenciadorCertificados.Services.Contracts;
using GerenciadorCertificados.Models.DTOs;

namespace GerenciadorCertificados.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public UserService(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public void InserirUsuario(UserRegisterDTO usuario)
        {
            var user = new Usuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha),
                Uuid = this.GerarUuid()
            };

            _repo.InserirUsuario(user);
        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            return _repo.ListarUsuarios();
        }

        public string GerarToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim("UserId", usuario.Id.ToString())
        }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Usuario BuscaPorEmail(string email)
        {
            return _repo.BuscaPorEmail(email);
        }

        public string GerarUuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
