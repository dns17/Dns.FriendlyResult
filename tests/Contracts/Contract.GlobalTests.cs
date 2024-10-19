using FriendlyResult;
using FriendlyResult.Contracts;

namespace Tests.Contracts;

public partial class Contract
{
    [Fact]
    public void IsNull_ShouldTriggerValidationError_WhenValueIsNull()
    {
        // Arrange
        int? valueInt = null;
        string? valueString = null;

        // Act
        Result<Guid> result1 = new Contract<Guid>()
            .IsNull(valueInt, "test1", "Generic Error");

        Result<Guid> result2 = new Contract<Guid>()
            .IsNull(valueString, "test2", "Generic Errors");

        // Assert

        result1.IsError.Should().BeTrue();
        result2.IsError.Should().BeTrue();
    }

    [Fact]
    public void IsNull_ShouldNotTriggerValidationError_WhenValueIsNotNull()
    {
        Assert.Fail("Implementing pendent...");
    }

    [Fact]
    public void Greater_ShouldTriggerValidationError_WhenValueIsGreaterThanComparison()
    {
        Assert.Fail("Implementing pendent...");
    }

    [Fact]
    public void Greater_ShouldNotTriggerValidationError_WhenValueIsLessThanOrEqualToComparison()
    {
        Assert.Fail("Implementing pendent...");
    }

    [Fact]
    public void GreaterThen_ShouldTriggerValidationError_WhenValueIsGreaterThanOrEqualToComparison()
    {
        Assert.Fail("Implementing pendent...");
    }

    [Fact]
    public void GreaterThen_ShouldNotTriggerValidationError_WhenValueIsLessThanComparison()
    {
        Assert.Fail("Implementing pendent...");
    }

    [Fact]
    public void Less_ShouldTriggerValidationError_WhenValueIsLessThanComparison()
    {
        Assert.Fail("Implementing pendent...");
    }

    [Fact]
    public void Less_ShouldNotTriggerValidationError_WhenValueIsGreaterThanOrEqualToComparison()
    {
        Assert.Fail("Implementing pendent...");
    }

    [Fact]
    public void LessThen_ShouldTriggerValidationError_WhenValueIsLessThanOrEqualToComparison()
    {
        Assert.Fail("Implementing pendent...");
    }

    [Fact]
    public void LessThen_ShouldNotTriggerValidationError_WhenValueIsGreaterThanComparison()
    {
        Assert.Fail("Implementing pendent...");
    }

}