using FriendlyResult.Enums;
using FriendlyResult.Interfaces;

namespace FriendlyResult;

public partial class Result : IResult
{
    public List<Error> Errors { get; } = new();
    public bool IsError => Errors.Any();

    public TNextValue MatchFirst<TNextValue>(
        Func<TNextValue> onAction,
        Func<Error, TNextValue> onFirstError)
    {
        return IsError ? onFirstError(Errors.First()) : onAction();
    }

    public TNextValue Match<TNextValue>(
        Func<TNextValue> onAction,
        Func<IReadOnlyList<Error>, TNextValue> onErrors)
    {
        return IsError ? onErrors(Errors) : onAction();
    }

    private Result(Error error)
    {
        Errors.Add(error);
    }

    private Result(List<Error> errors)
    {
        Errors.AddRange(errors);
    }

    private Result() { }

    public static implicit operator Result(Error error)
    {
        return new Result(error);
    }

    public static implicit operator Result(List<Error> errors)
    {
        return new Result(errors);
    }

    public static implicit operator Result(ResultState? result)
    {
        return result switch
        {
            ResultState.Success => new Result(),
            ResultState.Failure => new Result(new Error("Generic.Error", "Generic Error", TypeErrorEnum.Validation)),
            _ => throw new InvalidOperationException(nameof(ResultState))
        };
    }
}