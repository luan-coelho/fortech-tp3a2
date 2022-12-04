using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FortechTP3A2.Models
{
    public class Eletronico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        [MinLength(0)]
        public string Nome { get; set; }

        [DisplayName("Número da nosta fiscal")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        public string? NumeroNotaFiscal { get; set; }

        [Required(ErrorMessage = "Informe a data de Fabricação")]
        [DisplayName("Data de Fabricação")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFabricao { get; set; }

        [DisplayName("Observações")]
        [MaxLength(255, ErrorMessage = "Informe no máximo 255 caracteres")]
        public string? Observacoes { get; set; }

        [Required(ErrorMessage = "Informe o modelo")]
        [DisplayName("Modelo")] public int ModeloId { get; set; }

        [Required(ErrorMessage = "Informe o modelo")]
        public Modelo? Modelo { get; set; }
    }
}