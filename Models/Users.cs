using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUser { set; get; } 
    public string? Name { set; get; }
    public string? LastName { set; get; }
    public string? Email { set; get; }
    public string? Password { set; get; }
}