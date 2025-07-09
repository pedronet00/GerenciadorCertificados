using GerenciadorCertificados.Models;

namespace GerenciadorCertificados.Repositories.Contracts
{
    public interface IAreasCertificados
    {
        IEnumerable<AreasCertificados> List();

        void InserirAreaCertificado(AreasCertificados area);
    }
}
