using Iluminacao.Lojavirtual.Dominio.Entidade;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Iluminacao.LojaVirtual.Web.infraestrutura
{
    public class CarrinhoModelBinder : IModelBinder
    {
        private const string SessionKey = "Carrinho";

        //IModelBinder interface define o método BindModel
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //obter o carrinho da sessão
            Carrinho carrinho = null;

            if (controllerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            }
             //Criar carrinho se não tem a sessão

            if (carrinho = null)
            {
                carrinho = new Carrinho();

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }
            //retornar o carrinho
            return carrinho;

        }
    }

    }
}