using Domain.Entities;
using Domain.Repositories;
using Domain.Enums;
using TaskStatus = Domain.Enums.TaskStatus;
using Domain.Services;
using System;
using System.Threading.Tasks;

namespace Application.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepo;
    private readonly IUserRepository _userRepo;
    private readonly ILoggerService _logger;

    public TaskService(ITaskRepository taskRepo, IUserRepository userRepo, ILoggerService logger)
    {
        _taskRepo = taskRepo;
        _userRepo = userRepo;
        _logger = logger;
    }

    public async Task CreateTaskAsync(TaskItem task)
    {
        if (task.DueDate < DateTime.Now)
            throw new ArgumentException("Due date cannot be in the past.");

        task.Status = TaskStatus.Pending;
        await _taskRepo.AddAsync(task);
        _logger.Log($"Task '{task.Title}' created.");
    }

    public async Task AssignTaskAsync(Guid taskId, Guid userId)
    {
        var task = await _taskRepo.GetByIdAsync(taskId) ?? throw new Exception("Task not found.");
        var user = await _userRepo.GetByIdAsync(userId) ?? throw new Exception("User not found.");

        task.AssignedUserId = userId;
        await _taskRepo.UpdateAsync(task);
        _logger.Log($"Task '{task.Title}' assigned to user {user.Name}.");
    }

    public async Task<List<TaskItem>> GetAllTasksAsync()
    {
        return await _taskRepo.GetAllAsync();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(Guid taskId)
    {
        return await _taskRepo.GetByIdAsync(taskId);
    }

    public async Task<List<TaskItem>> GetTasksByUserAsync(Guid userId)
    {
        return await _taskRepo.GetByUserIdAsync(userId);
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        await _taskRepo.UpdateAsync(task);
        _logger.Log($"Task '{task.Title}' updated.");
    }

    public async Task DeleteTaskAsync(Guid taskId)
    {
        await _taskRepo.DeleteAsync(taskId);
        _logger.Log($"Task with ID '{taskId}' deleted.");
    }
}
