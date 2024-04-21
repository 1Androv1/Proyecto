using Models;

namespace Interfaces;

public interface IUserRepository
{
    Task SaveNewUser(Users userModel);
    Task<Users> GetUserInSession(string? userEmail);
    Task<Users> ValidateIfUserExist(string? email);
}