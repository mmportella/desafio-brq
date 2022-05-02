using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Data.DTO.CertificacaoDTO
{
    public class CreateCertificacaoDTO
    {

        [Required(ErrorMessage = "O campo Instituicao é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string Instituicao { get; set; }

        [Required(ErrorMessage = "O campo NomeCertificacao é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tamanho máximo do campo é 100 caracteres.")]
        public string NomeCertificacao { get; set; }

        [Required]
        public int SkillId { get; set; }

    }
}
