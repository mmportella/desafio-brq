using DesafioBRQ.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Data.DTO.SkillCandidatoDTO
{
    public class ReadSkillCandidatoDTO
    {

        [Key]
        [Required]
        public int IdSkillCandidato { get; set; }

        [Required]
        public int CandidatoId { get; set; }

        [Required]
        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }

    }
}
