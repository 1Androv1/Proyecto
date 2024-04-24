using System.Net;
using System.Net.Mail;
using Contexts;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories;

public class TaskRepository(SqlDbContext sqlDbContext) : ITaskRepository
{
    public async Task SaveNewTask(Tasks tasks)
    {
        sqlDbContext.Tasks!.Add(tasks);

        var userSendEmail = await sqlDbContext.Users!
            .FirstOrDefaultAsync(t => t.IdUser == tasks.OwnerUserId);
        
        if(userSendEmail == null)
            throw new ArgumentNullException(nameof(tasks), "No se pudo enviar el correo electronico.");

        string message = $"Hola {userSendEmail.Name} {userSendEmail.LastName}, te han asignado una tarea llamada {tasks.NameTask}, la cual comensara " +
                          $"el {tasks.StartTime} y finalizara {tasks.EndTime}";
        
        string displayName = "ASIGNACION DE TAREA";
        
        EnvioCorreo(userSendEmail.Email,message, displayName);
        
        await sqlDbContext.SaveChangesAsync();
    }
    public async Task<Tasks?> GetDetailTask(int id)
    {
        return await sqlDbContext.Tasks!
            .FirstOrDefaultAsync(t => t.IdTask == id);
    }
    public async Task UpdateTask(Tasks? tasks)
    {
        if (tasks == null)
            throw new ArgumentNullException(nameof(tasks), "La tarea proporcionada es nula.");

        var taskExist = await sqlDbContext.Tasks!
            .FirstOrDefaultAsync(t => t.IdTask == tasks.IdTask);

        if (taskExist == null)
            throw new InvalidOperationException($"No se encontró ninguna tarea con IdTask = {tasks.IdTask}.");
        
        taskExist.NameTask = tasks.NameTask;
        taskExist.Description = tasks.Description;
        taskExist.StatusId = tasks.StatusId;
        taskExist.StartTime = tasks.StartTime;
        taskExist.EndTime = tasks.EndTime;
        
        await sqlDbContext.SaveChangesAsync();
    }
    public async Task DeletedTaskId(int idTask)
    {
        var taskDelete = await sqlDbContext.Tasks!
            .FirstOrDefaultAsync(t => t.IdTask == idTask);
        
        if (taskDelete != null)
        {
            sqlDbContext.Tasks!.Remove(taskDelete);
        
            await sqlDbContext.SaveChangesAsync();
        }
    }
    public async Task<List<Tasks>> GetAllTasks()
    {
        return await sqlDbContext.Tasks!
            .Include(ts => ts.Status)
            .Include(u => u.User)
            .Include(u2 => u2.OwnerUser)
            .ToListAsync();
    }
    public async Task<List<Tasks>> FilterTask(string? filter)
    {
        return await sqlDbContext.Tasks!
            .Include(ts => ts.Status)
            .Include(u => u.User)
            .Include(u2 => u2.OwnerUser)
            .Where(f => f.NameTask != null && f.NameTask!.Contains(filter!))
            .ToListAsync();
    }
    public async Task UpdateStatus(Tasks? tasks)
    {
        if (tasks == null)
            throw new ArgumentNullException(nameof(tasks), "Cambio de Estado");

        var taskExist = await sqlDbContext.Tasks!
            .FirstOrDefaultAsync(t => t.IdTask == tasks.IdTask);

        if (taskExist == null)
            throw new InvalidOperationException($"No se encontró ninguna tarea con IdTask = {tasks.IdTask}.");

        taskExist.StatusId = tasks.StatusId;
        
        var userSendEmail = await sqlDbContext.Users!
            .FirstOrDefaultAsync(t => t.IdUser == taskExist.OwnerUserId);
        
        if(userSendEmail == null)
            throw new ArgumentNullException(nameof(taskExist), "No se pudo enviar el correo electronico de actualizacion de status.");

        string message = $"Hola {userSendEmail.Name} {userSendEmail.LastName}, la tarea {taskExist.NameTask}, fue cambiada de status ";
        string displayName = "CAMBIO DE STATUS";
        EnvioCorreo(userSendEmail.Email, message, displayName);
        
        await sqlDbContext.SaveChangesAsync();
    }
    public void EnvioCorreo(string? email, string? message, string? displayName)
    {
        try
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.To.Add(email!);

                mailMessage.Subject = "ASIGNACION DE TAREA";
                mailMessage.Body = $"{message}";
                mailMessage.IsBodyHtml = false;

                mailMessage.From = new MailAddress("rojaspruebasalejandro@gmail.com", displayName);

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

}