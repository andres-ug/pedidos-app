using Microsoft.EntityFrameworkCore;
using PedidosApp.Models;

namespace PedidosApp.Repository;

public class DetallePedidoRepository : IRepository<DetallePedido>
{
    private readonly PedidoDbContext _pedidoDbContext;

    public DetallePedidoRepository(PedidoDbContext pedidoDbContext)
    {
        _pedidoDbContext = pedidoDbContext;
    }

    public async Task<List<DetallePedido>> ObtenerTodos()
    {
        return await _pedidoDbContext.DetallePedidos.AsNoTracking().ToListAsync();
    }

    public async Task<DetallePedido> Agregar(DetallePedido entity)
    {
        await _pedidoDbContext.AddAsync(entity);
        return entity;
    }

    public async Task Eliminar(Guid id)
    {
        var detallePedido = await _pedidoDbContext.DetallePedidos
            .FirstAsync(x => x.Id == id);
        _pedidoDbContext.DetallePedidos.Remove(detallePedido);
    }
}