using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioBRQ.Models
{
    public class Skill
    {

        [Key]
        [Required]
        public int IdSkill { get; set; }

        [Required(ErrorMessage = "O campo NomeSkill é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string NomeSkill { get; set; }

        [JsonIgnore]
        public virtual List<Certificacao> Certificacoes { get; set; }

        [JsonIgnore]
        public virtual List<SkillCandidato> SkillsCandidato { get; set; }

    }
}
