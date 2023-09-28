using Fiap.Web.Donation.Models;


namespace Fiap.Web.Donation.Repository
{
    public interface IProdutoRepository
    {
        public IList<ProdutoModel> FindAll();

        public IList<ProdutoModel> FindAllWithTipo();

        public IList<ProdutoModel> FindByNome(string nome);

        public IList<ProdutoModel> FindAllByDisponivel(bool disponivel);

        public IList<ProdutoModel> FindAllDisponivelDoUsuario(bool disponivel, int usuarioId);

        public IList<ProdutoModel> FindAllDisponivelParaTroca(bool disponivel, int usuarioId);

        public IList<ProdutoModel> FindAllWithTipoOrderByName();

        public IList<ProdutoModel> FindAllWithTipoAndUsuario();

        public ProdutoModel FindById(int id);

        public int Insert(ProdutoModel produtoModel);

        public void Update(ProdutoModel produtoModel);

        public void Delete(ProdutoModel produtoModel);

        public void Delete(int id);

    }
}