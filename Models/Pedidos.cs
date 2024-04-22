using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Pedidos
{
    [Key]
    public int IdPedidos { get; set; }
    public int UserId { get; set; }
    public DateTime FechaPedido { get; set; }
    [ForeignKey("UserID")]
    public Users? Users { get; set; }
}