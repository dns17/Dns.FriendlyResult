using FriendlyResult.Enums;
using FriendlyResult.Interfaces;

namespace FriendlyResult;

public class Error : IError
{

    /// <inheritdoc/>
    public string Code { get; init; }

    /// <inheritdoc/>
    public string Description { get; init; }

    /// <inheritdoc/>
    public TypeErrorEnum TypeError { get; init; }

    /// <summary>
    /// Cria a instância de error.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="descripton"></param>
    /// <param name="typeError"></param>
    public Error(
        string code,
        string descripton,
        TypeErrorEnum typeError = TypeErrorEnum.Validation)
    {
        Code = code;
        Description = descripton;
        TypeError = typeError;
    }

    /// <summary>
    /// Caso algo não foi encontrado.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    public static Error NotFound(
        string code = "General.NotFound",
        string description = "It's not found.")
    {
        return new(code, description, TypeErrorEnum.NotFound);
    }

    /// <summary>
    /// Caso algo deu conflito.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    public static Error Conflit(
        string code = "General.Conflict",
        string description = "There's a conflict.")
    {
        return new(code, description, TypeErrorEnum.Conflict);
    }

    /// <summary>
    /// Caso algo não está autorizado acessar algum recurso.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    public static Error Inauthorized(
        string code = "General.Inauthorized",
        string description = "You don't have permission to access it.")
    {
        return new(code, description, TypeErrorEnum.Inauthorized);
    }

    /// <summary>
    /// Caso algo não é valido.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    public static Error Validation(
        string code = "General.Validation",
        string description = "Something is wrong to proceed with it.")
    {
        return new(code, description, TypeErrorEnum.Validation);
    }

    /// <summary>
    /// Caso algo falhar.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    public static Error Failure(
        string code = "General.Failure",
        string description = "There's been a failure to process it.")
    {
        return new(code, description, TypeErrorEnum.Failure);
    }
}