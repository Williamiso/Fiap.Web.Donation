using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Fiap.Web.Donation.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        // Listar Todos
        public IList<ProdutoModel> FindAll()
        {
            var produtos = dataContext.Produtos.ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public IList<ProdutoModel> FindAllWithTipo()
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public IList<ProdutoModel> FindByNome(string nome)
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public IList<ProdutoModel> FindAllByDisponivel(bool disponivel)
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .Where(p => p.Disponivel == disponivel) // WHERE Disponivel = {disponivel}   
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllDisponivelDoUsuario(bool disponivel, int usuarioId)
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .Where(p => p.Disponivel == disponivel && p.UsuarioId == usuarioId) // WHERE Disponivel = {disponivel}   
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllDisponivelParaTroca(bool disponivel, int usuarioId)
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .Where(p => p.Disponivel == disponivel && p.UsuarioId != usuarioId) // WHERE Disponivel = {disponivel}   
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public IList<ProdutoModel> FindAllWithTipoOrderByName()
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .OrderByDescending(p => p.Nome) // ORDER BY
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public IList<ProdutoModel> FindAllWithTipoAndUsuario()
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .Include(p => p.Usuario) // INNER JOIN
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }



        // Detalhe (Consulta por Id)
        public ProdutoModel FindById(int id)
        {
            //  WHERE          ProdutoId = {id}   
            var produto = dataContext.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            return produto;
        }

        // Inserir
        public int Insert(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();

            return produtoModel.ProdutoId;
        }

        // Alterar
        public void Update(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Update(produtoModel);
            dataContext.SaveChanges();
        }

        // Excluir
        public void Delete(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Remove(produtoModel);
            dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var produtoModel = new ProdutoModel()
            {
                ProdutoId = id,
            };

            Delete(produtoModel);
        }


    }
}