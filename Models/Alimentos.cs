using System.ComponentModel.DataAnnotations;

namespace Models;

public class Alimentos
{
    [Key]
    public int IdAlimentos { get; set; }
    [MaxLength(100)]
    public string? Nombre { get; set; }
    [MaxLength(255)]
    public string? Descripción { get; set; }
    public decimal Precio { get; set; }
    public int CantidadDisponible { get; set; }
}