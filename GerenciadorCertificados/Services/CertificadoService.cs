using GerenciadorCertificados.Models;
using GerenciadorCertificados.Models.DTOs;
using GerenciadorCertificados.Repositories.Contracts;
using GerenciadorCertificados.Services.Contracts;

namespace GerenciadorCertificados.Services
{
    public class CertificadoService : ICertificadoService
    {
        private readonly ICertificadoRepository _repo;

        public CertificadoService(ICertificadoRepository repo)
        {
            _repo = repo;
        }

        public void AtualizarCertificado(string uuid, CertificadoUpdateDTO certificado)
        {
            _repo.AtualizarCertificado(uuid, certificado);
        }

        public void ExcluirCertificado(string uuid)
        {
            _repo.ExcluirCertificado(uuid);
        }

        public Certificado FindCertificado(string uuid)
        {
            return _repo.FindCertificado(uuid);
        }

        public IEnumerable<CertificadoDTO> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }


        public void InserirCertificado(CertificadoUploadDTO dto)
        {
            if (dto.Arquivo == null || dto.Arquivo.Length == 0)
                throw new Exception("Arquivo inválido.");

            var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(dto.Arquivo.FileName);
            var caminho = Path.Combine("Certificados", nomeArquivo);

            if (!Directory.Exists("Certificados"))
                Directory.CreateDirectory("Certificados");

            using (var stream = new FileStream(caminho, FileMode.Create))
            {
                dto.Arquivo.CopyTo(stream);
            }

            var certificado = new Certificado
            {
                TituloCertificado = dto.TituloCertificado,
                QuantidadeHoras = dto.QuantidadeHoras,
                AreaCertificado = dto.AreaCertificado,
                IdUsuario = dto.IdUsuario,
                ArquivoCertificado = caminho,
                Uuid = Guid.NewGuid().ToString()
            };

            _repo.InserirCertificado(certificado);
        }

        public IEnumerable<Certificado> ListarCertificados()
        {
            return _repo.ListarCertificados();
        }
    }
}
