namespace Toycom.Models
{
    public class Carrinho
    {
        public int ProdutoId { get; set; }

        public Produtos Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }


        public decimal Total => Quantidade * Preco;
    }
}
