using FriendlyResult.Contracts;

namespace FriendlyResult.Extensions;

public static class ContractExtension
{
    public static Contract<TValue> Validate<TValue>(this TValue value)
        where TValue : class
    {
        return new Contract<TValue>();
    }
}