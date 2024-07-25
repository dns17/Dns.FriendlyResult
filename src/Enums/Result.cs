namespace FriendlyResult.Enums;

public readonly record struct Empty;

public static class Result
{
    public static Empty Empty => default;
}