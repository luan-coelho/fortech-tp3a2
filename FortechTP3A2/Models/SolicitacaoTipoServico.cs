namespace FortechTP3A2.Models
{
    public class SolicitacaoTipoServico
    {
        public int SolicitacaoServicoId { get; set; }
        public SolicitacaoServico SolicitacaoServico { get; set; }

        public int TipoServicoId { get; set; }

        public TipoServico TipoServico { get; set; }
    }
}
