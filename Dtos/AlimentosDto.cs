namespace Dtos;

public class AlimentosDto
{
    public int IdAlimentos { get; set; }
    public string? Nombre { get; set; }
    public string? Descripción { get; set; }
    public decimal Precio { get; set; }
    public int CantidadDisponible { get; set; }
}