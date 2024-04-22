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
        {
            throw new ArgumentNullException(nameof(tasks), "La tarea proporcionada es nula.");
        }

        var taskExist = await sqlDbContext.Tasks!
            .FirstOrDefaultAsync(t => t.IdTask == tasks.IdTask);

        if (taskExist == null)
        {
            throw new InvalidOperationException($"No se encontró ninguna tarea con IdTask = {tasks.IdTask}.");
        }
        taskExist!.NameTask = tasks!.NameTask;
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
}