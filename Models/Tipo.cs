using System.ComponentModel.DataAnnotations;

namespace ImobiControl.Models
{
    public class Tipo
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do estado é obrigatório")]
        public string Descricao { get; set; } 
    }
}