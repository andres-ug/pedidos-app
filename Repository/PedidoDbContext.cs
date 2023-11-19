using Microsoft.EntityFrameworkCore;
using PedidosApp.Models;

namespace PedidosApp.Repository;

public class PedidoDbContext : DbContext
{
    public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Comida> Comidas { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
}