using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobiControl.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        public string Senha { get; set; } 
        [Required(ErrorMessage = "O tipo do usuário é obrigatório")]
        public int Tipo { get; set; }
    }
}