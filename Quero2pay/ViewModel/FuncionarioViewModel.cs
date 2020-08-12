using Quero2pay.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quero2pay.ViewModel
{
    public class FuncionarioViewModel
    {
        public Funcionario funcionario { get; set; }
        public Cargo Cargo { get; set; }
        public Empresa Empresa { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}