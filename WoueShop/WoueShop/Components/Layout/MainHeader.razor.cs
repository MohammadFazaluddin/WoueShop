using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace WoueShop.Components.Layout
{
    public partial class MainHeader : ComponentBase, IDisposable
    {
        [Inject]
        NavigationManager NavManager { get; set; }

        string currentUrl = string.Empty;

        protected override void OnInitialized()
        {
            currentUrl = NavManager.ToBaseRelativePath(NavManager.Uri);
            NavManager.LocationChanged += OnLocationChanged;
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            currentUrl = NavManager.ToBaseRelativePath(e.Location);
            StateHasChanged();
        }

        public void Dispose()
        {
            NavManager.LocationChanged -= OnLocationChanged;
        }
    }
}
