namespace FriendlyResult.Tests;

public class ErrorTests
{
    [Fact]
    public void NotFound_MustDefaultValues()
    {
        // Arrange
        string code = "General.NotFound";
        string description = "It's not found.";

        // Act
        var error = Error.NotFound();

        // Arrange
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.NotFound);
    }

    [Fact]
    public void NotFound_WhenPassedPerParamenterAllValues_ShouldReturnErrorObjectInstance()
    {
        // Arrange
        string code = "Code.Something";
        string description = "Description";

        // Act
        var error = Error.NotFound(code, description);

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.NotFound);
    }

    [Fact]
    public void Conflict_MustDefaultValues()
    {
        // Arrange
        string code = "General.Conflict";
        string description = "There's a conflict.";

        // Act
        var error = Error.Conflit();

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.Conflict);
    }

    [Fact]
    public void Conflit_WhenPassedPerParamenterAllValues_ShouldReturnErrorObjectInstance()
    {
        // Arrange
        string code = "Code.Something";
        string description = "Description";

        // Act
        var error = Error.Conflit(code, description);

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.Conflict);
    }

    [Fact]
    public void Inauthorized_MustDefaultValues()
    {
        // Arrange
        string code = "General.Inauthorized";
        string description = "You don't have permission to access it.";

        // Act
        var error = Error.Inauthorized();

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.Inauthorized);
    }

    [Fact]
    public void Inauhorized_WhenPassedPerParamenterAllValues_ShouldReturnErrorObjectInstance()
    {
        // Arrange
        string code = "Code.Something";
        string description = "Description";

        // Act
        var error = Error.Inauthorized(code, description);

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.Inauthorized);
    }

    [Fact]
    public void Validation_MustDefaultValues()
    {
        // Arrange
        string code = "General.Validation";
        string description = "Something is wrong to proceed with it.";

        // Act
        var error = Error.Validation();

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.Validation);
    }

    [Fact]
    public void Validation_WhenPassedPerParamenterAllValues_ShouldReturnErrorObjectInstance()
    {
        // Arrange
        string code = "Code.Something";
        string description = "Description";

        // Act
        var error = Error.Validation(code, description);

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.Validation);
    }

    [Fact]
    public void Failure_MustDefaultValues()
    {
        // Arrange
        string code = "General.Failure";
        string description = "There's been a failure to process it.";

        // Act
        var error = Error.Failure();

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.Failure);
    }

    [Fact]
    public void Failure_WhenPassedPerParamenterAllValues_ShouldReturnErrorObjectInstance()
    {
        // Arrange
        string code = "Code.Something";
        string description = "Description";

        // Act
        var error = Error.Failure(code, description);

        // Assert
        error.Code.Should().Be(code);
        error.Description.Should().Be(description);
        error.TypeError.Should().Be(TypeErrorEnum.Failure);
    }
}