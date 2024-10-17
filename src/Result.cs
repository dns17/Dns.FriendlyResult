using FriendlyResult.Common;
using FriendlyResult.Interfaces;

namespace FriendlyResult;

/// <summary>
/// Padrão Result Pattern.
/// </summary>
/// 
public partial class Result<TValue> : IResult
{
    private readonly List<Error> _errors = [];

    /// <inheritdoc/>
    public IReadOnlyList<Error> Errors => _errors;

    /// <inheritdoc/>
    public TValue Value { get; } = default!;

    /// <inheritdoc/>
    public bool IsError => Errors.Any();

    /// <summary>
    /// Retorna o primeiro erro de uma lista. Caso não tiver erros, irá retornar nulo.
    /// </summary>
    /// <returns></returns>
    public Error? FirstError =>
        Errors?.FirstOrDefault();

    /// <summary>
    /// Chama expressão lambada de acordo com o status do resultado. Caso for bem sucessedido, irá chamar o onValue senão onFirstError.
    /// </summary>
    /// <param name="onValue">Sucesso</param>
    /// <param name="onFirstError">Error</param>
    public TNextValue MatchFirst<TNextValue>(
        Func<TValue, TNextValue> onValue,
        Func<Error, TNextValue> onFirstError)
    {
        return IsError ? onFirstError(Errors.First()) : onValue(Value);
    }

    /// <summary>
    /// Chama expressão lambada de acordo com o status do resultado. Caso for bem sucessedido, irá chamar o onValue senão onFirstError.
    /// </summary>
    /// <param name="onValue">Sucesso</param>
    /// <param name="onFirstError">Error</param>
    public TNextValue MatchFirst<TNextValue>(
        Func<TNextValue> onValue,
        Func<Error, TNextValue> onFirstError)
    {
        return IsError ? onFirstError(Errors.First()) : onValue();
    }

    /// <summary>
    /// Chama expressão lambada de acordo com o status do resultado. Caso for bem sucessedido, irá chamar o onValue senão onErrors.
    /// </summary>
    /// <param name="onValue">Sucesso</param>
    /// <param name="onErrors">Error</param>
    public TNextValue Match<TNextValue>(
        Func<TValue, TNextValue> onValue,
        Func<IReadOnlyList<Error>, TNextValue> onErrors)
    {
        return IsError ? onErrors(Errors) : onValue(Value);
    }

    /// <summary>
    /// Chama expressão lambada de acordo com o status do resultado. Caso for bem sucessedido, irá chamar o onValue senão onErrors.
    /// </summary>
    /// <param name="onValue"></param>
    /// <param name="onErrors"></param>
    public TNextValue Match<TNextValue>(
        Func<TNextValue> onValue,
        Func<IReadOnlyList<Error>, TNextValue> onErrors)
    {
        return IsError ? onErrors(Errors) : onValue();
    }

    private Result(TValue value)
    {
        Value = value;
    }

    private Result(Error error)
    {
        _errors.Add(error);
    }

    private Result(List<Error> errors)
    {
        _errors.AddRange(errors);
    }

    private Result(IReadOnlyList<Error> errors)
    {
        _errors.AddRange(errors);
    }

    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue>(value);
    }

    public static implicit operator Result<TValue>(Error error)
    {
        return new Result<TValue>(error);
    }

    public static implicit operator Result<TValue>(List<Error> errors)
    {
        return new Result<TValue>(errors);
    }

    public static implicit operator Result<TValue>(ContractBase contract)
    {
        return new Result<TValue>(contract.Errors);
    }
}