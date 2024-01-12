using Microsoft.AspNetCore.Components;
using WoueShop.Data.Interfaces;
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
            try
            {
                var result = await ProductsRepository!.GetAll();

                products = result;

            }
            catch (Exception ex)
            {

                throw;
            }
            StateHasChanged();
        }
    }
}
