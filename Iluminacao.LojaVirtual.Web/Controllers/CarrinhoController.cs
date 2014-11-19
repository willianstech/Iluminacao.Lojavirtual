﻿using Iluminacao.Lojavirtual.Dominio.Repositorio;
using System.Web.Mvc;
using Iluminacao.Lojavirtual.Dominio.Entidade;
using System.Linq;
using Iluminacao.LojaVirtual.Web.Models;
using System.Configuration;



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

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }



        //ESSE MÉTODO "POSTA" O PEDIDO VIA EMAIL(ARQUIVADO NUMA PASTA LOCAL)
        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            Carrinho carrinho = ObterCarrinho();

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }

        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }



    }
}