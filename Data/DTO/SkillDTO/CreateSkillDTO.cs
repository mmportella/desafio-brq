using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Data.DTO.SkillDTO
{
    public class CreateSkillDTO
    {

        [Required(ErrorMessage = "O campo NomeSkill é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string NomeSkill { get; set; }

    }
}
