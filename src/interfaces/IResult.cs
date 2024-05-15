namespace FriendlyResult.Interfaces;

public interface IResult
{
    List<Error> Errors { get; }
    bool IsError { get; }
}