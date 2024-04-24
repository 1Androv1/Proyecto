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
        
        var asigSendEmail = await sqlDbContext.Users!
            .FirstOrDefaultAsync(t => t.IdUser == tasks.UserCreateId);
        
        if(userSendEmail == null)
            throw new ArgumentNullException(nameof(tasks), "No se pudo enviar el correo electronico.");
        
        string displayName = "ASIGNACIÓN";
        string subject = "ASIGNACIÓN DE TAREA-"+DateTime.Now; 
        
        string message = $@"
        <table width='100%' align='center' border='0' cellspacing='0px' cellpadding='0' style='max-width:670px;border:solid 1px #dcdcdc'>
            <tbody>
                <tr>
                    <td style='padding:0px 5% 0px'>
                        <table width='100%' align='center' cellspacing='0' cellpadding='0' border='0' style='max-width:550px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;font-size:16px;color:#646464;font-weight:400'>
                            <tbody>
                                <tr>
                                    <td width='100%' style='text-align:center;padding:80px 0 10px'>
                                        <img src='https://ci3.googleusercontent.com/meips/ADKq_NbCcRxpBNHl8ejSSlzMFHeRnrpSwTh5Fh8OtftxGrvLelXAEiFfAOMvc431MFwnSbns04QvIJyRCFEjhLYc1scU_fH8Y1ko2NtArEWCAXST7sNDSWyGX98=s0-d-e1-ft#https://mail-nequi-co.s3.amazonaws.com/facturas/facturas_babel.png' alt='facturas_exitoso' class='CToWUd' data-bit='iit'>
                                    </td>
                                </tr>
                                <tr>
                                    <td width='100%' style='font-size:18px;font-weight:700;color:#200020;padding:25px 0 20px;text-align:center'>
                                        {userSendEmail.Name} {userSendEmail.LastName}
                                    </td>
                                </tr>
                                <tr>
                                    <td width='100%' style='font-size:16px'>
                                        Una tarea ha cambiado de estado
                                    </td>
                                </tr>
                                <tr>
                                    <td width='100%' style='font-size:18px;font-weight:700;padding:20px 0 10px'>
                                        Nombre: {tasks.NameTask}
                                    </td>
                                </tr>
                                <tr>
                                    <td width='100%' style='font-size:16px'>
                                        Comienza: {tasks.StartTime}
                                    </td>
                                </tr>
                                <tr>
                                    <td width='100%' style='font-size:16px'>
                                        Finaliza: {tasks.EndTime}
                                    </td>
                                </tr>
                                <tr>
                                    <td width='100%' style='font-size:16px'>
                                        Descripcion: {tasks.Description}
                                    </td>
                                </tr>
                                <tr>
                                    <td width='100%' style='padding:40px 0px 50px;color:#848484;font-size:16px;text-align:left'>
                                        Cualquier duda no dudes en comunicarte con tu instructor {asigSendEmail!.Name} {asigSendEmail.LastName} la cual te asigno la tarea.<br>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>";

        
        EnvioCorreo(userSendEmail.Email,message, displayName, subject);
        
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
        taskExist.OwnerUserId = tasks.OwnerUserId;
        
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

        string message = 
            $@"<table width='100%' align='center' border='0' cellspacing='0px' cellpadding='0' style='max-width:670px;border:solid 1px #dcdcdc'>
                <tbody>
                    <tr>
                        <td style='padding:0px 5% 0px'>
                            <table width='100%' align='center' cellspacing='0' cellpadding='0' border='0' style='max-width:550px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;font-size:16px;color:#646464;font-weight:400'>
                                <tbody>
                                    <tr>
                                        <td width='100%' style='text-align:center;padding:80px 0 10px'>
                                            <img src='https://ci3.googleusercontent.com/meips/ADKq_NbCcRxpBNHl8ejSSlzMFHeRnrpSwTh5Fh8OtftxGrvLelXAEiFfAOMvc431MFwnSbns04QvIJyRCFEjhLYc1scU_fH8Y1ko2NtArEWCAXST7sNDSWyGX98=s0-d-e1-ft#https://mail-nequi-co.s3.amazonaws.com/facturas/facturas_babel.png' alt='facturas_exitoso' class='CToWUd' data-bit='iit'>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width='100%' style='font-size:18px;font-weight:700;color:#200020;padding:25px 0 20px;text-align:center'>
                                            {userSendEmail.Name} {userSendEmail.LastName}
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width='100%' style='font-size:16px'>
                                            Te han Asignado una Tarea.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width='100%' style='font-size:18px;font-weight:700;padding:20px 0 10px'>
                                            Nombre: {taskExist.NameTask}
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width='100%' style='font-size:16px'>
                                            Comienza: {taskExist.StartTime}
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width='100%' style='font-size:16px'>
                                            Finaliza: {taskExist.EndTime}
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width='100%' style='font-size:16px'>
                                            Descripcion: {taskExist.Description}
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width='100%' style='padding:40px 0px 50px;color:#848484;font-size:16px;text-align:left'>
                                            Recuerda estar al tanto del cambio de cada tarea<br>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>";
        
        string displayName = "STATUS";
        string subject = "CAMBIO DE STATUS-"+DateTime.Now;
        EnvioCorreo(userSendEmail.Email, message, displayName, subject);
        
        await sqlDbContext.SaveChangesAsync();
    }
    public void EnvioCorreo(string? email, string? message, string? displayName, string subject)
    {
        try
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.To.Add(email!);

                mailMessage.Subject = subject;
                mailMessage.Body = $"{message}";
                mailMessage.IsBodyHtml = true;

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