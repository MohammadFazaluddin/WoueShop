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

        public async Task<ProductViewModel?> Add(ProductViewModel product)
        {
            var result = await httpClient.PostAsJsonAsync<ProductViewModel>("products", product);

            return await result.Content.ReadFromJsonAsync<ProductViewModel>();
        }

        public Task<ProductViewModel?> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductViewModel>?> GetAll()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ProductViewModel>>("products");

            return result;
        }

        public Task<ProductViewModel?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel?> Update(Guid id, ProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
