using System.ComponentModel.DataAnnotations;

namespace ImobiControl.Models
{
    public class Pessoa
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O nome da pessoa é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome da pessoa deve ter no máximo 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O CPF da pessoa é obrigatório")]
        [StringLength(14, ErrorMessage = "O CPF da pessoa deve ter no máximo 14 caracteres")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O Endereço é obrigatório")]
        [StringLength(50, ErrorMessage = "O Endereço deve ter no máximo 50 caracteres")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O Número é obrigatório")]
        [StringLength(10, ErrorMessage = "O Número deve ter no máximo 10 caracteres")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "O Bairro é obrigatório")]
        [StringLength(50, ErrorMessage = "O Bairro deve ter no máximo 50 caracteres")]
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "O CEP é obrigatório")]
        [StringLength(10, ErrorMessage = "O CEP deve ter no máximo 10 caracteres")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O E-Mail é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Telefone é obrigatório")]
        [StringLength(15, ErrorMessage = "O Telefone deve ter no máximo 15 caracteres")]
        public string Telefone { get; set; }
        public decimal Comissao { get; set; }
        public bool Proprietario { get; set; }
        public bool Cliente { get; set; }
        public bool Funcionario { get; set; }
    }
}