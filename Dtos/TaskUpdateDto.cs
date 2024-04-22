namespace Dtos;

public class TaskUpdateDto
{
    public int IdTask { set; get; }
    public string? NameTask { set; get; } 
    public string? Description { set; get; }
    public DateTime? StartTime { set; get; }
    public DateTime? EndTime { set; get; }
    public int StatusId { set; get; }
}