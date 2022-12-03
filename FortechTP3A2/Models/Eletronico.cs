namespace FortechTP3A2.Models
{
    public class Eletronico
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string NumeroNotaFiscal { get; set; }

        public DateTime DataFabricao { get; set; }

        public string Observacoes { get; set; }

        public int ModeloId { get; set;}

        public Modelo Modelo { get; set; }
    }
}
