namespace PracticaU1Act2;

/// <summary>
/// Mensajes de error compartidos por las estructuras, para que sean claros
/// y consistentes en todas las pruebas.
/// </summary>
public static class MensajesError
{
    /// <summary>Distingue entre una colección vacía y un índice fuera del rango válido.</summary>
    public static string FueraDeRango(int indice, int cantidad) =>
        cantidad == 0
            ? $"La colección está vacía: no existe el índice {indice}."
            : $"Índice {indice} fuera de rango (válidos: 0 a {cantidad - 1}).";

    /// <summary>
    /// Quita el sufijo en inglés "(Parameter '...')" que .NET agrega a ArgumentException,
    /// para mostrar solo el mensaje en español.
    /// </summary>
    public static string ParaMostrar(Exception ex) =>
        ex is ArgumentException { ParamName: not null } argumento
            ? argumento.Message.Replace($" (Parameter '{argumento.ParamName}')", "")
            : ex.Message;
}
