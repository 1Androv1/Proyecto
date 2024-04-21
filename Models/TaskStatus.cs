using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class TaksStatus
{
    [Key]
    public int IdTaskStatus { set; get; }
    [MaxLength(20)]
    public string? NameStatus { set; get; }
}