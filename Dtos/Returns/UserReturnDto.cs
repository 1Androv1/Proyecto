namespace Dtos.Returns;

public class UserReturnDto
{
    public int IdUser { set; get; } 
    public string? Name { set; get; }
    public string? LastName { set; get; }
    public string? Email { set; get; }
    public string? Password { set; get; }
    public int RolId { set; get; }
    public bool Verification { set; get; }
}