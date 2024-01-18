using BlazorShop.Models.DTOs;
using BlazorShop.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class CatologoServices : ICatologoServices
    {
        public HttpClient _httpClient;
        public ILogger<CatologoServices> _logger;

        public CatologoServices(HttpClient httpClient, ILogger<CatologoServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public Task<CategoriaDto> GetCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategorias()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<CategoriaDto>>($"api/categoria/") ?? new List<CategoriaDto>();
            }
            catch (Exception)
            {
                _logger.LogError("Error ao acesssar produtos : api/produtos/id");
                throw;
            }
        }
    }
}
