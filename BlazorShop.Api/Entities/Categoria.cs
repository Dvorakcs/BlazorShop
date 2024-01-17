using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Nome { get; set; }
        [MaxLength(100)]
        public string? IconCSS { get; set; }

        public Collection<Produto> Produtos { get; set; } = new();
    }
}
