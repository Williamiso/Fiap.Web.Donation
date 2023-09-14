using Fiap.Web.Donation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation.Controllers
{
    public class ProdutoController : Controller
    {
        private List<ProdutoModel> produtos;

        public ProdutoController()
        {
            produtos = new List<ProdutoModel>{
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    Nome = "Iphone 11",
                    TipoProdutoId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 2,
                    Nome = "Iphone 12",
                    TipoProdutoId = 2,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 3,
                    Nome = "Iphone 13",
                    TipoProdutoId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 4,
                    Nome = "Iphone 14",
                    TipoProdutoId = 1,
                    Disponivel = false,
                    DataExpiracao = DateTime.Now,
                },

            };

        }
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.Produtos = produtos;
            //TempData["Produtos"] = produtos;

            return View();
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }


        [HttpPost]
         public IActionResult Novo(ProdutoModel produtoModel)
        {


            //ViewBag.Mensagem = $"{produtoModel.Nome} cadastrado com sucesso";
            TempData["Mensagem"] = $"{produtoModel.Nome} cadastrado com sucesso!";

            return RedirectToAction("Index");
        }


    }
}
