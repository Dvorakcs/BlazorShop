using BlazorShop.Models.DTOs;
using BlazorShop.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class ProdutosServices : IProdutosServices
    {
        public HttpClient _httpClient;
        public ILogger<ProdutosServices> _logger;

        public ProdutosServices(HttpClient httpClient, ILogger<ProdutosServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ProdutoDto> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoDto>> GetItens()
        {
            try
            {
                return await _httpClient.
                GetFromJsonAsync<IEnumerable<ProdutoDto>>
                ("api/produtos") ?? new List<ProdutoDto> { };
            }
            catch (Exception)
            {
                _logger.LogError("Error ao acesssar produtos : api/produtos");
                throw;
            }


        }

        public async Task<IEnumerable<ProdutoDto>> GetItensPorCategoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
