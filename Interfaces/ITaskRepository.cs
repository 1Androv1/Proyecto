using Models;

namespace Interfaces;

public interface ITaskRepository
{
    Task SaveNewTask(Tasks tasks);
    Task<Tasks?> GetDetailTask(int id);
    Task UpdateTask(Tasks? tasks);
    Task DeletedTaskId(int idTask);
}