using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ImobiControl.Models
{
    public class Foto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }
        [Required(ErrorMessage = "A descrição da foto é obrigatória")]
        [StringLength(50, ErrorMessage = "A descrição da foto deve ter no máximo 50 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O arquivo da foto é obrigatório")]
        public string Arquivo { get; set; }
    }
}