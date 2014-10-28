using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.WebPages.Html;
using Iluminacao.LojaVirtual.Web.Models;
using System.Web.Mvc;
using Iluminacao.LojaVirtual.Web.HtmlHelpers;


namespace Iluminacao.LojaVirtual.UnitText
{
    [TestClass]
    public class UnitTestIluminacao
    {
        [TestMethod]
        public void Take()
        {
            //O operador Take é usado para selecionar os primeiros n objetos de uma coleção.

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resultado = from num in numeros.Take(5) select num;
            int[] teste = { 5, 4, 1, 3, 9 };

            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void Skip()
        {
            //O operador skip ignora o(s) primeiro(s) n objetos de uma coleção.

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resultado = from num in numeros.Take(5).Skip(2) select num;
            int[] teste = {1,3,9};

            CollectionAssert.AreEqual(resultado.ToArray(),teste);

        }

        [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange

            System.Web.Mvc.HtmlHelper html = null;
            Paginacao paginacao = new Paginacao()
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);


            //Assert

            Assert.AreEqual(
                @"<a class =""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class =""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                );
        }
    }
}

            


