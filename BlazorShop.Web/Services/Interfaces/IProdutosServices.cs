using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface IProdutosServices
    {
        Task<IEnumerable<ProdutoDto>> GetItens();
        Task<ProdutoDto> GetItem(int id);
        Task<IEnumerable<ProdutoDto>> GetItensPorCategoria(int id);
    }
}
