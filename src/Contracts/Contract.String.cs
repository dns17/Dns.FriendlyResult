using System.Diagnostics.CodeAnalysis;

using FriendlyResult.Common;

namespace FriendlyResult.Contracts;

public partial class Contract<TValue> : ContractBase
{

    public Contract<TValue> IsEmpty([NotNull] string value, string code, string message)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (string.Empty == value)
        {
            _errors.Add(Error.Validation(code, message));
        }

        return this;
    }

    public Contract<TValue> IsNullOrEmpty(string? value, string code, string message)
    {

        if (string.IsNullOrEmpty(value))
        {
            _errors.Add(Error.Validation(code, message));
        }

        return this;
    }
}