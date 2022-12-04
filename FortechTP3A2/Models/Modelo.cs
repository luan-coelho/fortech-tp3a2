using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FortechTP3A2.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a descrição")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        [MinLength(0)]
        public string Descricao { get; set; }
        [DisplayName("Marca")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
