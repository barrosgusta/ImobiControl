using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobiControl.Models
{
    public class Cidade
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome da cidade deve ter no máximo 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O estado é obrigatório")]
        public string EstadoSigla { get; set; }
        public Estado Estado { get; set; }
    }
}