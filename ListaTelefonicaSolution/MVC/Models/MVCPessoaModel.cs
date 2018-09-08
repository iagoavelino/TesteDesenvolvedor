using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCPessoaModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string email { get; set; }
        public System.DateTime data_nascimento { get; set; }
        public int Id { get; set; }

    }
}