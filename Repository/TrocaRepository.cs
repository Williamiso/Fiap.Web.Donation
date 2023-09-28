using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Models;

namespace Fiap.Web.Donation.Repository
{
    public class TrocaRepository
    {
        private readonly DataContext dataContext;

        public TrocaRepository(DataContext context)
        {
            this.dataContext = context;
        }

        public Guid Insert(TrocaModel trocaModel)
        {
            dataContext.Trocas.Add(trocaModel);
            dataContext.SaveChanges();

            return trocaModel.TrocaId;
        }
    }
}
