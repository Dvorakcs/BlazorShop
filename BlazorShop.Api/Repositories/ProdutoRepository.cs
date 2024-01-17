using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using BlazorShop.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetItem(int id)
        {
            return await _context.Produtos
                                    //include carrega o dados de outra tabela na tebala pai
                                    .Include(c => c.Categoria)
                                    //retorna o produtos com o id igual.
                                    .SingleOrDefaultAsync(p => p.Id == id) 
                                    // coloquei somente para sumir o alerta de avisa grr :)
                                    ?? new Produto();
        }

        public async Task<IEnumerable<Produto>> GetItens()
        {
            return await _context.Produtos
                                   //include carrega o dados de outra tabela na tebala pai
                                   .Include(c => c.Categoria)
                                   //retorna lista de produto
                                   .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetItensPorCategoria(int id)
        {
            return await _context.Produtos
                                   //include carrega o dados de outra tabela na tebala pai
                                   .Include(c => c.Categoria)
                                   //retorna o produtos com o id da categoria.
                                   .Where(p => p.CategoriaId == id)
                                   //retorna lista de produto
                                   .ToListAsync();
        }
    }
}
