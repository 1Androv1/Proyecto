using Dtos;
using Models;

namespace Interfaces;

public interface IUserRepository
{
    Task SaveNewUser(Users userModel);
    Task<Users> GetUserInSession(string? userEmail);
    Task<Users> ValidateIfUserExist(int? idUser);
    Task ChangeVerification(string? email);
    Task<List<UsersFilterDto>> GetAllUser();
}