using FriendlyResult.Enums;

namespace FriendlyResult.Interfaces;

public interface IError
{
    /// <summary>
    /// Código do error, padrão General.NotFound
    /// </summary>
    string Code { get; }

    /// <summary>
    /// Descrição do erro, exemplo: Não foi encontrado.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Tipos de erros.
    /// </summary>
    TypeErrorEnum TypeError { get; }
}