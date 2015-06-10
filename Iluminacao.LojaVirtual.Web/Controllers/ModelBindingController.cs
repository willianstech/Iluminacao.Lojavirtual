using Iluminacao.Lojavirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iluminacao.LojaVirtual.Web.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            return View(new Produto());
        }


        [HttpPost]
        public ActionResult Editar([Bind(Include = "Nome")]Produto produt)
        {
            var produto = new Produto();

            //Produto.Nome = prod.Nome;
            //Produto.Preco = prod.Preco;

            return RedirectToAction("Index");
 
        }
    }
}