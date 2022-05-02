using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Models
{
    public class CertificacaoCandidato
    {

        [Key]
        [Required]
        public int IdCertificacaoCandidato { get; set; }

        [Required]
        public int CandidatoId { get; set; }

        [Required]
        public int CertificacaoId { get; set; }

        public virtual Candidato Candidato { get; set; }

        public virtual Certificacao Certificacao { get; set; }

    }
}
