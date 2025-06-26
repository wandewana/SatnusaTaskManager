using Domain.Enums;
using System;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Presentation.Dtos;

public record CreateTaskDto(string Title, string Description, DateTime DueDate, TaskPriority Priority);
public record UpdateTaskDto(string Title, string Description, DateTime DueDate, TaskPriority Priority, TaskStatus Status);
