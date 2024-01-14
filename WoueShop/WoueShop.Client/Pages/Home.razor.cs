using Microsoft.AspNetCore.Components;
using WoueShop.Data.Interfaces;
using WoueShop.Shared.ViewModels;
using WouShop.Database.Entities;

namespace WoueShop.Client.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        IProductsRepository? ProductsService { get; set; }

        IEnumerable<ProductModel> products;

        protected override async Task OnInitializedAsync()
        {
            await GetAllProducts();
        }

        async Task GetAllProducts()
        {
            var result = await ProductsService!.GetAll();

            products = result;

            StateHasChanged();
        }

    }
}
