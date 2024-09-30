namespace FriendlyResult.Interfaces;

public interface IResult
{
    /// <summary>
    /// Lista com todos os erros
    /// </summary>
    List<Error> Errors { get; }

    /// <summary>
    /// Retorna verdadeiro caso há erros como retorno.
    /// </summary>
    bool IsError { get; }
}