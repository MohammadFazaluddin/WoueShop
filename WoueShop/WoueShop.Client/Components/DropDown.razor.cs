using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace WoueShop.Client.Components
{
    partial class DropDown : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public EventCallback Close { get; set; }

        async void ClickClose(FocusEventArgs focus)
        {
            await Close.InvokeAsync();
        }
    }
}
