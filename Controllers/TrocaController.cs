using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Models;
using Fiap.Web.Donation.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation.Controllers
{
    public class TrocaController : BaseController
    {
        private readonly ProdutoRepository produtoRepository;

        private readonly TrocaRepository trocaRepository;

        




        public TrocaController(DataContext datacontext, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            produtoRepository = new ProdutoRepository(datacontext);
            trocaRepository = new TrocaRepository(datacontext);
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var trocaModel = new TrocaModel();
            trocaModel.ProdutoId1 = id;
            trocaModel.ProdutoModel1 = produtoRepository.FindById(id);

            ComboMeusProdutos();

            return View(trocaModel);
        }

        [HttpPost]

        public IActionResult Index(TrocaModel trocaModel)
        {
            var produto1 = produtoRepository.FindById(trocaModel.ProdutoId1);
            var produto2 = produtoRepository.FindById(trocaModel.ProdutoId2);

            try
            {
                if (produto1.Disponivel == false)
                {
                    throw new Exception("Produto selecionado indisponível");
                }

                if (produto2.Disponivel == false)
                {
                    throw new Exception("O seu produto já foi trocado");
                }

                if ((produto2.Valor / produto1.Valor) < 0.9)
                {
                    throw new Exception("O seu produto tem o valor menor que 90% do produto selecionado");
                }

                produto1.Disponivel = false;
                produtoRepository.Update(produto1);

                produto2.Disponivel = false;
                produtoRepository.Update(produto2);

                trocaModel.Status = Models.TrocaStatus.Iniciado;
                trocaRepository.Insert(trocaModel);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                ComboMeusProdutos();
                return View(trocaModel);
            }

        }
        

           

     
        private void ComboMeusProdutos()
        {
            var Produtos = produtoRepository.FindAllDisponivelDoUsuario(true, UsuarioId);

            var comboProdutos = new SelectList(Produtos, "ProdutoId", "Nome");

            ViewBag.MeusProdutos = comboProdutos;
        }
    }
}
