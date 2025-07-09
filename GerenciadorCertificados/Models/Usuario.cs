namespace GerenciadorCertificados.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        public string Uuid { get; set; }

        public string Nome { get; set; }

        public DateOnly DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public ICollection<Certificado> Certificados { get; set; }


    }
}
