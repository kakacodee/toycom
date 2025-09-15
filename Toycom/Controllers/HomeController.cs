using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Toycom.Models;
using Toycom.Repositorio;
namespace Toycom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            return View();
            var produtos = await _produtoRepositorio.TodosProdutos();
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
