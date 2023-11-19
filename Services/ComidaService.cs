using PedidosApp.Models;
using PedidosApp.Repository;

namespace PedidosApp.Services;

public class ComidaService
{
    private readonly IRepository<Comida> comidaRepository;

    public ComidaService(IRepository<Comida> comidaRepository)
    {
        this.comidaRepository = comidaRepository;
    }

    public async Task<List<Comida>> ObtenerTodas()
    {
        return await comidaRepository.ObtenerTodos();
    }
}