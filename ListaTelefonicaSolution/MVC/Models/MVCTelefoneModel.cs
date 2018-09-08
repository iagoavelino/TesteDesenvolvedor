using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCTelefoneModel
    {
        public int id { get; set; }
        public string ddd { get; set; }
        public string numero { get; set; }
        public int pessoa_id { get; set; }

    }
}