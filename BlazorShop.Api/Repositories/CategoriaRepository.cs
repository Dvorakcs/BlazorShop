using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using BlazorShop.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await _context.Categorias.SingleOrDefaultAsync(p => p.Id == id)?? new Categoria();
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();

        }
    }
}
