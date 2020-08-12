using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quero2pay.Models
{
    public class Funcionario
    {
        [Key]
        public int idFuncionario { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [Required]
        [DisplayName("Empresa")]
        public int idEmpresa { get; set; }

        [Required]
        [DisplayName("Cargo")]
        public int idCargo { get; set; }

        public Empresa Empresa { get; set; }
        public Cargo Cargo { get; set; }
    }
}