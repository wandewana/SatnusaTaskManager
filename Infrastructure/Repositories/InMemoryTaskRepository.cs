using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public Task AddAsync(TaskItem task)
    {
        _tasks.Add(task);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null) _tasks.Remove(task);
        return Task.CompletedTask;
    }

    public Task<List<TaskItem>> GetAllAsync() => Task.FromResult(_tasks);

    public Task<TaskItem?> GetByIdAsync(Guid id) =>
        Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));

    public Task<List<TaskItem>> GetByUserIdAsync(Guid userId) =>
        Task.FromResult(_tasks.Where(t => t.AssignedUserId == userId).ToList());

    public Task UpdateAsync(TaskItem task)
    {
        var index = _tasks.FindIndex(t => t.Id == task.Id);
        if (index != -1) _tasks[index] = task;
        return Task.CompletedTask;
    }
}
