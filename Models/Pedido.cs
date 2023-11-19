using System.ComponentModel.DataAnnotations;

namespace PedidosApp.Models;

public class Pedido
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
    public string NombreCliente { get; set; } = null!;

    [Required(ErrorMessage = "La dirección es obligatoria.")]
    public string Direccion { get; set; } = null!;

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [StringLength(10, ErrorMessage = "El teléfono debe tener máximo 10 caracteres.")]
    public string Telefono { get; set; } = null!;

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
    public string Email { get; set; } = null!;

    public List<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();

    // Propiedades para los detalles de compra
    public decimal Subtotal => Detalles.Sum(detalle => detalle.Subtotal);
    public decimal Iva => Subtotal * 0.12m;
    public decimal Total => Subtotal + Iva;
}