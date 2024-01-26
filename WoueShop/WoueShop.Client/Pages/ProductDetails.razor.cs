using Microsoft.AspNetCore.Components;
using WoueShop.Client.Services;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Client.Pages
{
    public partial class ProductDetails : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        ProductAPIService? ProductService { get; set; }

        ProductViewModel? product;

        protected override async Task OnParametersSetAsync()
        {
            await GetProductById();
        }

        async Task GetProductById()
        {
            product = await ProductService!.GetById(new Guid(Id));
            StateHasChanged();
        }
    }
}
