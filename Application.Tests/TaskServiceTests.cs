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
}
