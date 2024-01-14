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
            throw new NotImplementedException();
        }

        public Task<ProductModel?> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>?> GetAll()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>("products");

            return result;
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
