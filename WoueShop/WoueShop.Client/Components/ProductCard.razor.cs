using Microsoft.AspNetCore.Components;

namespace WoueShop.Client.Components
{
    public partial class ProductCard : ComponentBase
    {
        [Parameter]
        public Guid ProductId { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public decimal Price { get; set; }

        [Inject]
        NavigationManager NavManager { get; set; }

        void NavigateToDetails()
        {
            NavManager.NavigateTo($"Product/{ProductId}");
        }
    }
}
