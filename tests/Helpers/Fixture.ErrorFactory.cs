namespace FriendlyResult.Tests.Helpers;

public partial class Fixture
{
    public static class ErrorFactory
    {
        public static List<Error> CreateList(int amount = 0) =>
            Enumerable.Range(0, amount).Select(Create).ToList();

        public static Error Create(int index = 0) =>
            new Error(
                Constaint.Error.GetCode(index),
                Constaint.Error.GetDescription(index),
                Constaint.Error.TypeErrorEnum);
    }
}