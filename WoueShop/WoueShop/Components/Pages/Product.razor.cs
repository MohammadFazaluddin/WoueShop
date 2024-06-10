using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using WoueShop.Client.AuthUtility;
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

        [Inject]
        AuthenticationStateProvider AuthStateProvider { get; set; }

        [CascadingParameter]
        HttpContext HttpContext { get; set; }

        string authuser = "no user";
        bool? authorized = null;
        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthStateProvider.GetAuthenticationStateAsync();

            authorized = auth.User.Identity.IsAuthenticated;
            authuser = auth.User.Identity.Name;
            StateHasChanged();
            base.OnInitializedAsync();
        }

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
