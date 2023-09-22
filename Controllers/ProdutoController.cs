using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Models;
using Fiap.Web.Donation.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepository produtoRepository;
        private readonly TipoProdutoRepository tipoprodutoRepository;

        private readonly int UsuarioId = 1;


        public ProdutoController(DataContext dataContext)
        {
           
            produtoRepository = new ProdutoRepository(dataContext);            
            tipoprodutoRepository = new TipoProdutoRepository(dataContext);            

        }

        [HttpGet]
        public IActionResult Index()
        {

            var produtos = produtoRepository.FindAllWithTipoOrderByName();
            //TempData["Produtos"] = produtos;

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new ProdutoModel());
        }


        [HttpPost]
         public IActionResult Novo(ProdutoModel produtoModel)
        {
            if (string.IsNullOrEmpty(produtoModel.Nome))
            {
                ViewBag.Mensagem = "O campo nome é requerido";

                return View(produtoModel);

            }
            else
            {
                produtoModel.UsuarioId = 1;
                produtoRepository.Insert(produtoModel);

                //ViewBag.Mensagem = $"{produtoModel.Nome} cadastrado com sucesso";
                TempData["Mensagem"] = $"{produtoModel.Nome} cadastrado com sucesso!";

                return RedirectToAction("Index");
            }
        }

         [HttpGet]
        public IActionResult Editar(int id)
        {
            ComboTipoProduto();

            var produto = produtoRepository.FindById(id);

          
            return View(produto);
        }


        [HttpPost]
         public IActionResult Editar(ProdutoModel produtoModel)
        {
            if(string.IsNullOrEmpty(produtoModel.Nome))
            {
                ComboTipoProduto();

                ViewBag.Mensagem = "O campo nome é requerido";

                return View(produtoModel);

            } else
            {
                
                produtoModel.UsuarioId = 1;
                produtoRepository.Update(produtoModel);

                //ViewBag.Mensagem = $"{produtoModel.Nome} cadastrado com sucesso";
                TempData["Mensagem"] = $"{produtoModel.Nome} alterado com sucesso!";

                return RedirectToAction("Index");
            }
        }

           
        

       
        private void ComboTipoProduto()
        {
            var tiposProdutos = tipoprodutoRepository.FindAll();

            var comboTipoProdutos = new SelectList(tiposProdutos, "TipoProdutoId", "Nome");

            ViewBag.TipoProdutos = comboTipoProdutos;
        }

    }
}
