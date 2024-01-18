using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface ICatologoServices
    {
        Task<CategoriaDto> GetCategoria(int id);
        Task<IEnumerable<CategoriaDto>> GetCategorias();
    }
}
