using Models;

namespace Dtos;

public class TaskListDto
{
    public int IdTask { set; get; }
    public string? NameTask { set; get; } 
    public string? Description { set; get; }
    public DateTime? CreationDate { set; get; }
    public DateTime? StartTime { set; get; }
    public DateTime? EndTime { set; get; }
    public int StatusId { set; get; }
    public TaksStatus? Status { get; set; }
    public int UserCreateId { set; get; }
    public Users? User { get; set; }
    public int OwnerUserId { set; get; }
    public Users? OwnerUser { get; set; }
}