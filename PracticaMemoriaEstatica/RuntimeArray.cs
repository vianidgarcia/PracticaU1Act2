using System.Runtime.CompilerServices;

namespace PracticaU1Act2;

/// <summary>
/// Program 1: an array created with a size chosen at run time
/// and resized afterwards. Array.Resize does not stretch the original block:
/// it allocates a new array on the Heap and copies the data.
/// </summary>
public class RuntimeArray
{
    private int[]? _data;

    public bool Exists => _data is not null;
    public int Length => _data?.Length ?? 0;

    /// <summary>Identifies the array object (it changes when a new block is allocated).</summary>
    public int Identifier => _data is null ? 0 : RuntimeHelpers.GetHashCode(_data);

    /// <summary>Creates the array and fills it with 10, 20, 30...</summary>
    public void Create(int size)
    {
        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size), "El tamaño debe ser mayor que 0.");

        _data = new int[size];
        for (int i = 0; i < size; i++)
            _data[i] = (i + 1) * 10;
    }

    /// <summary>Changes the size while keeping the data; new positions are set to 0.</summary>
    public void Resize(int newSize)
    {
        if (_data is null)
            throw new InvalidOperationException("Primero crea el arreglo.");
        if (newSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(newSize), "El tamaño debe ser mayor que 0.");

        int[] current = _data;
        Array.Resize(ref current, newSize);
        _data = current;
    }

    // Independent copy so the drawing can keep the old block after a resize.
    public int[]? CopyData() => (int[]?)_data?.Clone();

    /// <summary>Text with the first elements, to show on screen.</summary>
    public string GetContent(int max = 20)
    {
        if (_data is null) return "(sin arreglo)";

        string visibleItems = string.Join(", ", _data.Take(max));
        return _data.Length > max
            ? $"[{visibleItems}, ... ({_data.Length - max} más)]"
            : $"[{visibleItems}]";
    }
}