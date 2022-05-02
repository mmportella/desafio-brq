using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Data.DTO.CertificacaoCandidatoDTO
{
    public class CreateCertificacaoCandidatoDTO
    {

        [Required]
        public int CandidatoId { get; set; }

        [Required]
        public int CertificacaoId { get; set; }

    }
}
