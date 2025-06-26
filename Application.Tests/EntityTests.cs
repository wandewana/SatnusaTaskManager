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
}
