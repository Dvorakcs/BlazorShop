using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface ICarrinhoCompraServices
    {
        Task<List<CarrinhoItemDto>> GetItens(string usuarioId);
        Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

    }
}
