using Microsoft.AspNetCore.Components;
using WoueShop.Client.Services;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Web.Pages
{
    public partial class Product : ComponentBase
    {
        [Parameter]
        public ProductViewModel Model { get; set; }

        [Inject]
        ProductAPIService? ProductService { get; set; }

        [Inject]
        NavigationManager NavManager { get; set; }

        ProductViewModel EditModel { get; set; } = new();

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
            var result = await ProductService!.Add(EditModel);

            if (result != null)
                NavManager.NavigateTo("/");
        }
    }
}
