using BlazorAppModeloKlinMilk.Models;
using BlazorAppModeloKlinMilk.Shared;
using MetodoKlinMilk.Data;
using MetodoKlinMilk.Data.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Services;
using MetodoKlinMilk.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IAcessoService, AcessoService>();
builder.Services.AddScoped<IAcessoRepository, AcessoRepository>();
builder.Services.AddScoped<Context>();
builder.Services.AddSingleton<AcessoEntityModel>();
builder.Services.AddSingleton<TipoPlano>();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
