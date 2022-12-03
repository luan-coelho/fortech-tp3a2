using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FortechTP3A2.Models
{
    public class Marca
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Descrição")]
        [DisplayName("Descrição")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        [MinLength(0)]
        public string Descricao { get; set; }

        public IList<Modelo>? Modelos { get; set; }
   }
}
