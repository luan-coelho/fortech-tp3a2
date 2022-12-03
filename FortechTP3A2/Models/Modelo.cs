namespace FortechTP3A2.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
