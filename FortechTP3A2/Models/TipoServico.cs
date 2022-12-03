namespace FortechTP3A2.Models
{
    public class TipoServico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public IList<SolicitacaoTipoServico> Solicitacoes { get; set; }
    }
}
