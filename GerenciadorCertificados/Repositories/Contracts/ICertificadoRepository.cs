using GerenciadorCertificados.Models;
using GerenciadorCertificados.Models.DTOs;

namespace GerenciadorCertificados.Repositories.Contracts
{
    public interface ICertificadoRepository
    {
        void InserirCertificado(Certificado certificado);

        IEnumerable<CertificadoDTO> GetByUserId(string userUuid);

        IEnumerable<Certificado> ListarCertificados();

        Certificado FindCertificado(string uuid);

        void ExcluirCertificado(string uuid);

        void AtualizarCertificado(string uuid, CertificadoUpdateDTO certificado);
    }
}
