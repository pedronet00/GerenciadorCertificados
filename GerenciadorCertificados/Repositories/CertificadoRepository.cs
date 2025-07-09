using GerenciadorCertificados.Data;
using GerenciadorCertificados.Models;
using GerenciadorCertificados.Models.DTOs;
using GerenciadorCertificados.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GerenciadorCertificados.Repositories
{
    public class CertificadoRepository : ICertificadoRepository
    {
        private readonly AppDbContext _context;

        public CertificadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AtualizarCertificado(string uuid, CertificadoUpdateDTO certificado)
        {
            var _certificado = this.FindCertificado(uuid);

            _certificado.AreaCertificado = certificado.AreaCertificado;
            _certificado.TituloCertificado = certificado.TituloCertificado;
            _certificado.QuantidadeHoras = certificado.QuantidadeHoras;
            _certificado.ArquivoCertificado = certificado.ArquivoCertificado;
            _context.SaveChanges();


        }

        public void ExcluirCertificado(string uuid)
        {
            var certificado = this.FindCertificado(uuid);

            _context.Certificado.Remove(certificado);
            _context.SaveChanges();
        }

        public Certificado FindCertificado(string uuid)
        {
            return _context.Certificado.FirstOrDefault(x => x.Uuid == uuid);
        }

        public IEnumerable<CertificadoDTO> GetByUserId(string userUuid)
        {
            return _context.Certificado
                .Include(c => c.Usuario)
                .Where(c => c.Usuario.Uuid == userUuid)
                .Select(c => new CertificadoDTO
                {
                    TituloCertificado = c.TituloCertificado,
                    QuantidadeHoras = c.QuantidadeHoras,
                    UsuarioNome = c.Usuario.Nome
                })
                .ToList();
        }


        public void InserirCertificado(Certificado certificado)
        {
            _context.Certificado.Add(certificado);
            _context.SaveChanges();
        }

        public IEnumerable<Certificado> ListarCertificados()
        {
            return _context.Certificado.ToList();
        }
    }
}
