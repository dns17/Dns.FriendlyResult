using FriendlyResult.Extensions;

namespace FriendlyResult.Tests;

public class ResultExtensionTest
{

    [Fact]
    public void ConvertTo_WhenPassTypeCanConverted_ShouldResultWithTypeOrResultWithErrors()
    {
        // Arrange
        Error error = Helpers.Fixture.ErrorFactory.Create();
        Result<double> doubleNum = 10.0;
        Result<double> doubleNumErrors = error;
        // Act
        Func<Result<int>> actConvertToInt = () =>
        {
            Result<int> converted = doubleNum.ConvertTo<double, int>();
            return converted;
        };

        Func<Result<int>> actConvertToError = () =>
        {
            Result<int> converted = doubleNumErrors.ConvertTo<double, int>();
            return converted;
        };

        // Assert
        actConvertToInt.Should().NotThrow();
        var resultInt = actConvertToInt();
        resultInt.Value.Should().Be(10);

        actConvertToError.Should().NotThrow();
        var resultError = actConvertToError();
        resultError.Errors.Should().Contain(error);
    }

    [Fact]
    public void ConvertTo_WhenPassSubClass_ShouldConvertToSuperClass()
    {
        // Arrange
        BTest bTest = new BTest();
        Result<BTest> resultB = bTest;

        // Act
        Func<Result<ATest>> act = () =>
        {
            Result<ATest> converted = resultB.ConvertTo<BTest, ATest>();
            return converted;
        };

        // Assert
        act.Should().NotThrow();
    }
}

public class ATest
{

}

public class BTest : ATest
{

}