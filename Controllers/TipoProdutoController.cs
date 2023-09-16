using Fiap.Web.Donation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation.Controllers
{
    public class TipoProdutoController : Controller
    {

        private List<TipoProdutoModel> tipoProduto;

        public TipoProdutoController()
        {
            tipoProduto = new List<TipoProdutoModel>
            {
                new TipoProdutoModel()
                {
                    Id = 1,
                    Nome = "Smartphone",
                    Descricao = "Android 64Gb"
                },
                new TipoProdutoModel()
                {
                    Id = 2,
                    Nome = "Eletrodoméstico",
                    Descricao = "Geladeira"
                },
                new TipoProdutoModel()
                {
                    Id = 3,
                    Nome = "Vestimenta",
                    Descricao = "Camiseta"
                },

            };
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            
            return View(tipoProduto);
        }
        
        [HttpGet]
        public IActionResult Novo()
        {
            return View(new TipoProdutoModel());
        }

        [HttpPost]
        public IActionResult Novo(TipoProdutoModel tipoProdutoModel)
        {
            if (string.IsNullOrEmpty(tipoProdutoModel.Nome))
            {
                ViewBag.Mensagem = "O campo nome é requerido";
                return View(tipoProdutoModel);
            }
            else
            {
                // INSERT INTO PRODUTO VALUES ...
                TempData["Mensagem"] = $"{tipoProdutoModel.Nome} cadastrado com sucesso";
                return RedirectToAction("Index");
            }
        }

    

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var tipoProdutos = tipoProduto [id - 1];


            return View(tipoProdutos);
        }


        [HttpPost]
        public IActionResult Editar(TipoProdutoModel tipoprodutoModel)
        {
            if (string.IsNullOrEmpty(tipoprodutoModel.Nome))
            {
                ViewBag.Mensagem = "O campo nome é requerido";

                return View(tipoprodutoModel);

            }
            else
            {
                //ViewBag.Mensagem = $"{produtoModel.Nome} cadastrado com sucesso";
                TempData["Mensagem"] = $"{tipoprodutoModel.Nome} alterado com sucesso!";

                return RedirectToAction("Index");
            }
        }
    }
}
