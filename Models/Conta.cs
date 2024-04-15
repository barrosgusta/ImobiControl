using System.ComponentModel.DataAnnotations;

namespace ImobiControl.Models
{
    public class Conta
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A descrição da conta é obrigatória")]
        [StringLength(50, ErrorMessage = "A descrição da conta deve ter no máximo 50 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O tipo da conta é obrigatório")]
        public int Tipo { get; set; }
        [Required(ErrorMessage = "O valor da conta é obrigatório")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "A data de registro da conta é obrigatória")]
        public DateTime DataRegistro { get; set; }
        [Required(ErrorMessage = "A data de vencimento da conta é obrigatória")]
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagto { get; set; }
        [Required(ErrorMessage = "A situação da conta é obrigatória")]
        public int Situacao { get; set; }
        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}