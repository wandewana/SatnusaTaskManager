using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;
using Application;

namespace Application.Tests.Integration;

public class TaskServiceIntegrationTests
{
    [Fact]
    public async Task Create_And_Assign_Task_Should_Succeed()
    {
        var services = new ServiceCollection()
            .AddInfrastructure()
            .AddApplication()
            .BuildServiceProvider();

        var taskService = services.GetRequiredService<TaskService>();
        var userRepo = services.GetRequiredService<IUserRepository>();

        var user = new User { Name = "Bob" };
        await userRepo.AddAsync(user);

        var task = new TaskItem { Title = "Fix bug", DueDate = DateTime.Now.AddDays(1) };
        await taskService.CreateTaskAsync(task);
        await taskService.AssignTaskAsync(task.Id, user.Id);

        var taskRepo = services.GetRequiredService<ITaskRepository>();
        var assigned = await taskRepo.GetByIdAsync(task.Id);

        Assert.NotNull(assigned);
        Assert.Equal(user.Id, assigned.AssignedUserId);
    }
}
