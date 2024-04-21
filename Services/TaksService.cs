using Dtos;
using Interfaces;
using Models;
using Helpers.Objects;

namespace Services;

public class TaksService(ITaskRepository taskRepository) : ITaskService
{
    public async Task SaveAnNewTask(TaksDto taksDto)
    {
        var tasks = taksDto.ConvertTaksDtoToModel<TaksDto, Tasks>();
        await taskRepository.SaveNewTask(tasks);
    }

    public async Task UpdateATask(TaskUpdateDto taskUpdateDto)
    {
        var taskId = taskUpdateDto.TaskId;
    }
}