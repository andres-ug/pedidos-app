using Microsoft.EntityFrameworkCore;
using PedidosApp.Models;

namespace PedidosApp.Repository;

public class PedidoRepository : IRepository<Pedido>
{
    private readonly PedidoDbContext dbContext;

    public PedidoRepository(PedidoDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Pedido>> ObtenerTodos()
    {
        var pedidos = await dbContext.Pedidos
            .Include(pedido => pedido.Detalles).ToListAsync();
        return pedidos;
    }


    public async Task<Pedido> Agregar(Pedido pedido)
    {
        await dbContext.Pedidos.AddAsync(pedido);
        return pedido;
    }

    public async Task Eliminar(Guid id)
    {
        var pedido = await dbContext.Pedidos
            .FirstAsync(pedido => pedido.Id == id);
        dbContext.Pedidos.Remove(pedido);
        await dbContext.SaveChangesAsync();
    }
}