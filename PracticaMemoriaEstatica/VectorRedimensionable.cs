namespace PracticaU1Act2;

/// <summary>
/// Vector que crece en tiempo de ejecución.
/// Internamente es un bloque CONTIGUO de tamaño fijo; para crecer hay que
/// reservar un bloque nuevo más grande y copiar todos los elementos.
/// Usa int (y no un genérico) para que la memoria por elemento sea fija y comparable.
/// </summary>
public class VectorRedimensionable
{
    private int[] _datos;          // bloque contiguo en memoria
    private int _cantidad;         // elementos realmente usados

    public int Cantidad => _cantidad;
    public int Capacidad => _datos.Length;
    public int Redimensiones { get; private set; }            // cuántas veces se copió el arreglo
    public int EspaciosLibres => _datos.Length - _cantidad;   // memoria reservada sin usar

    public VectorRedimensionable(int capacidadInicial)
    {
        if (capacidadInicial <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacidadInicial), "La capacidad debe ser mayor que 0.");
        _datos = new int[capacidadInicial];
    }

    /// <summary>Agrega al final; si no cabe, duplica la capacidad (costo amortizado O(1)).</summary>
    public void Agregar(int valor)
    {
        if (_cantidad == _datos.Length)
            Redimensionar(CalcularNuevaCapacidad());
        _datos[_cantidad++] = valor;
    }

    /// <summary>Acceso directo por índice: O(1).</summary>
    public int Obtener(int indice)
    {
        if (indice < 0 || indice >= _cantidad)
            throw new IndexOutOfRangeException(MensajesError.FueraDeRango(indice, _cantidad));
        return _datos[indice];
    }

    /// <summary>Duplica la capacidad sin rebasar el tamaño máximo que .NET permite para un arreglo.</summary>
    private int CalcularNuevaCapacidad()
    {
        if (_datos.Length >= Array.MaxLength)
            throw new InvalidOperationException("El vector alcanzó el tamaño máximo permitido para un arreglo.");

        long doble = (long)_datos.Length * 2;      // long evita el desbordamiento de int
        return (int)Math.Min(doble, Array.MaxLength);
    }

    /// <summary>Reserva un arreglo nuevo y copia los elementos: costo O(n).</summary>
    private void Redimensionar(int nuevaCapacidad)
    {
        int[] nuevo = new int[nuevaCapacidad];
        Array.Copy(_datos, nuevo, _cantidad);
        _datos = nuevo;            // el bloque viejo queda sin referencias y lo libera el GC
        Redimensiones++;
    }
}
