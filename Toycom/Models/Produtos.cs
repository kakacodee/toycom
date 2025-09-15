using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Toycom.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira um nome válido")]
        [StringLength(40)]
        public string Nome { get; set; }

        [StringLength(150)]
        public string Descricao { get; set; }

        [Required(ErrorMessage ="Insira um preço válido")]
        [Range(1.00, double.MaxValue)]
        public decimal Preco {  get; set; }
        [Display(Name = "URl")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Insira uma quantidade válida")]
        [Range(0, int.MaxValue)]
        public int Estoque { get; set; }
    }
}
