using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;
using System;
using System.Threading.Tasks;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Priority = dto.Priority
        };

        await _taskService.CreateTaskAsync(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        return task == null ? NotFound() : Ok(task);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("/api/users/{userId}/tasks")]
    public async Task<IActionResult> GetTasksByUser(Guid userId)
    {
        var tasks = await _taskService.GetTasksByUserAsync(userId);
        return Ok(tasks);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskDto dto)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null) return NotFound();

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.DueDate = dto.DueDate;
        task.Priority = dto.Priority;
        task.Status = dto.Status;

        await _taskService.UpdateTaskAsync(task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null) return NotFound();

        await _taskService.DeleteTaskAsync(id);
        return NoContent();
    }

    [HttpPost("{taskId}/assign/{userId}")]
    public async Task<IActionResult> AssignTask(Guid taskId, Guid userId)
    {
        await _taskService.AssignTaskAsync(taskId, userId);
        return NoContent();
    }
}
