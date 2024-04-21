using Contexts;
using Interfaces;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class UserRepository(SqlDbContext sqlDbContext) : IUserRepository
{
    public async Task SaveNewUser(Users user)
    {
        var email = user.Email;

        var result = sqlDbContext.Users!
            .Where(t => t.Email == email);

        if (result.Any())
        {
            return;
        }

        sqlDbContext.Users!.Add(user);
        await sqlDbContext.SaveChangesAsync();
    }
    
    public async Task<Users> GetUserInSession(string? userEmail)
    {
        return await sqlDbContext.Users!
            .Where(t => t.Email == userEmail)
            .FirstAsync();
    }
    
    public Task<Users> ValidateIfUserExist(string? email)
    {
        return sqlDbContext.Users!
            .Where(t => t.Email == email)
            .FirstAsync();
    }
}