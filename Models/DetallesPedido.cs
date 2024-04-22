using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class DetallesPedido
{
    [Key]
    public int IdDetalles { get; set; }
    public int PedidoId { get; set; }
    public int AlimentoId { get; set; }
    public int Cantidad { get; set; }
    [ForeignKey("PedidoId")]
    public Pedidos? Pedidos { get; set; }
    [ForeignKey("AlimentoId")]
    public Alimentos? Alimentos { get; set; }
}