using Dtos;

namespace Interfaces;

public interface ITaskService
{
    Task SaveAnNewTask(TaksDto taksDto);
    Task UpdateATask(TaskUpdateDto taskUpdateDto);
    Task<TaksDto?> GetDetailTask(int idTask);
    Task DeletedTaskId(int idTask);
    Task<List<TaskListDto>> GetAllTask();
    Task<List<TaskListDto>> FilterTask(string? filter);
    Task UpdateStatus(TaskChangeStatusDto changeStatusDto);
}