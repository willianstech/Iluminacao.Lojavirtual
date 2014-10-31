using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iluminacao.Lojavirtual.Dominio.Entidade;
using System.Collections.Generic;
using System.Linq;

namespace Iluminacao.LojaVirtual.UnitText
{
    [TestClass]
    public class TesteCarrinhoCompras
    {

        //Teste add itens ao carrinho

        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {

            //Arrange - Criação dos Produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            //Produto produto3 = new Produto
            //{
            //    ProdutoId = 3,
            //    Nome = "Teste3"
            //};

            //Arrange

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);
            //carrinho.AdicionarItem(produto3, 4);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);


        }

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            //Produto produto3 = new Produto
            //{
            //    ProdutoId = 3,
            //    Nome = "Teste3"
            //};

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);


            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho.
                OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(resultado.Length, 2);

            Assert.AreEqual(resultado[0].Quantidade, 11);
            Assert.AreEqual(resultado[1].Quantidade, 1);          

        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste3"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.RemoverItem(produto2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto2).Count(), 0);

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2); 
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado, 450M);
           
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);          
 
        }
    }

   

}
 
      