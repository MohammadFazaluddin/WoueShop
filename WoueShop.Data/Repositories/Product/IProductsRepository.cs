using WouShop.Database.Entities;

namespace WoueShop.Data.Repositories.Product
{
    public interface IProductsRepository
    {
        Task<ProductModel?> Add(ProductModel product);

        Task<ProductModel?> Update(Guid id, ProductModel product);

        Task<ProductModel?> GetById(Guid id);

        Task<ProductModel?> DeleteById(Guid id);

        Task<IEnumerable<ProductModel>?> GetAll();

    }
}
