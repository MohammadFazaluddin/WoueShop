using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace WoueShop.Components.PageComponents
{
    public partial class Toaster : ComponentBase
    {
        [Parameter]
        public string Type { get; set; }

        [Parameter]
        [MaxLength(50)]
        public string Message { get; set; }
    }
}
