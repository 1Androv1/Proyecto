using System.Text.Json.Serialization;
using Models;
namespace Dtos;

public class AlimentosCompraDto
{
    public int IdAlimentos { get; set; }
    [JsonIgnore]
    public string? Nombre { get; set; }
    [JsonIgnore]
    public string? Descripción { get; set; }
    [JsonIgnore]
    public decimal Precio { get; set; }
    public int CantidadDisponible { get; set; }
    public int UserId { set; get; }
}