using Tests.TestUtils.Inhents;
using Tests.TestUtils.Factories;

namespace FriendlyResult.Tests;

public class ResultTests
{
    [Fact]
    public void GenericType_ShouldAssignmentIntoTValue()
    {
        // Arrange
        int intValue = 10;
        double doubleValue = 10.0;
        string stringValue = "Something";
        float floatValue = 10.3f;

        // Act
        Result<int> resultInt = intValue;
        Result<double> resultDouble = doubleValue;
        Result<string> resultString = stringValue;
        Result<float> resultFloat = floatValue;
        Result<Success> resultSuccess = ResultState.Success;

        // Assert
        resultInt.Value.Should<int>().Be(intValue);
        resultInt.IsError.Should().BeFalse();

        resultDouble.Value.Should<double>().Be(doubleValue);
        resultDouble.IsError.Should().BeFalse();

        resultString.Value.Should<string>().Be(stringValue);
        resultString.IsError.Should().BeFalse();

        resultFloat.Value.Should<float>().Be(floatValue);
        resultFloat.IsError.Should().BeFalse();

        resultSuccess.Value.Should().Be(ResultState.Success);
    }

    [Fact]
    public void Error_ShouldConvertToResult()
    {
        // Arrange
        Error error = new Error("Code", "Description", TypeErrorEnum.Validation);

        // Act
        Result<double> result = error;

        // Assert
        result.IsError.Should().BeTrue();
        result.Errors.Should().Contain(error);
    }

    [Fact]
    public void ListErrors_ShouldConvertToResult()
    {
        // Arrange
        List<Error> errors = Fixture.ErrorFactory.CreateList(5);

        // Act
        Result<double> result = errors;

        // Assert
        result.IsError.Should().BeTrue();
        result.Errors.Should().Contain(errors);
    }

    [Fact]
    public void MatchFirst_WhenOnErrorFirstInvoked_ShouldReturnFirstError()
    {
        // Arrange
        List<Error> errors = Fixture.ErrorFactory.CreateList(5);

        Result<double> result = errors;

        bool onFirstError(Error errors)
        {
            errors.Should().BeEquivalentTo(result.Errors[0]);
            return true;
        }

        bool onValue(double _) => throw new Exception("Should not be called.");

        // Act
        Func<bool> act = () => result.MatchFirst(
            onValue,
            onFirstError
        );

        // Assert
        act.Should().NotThrow().Subject.Should().BeTrue();
    }

    [Fact]
    public void MatchFirst_WhenOnValueInvoked_ShouldReturnValue()
    {
        // Arrange
        Guid value = Guid.NewGuid();

        Result<Guid> result = value;

        bool onFirstError(Error _) => throw new Exception("Should not be called.");
        bool onValue(Guid valueParam)
        {
            valueParam.Should().Be(value);
            return true;
        }

        // Act
        Func<bool> act = () => result.MatchFirst(
            onValue,
            onFirstError
        );

        // Assert
        act.Should().NotThrow().Subject.Should().BeTrue();
    }

    [Fact]
    public void Match_WhenOnErrorsInvoked_ShouldReturnErrorsList()
    {
        // Arrange
        List<Error> errors = Fixture.ErrorFactory.CreateList(5);

        Result<Guid> result = errors;

        bool onErrors(IReadOnlyList<Error> errors)
        {
            errors.Should().BeEquivalentTo(errors);
            return true;
        }

        bool onValue(Guid _) => throw new Exception("");

        // Act
        Func<bool> act = () => result.Match(
            onValue,
            onErrors
        );

        // Assert
        act.Should().NotThrow().Subject.Should().BeTrue();
    }

    [Fact]
    public void Match_WhenOnValueInvoked_ShouldReturnValue()
    {
        // Arrange
        Guid value = Guid.NewGuid();

        Result<Guid> result = value;

        bool onErrors(IReadOnlyList<Error> _) => throw new Exception("Should not be called.");
        bool onValue(Guid valueParam)
        {
            valueParam.Should().Be(value);
            return true;
        }

        // Act
        Func<bool> act = () => result.Match(
            onValue,
            onErrors
        );

        // Assert
        act.Should().NotThrow().Subject.Should().BeTrue();
    }

    [Fact]
    public void FirstError_ShouldReturnFirstError()
    {
        // Arrange
        Result<Guid> result = Error.NotFound();

        // Act
        Error? error = result.FirstError;

        // Assert
        error.Should().NotBeNull();
        error.Should().BeEquivalentTo(Error.NotFound());
    }

    [Fact]
    public void FirstError_ShouldReturnNullable()
    {
        // Arrange
        Result<Guid> result = Guid.NewGuid();

        // Act
        Error? error = result.FirstError;

        // Assert
        error.Should().BeNull();
    }

    [Fact]
    public void ClassB_ShouldBeAssignableToClassA_WhenInheriting()
    {
        // Arrange
        Result<ClassA> resultA = null!;

        // Act
        resultA = new ClassB();

        // Assert
        resultA.Should().NotBeNull();
        resultA.Should().BeAssignableTo<ClassB>();
    }
}