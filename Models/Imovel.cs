using System.ComponentModel.DataAnnotations;

namespace ImobiControl.Models
{
    public class Imovel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O endereço do imóvel é obrigatório")]
        [StringLength(50, ErrorMessage = "O endereço do imóvel deve ter no máximo 50 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O número do imóvel é obrigatório")]
        [StringLength(10, ErrorMessage = "O número do imóvel deve ter no máximo 10 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O bairro do imóvel é obrigatório")]
        [StringLength(50, ErrorMessage = "O bairro do imóvel deve ter no máximo 50 caracteres")]
        public string Bairro { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "O CEP do imóvel é obrigatório")]
        [StringLength(10, ErrorMessage = "O CEP do imóvel deve ter no máximo 10 caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O preço do imóvel é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A avaliação do imóvel é obrigatória")]
        [StringLength(50, ErrorMessage = "A avaliação do imóvel deve ter no máximo 50 caracteres")]
        public string Avaliacao { get; set; }

        [Required(ErrorMessage = "A finalidade do imóvel é obrigatória")]
        public int Finalidade { get; set; }

        [Required(ErrorMessage = "A área total do imóvel é obrigatória")]
        public decimal AreaTotal { get; set; }

        [Required(ErrorMessage = "A área construída do imóvel é obrigatória")]
        public decimal AreaConstruida { get; set; }

        [Required(ErrorMessage = "O número de cômodos do imóvel é obrigatório")]
        public int Comodos { get; set; }

        [Required(ErrorMessage = "O número de vagas de garagem do imóvel é obrigatório")]
        public int VagaGaragem { get; set; }

        [Required(ErrorMessage = "A taxa de comissão do imóvel é obrigatória")]
        public decimal TaxaComissao { get; set; }

        public Guid CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        public Guid TipoId { get; set; }
        public Tipo Tipo { get; set; }

        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}