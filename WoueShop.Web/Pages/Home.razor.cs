using Microsoft.AspNetCore.Components;
using WoueShop.Client.Services;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Web.Pages
{
    public partial class Home 
    {
        [Inject]
        ProductAPIService? ProductService { get; set; }

        IEnumerable<ProductViewModel> products;

        protected override async Task OnInitializedAsync()
        {
            await GetAllProducts();
        }

        async Task GetAllProducts()
        {
            var result = await ProductService!.GetAll();

            products = result;

            StateHasChanged();
        }

        async Task DeleteProduct(Guid id)
        {
            var result = await ProductService!.DeleteById(id);

            await GetAllProducts();
        }
    }
}
