using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FortechTP3A2.Models
{
    public class SolicitacaoServico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        [MinLength(0)]
        public string Nome { get; set; }

        public string? Detalhes { get; set; }

        [Required(ErrorMessage = "Informe o valor")]
        public decimal Valor { get; set; }

        [DisplayName("Eletrônico")]
        [Required(ErrorMessage = "Informe um eletrônico")]
        public IList<Eletronico> Eletronicos { get; set; }

        [DisplayName("Tipo de Serviço")]
        [Required(ErrorMessage = "Informe o tipo de serviço")]
        public IList<SolicitacaoTipoServico> TiposServico { get; set; }

        [DisplayName("Usuário")]
        public int? UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
