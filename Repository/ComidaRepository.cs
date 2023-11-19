using Microsoft.EntityFrameworkCore;
using PedidosApp.Models;

namespace PedidosApp.Repository;

public class ComidaRepository : IRepository<Comida>
{
    private readonly PedidoDbContext dbContext;

    public ComidaRepository(PedidoDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Comida>> ObtenerTodos()
    {
        return await dbContext.Comidas.ToListAsync();
    }

    public async Task<Comida> ObtenerPorId(int id)
    {
        return await dbContext.Comidas.FindAsync(id);
    }

    public async Task<Comida> Agregar(Comida comida)
    {
        dbContext.Comidas.Add(comida);
        await dbContext.SaveChangesAsync();
        return comida;
    }

    public async Task Eliminar(Guid id)
    {
        var comida = await dbContext.Comidas
            .FirstAsync(comida => comida.Id == id);
        dbContext.Comidas.Remove(comida);
        await dbContext.SaveChangesAsync();
    }
}