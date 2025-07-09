using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorCertificados.Models
{
    public class Certificado
    {
        public int Id { get; set; }

        public string Uuid { get; set; }

        public string TituloCertificado { get; set; }

        public float QuantidadeHoras { get; set; }

        public string ArquivoCertificado { get; set; }

        public int AreaCertificado { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
