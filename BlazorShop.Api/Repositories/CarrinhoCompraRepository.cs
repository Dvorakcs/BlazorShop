using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using BlazorShop.Api.Repositories.Interfaces;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Api.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarrinhoCompraRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoItem> DeletaItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoItem> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CarrinhoItem>> GetItems(string usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
