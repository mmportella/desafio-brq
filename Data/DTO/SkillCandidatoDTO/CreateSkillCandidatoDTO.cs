using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Data.DTO.SkillCandidatoDTO
{
    public class CreateSkillCandidatoDTO
    {

        [Required]
        public int CandidatoId { get; set; }

        [Required]
        public int SkillId { get; set; }

    }
}
