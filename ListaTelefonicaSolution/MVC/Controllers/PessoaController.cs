using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            IEnumerable<MVCPessoaModel> pessoas;
            HttpResponseMessage resposta = GlobalVariables.WebApiClient.GetAsync("Pessoa").Result;
            pessoas = resposta.Content.ReadAsAsync<IEnumerable<MVCPessoaModel>>().Result;
            return View(pessoas);
        }
    }
}