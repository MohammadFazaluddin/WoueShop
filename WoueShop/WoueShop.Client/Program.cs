using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WoueShop.Client.Services;
using WoueShop.Data.Repositories.ProductRepositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient()
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/")
});

builder.Services.AddScoped<IProductsRepository, ProductAPIService>();

await builder.Build().RunAsync();
