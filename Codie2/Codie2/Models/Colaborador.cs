using System;
using System.ComponentModel.DataAnnotations;

namespace Codie2.Models
{
    public class Colaborador
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [MaxLength(100, ErrorMessage = "Este Campo Deve Conter Entre  3 e 100 Caracteres")]
        [MinLength(3, ErrorMessage = "Este Campo Deve Conter Entre  3 e 100 Caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Invalida")]
        public int TimeID { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Invalida")]

        public int CargoID { get; set; }

        public DateTime DataInicio { get; set; }

        [MaxLength(1024, ErrorMessage = "Este Campo Deve Conter No Máximo 1024 Caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
