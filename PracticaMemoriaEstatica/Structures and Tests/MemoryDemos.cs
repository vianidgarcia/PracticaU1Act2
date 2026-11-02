using System.Runtime.CompilerServices;

namespace PracticaU1Act2.Models;

/// <summary>
/// Conceptual demonstrations that contrast static memory (stack, fixed size)
/// with dynamic memory (objects created with new on the Heap).
/// </summary>
public static class MemoryDemos
{
    private const int FixedSize = 5;   // size defined at compile time

    // ---------- Static memory: fixed-size array on the stack ----------
    public static List<string> FixedArrayOnStack()
    {
        // stackalloc reserves the block on the method stack, not on the Heap
        Span<int> onStack = stackalloc int[FixedSize];
        for (int i = 0; i < onStack.Length; i++)
            onStack[i] = (i + 1) * 10;

        var lines = new List<string>
        {
            $"Arreglo de {FixedSize} enteros reservado en la PILA con stackalloc (tamaño fijo, definido en compilación).",
            $"Contenido: [{string.Join(", ", onStack.ToArray())}]"
        };

        // Try to store one more element than fits (for demonstration only)
        int extraIndex = FixedSize;
        try
        {
            onStack[extraIndex] = (extraIndex + 1) * 10;
            lines.Add("Se escribió fuera del límite (resultado inesperado).");
        }
        catch (IndexOutOfRangeException)
        {
            lines.Add($"Intento de escribir en el índice {extraIndex}: IndexOutOfRangeException. El bloque no puede crecer.");
        }

        lines.Add("Para tener más espacio habría que reservar otro bloque y copiar los datos (lo que hace Array.Resize).");
        lines.Add("Este bloque se libera solo al terminar el método; el recolector de basura (GC) no interviene.");
        return lines;
    }

    // ---------- Value (copy) versus reference (object shared on the Heap) ----------
    private struct ValuePoint { public int X; }            // value type: copied entirely
    private sealed class ReferencePoint { public int X; } // reference type: the object lives on the Heap

    public static List<string> ValueVsReference()
    {
        var valueA = new ValuePoint { X = 1 };
        ValuePoint valueB = valueA;        // independent copy of the data
        valueB.X = 99;

        var referenceA = new ReferencePoint { X = 1 };
        ReferencePoint referenceB = referenceA;   // copy of the reference: same object
        referenceB.X = 99;

        return new List<string>
        {
            "Tipo por valor (struct) como variable local, normalmente en la pila:",
            $"  a.X = {valueA.X}, b.X = {valueB.X} -> b es una copia; cambiarla no afecta a a.",
            "Tipo por referencia (class) creado con new en el Heap:",
            $"  a.X = {referenceA.X}, b.X = {referenceB.X} -> a y b apuntan al mismo objeto.",
            $"  Id de a: #{RuntimeHelpers.GetHashCode(referenceA)}, id de b: #{RuntimeHelpers.GetHashCode(referenceB)}; " +
            $"¿misma instancia? {(ReferenceEquals(referenceA, referenceB) ? "Sí" : "No")}"
        };
    }
}
