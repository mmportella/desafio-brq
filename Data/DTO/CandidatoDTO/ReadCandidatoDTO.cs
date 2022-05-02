using System.ComponentModel.DataAnnotations;

namespace DesafioBRQ.Data.DTO.CandidatoDTO
{
    public class ReadCandidatoDTO
    {

        [Key]
        [Required]
        public int IdCandidato { get; set; }

        [Required(ErrorMessage = "O campo Cpf é obrigatório.")]
        [Range(11111111111, 99999999999, ErrorMessage = "Informe o cpf completo.")]
        public long Cpf { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tamanho máximo do campo é 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tamanho máximo do campo é 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [Range(11111111, 99999999999, ErrorMessage = "Informe o telefone com DDD.")]
        public long Telefone { get; set; }

        [Required(ErrorMessage = "O campo Genero é obrigatório.")]
        [StringLength(10, ErrorMessage = "O tamanho máximo do campo é 10 caracter.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo Nascimento é obrigatório.")]
        [StringLength(10, ErrorMessage = "O tamanho máximo do campo é 10 caracteres.")]
        public string Nascimento { get; set; }

    }
}
