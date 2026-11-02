namespace PracticaU1Act2;

/// <summary>
/// Error messages shared by the data structures, so that they are clear
/// and consistent across all tests.
/// </summary>
public static class ErrorMessages
{
    /// <summary>Distinguishes between an empty collection and an index outside the valid range.</summary>
    public static string OutOfRange(int index, int count) =>
        count == 0
            ? $"La colección está vacía: no existe el índice {index}."
            : $"Índice {index} fuera de rango (válidos: 0 a {count - 1}).";

    /// <summary>
    /// Removes the English suffix "(Parameter '...')" that .NET adds to ArgumentException,
    /// so that only the Spanish message is shown.
    /// </summary>
    public static string ToDisplayText(Exception ex) =>
        ex is ArgumentException { ParamName: not null } argument
            ? argument.Message.Replace($" (Parameter '{argument.ParamName}')", "")
            : ex.Message;
}
