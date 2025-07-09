using GerenciadorCertificados.Models.DTOs;
using GerenciadorCertificados.Models;

namespace GerenciadorCertificados.Services.Contracts
{
    public interface ICertificadoService
    {
        void InserirCertificado(CertificadoUploadDTO dto);
        IEnumerable<Certificado> ListarCertificados();

        IEnumerable<CertificadoDTO> GetByUserId(string userId);

        Certificado FindCertificado(string uuid);

        void ExcluirCertificado(string uuid);

        void AtualizarCertificado(string uuid, CertificadoUpdateDTO certificado);

    }
}
