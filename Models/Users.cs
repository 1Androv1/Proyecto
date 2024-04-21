using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}