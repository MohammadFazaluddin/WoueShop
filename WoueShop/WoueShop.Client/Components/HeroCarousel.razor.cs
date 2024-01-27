using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WoueShop.Client.Components
{
    public partial class HeroCarousel : ComponentBase
    {
        [Inject]
        IJSRuntime? JsRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await GetFlickity();
        }

        async Task GetFlickity()
        {
            await JsRuntime!.InvokeVoidAsync("startFlickity");
        }
    }
}
