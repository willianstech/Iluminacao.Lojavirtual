using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iluminacao.Lojavirtual.Dominio.Entidade
{
    public class Carrinho
    {
       
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();
             //adicionar

        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade

                });

            }         
            else
            {
                item.Quantidade += quantidade;
            }

            
        }

        //remover
        public void RemoverItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);

        }

        //obter o valor total
        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(e => e.Produto.Preco*e.Quantidade);
        }


        //limpar o carrinho
        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }


        //itens do carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get {return _itemCarrinho;}
        }
    }


    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

    }
}
