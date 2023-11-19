using System.ComponentModel.DataAnnotations;

namespace PedidosApp.Models;

public class DetallePedido
{

    [Key] public Guid Id { get; set; }
    
    [Required(ErrorMessage = "El campo Cantidad es requerido")]
    public int Cantidad { get; set; }
    
    public decimal Subtotal => Comida.Precio * Cantidad;

    public Guid PedidoId { get; set; } // Clave foránea
    public Pedido Pedido { get; set; } = new(); // Propiedad de navegación

    public Guid ComidaId { get; set; } // Clave foránea
    public Comida Comida { get; set; } = new(); // Propiedad de navegación
}