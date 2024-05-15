using FriendlyResult.Enums;

namespace FriendlyResult.Interfaces;

public interface IError
{
    string Code { get; }
    string Description { get; }
    TypeErrorEnum TypeError { get; }
}