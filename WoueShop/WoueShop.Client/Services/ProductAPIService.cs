using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Client.Services
{
    public class ProductAPIService
    {
        private readonly HttpClient _httpClient;

        public ProductAPIService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductViewModel>?> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ProductViewModel>>("products");

            return result;
        }

        public async Task<ProductViewModel?> GetById(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ProductViewModel>($"products/{id}");

            return result;
        }

    }
}
