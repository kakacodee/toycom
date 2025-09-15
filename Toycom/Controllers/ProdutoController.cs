using Microsoft.AspNetCore.Mvc;

namespace Toycom.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
