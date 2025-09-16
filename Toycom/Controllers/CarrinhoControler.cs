using Microsoft.AspNetCore.Mvc;
using Toycom.Repositorio;

namespace Toycom.Controllers
{
    public class CarrinhoControler : Controller
    {
        private readonly CarrinhoRep _carrinhoRep;
        private readonly ProdutoRep _produtoRep;

        public CarrinhoControler(CarrinhoRep carrinhoRep, ProdutoRep produtoRep)
        {
            _carrinhoRep = carrinhoRep;
            _produtoRep = produtoRep;
        }
        public async Task<IActionResult> Index()
        {
            var cartItems = _carrinhoRep.CarrinhoItems(HttpContext.Session);
            foreach (var item in cartItems)
            {
                item.Produto = await _produtoRep.ProdutosPorId(item.ProdutoId);

                if(item.Produto != null)
                {

                }
            }
            ViewBag.TotalCarrinho = _carrinhoRep.TotalCarrinho(HttpContext.Session);
            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarCarrinho(int produtoId, int quantidade = 1)
        {
            var produto = await _produtoRep.ProdutosPorId(produtoId);
            if (produto == null)
            {
                TempData["Message"] = "Produto não encontrado."; // Use TempData para mensagens
                return RedirectToAction("Index", "Home");
            }

            _carrinhoRep.AdicionarCarrinho(HttpContext.Session, produtos, quantidade);
            return RedirectToAction("Index", "Carrinho");
        }

        [HttpPost]
        public IActionResult AlterarQuantidadeItem(int produtoId, int novaQuantidade)
        {
            _carrinhoRep.AlterarQuantidadeItem(HttpContext.Session, produtoId, novaQuantidade);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int produtoId)
        {
            _carrinhoRep.RemoverItemCarrinho(HttpContext.Session, produtoId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult LimparCarrinho()
        {
            _carrinhoRep.LimparCarrinho(HttpContext.Session);
            return RedirectToAction("Index");
        }
    }
}
