using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation.Repository
{
    public class ProdutoRepository
    {
        private readonly DataContext dataContext;
        public ProdutoRepository(DataContext ctx) {
            dataContext = ctx;
        }

        //Listar Todos
        public IList<ProdutoModel> FindAll()
        {
            var produtos = dataContext.Produtos.ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        } 
        public IList<ProdutoModel> FindAllWithTipo()
        {
            var produtos = dataContext.Produtos.Include(p => p.TipoProduto).ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllWithTipoOrderByName()
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .OrderBy(p => p.Nome) // ORDER BY
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        public IList<ProdutoModel> FindAllByDisponivel()
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .Where(p => p.Disponivel) // WHERE Disponivel = {disponivel}
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        //Detalhe (Consulta por Id)

        public ProdutoModel FindById(int id)
        {                                        // WHERE         ProdutoId = {id}
            var produto = dataContext.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            return produto;
        }

        //Inserir

        public int Insert(ProdutoModel produtoModel)
        {
            produtoModel.DataCadastro = DateTime.Now;


            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();

            return produtoModel.ProdutoId;
        }

        //Alterar

        public void Update(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Update(produtoModel);
            dataContext.SaveChanges();
        }

        //Excluir

        public void Delete(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Remove(produtoModel);
            dataContext.SaveChanges();
        }
    }
}
