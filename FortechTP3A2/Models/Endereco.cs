namespace FortechTP3A2.Models
{
    public class Endereco
    {
        public int id { get; set; }

        public string cep { get; set; }

        public string rua { get; set; }

        public string numero { get; set; }

        public string bairro { get; set; }

        public string complemento { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
