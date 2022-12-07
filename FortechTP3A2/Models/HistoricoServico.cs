using System.ComponentModel;

namespace FortechTP3A2.Models
{
    public class HistoricoServico
    {
        public int Id { get; set; }
        [DisplayName("Solicitação")]
        public int SolicitacaoServicoId { get; set; }
        [DisplayName("Solicitação")]
        public SolicitacaoServico SolicitacaoServico { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
