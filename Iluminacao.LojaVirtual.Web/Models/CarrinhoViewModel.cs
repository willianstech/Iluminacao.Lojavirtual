using Iluminacao.Lojavirtual.Dominio.Entidade;

namespace Iluminacao.LojaVirtual.Web.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public string returnUrl { get; set; }
    }
}