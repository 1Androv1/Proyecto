using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models;

public class Users
{
    [Key]
    public int IdUser { set; get; } 
    [MaxLength(20)]
    public string? Name { set; get; }
    [MaxLength(20)]
    public string? LastName { set; get; }
    [MaxLength(80)]
    public string? Email { set; get; }
    [MaxLength(20)]
    public string? Password { set; get; }
    public int RolId { set; get; }
    [ForeignKey("RolId")] public Rols? Rols { get; set; }
    public bool Verification { set; get; } = false;
}