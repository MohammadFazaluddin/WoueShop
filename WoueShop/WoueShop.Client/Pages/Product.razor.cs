using Microsoft.AspNetCore.Components;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Client.Pages
{
    public partial class Product : ComponentBase
    {
        [Parameter]
        public ProductViewModel Model { get; set; }

        ProductViewModel EditModel { get; set; } = new();

        protected override void OnParametersSet()
        {
            EditModel = Model;
        }

        void HandleSubmit()
        {

        }
    }
}
