using GerenciadorCertificados.Models;
using GerenciadorCertificados.Models.DTOs;
using GerenciadorCertificados.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorCertificados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificadosController : ControllerBase
    {
        private readonly ICertificadoService _service;

        public CertificadosController(ICertificadoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CertificadoUploadDTO dto)
        {
            _service.InserirCertificado(dto);
            return Ok("Certificado enviado com sucesso.");
        }

        [HttpGet("/certificado/{uuid}")]
        public Certificado GetCertificado(string uuid)
        {
            return _service.FindCertificado(uuid);
        }

        [HttpPut("{uuid}")]
        public IActionResult AtualizarCertificado(string uuid, [FromBody] CertificadoUpdateDTO certificadoDTO)
        {
            _service.AtualizarCertificado(uuid, certificadoDTO);

            return Ok("Certificado atualizado.");
        }

        [HttpDelete("{uuid}")]
        public IActionResult ExcluirCertificado(string uuid)
        {
            _service.ExcluirCertificado(uuid);

            return Ok("Certificado excluído com sucesso.");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Certificado>> Get()
        {
            var lista = _service.ListarCertificados();
            return Ok(lista);
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<Certificado>> GetByUserId(string userId)
        {
            var lista = _service.GetByUserId(userId);
            return Ok(lista);
        }
    }
}
