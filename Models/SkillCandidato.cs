using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Models
{
    public class SkillCandidato
    {

        [Key]
        [Required]
        public int IdSkillCandidato { get; set; }

        [Required]
        public int CandidatoId { get; set; }

        [Required]
        public int SkillId { get; set; }

        public virtual Candidato Candidato { get; set; }

        public virtual Skill Skill { get; set; }

    }
}
