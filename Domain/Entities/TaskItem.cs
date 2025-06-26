using System;
using Domain.Enums;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; }
    public TaskStatus Status { get; set; }
    public Guid? AssignedUserId { get; set; }
}
