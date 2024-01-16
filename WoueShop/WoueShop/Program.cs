using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WoueShop.Client.Pages;
using WoueShop.Components;
using WoueShop.Data;
using WoueShop.Data.AuthEntities;
using WoueShop.Middlewares;
using WouShop.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

#region Database Services

builder.Services.AddDbContextPool<DatabaseContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration
        .GetConnectionString("DefaultConnection"))
             .UseSnakeCaseNamingConvention();
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    }).AddCookie(options =>
    {
        options.LoginPath = "/signin";
    });
//.AddIdentityCookies();

builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

#endregion

#region Common Services

builder.Services.AddScoped(http => new HttpClient()
    {
        BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings")["BASE_ADDRESS"]! + "api/")
    });

builder.Services.AddDataServices();

builder.Services.RegisterAdmin();

builder.Services.AddControllers();

#endregion

#region Request Response Pipeline
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

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Home).Assembly);

app.Run();
#endregion