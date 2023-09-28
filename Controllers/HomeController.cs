using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Models;
using Fiap.Web.Donation.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.Donation.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProdutoRepository produtoRepository;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _logger = logger;
            produtoRepository = new ProdutoRepository(dataContext);
        }

        public IActionResult Index()
        {
            
            var lista = produtoRepository.FindAllDisponivelParaTroca(true, UsuarioId);

            return View(lista); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}