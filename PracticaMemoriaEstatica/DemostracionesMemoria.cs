using System.Runtime.CompilerServices;

namespace PracticaU1Act2;

/// <summary>
/// Demostraciones conceptuales que contrastan la memoria estática (pila, tamaño fijo)
/// con la memoria dinámica (objetos creados con new en el Heap).
/// </summary>
public static class DemostracionesMemoria
{
    private const int TamanoFijo = 5;   // tamaño definido en compilación

    // ---------- Memoria estática: arreglo de tamaño fijo en la pila ----------
    public static List<string> ArregloFijoEnPila()
    {
        // stackalloc reserva el bloque en la pila del método, no en el Heap
        Span<int> enPila = stackalloc int[TamanoFijo];
        for (int i = 0; i < enPila.Length; i++)
            enPila[i] = (i + 1) * 10;

        var lineas = new List<string>
        {
            $"Arreglo de {TamanoFijo} enteros reservado en la PILA con stackalloc (tamaño fijo, definido en compilación).",
            $"Contenido: [{string.Join(", ", enPila.ToArray())}]"
        };

        // Se intenta guardar un elemento más del que cabe (solo con fines demostrativos)
        int indiceExtra = TamanoFijo;
        try
        {
            enPila[indiceExtra] = (indiceExtra + 1) * 10;
            lineas.Add("Se escribió fuera del límite (resultado inesperado).");
        }
        catch (IndexOutOfRangeException)
        {
            lineas.Add($"Intento de escribir en el índice {indiceExtra}: IndexOutOfRangeException. El bloque no puede crecer.");
        }

        lineas.Add("Para tener más espacio habría que reservar otro bloque y copiar los datos (lo que hace Array.Resize).");
        lineas.Add("Este bloque se libera solo al terminar el método; el recolector de basura (GC) no interviene.");
        return lineas;
    }

    // ---------- Valor (copia) frente a referencia (objeto compartido en el Heap) ----------
    private struct PuntoValor { public int X; }            // tipo por valor: se copia completo
    private sealed class PuntoReferencia { public int X; } // tipo por referencia: el objeto vive en el Heap

    public static List<string> ValorVsReferencia()
    {
        var valorA = new PuntoValor { X = 1 };
        PuntoValor valorB = valorA;        // copia independiente de los datos
        valorB.X = 99;

        var referenciaA = new PuntoReferencia { X = 1 };
        PuntoReferencia referenciaB = referenciaA;   // copia de la referencia: mismo objeto
        referenciaB.X = 99;

        return new List<string>
        {
            "Tipo por valor (struct) como variable local, normalmente en la pila:",
            $"  a.X = {valorA.X}, b.X = {valorB.X} -> b es una copia; cambiarla no afecta a a.",
            "Tipo por referencia (class) creado con new en el Heap:",
            $"  a.X = {referenciaA.X}, b.X = {referenciaB.X} -> a y b apuntan al mismo objeto.",
            $"  Id de a: #{RuntimeHelpers.GetHashCode(referenciaA)}, id de b: #{RuntimeHelpers.GetHashCode(referenciaB)}; " +
            $"¿misma instancia? {(ReferenceEquals(referenciaA, referenciaB) ? "Sí" : "No")}"
        };
    }
}
