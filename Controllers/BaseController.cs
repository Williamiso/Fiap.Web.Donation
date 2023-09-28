using Fiap.Web.Donation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiap.Web.Donation.Controllers
{
    public class BaseController : Controller
    {

        public readonly int UsuarioId = 0;

        public readonly bool Autenticado = false;

        public readonly UsuarioModel? UsuarioLogado;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Session != null)
            {
                var usuarioJson = httpContextAccessor.HttpContext.Session.GetString("UsuarioLogado");

                if (!string.IsNullOrEmpty(usuarioJson))
                {
                    UsuarioLogado = JsonConvert.DeserializeObject<UsuarioModel>(usuarioJson);
                    UsuarioId = UsuarioLogado.UsuarioId;
                    Autenticado = true;
                }

            }
        }









    }
}
