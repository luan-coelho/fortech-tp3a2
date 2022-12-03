using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FortechTP3A2.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        [MinLength(0)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [MaxLength(255, ErrorMessage = "Informe no máximo 255 caracteres")]
        [MinLength(0)]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }
        
        [DisplayName("CPF")]
        [Required(ErrorMessage = "Informe o CPF")]
        [MaxLength(14, ErrorMessage = "Informe no máximo 14 caracteres")]
        [MinLength(0)]
        public string Cpf { get; set; }
        
        [MaxLength(255, ErrorMessage = "Informe no máximo 20 caracteres")]
        [MinLength(0)]
        public string? Rg { get; set; }
        public string Senha { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        public IList<Endereco> Enderecos { get; set; }

        public IList<SolicitacaoServico> Solicitacoes { get; set; }

        public bool Admin { get; set; }

        public bool Ativo { get; set; }
    }
}
