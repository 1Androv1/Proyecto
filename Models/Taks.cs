using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Taks
{
    [Key]
    public int IdTask { set; get; }
    [MaxLength(30)]
    public string? NameTask { set; get; } 
    [MaxLength(30)]
    public string? Description { set; get; }
    public DateTime? CreationDate { set; get; } = DateTime.Now;
    public DateTime? StartTime { set; get; }
    public DateTime? EndTime { set; get; }
    public int StatusId { set; get; }
    [ForeignKey("StatusId")] public TaskStatus? Status { get; set; }
    public int UserCreateId { set; get; }
    [ForeignKey("UserCreateId")] public Users? User { get; set; }
    public int OwnerUserId { set; get; }
    [ForeignKey("OwnerUserId")] public Users? OwnerUser { get; set; }
}