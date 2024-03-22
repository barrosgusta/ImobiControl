using System.ComponentModel.DataAnnotations;

namespace ImobiControl.Models
{
    public class Estado
    {
        [Key]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A sigla do estado deve ter 2 caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "O nome do estado é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome do estado deve ter no máximo 50 caracteres")]
        public string Nome { get; set; } 
    }
}