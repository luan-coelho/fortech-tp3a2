namespace FortechTP3A2.Models
{
    public class HistoricoServico
    {
        public string Id { get; set; }
        public int SolicitacaoServicoId { get; set; }
        public SolicitacaoServico SolicitacaoServico { get; set; }

        public string Descricao { get; set; }
    }
}
