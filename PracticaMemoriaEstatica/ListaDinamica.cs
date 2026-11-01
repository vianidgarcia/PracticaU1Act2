using System.Runtime.CompilerServices;

namespace PracticaU1Act2;

/// <summary>
/// Información de solo lectura de un nodo. Permite mostrar la estructura
/// sin entregar el nodo real (que podría modificarse desde fuera).
/// </summary>
public readonly record struct InfoNodo(int Posicion, int Dato, int Id, int? IdSiguiente);

/// <summary>
/// Programa 2: lista enlazada simple con memoria dinámica.
/// Se reserva un nodo por elemento, justo cuando se necesita; nunca se copia.
/// </summary>
public class ListaDinamica
{
    /// <summary>
    /// Nodo privado: cada instancia se crea con "new" y vive en el Heap.
    /// Solo la lista puede crear nodos o cambiar sus enlaces (encapsulamiento).
    /// </summary>
    private sealed class Nodo
    {
        public int Dato { get; }
        public Nodo? Siguiente { get; set; }

        public Nodo(int dato) => Dato = dato;
    }

    private Nodo? _cabeza;
    private Nodo? _cola;           // permite insertar al final en O(1)

    public int Cantidad { get; private set; }

    /// <summary>Crea un nodo nuevo en el Heap y lo enlaza al final: O(1).</summary>
    public void Agregar(int valor)
    {
        var nuevo = new Nodo(valor);
        if (_cabeza is null)
            _cabeza = _cola = nuevo;
        else
        {
            _cola!.Siguiente = nuevo;
            _cola = nuevo;
        }
        Cantidad++;
    }

    /// <summary>No hay índice: hay que recorrer los enlaces, O(n).</summary>
    public int Obtener(int indice)
    {
        if (indice < 0 || indice >= Cantidad)
            throw new IndexOutOfRangeException(MensajesError.FueraDeRango(indice, Cantidad));

        Nodo actual = _cabeza!;
        for (int i = 0; i < indice; i++)
            actual = actual.Siguiente!;
        return actual.Dato;
    }

    /// <summary>
    /// Describe los primeros nodos siguiendo las referencias. El Id es el código de
    /// identidad del objeto en .NET: distingue instancias, pero no es una dirección real.
    /// </summary>
    public IEnumerable<InfoNodo> DescribirNodos(int maximo)
    {
        Nodo? actual = _cabeza;
        int posicion = 0;
        while (actual is not null && posicion < maximo)
        {
            int? idSiguiente = actual.Siguiente is null ? null : RuntimeHelpers.GetHashCode(actual.Siguiente);
            yield return new InfoNodo(posicion, actual.Dato, RuntimeHelpers.GetHashCode(actual), idSiguiente);
            actual = actual.Siguiente;
            posicion++;
        }
    }

    /// <summary>Elimina el primer nodo; queda sin referencias y el GC lo libera.</summary>
    public bool EliminarPrimero()
    {
        if (_cabeza is null) return false;
        _cabeza = _cabeza.Siguiente;
        if (_cabeza is null) _cola = null;
        Cantidad--;
        return true;
    }
}
