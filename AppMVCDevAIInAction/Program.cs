using AppMVCDevAIInAction.Models;
using AppMVCDevAIInAction.Shared;
using MetodoKlinMilk.Data;
using MetodoKlinMilk.Data.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Services;
using MetodoKlinMilk.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<AcessoEntityModel>();
builder.Services.AddSingleton<TipoPlano>();
builder.Services.AddScoped<IAcessoService, AcessoService>();
builder.Services.AddScoped<IAcessoRepository, AcessoRepository>();
builder.Services.AddScoped<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
