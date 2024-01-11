using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WoueShop.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped(http => new HttpClient()
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/")
});

await builder.Build().RunAsync();
