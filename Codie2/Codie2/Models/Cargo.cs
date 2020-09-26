using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codie2.Models
{
    public class Cargo
    {

        [Key]
        public int CargoID { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [MaxLength(100, ErrorMessage = "Este Campo Deve Conter Entre  3 e 100 Caracteres")]
        [MinLength(3, ErrorMessage = "Este Campo Deve Conter Entre  3 e 100 Caracteres")]
        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

    }
}
