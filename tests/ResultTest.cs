namespace FriendlyResult.Tests;

public class ResultTest
{
    [Fact]
    public void Error_ShouldConvertToResult()
    {
        // Arrange 
        Error error = new Error("Teste.Code", "Testando", TypeErrorEnum.NotFound);

        // Act
        Result result = error;

        // Assert
        result.Errors.Should().Contain(error);
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public void ListErrors_ShouldConvertToResult()
    {
        // Arrange
        List<Error> errors = Helpers.Fixture.ErrorFactory.CreateList(5);

        // Act
        Result result = errors;

        // Assert
        result.Errors.Should().Contain(errors);
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public void ResultState_WhenTypeBeFailure_ShouldReturnErrors()
    {
        // Arrange
        ResultState resultEnum = ResultState.Failure;

        // Act
        Result result = resultEnum;

        // Assert
        result.IsError.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void ResultState_WhenTypeBeSuccess_ShouldReturnNoErrors()
    {
        // Arrange
        ResultState resultEnum = ResultState.Success;

        // Act
        Result result = resultEnum;

        // Assert
        result.IsError.Should().BeFalse();
        result.Errors.Should().HaveCount(0);
    }

    [Fact]
    public void ResultState_WhenInvalidRange_ShouldThrowException()
    {
        // Arrange
        ResultState? ResultState = null;

        // Act
        Action act = () => { Result result = ResultState; };

        // Assert
        act.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void MatchFirst_WhenFirstErrorInvoked_ShouldReturnFirstError()
    {
        // Arrange
        Error error = Helpers.Fixture.ErrorFactory.Create();

        Result result = error;

        bool onFirstError(Error error)
        {
            error.Should().Be(error);
            return true;
        }

        bool onAction() => throw new Exception("Should not be called.");

        // Act
        Func<bool> act = () => result.MatchFirst(
            onAction,
            onFirstError
        );

        // Assert
        act.Should().NotThrow().Subject.Should().BeTrue();
    }

    [Fact]
    public void MatchFirst_WhenActionInvoked_ShouldBeCall()
    {
        // Arrange
        Result result = ResultState.Success;
        bool onAction() => true;
        bool onFirstError(Error _) => throw new Exception("Should not be called.");

        // Act
        Func<bool> act = () => result.MatchFirst(
            onAction,
            onFirstError
        );

        // Assert
        act.Should().NotThrow().Subject.Should().BeTrue();
    }

    [Fact]
    public void Match_WhenOnErrorsInvoked_ShouldReturnErrorsList()
    {
        // Arrange
        var errors = Helpers.Fixture.ErrorFactory.CreateList(5);
        Result result = errors;
        bool onAction() => throw new Exception("Should not be called.");
        bool onErrorsList(IReadOnlyList<Error> errorsParam)
        {
            errorsParam.Should().ContainInConsecutiveOrder(errors);
            return true;
        }

        // Act
        Func<bool> act = () => result.Match(
            onAction,
            onErrorsList
        );

        // Assert
        act.Should().NotThrow().Subject.Should().BeTrue();
    }

    [Fact]
    public void Match_WhenOnActionInvoked_ShouldBeCall()
    {
        // Arrange
        Result result = ResultState.Success;

        bool onAction() => true;
        bool onErrors(IReadOnlyList<Error> _) => throw new Exception("Should not be called.");

        // Act
        Func<bool> act = () => result.Match(
            onAction,
            onErrors
        );

        // Assert
        act.Should().NotThrow().Subject.Should().BeTrue();
    }
}