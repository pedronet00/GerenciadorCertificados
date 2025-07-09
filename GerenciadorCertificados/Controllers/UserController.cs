using GerenciadorCertificados.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciadorCertificados.Models;
using GerenciadorCertificados.Models.DTOs;
using GerenciadorCertificados.Services.Contracts;

namespace GerenciadorCertificados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<IEnumerable<Usuario>> ListarUsuarios()
        {
            var users = _service.ListarUsuarios();

            return Ok(users);
        }


        [HttpPost]
        public ActionResult Post([FromBody] UserRegisterDTO novoUser)
        {
            _service.InserirUsuario(novoUser);
            return Ok(novoUser);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            try
            {
                var usuario = _service.BuscaPorEmail(login.Email);

                if (usuario == null || !BCrypt.Net.BCrypt.Verify(login.Senha, usuario.Senha))
                {
                    return Unauthorized("Credenciais inválidas.");
                }

                var token = _service.GerarToken(usuario);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }




    }
}
