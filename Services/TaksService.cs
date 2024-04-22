using System.ComponentModel.DataAnnotations;
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
        int idTask = taskUpdateDto.IdTask;
        var taskExits = await taskRepository.GetDetailTask(idTask);
        
        if (taskExits == null)
            throw new ValidationException($"The Task {idTask} does not exist.");

        var taskModel = taskUpdateDto.ConvertDtoToModel<TaskUpdateDto, Tasks>();
        await taskRepository.UpdateTask(taskModel);
    }
    
    public async Task<TaksDto?> GetDetailTask(int idTask)
    {
        var taskDto = await taskRepository.GetDetailTask(idTask);
        return taskDto?.ConvertModelTaskIdToDto<Tasks, TaksDto>();
    }
    
    public async Task DeletedTaskId(int idTask)
    {
        await taskRepository.DeletedTaskId(idTask);
    }
    
    public async Task<List<TaskListDto>> GetAllTask()
    {
        var tasks = await taskRepository.GetAllTasks();
        var tasksDto = tasks.ConvertTaskListToDto<Tasks, TaskListDto>();
        return tasksDto;
    }
}