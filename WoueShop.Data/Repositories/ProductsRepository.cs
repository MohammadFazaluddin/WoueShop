using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WoueShop.Data.Interfaces;
using WouShop.Database;
using WouShop.Database.Entities;

namespace WoueShop.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DatabaseContext _database;

        public ProductsRepository(DatabaseContext database)
        {
            this._database = database;
        }

        public async Task<ProductModel?> Add(ProductModel product)
        {
            _database.Add(product);
            await _database.SaveChangesAsync();

            return product;
        }

        public async Task<ProductModel?> DeleteById(Guid id)
        {
            var entity = await GetById(id);

            if(entity == null)
            {
                return null;
            }

            _database.Entry(entity).State = EntityState.Deleted;

            await _database.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<ProductModel>?> GetAll()
        {
            var result = await _database.Products
                                    .OrderBy(e => e.IsOurChoice)
                                    .ToListAsync();

            return result;
        }

        public async Task<ProductModel?> GetById(Guid id)
        {
            var result = await _database.Products.FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public async Task<ProductModel?> Update(Guid id, ProductModel product)
        {
            var entity = await GetById(id);

            if(entity == null)
            {
                return null;
            }

            entity.Price = product.Price;
            entity.DiscountedPrice = product.DiscountedPrice;
            entity.IsOurChoice = product.IsOurChoice;
            entity.IsActive = product.IsActive;
            entity.Name = product.Name;
            entity.DeletedAt = product.DeletedAt;
            entity.ModifiedAt = DateTime.UtcNow;
            entity.ModifiedBy = product.ModifiedBy;

            _database.Entry(entity).State = EntityState.Modified;

            await _database.SaveChangesAsync();

            return entity;
        }
    }
}
