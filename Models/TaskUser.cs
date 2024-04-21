using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class TaskUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTaskUser { set; get; }
    public int TaskId { set; get; }
    [ForeignKey("TaskId")] public Tasks? Task { get; set; }
    public int UserId { set; get; }
    [ForeignKey("UserId")] public Users? User { get; set; }
}