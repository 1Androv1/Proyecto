using Models;

namespace Interfaces;

public interface ITaskRepository
{
    Task SaveNewTask(Tasks tasks);
}