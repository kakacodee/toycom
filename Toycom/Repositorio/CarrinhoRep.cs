
using Newtonsoft.Json;
using Toycom.Models;

namespace Toycom.Repositorio;
public class CarrinhoRep
{
    private const string CartSessionKey = "Carrinho";

    public List<Carrinho> CarrinhoItems(ISession session)
    {
        var cartJson = session.GetString(CartSessionKey);
        return cartJson == null ? new List<Carrinho>() : JsonConvert.DeserializeObject<List<Carrinho>>(cartJson);
    }

    public void AdicionarCarrinho(ISession session, Carrinho carrinho, int quantidade)
    {
        var cart = CarrinhoItems(session);
        var existingItem = cart.FirstOrDefault(item => item.ProdutoId == carrinho.ProdutoId);

        if (existingItem != null)
        {
            existingItem.Quantidade += quantidade;
        }
        else
        {
            cart.Add(new Carrinho
            {
                ProdutoId = carrinho.ProdutoId,
                Produto = carrinho.Produto,
                Quantidade = carrinho.Quantidade,
                Preco = carrinho.Preco
            });
        }
        SalvarCarrinho(session, cart);
    }

    public void AlterarQuantidadeItem(ISession session, int produtoId, int novaQuantidade)
    {
        var cart = CarrinhoItems(session);
        var itemAlterar = cart.FirstOrDefault(item => item.ProdutoId == produtoId);

        if (itemAlterar != null)
        {
            if (novaQuantidade <= 0)
            {
                cart.Remove(itemAlterar);
            }
            else
            {
                itemAlterar.Quantidade = novaQuantidade;
            }
            SalvarCarrinho(session, cart);
        }
    }

    public void RemoverItemCarrinho(ISession session, int produtoId)
    {
        var cart = CarrinhoItems(session);
        var itemRemover = cart.FirstOrDefault(item => item.ProdutoId == produtoId);
        if (itemRemover != null)
        {
            cart.Remove(itemRemover);
            SalvarCarrinho(session, cart);
        }
    }

    public void LimparCarrinho(ISession session)
    {
        session.Remove(CartSessionKey);
    }

    public decimal TotalCarrinho(ISession session)
    {
        return CarrinhoItems(session).Sum(item => item.Total);
    }

    private void SalvarCarrinho(ISession session, List<Carrinho> cart)
    {
        session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
    }
}
