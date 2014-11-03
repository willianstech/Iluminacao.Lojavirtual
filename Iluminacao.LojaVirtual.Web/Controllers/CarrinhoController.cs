using Iluminacao.Lojavirtual.Dominio.Repositorio;
using System.Web.Mvc;
using Iluminacao.Lojavirtual.Dominio.Entidade;
using System.Linq;
using Iluminacao.LojaVirtual.Web.Models;



namespace Iluminacao.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {

        private ProdutosRepositorio _repositorio;



        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos.
                FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
                
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];

                if(carrinho == null)
                {
                    carrinho = new Carrinho();
                    Session["Carrinho"] = carrinho;
                }
                return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.
                FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnurl)
        {
            return View(new CarrinhoViewModel
                {
                    Carrinho = ObterCarrinho(),
                    returnUrl = returnurl
                });
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }


    }
}