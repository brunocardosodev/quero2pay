using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quero2pay.Models
{
    public class Cargo
    {
        [Key]
        public int idCargo { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Cargo")]
        public string nmCargo { get; set; }

        [Required]
        [DisplayName("Salário")]
        public decimal salario { get; set; }
        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}