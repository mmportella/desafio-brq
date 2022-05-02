using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioBRQ.Models
{
    public class Certificacao
    {

        [Key]
        [Required]
        public int IdCertificacao { get; set; }

        [Required(ErrorMessage = "O campo Instituicao é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string Instituicao { get; set; }

        [Required(ErrorMessage = "O campo NomeCertificacao é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tamanho máximo do campo é 100 caracteres.")]
        public string NomeCertificacao { get; set; }

        [Required]
        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        [JsonIgnore]
        public virtual List<CertificacaoCandidato> CertificacoesCandidato { get; set; }

    }
}
