using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation.Controllers
{
    public class MinhasTrocasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
