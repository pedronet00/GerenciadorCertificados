using GerenciadorCertificados.Data;
using GerenciadorCertificados.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove o AppDbContext original
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);

            // Adiciona o AppDbContext em memória
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });

            // Garante que o banco seja criado e populado
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();

            // Remove dados antigos e insere um usuário
            if (!db.Usuario.Any(u => u.Email == "pedro2@gmail.com"))
            {
                db.Usuario.Add(new Usuario
                {
                    Nome = "Pedro 2",
                    Email = "pedro2@gmail.com",
                    Senha = BCrypt.Net.BCrypt.HashPassword("123"),
                    Uuid = Guid.NewGuid().ToString()
                });
                db.SaveChanges();
            }
        });
    }
}
