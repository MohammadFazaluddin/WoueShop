using System.Net.Http.Json;
using WoueShop.Data.Interfaces;
using WoueShop.Shared.ViewModels;
using WouShop.Database.Entities;

namespace WoueShop.Client.Services
{
    public class ProductAPIService : IProductsRepository
    {
        private readonly HttpClient httpClient;

        public ProductAPIService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ProductModel?> Add(ProductModel product)
        {
            var result = await httpClient.PostAsJsonAsync<ProductModel>("products", product);

            return await result.Content.ReadFromJsonAsync<ProductModel>();
        }

        public Task<ProductModel?> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductModel>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel?> Update(Guid id, ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
