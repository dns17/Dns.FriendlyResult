namespace FriendlyResult.Enums;

public readonly record struct Success;
public readonly record struct Created;
public readonly record struct Updated;
public readonly record struct Deleted;

/// <summary>
/// Estado de um retorno quando o Result não retorna nenhum valor. 
/// </summary>
public static class ResultState
{
    /// <summary>
    /// Caso for sucesso
    /// </summary>
    public static Success Success => default;

    /// <summary>
    /// Caso for criado
    /// </summary>
    public static Created Created => default;

    /// <summary>
    /// Caso for deletado
    /// </summary>
    public static Deleted Deleted => default;

    /// <summary>
    /// Caso for atualizado
    /// </summary>
    public static Updated Updated => default;
}