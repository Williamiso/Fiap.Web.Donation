using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Models;


namespace Fiap.Web.Donation.Repository
{
    public class TipoProdutoRepository
    {
        private readonly DataContext dataContext;

        public TipoProdutoRepository(DataContext ctx)
        {
            dataContext = ctx;
        }


        public IList<TipoProdutoModel> FindAll()
        {
            var tipos = dataContext.TipoProdutos.ToList();

            return tipos == null ? new List<TipoProdutoModel>() : tipos;
        }

        public TipoProdutoModel FindById(int id)
        {
            var tipo = dataContext.TipoProdutos.FirstOrDefault(t => t.TipoProdutoId == id);

            return tipo;
        }

        public int Insert(TipoProdutoModel tipoModel)
        {
            dataContext.TipoProdutos.Add(tipoModel);
            dataContext.SaveChanges();

            return tipoModel.TipoProdutoId;
        }

        // Alterar
        public void Update(TipoProdutoModel tipoModel)
        {
            dataContext.TipoProdutos.Update(tipoModel);
            dataContext.SaveChanges();
        }

        // Excluir
        public void Delete(TipoProdutoModel tipoModel)
        {
            dataContext.TipoProdutos.Remove(tipoModel);
            dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var tipoModel = new TipoProdutoModel()
            {
                TipoProdutoId = id,
            };

            Delete(tipoModel);
        }

    }
}