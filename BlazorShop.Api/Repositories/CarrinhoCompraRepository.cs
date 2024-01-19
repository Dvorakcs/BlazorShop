using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using BlazorShop.Api.Repositories.Interfaces;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarrinhoCompraRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        private async Task<bool> CarrinhoItemExite(int carrinhoId,int produtoId)
        {
            return await _appDbContext.CarrinhoItens.
                                       AnyAsync(c => c.CarrinhoId == carrinhoId &&
                                                     c.ProdutoId == produtoId);      
        }
        public async Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            if (await CarrinhoItemExite(
                carrinhoItemAdicionaDto.CarrinhoId,
                carrinhoItemAdicionaDto.ProdutoId) is false)
            {
                var item = await (from produto in _appDbContext.Produtos
                                  where produto.Id == carrinhoItemAdicionaDto.ProdutoId
                                  select new CarrinhoItem
                                  {
                                      CarrinhoId = carrinhoItemAdicionaDto.CarrinhoId,
                                      ProdutoId = produto.Id,
                                      Quantidade = carrinhoItemAdicionaDto.Quantidade
                                  }).SingleOrDefaultAsync();

                if(item is not null)
                {
                    var result = await _appDbContext.CarrinhoItens.AddAsync(item);  
                    await _appDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return new CarrinhoItem();
        }

        public Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoItem> DeletaItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoItem> GetItem(int id)
        {
            return await (from carrinho in _appDbContext.Carrinhos
                          join carrinhoItem in _appDbContext.CarrinhoItens
                          on carrinho.Id equals carrinhoItem.CarrinhoId
                          where carrinhoItem.Id == id
                          select new CarrinhoItem
                          {
                              Id = carrinhoItem.Id,
                              ProdutoId = carrinhoItem.ProdutoId,
                              Quantidade = carrinhoItem.Quantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId

                          }).SingleOrDefaultAsync() ?? new CarrinhoItem();
        }

        public async Task<IEnumerable<CarrinhoItem>> GetItems(string usuarioId)
        {
            return await (from carrinho in _appDbContext.Carrinhos
                          join carrinhoItem in _appDbContext.CarrinhoItens
                          on carrinho.Id equals carrinhoItem.CarrinhoId
                          where carrinho.UsuarioId == usuarioId
                          select new CarrinhoItem
                          {
                              Id = carrinhoItem.Id,
                              ProdutoId = carrinhoItem.ProdutoId,
                              Quantidade = carrinhoItem.Quantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId

                          }).ToListAsync();
        }
    }
}
