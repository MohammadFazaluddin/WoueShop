using Microsoft.AspNetCore.Components;
using WoueShop.Data.Repositories.Product;
using WouShop.Database.Entities;

namespace WoueShop.Components.Pages
{
    public partial class Product : ComponentBase
    {
        [Parameter]
        public ProductModel Model { get; set; }

        [Inject]
        IProductsRepository? ProductRepository { get; set; }

        [Inject]
        NavigationManager NavManager { get; set; }

        ProductModel EditModel { get; set; } = new();

        protected override void OnParametersSet()
        {
            if (Model != null)
            {
                EditModel = Model;
            }
        }

        void HandleSubmit()
        {
            Add();
        }

        async void Add()
        {
            var result = await ProductRepository!.Add(EditModel);

            if (result != null)
                NavManager.NavigateTo("/");
        }
    }
}
