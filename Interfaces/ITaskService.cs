using Dtos;

namespace Interfaces;

public interface ITaskService
{
    Task SaveAnNewTask(TaksDto taksDto);
    Task UpdateATask(TaskUpdateDto taskUpdateDto);
}