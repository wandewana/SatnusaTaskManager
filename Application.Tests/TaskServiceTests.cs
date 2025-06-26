using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests;

public class TaskServiceTests
{
    [Fact]
    public async Task CreateTaskAsync_ShouldThrow_WhenDueDateIsPast()
    {
        // Arrange
        var task = new TaskItem { Title = "Late Task", DueDate = DateTime.Now.AddDays(-1) };

        var mockTaskRepo = new Mock<ITaskRepository>();
        var mockUserRepo = new Mock<IUserRepository>();
        var mockLogger = new Mock<ILoggerService>();

        var service = new TaskService(mockTaskRepo.Object, mockUserRepo.Object, mockLogger.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => service.CreateTaskAsync(task));
    }

    [Fact]
    public async Task AssignTaskAsync_ShouldSetAssignedUserId()
    {
        var task = new TaskItem { Id = Guid.NewGuid(), Title = "T", DueDate = DateTime.Now.AddDays(1) };
        var user = new User { Id = Guid.NewGuid(), Name = "Bob" };

        var taskRepo = new Mock<ITaskRepository>();
        var userRepo = new Mock<IUserRepository>();
        var logger = new Mock<ILoggerService>();

        taskRepo.Setup(r => r.GetByIdAsync(task.Id)).ReturnsAsync(task);
        userRepo.Setup(r => r.GetByIdAsync(user.Id)).ReturnsAsync(user);

        var service = new TaskService(taskRepo.Object, userRepo.Object, logger.Object);

        await service.AssignTaskAsync(task.Id, user.Id);

        taskRepo.Verify(r => r.UpdateAsync(It.Is<TaskItem>(t => t.AssignedUserId == user.Id)), Times.Once);
    }
}
