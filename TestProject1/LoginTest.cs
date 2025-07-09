using GerenciadorCertificados.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

public class LoginTest : IClassFixture<CustomWebApplicationFactory<GerenciadorCertificados.Program>>
{
    private readonly HttpClient _client;

    public LoginTest(CustomWebApplicationFactory<GerenciadorCertificados.Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login_DeveRetornarToken_QuandoCredenciaisForemValidas()
    {
        var login = new LoginDTO
        {
            Email = "pedro2@gmail.com",
            Senha = "123"
        };

        var json = JsonSerializer.Serialize(login);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/User/login", content);

        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("RESPONSE:");
        Console.WriteLine(responseBody);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("token", responseBody);
    }

    [Fact]
    public async Task Login_DeveRetornar401_QuandoSenhaEstiverErrada()
    {
        var login = new LoginDTO
        {
            Email = "pedro2@gmail.com",
            Senha = "senhaerrada"
        };

        var json = JsonSerializer.Serialize(login);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/User/login", content);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
