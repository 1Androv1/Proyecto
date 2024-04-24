using System.Net;
using System.Net.Mail;
using Contexts;
using Dtos;
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
        var user = await sqlDbContext.Users!
            .Where(t => t.Email == userEmail)
            .FirstAsync();

        if(user.Verification == false)
            EnvioCorreo(user.Email, user.Name + " " + user.LastName);
        
        return user;
    }
    
    public Task<Users> ValidateIfUserExist(int? idUser)
    {
        return sqlDbContext.Users!
            .Where(t => t.IdUser == idUser)
            .FirstAsync();
    }

    public void EnvioCorreo(string? email, string? nombres)
    {
        try
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.To.Add(email!);

                mailMessage.Subject = "VERIFICACION DE CORREO ELECTRONICO";
                mailMessage.Body =
                    $"Hola {nombres}, has creado una cuenta en el sistema, por favor ingresa al siguiente link para" +
                    $"poder validar tu correo electronico: 'http://localhost:5235/api/users/verifyEmail/{email}";
                mailMessage.IsBodyHtml = false;

                mailMessage.From = new MailAddress("rojaspruebasalejandro@gmail.com", "ALERTA");

                using (SmtpClient cliente = new SmtpClient())
                {
                    cliente.UseDefaultCredentials = false;
                    cliente.Credentials =
                        new NetworkCredential("rojaspruebasalejandro@gmail.com", "fqrh phga jgli cmrv");
                    cliente.Port = 587;
                    cliente.EnableSsl = true;

                    cliente.Host = "smtp.gmail.com";
                    cliente.Send(mailMessage);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task ChangeVerification(string? email)
    {
        var user = await sqlDbContext.Users!
            .FirstOrDefaultAsync(u => u.Email == email);

        user!.Verification = true;
        
        await sqlDbContext.SaveChangesAsync();
    }
    
    public async Task<List<UsersFilterDto>> GetAllUser()
    {
        return await sqlDbContext.Users!
            .Select(user => new UsersFilterDto()
            {
                IdUser = user.IdUser,
                Name = user.Name + " " + user.LastName
            })
            .ToListAsync();
    }

}