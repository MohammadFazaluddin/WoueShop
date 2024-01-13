using Microsoft.EntityFrameworkCore;
using WouShop.Database;
using WoueShop.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAntiforgery();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<DatabaseContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration
        .GetConnectionString("DefaultConnection"))
             .UseSnakeCaseNamingConvention();
});


builder.Services.AddDataServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapRazorPages();
app.MapFallbackToFile("index.html");
app.MapControllers();

app.UseAntiforgery();

app.Run();
