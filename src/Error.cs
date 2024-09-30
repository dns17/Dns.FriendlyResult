using FriendlyResult.Enums;
using FriendlyResult.Interfaces;

namespace FriendlyResult;

public class Error : IError
{
    public string Code { get; init; }
    public string Description { get; init; }
    public TypeErrorEnum TypeError { get; init; }

    public Error(
        string code,
        string descripton,
        TypeErrorEnum typeError = TypeErrorEnum.Validation)
    {
        Code = code;
        Description = descripton;
        TypeError = typeError;
    }

    public static Error NotFound(
        string code = "General.NotFound",
        string description = "It's not found.")
    {
        return new(code, description, TypeErrorEnum.NotFound);
    }

    public static Error Conflit(
        string code = "General.Conflict",
        string description = "There's a conflict.")
    {
        return new(code, description, TypeErrorEnum.Conflict);
    }

    public static Error Inauthorized(
        string code = "General.Inauthorized",
        string description = "You don't have permission to access it.")
    {
        return new(code, description, TypeErrorEnum.Inauthorized);
    }

    public static Error Validation(
        string code = "General.Validation",
        string description = "Something is wrong to proceed with it.")
    {
        return new(code, description, TypeErrorEnum.Validation);
    }

    public static Error Failure(
        string code = "General.Failure",
        string description = "There's been a failure to process it.")
    {
        return new(code, description, TypeErrorEnum.Failure);
    }
}