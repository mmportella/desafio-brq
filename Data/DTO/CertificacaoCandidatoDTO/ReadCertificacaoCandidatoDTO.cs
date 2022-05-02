using DesafioBRQ.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Data.DTO.CertificacaoCandidatoDTO
{
    public class ReadCertificacaoCandidatoDTO
    {

        [Key]
        [Required]
        public int IdCertificacaoCandidato { get; set; }

        [Required]
        public int CandidatoId { get; set; }

        [Required]
        public int CertificacaoId { get; set; }

        public virtual Certificacao Certificacao { get; set; }

    }
}
