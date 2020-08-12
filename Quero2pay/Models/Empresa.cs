using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quero2pay.Models
{
    public class Empresa
    {
        [Key]
        public int idEmpresa { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Empresa")]
        public string nmEmpresa { get; set; }

        [Required]
        [StringLength(350)]
        [DisplayName("Rua")]
        public string rua { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Bairro")]
        public string bairro { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Cidade")]
        public string cidade { get; set; }

        [Required]
        [StringLength(2)]
        [DisplayName("UF")]
        public string estado { get; set; }

        [Required]
        [DisplayName("Número")]
        public int numero { get; set; }

        [StringLength(100)]
        [DisplayName("Complemento")]
        public string  complemento { get; set; }

        [Required]
        [DisplayName("CEP")]
        public string cep { get; set; }

        [Required]
        [StringLength(3)]
        [DisplayName("DDD")]
        public string ddd { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Telefone")]
        public string nuTelefone { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}