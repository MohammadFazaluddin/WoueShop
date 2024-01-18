using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WoueShop.Client.AuthUtility;
using WoueShop.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient()
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/")
});

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<ProductAPIService>();
builder.Services.AddSingleton<AuthenticationStateProvider, AppAuthenticationStateProvider>();

builder.Services.AddHttpContextAccessor();

await builder.Build().RunAsync();
