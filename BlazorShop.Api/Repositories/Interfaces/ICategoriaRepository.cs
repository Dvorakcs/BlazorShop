using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
       Task<Categoria> GetCategoria(int id);
       Task<IEnumerable<Categoria>> GetCategorias();
    }
}
