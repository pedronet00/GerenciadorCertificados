using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GerenciadorCertificados.Models;

namespace GerenciadorCertificados.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Certificado> Certificado { get; set; }

    }
}
