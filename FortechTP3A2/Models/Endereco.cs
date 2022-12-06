using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FortechTP3A2.Models
{
    public class Endereco
    {
        public int id { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Informe o CEP")]
        [MaxLength(20, ErrorMessage = "Informe no máximo 20 caracteres")]
        [MinLength(0)]
        public string cep { get; set; }
        
        [DisplayName("Rua")]
        [Required(ErrorMessage = "Informe a rua")]
        [MaxLength(255, ErrorMessage = "Informe no máximo 255 caracteres")]
        [MinLength(0)]
        public string rua { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Informe o número")]
        [MaxLength(10, ErrorMessage = "Informe no máximo 10 caracteres")]
        [MinLength(0)]
        public string numero { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Informe o bairro")]
        [MaxLength(255, ErrorMessage = "Informe no máximo 255 caracteres")]
        [MinLength(0)]
        public string bairro { get; set; }

        [DisplayName("Complemento")]
        public string? complemento { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Informe a cidade")]
        [MaxLength(255, ErrorMessage = "Informe no máximo 255 caracteres")]
        [MinLength(0)]
        public string cidade { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Informe o estado")]
        [MaxLength(255, ErrorMessage = "Informe no máximo 255 caracteres")]
        [MinLength(0)]
        public string estado { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
