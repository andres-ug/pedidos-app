using System.ComponentModel.DataAnnotations;

namespace PedidosApp.Models;

public class Comida
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El precio es obligatorio.")]
    public decimal Precio { get; set; }
}