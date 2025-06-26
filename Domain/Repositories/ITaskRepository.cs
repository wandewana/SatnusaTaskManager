using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface ITaskRepository
{
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(Guid taskId);
    Task<TaskItem?> GetByIdAsync(Guid taskId);
    Task<List<TaskItem>> GetAllAsync();
    Task<List<TaskItem>> GetByUserIdAsync(Guid userId);
}
