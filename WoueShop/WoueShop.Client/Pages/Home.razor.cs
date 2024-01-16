using Microsoft.AspNetCore.Components;
using WoueShop.Client.Services;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Client.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        ProductAPIService? ProductsService { get; set; }

        IEnumerable<ProductViewModel> products;

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
