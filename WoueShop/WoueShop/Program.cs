using Microsoft.EntityFrameworkCore;
using WoueShop.Client.Pages;
using WoueShop.Client.Services;
using WoueShop.Components;
using WoueShop.Data;
using WoueShop.Data.Interfaces;
using WoueShop.Data.Repositories;
using WouShop.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContextPool<DatabaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
});

builder.Services.AddDataServices();

builder.Services.AddScoped(http => new HttpClient()
{
    BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings")["BASE_ADDRESS"]! + "api/")
});

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Product).Assembly);

app.Run();
