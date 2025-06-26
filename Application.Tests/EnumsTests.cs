using System;
using System.Linq;
using Xunit;
using Domain.Enums;
// Add an alias to resolve the ambiguity with System.Threading.Tasks.TaskStatus
using TaskStatus = Domain.Enums.TaskStatus;

namespace Application.Tests;

public class EnumsTests
{
    [Fact]
    public void TaskStatus_ShouldContainAllExpectedValues()
    {
        var values = Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>().ToList();
        Assert.Contains(TaskStatus.Pending, values);
        Assert.Contains(TaskStatus.InProgress, values);
        Assert.Contains(TaskStatus.Completed, values);
        Assert.Contains(TaskStatus.Cancelled, values);
        Assert.Equal(4, values.Count);
    }

    [Fact]
    public void TaskPriority_ShouldContainAllExpectedValues()
    {
        var values = Enum.GetValues(typeof(TaskPriority)).Cast<TaskPriority>().ToList();
        Assert.Contains(TaskPriority.Low, values);
        Assert.Contains(TaskPriority.Medium, values);
        Assert.Contains(TaskPriority.High, values);
        Assert.Equal(3, values.Count);
    }
}
