namespace Dtos;

public class TaksDto
{
    public int IdTask { set; get; }
    public string? NameTask { set; get; } 
    public string? Description { set; get; }
    public DateTime? CreationDate { set; get; } = DateTime.Now;
    public DateTime? StartTime { set; get; }
    public DateTime? EndTime { set; get; }
    public int StatusId { set; get; }
    public int UserCreateId { set; get; }
    public int OwnerUserId { set; get; }
}