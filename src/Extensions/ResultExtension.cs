namespace FriendlyResult.Extensions;

public static class ResultExtension
{
    public static Result<TDestination> ConvertTo<TSource, TDestination>(this Result<TSource> result)
        where TSource : notnull
        where TDestination : notnull
    {
        Result<TDestination> destination;

        if (result.IsError)
        {
            destination = result.Errors.ToList();
            return destination;
        }

        if (result.Value.GetType().IsClass)
        {
            destination = (TDestination)(object)result.Value;
        }
        else
        {
            destination = (TDestination)Convert.ChangeType(result.Value, typeof(TDestination));
        }

        return destination;
    }

}