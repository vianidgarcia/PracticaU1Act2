using PracticaU1Act2.UI;

namespace PracticaU1Act2.Models;

/// <summary>
/// Vector that grows at run time.
/// Internally it is a CONTIGUOUS block of fixed size; to grow, a larger new block
/// must be allocated and all the elements copied.
/// It uses int (not a generic type) so that memory per element is fixed and comparable.
/// </summary>
public class ResizableVector
{
    private int[] _data;          // contiguous block in memory
    private int _count;         // elements actually in use

    public int Count => _count;
    public int Capacity => _data.Length;
    public int ResizeCount { get; private set; }            // how many times the array was copied
    public int FreeSlots => _data.Length - _count;   // reserved memory that is not in use

    public ResizableVector(int initialCapacity)
    {
        if (initialCapacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(initialCapacity), "La capacidad debe ser mayor que 0.");
        _data = new int[initialCapacity];
    }

    /// <summary>Appends at the end; if it does not fit, it doubles the capacity (amortized O(1) cost).</summary>
    public void Add(int value)
    {
        if (_count == _data.Length)
            Resize(CalculateNewCapacity());
        _data[_count++] = value;
    }

    /// <summary>Direct access by index: O(1).</summary>
    public int Get(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException(ErrorMessages.OutOfRange(index, _count));
        return _data[index];
    }

    /// <summary>Doubles the capacity without exceeding the maximum size .NET allows for an array.</summary>
    private int CalculateNewCapacity()
    {
        if (_data.Length >= Array.MaxLength)
            throw new InvalidOperationException("El vector alcanzó el tamaño máximo permitido para un arreglo.");

        long doubled = (long)_data.Length * 2;      // long avoids int overflow
        return (int)Math.Min(doubled, Array.MaxLength);
    }

    /// <summary>Allocates a new array and copies the elements: O(n) cost.</summary>
    private void Resize(int newCapacity)
    {
        int[] newData = new int[newCapacity];
        Array.Copy(_data, newData, _count);
        _data = newData;            // the old block is left without references and the GC frees it
        ResizeCount++;
    }
}
