using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation.Controllers
{
    public class TodasTrocasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
