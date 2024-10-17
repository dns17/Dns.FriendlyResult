namespace FriendlyResult.Common;

public abstract class ContractBase
{
    protected readonly List<Error> _errors = [];

    public IReadOnlyList<Error> Errors => _errors;
}