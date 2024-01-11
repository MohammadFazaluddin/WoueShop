using System.Net.Http.Json;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Client.Services
{
    public class ProductAPIService
    {
        private readonly HttpClient httpClient;

        public ProductAPIService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> Add(ProductViewModel product)
        {
            var result = httpClient.PostAsJsonAsync("products", product);

            return result.IsCompletedSuccessfully;
        }
    }
}
