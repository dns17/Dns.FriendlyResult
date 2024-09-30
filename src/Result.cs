using FriendlyResult.Interfaces;

namespace FriendlyResult;

public partial class Result<TValue> : IResult
{
    public List<Error> Errors { get; } = new();
    public TValue Value { get; } = default!;
    public bool IsError => Errors.Any();

    public Error? FirstError =>
        Errors?.FirstOrDefault();

    public TNextValue MatchFirst<TNextValue>(
        Func<TValue, TNextValue> onValue,
        Func<Error, TNextValue> onFirstError)
    {
        return IsError ? onFirstError(Errors.First()) : onValue(Value);
    }

    public TNextValue MatchFirst<TNextValue>(
        Func<TNextValue> onValue,
        Func<Error, TNextValue> onFirstError
    )
    {
        return IsError ? onFirstError(Errors.First()) : onValue();
    }

    public TNextValue Match<TNextValue>(
        Func<TValue, TNextValue> onValue,
        Func<IReadOnlyList<Error>, TNextValue> onErrors)
    {
        return IsError ? onErrors(Errors) : onValue(Value);
    }

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
        Errors.Add(error);
    }

    private Result(List<Error> errors)
    {
        Errors.AddRange(errors);
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
}