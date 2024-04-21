using Contexts;
using Interfaces;
using Models;

namespace Repositories;

public class TaskRepository(SqlDbContext sqlDbContext) : ITaskRepository
{
    public async Task SaveNewTask(Tasks tasks)
    {
        sqlDbContext.Tasks!.Add(tasks);
        await sqlDbContext.SaveChangesAsync();
    }

}