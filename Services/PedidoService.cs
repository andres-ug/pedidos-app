using PedidosApp.Models;
using PedidosApp.Repository;

namespace PedidosApp.Services;

public class PedidoService
{
    private readonly IRepository<Pedido> _pedidoRepository;
    private readonly IRepository<DetallePedido> _detallePedidoRepository;

    public PedidoService(IRepository<Pedido> pedidoRepository, IRepository<DetallePedido> detallePedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _detallePedidoRepository = detallePedidoRepository;
    }

    public async Task<List<Pedido>> ObtenerTodos()
    {
        return await _pedidoRepository.ObtenerTodos();
    }

    public async Task AgregarPedido(Pedido pedido)
    {
        await _pedidoRepository.Agregar(pedido);
    }

    public async Task EliminarPedido(Guid id)
    {
        await _pedidoRepository.Eliminar(id);
    }
    
    public async Task<DetallePedido> AgregarDetallePedido(DetallePedido detallePedido)
    {
        await _detallePedidoRepository.Agregar(detallePedido);
        return detallePedido;
    }
    
    // public async Task<DetallePedido> ActualizarCantDetalle(DetallePedido detallePedido)
    // {
    //     await _detallePedidoRepository.(detallePedido);
    //     return detallePedido;
    // }

    public async Task EliminarDetallePedido(Guid id)
    {
        await _pedidoRepository.Eliminar(id);
    }
}