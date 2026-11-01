using System.Runtime.CompilerServices;

namespace PracticaU1Act2;

/// <summary>
/// Programa 1: arreglo que se crea con un tamaño elegido en tiempo de ejecución
/// y que después se redimensiona. Array.Resize no estira el bloque original:
/// reserva un arreglo nuevo en el Heap y copia los datos.
/// </summary>
public class ArregloEnEjecucion
{
    private int[]? _datos;

    public bool Existe => _datos is not null;
    public int Longitud => _datos?.Length ?? 0;

    /// <summary>Identifica al objeto arreglo (cambia si se reserva un bloque nuevo).</summary>
    public int Identificador => _datos is null ? 0 : RuntimeHelpers.GetHashCode(_datos);

    /// <summary>Crea el arreglo y lo llena con 10, 20, 30...</summary>
    public void Crear(int tamano)
    {
        if (tamano <= 0)
            throw new ArgumentOutOfRangeException(nameof(tamano), "El tamaño debe ser mayor que 0.");

        _datos = new int[tamano];
        for (int i = 0; i < tamano; i++)
            _datos[i] = (i + 1) * 10;
    }

    /// <summary>Cambia el tamaño conservando los datos; las posiciones nuevas quedan en 0.</summary>
    public void Redimensionar(int nuevoTamano)
    {
        if (_datos is null)
            throw new InvalidOperationException("Primero crea el arreglo.");
        if (nuevoTamano <= 0)
            throw new ArgumentOutOfRangeException(nameof(nuevoTamano), "El tamaño debe ser mayor que 0.");

        int[] actual = _datos;
        Array.Resize(ref actual, nuevoTamano);
        _datos = actual;
    }

    // Independent copy so the drawing can keep the old block after a resize.
    public int[]? CopiarDatos() => (int[]?)_datos?.Clone();

    /// <summary>Texto con los primeros elementos, para mostrar en pantalla.</summary>
    public string Contenido(int maximo = 20)
    {
        if (_datos is null) return "(sin arreglo)";

        string visibles = string.Join(", ", _datos.Take(maximo));
        return _datos.Length > maximo
            ? $"[{visibles}, ... ({_datos.Length - maximo} más)]"
            : $"[{visibles}]";
    }
}