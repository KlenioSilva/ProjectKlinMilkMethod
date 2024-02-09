using AppRazorDevAIInAction.EF;
using AppRazorDevAIInAction.Models;
using AppRazorDevAIInAction.Shared;
using MetodoKlinMilk.Data.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Services;
using MetodoKlinMilk.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAcessoService, AcessoService>();
builder.Services.AddScoped<IAcessoRepository, AcessoRepository>();
builder.Services.AddScoped<Context>();
builder.Services.AddSingleton<AcessoEntityModel>();
builder.Services.AddSingleton<TipoPlano>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
