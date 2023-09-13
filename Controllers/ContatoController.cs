using Fiap.Web.Donation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation.Controllers
{
    public class ContatoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Gravar(ContatoModel contatoModel)
        {
            return View("Sucesso");
        }
        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }
    }
}
