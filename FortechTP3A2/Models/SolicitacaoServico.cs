using System.ComponentModel;

namespace FortechTP3A2.Models
{
    public class SolicitacaoServico
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Detalhes { get; set; }

        public decimal Valor { get; set; }

        public IList<Eletronico> Eletronicos { get; set; }
        
        public IList<SolicitacaoTipoServico> TiposServico { get; set; }

        [DisplayName("Usuário")]
        public int? UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
