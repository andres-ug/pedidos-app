using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using PedidosApp.Data;
using MudBlazor.Services;
using PedidosApp.Models;
using PedidosApp.Repository;
using PedidosApp.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<PedidoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Pedido>, PedidoRepository>();
builder.Services.AddScoped<IRepository<Comida>, ComidaRepository>();
builder.Services.AddScoped<IRepository<DetallePedido>, DetallePedidoRepository>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<ComidaService>();
builder.Services.AddMudServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var dbContext = serviceProvider.GetRequiredService<PedidoDbContext>();

        // Ejecutar las migraciones para asegurarse de que la base de datos esté actualizada
        dbContext.Database.Migrate();

        // Verificar si hay comidas creadas
        if (!dbContext.Comidas.Any())
        {
            // Si no hay comidas, crea algunas de ejemplo
            var comidas = new List<Comida>
            {
                new() { Nombre = "Encebollado", Precio = 10.99M },
                new() { Nombre = "Ceviche de Camarón", Precio = 12.99M },
                new() { Nombre = "Seco de Chivo", Precio = 15.99M },
                new() { Nombre = "Arroz con Menestra y Carne Asada", Precio = 14.99M },
                new() { Nombre = "Bolon de Verde", Precio = 8.99M }
            };

            dbContext.Comidas.AddRange(comidas);
            dbContext.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al intentar inicializar la base de datos.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();