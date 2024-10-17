using FriendlyResult.Common;

namespace FriendlyResult.Contracts;

public partial class Contract<TValue> : ContractBase
{
    public Contract<TValue> IsNull<T>(T value, string code, string message)
    {
        if (value is null)
        {
            Error.Validation(code, message);
        }

        return this;
    }
    public Contract<TValue> Greater<T>(T value, T comparison, string code, string message)
        where T : IComparable<T>
    {
        if (value.CompareTo(comparison) > 0)
        {
            Error.Validation(code, message);
        }

        return this;
    }

    public Contract<TValue> GreaterThen<T>(T value, T comparison, string code, string message)
        where T : IComparable<T>
    {
        if (value.CompareTo(comparison) >= 0)
        {
            Error.Validation(code, message);
        }

        return this;
    }

    public Contract<TValue> Less<T>(T value, T comparison, string code, string message)
        where T : IComparable<T>
    {
        if (value.CompareTo(comparison) < 0)
        {
            Error.Validation(code, message);
        }

        return this;
    }

    public Contract<TValue> LessThen<T>(T value, T comparison, string code, string message)
        where T : IComparable<T>
    {
        if (value.CompareTo(comparison) <= 0)
        {
            Error.Validation(code, message);
        }

        return this;
    }
}