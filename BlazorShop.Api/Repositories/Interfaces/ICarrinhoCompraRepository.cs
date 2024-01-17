using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Api.Repositories.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItem> DeletaItem(int id);
        Task<CarrinhoItem> GetItem(int id);
        Task<IEnumerable<CarrinhoItem>> GetItems(string usuarioId);
    }
}
