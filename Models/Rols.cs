using System.ComponentModel.DataAnnotations;

namespace Models;

public class Rols
{
    [Key]
    public int IdRol { get; set; }
    [MaxLength(20)]
    public string? RolName { set; get; }
}