namespace FriendlyResult.Tests.Helpers;

public partial class Constaint
{
    public static class Error
    {
        public static string Code => "Code";
        public static string Description => "Description";
        public static TypeErrorEnum TypeErrorEnum => TypeErrorEnum.Validation;
        public static string GetCode(int index = 0) => $"Code {index}";
        public static string GetDescription(int index = 0) => $"Description {index}";
    }
}