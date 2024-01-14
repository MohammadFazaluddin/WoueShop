using Microsoft.AspNetCore.Components;
using WoueShop.Data.Repositories.ProductRepositories;
using WoueShop.Shared.ViewModels;
using WouShop.Database.Entities;

namespace WoueShop.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        IProductsRepository? ProductsRepository { get; set; }

        IEnumerable<ProductModel> products;

        protected override async Task OnInitializedAsync()
        {
            await GetAllProducts();
        }

        async Task GetAllProducts()
        {
            var result = await ProductsRepository!.GetAll();

            products = result;

            StateHasChanged();
        }

        async Task DeleteProduct(Guid id)
        {
            var result = await ProductsRepository!.DeleteById(id);

            await GetAllProducts();
        }
    }
}
