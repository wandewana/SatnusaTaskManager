using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Integration;

public class InMemoryTaskRepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldStoreTask()
    {
        var repo = new InMemoryTaskRepository();
        var task = new TaskItem { Title = "Sample", DueDate = DateTime.Now.AddDays(1) };

        await repo.AddAsync(task);
        var stored = await repo.GetByIdAsync(task.Id);

        Assert.NotNull(stored);
        Assert.Equal("Sample", stored.Title);
    }
}
