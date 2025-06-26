using Domain.Repositories;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Application.Tests.Infrastructure;

public class DependencyInjectionTests
{
    [Fact]
    public void AddInfrastructure_ShouldRegisterServices()
    {
        var services = new ServiceCollection()
            .AddInfrastructure()
            .BuildServiceProvider();

        var taskRepo = services.GetService<ITaskRepository>();
        Assert.NotNull(taskRepo);
    }
}
