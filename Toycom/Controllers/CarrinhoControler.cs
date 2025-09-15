using Microsoft.AspNetCore.Mvc;

namespace Toycom.Controllers
{
    public class CarrinhoControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
