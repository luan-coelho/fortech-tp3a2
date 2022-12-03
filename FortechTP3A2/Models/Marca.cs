namespace FortechTP3A2.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public IList<Modelo> Modelos { get; set; }
   }
}
