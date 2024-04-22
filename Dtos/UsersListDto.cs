namespace Dtos;

public class UsersListDto
{
    public int IdUser { set; get; } 
    public string? Name { set; get; }
    public string? LastName { set; get; }
    public string? Email { set; get; }
    public string? Password { set; get; }
}