using Microsoft.AspNetCore.Components;

namespace WoueShop.Client.Components
{
    public partial class ProductCard : ComponentBase
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public decimal Price { get; set; }
    }
}
