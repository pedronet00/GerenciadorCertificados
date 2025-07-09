namespace GerenciadorCertificados.Models.DTOs
{
    public class CertificadoUploadDTO
    {
        public string TituloCertificado { get; set; }
        public float QuantidadeHoras { get; set; }
        public int AreaCertificado { get; set; }
        public int IdUsuario { get; set; }
        public IFormFile Arquivo { get; set; }
    }

}
