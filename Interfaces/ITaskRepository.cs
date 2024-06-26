﻿using Models;

namespace Interfaces;

public interface ITaskRepository
{
    Task SaveNewTask(Tasks tasks);
    Task<Tasks?> GetDetailTask(int id);
    Task UpdateTask(Tasks? tasks);
    Task DeletedTaskId(int idTask);
    Task<List<Tasks>> GetAllTasks();
    Task<List<Tasks>> FilterTask(string? filter);
    Task UpdateStatus(Tasks? tasks);
}