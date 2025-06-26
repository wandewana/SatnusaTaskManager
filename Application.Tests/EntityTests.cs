using Domain.Entities;
using System;
using Xunit;

namespace Application.Tests;

public class EntityTests
{
    [Fact]
    public void User_ShouldGenerateGuidId()
    {
        var user = new User { Name = "Alice" };
        Assert.NotEqual(Guid.Empty, user.Id);
    }

    [Fact]
    public void TaskItem_ShouldHaveDefaultGuid()
    {
        var task = new TaskItem { Title = "Test", Description = "Test", DueDate = DateTime.Now.AddDays(1) };
        Assert.NotEqual(Guid.Empty, task.Id);
    }
}
