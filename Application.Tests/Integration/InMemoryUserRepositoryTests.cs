using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Integration;

public class InMemoryUserRepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldStoreUser()
    {
        var repo = new InMemoryUserRepository();
        var user = new User { Name = "Alice" };

        await repo.AddAsync(user);
        var stored = await repo.GetByIdAsync(user.Id);

        Assert.NotNull(stored);
        Assert.Equal("Alice", stored.Name);
    }
}
