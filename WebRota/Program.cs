using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Adicione esta declaração no topo do arquivo
using WebRota.Domain.Interfaces;
using WebRota.Infra.Context;
using WebRota.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = builder.Configuration;
builder.Services.AddControllersWithViews();
// Configuração do DbContext com a string de conexão
builder.Services.AddDbContext<WebRotaContext>(options =>
    options.UseSqlServer(@"Server=localhost;Database=testeDB;User Id=SA;Password=Willian!@Cavalo125Ra;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=true;"));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
