using BlazorShop.Models.DTOs;
using BlazorShop.Web.Services.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{

    public class CarrinhoCompraService : ICarrinhoCompraServices
    {
        private readonly HttpClient _httpClient;

        public CarrinhoCompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
           var response = await _httpClient.PostAsJsonAsync<CarrinhoItemAdicionaDto>($"api/CarrinhoCompra/", carrinhoItemAdicionaDto);
            if (response.IsSuccessStatusCode)
            {
                if(response.StatusCode is HttpStatusCode.NoContent)
                {
                    return default(CarrinhoItemDto);
                }

                return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
            }
            return default(CarrinhoItemDto);
        }

        public async Task<List<CarrinhoItemDto>> GetItens(string usuarioId)
        {
            try
            {
                var reponse = await _httpClient.GetFromJsonAsync<IEnumerable<CarrinhoItemDto>>($"api/CarrinhoCompra/{usuarioId}/GetItens") ?? new List<CarrinhoItemDto>();
                return reponse.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
