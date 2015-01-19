using Iluminacao.Lojavirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iluminacao.Lojavirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {

        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        //Salvar produto - Alterar produto

        public void Salvar(Produto produto)
        {
            if (produto.ProdutoId == 0)
            {
                //Salvando
                _context.Produtos.Add(produto);
            }
            else
            {
                //Alteração
                Produto prod = _context.Produtos.Find(produto.ProdutoId);
                if(prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;
                }
            }
            _context.SaveChanges();
        }
        
    }
}
