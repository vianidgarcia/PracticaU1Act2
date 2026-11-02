using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PracticaU1Act2;

/// <summary>One row of the comparison table (times are the median of several repetitions).</summary>
public record ComparisonRow(
    int N,
    double VectorTimeMs,
    double ListTimeMs,
    double VectorMemoryKb,
    double ListMemoryKb,
    int VectorCopies);

/// <summary>
/// Test cases and measurements for the practice. It uses no controls or Console:
/// it returns the results so the form can display them.
/// </summary>
public static class TestBench
{
    public const int Repetitions = 5;            // repetitions per measurement (the median is reported)
    private const int AccessRepetitions = 3;     // fewer, because reading the whole list by index is O(n²) in total

#if DEBUG
    public static bool IsDebugBuild { get; } = true;
#else
    public static bool IsDebugBuild { get; } = false;
#endif

    // ---------- Test case: automatic growth of the vector ----------
    public static List<string> VectorCase()
    {
        var lines = new List<string>();
        var vector = new ResizableVector(2);
        for (int i = 1; i <= 9; i++)
        {
            vector.Add(i * 10);
            lines.Add($"Agregado {i * 10,3} | cantidad {vector.Count} | capacidad {vector.Capacity,2} | copias {vector.ResizeCount}");
        }
        lines.Add($"Espacios reservados sin usar: {vector.FreeSlots}");
        lines.Add($"Elemento en índice 4 (acceso directo): {vector.Get(4)}");
        return lines;
    }

    // ---------- Test case: nodes created on the Heap ----------
    public static List<string> ListCase()
    {
        var lines = new List<string>();
        var list = new DynamicList();
        for (int i = 1; i <= 5; i++) list.Add(i * 10);
        lines.Add($"Nodos creados: {list.Count}");
        lines.Add($"Elemento en índice 4 (recorriendo enlaces): {list.Get(4)}");
        list.RemoveFirst();
        lines.Add($"Tras eliminar el primero: {list.Count} nodos, nuevo primero = {list.Get(0)}");
        return lines;
    }

    // ---------- Validations: edge cases ----------
    public static List<string> ValidationCases()
    {
        var listWithData = new DynamicList();
        for (int i = 1; i <= 3; i++) listWithData.Add(i * 10);

        return new List<string>
        {
            RunCase("Vector con capacidad inicial 0", () => new ResizableVector(0)),
            RunCase("Leer el índice 5 de un vector vacío", () => new ResizableVector(3).Get(5)),
            RunCase("Leer el índice 0 de una lista vacía", () => new DynamicList().Get(0)),
            RunCase("Leer el índice -1 de una lista con 3 nodos", () => listWithData.Get(-1)),
            RunCase("Crear un arreglo de tamaño 0", () => new RuntimeArray().Create(0)),
            RunCase("Redimensionar sin haber creado el arreglo", () => new RuntimeArray().Resize(5)),
            $"Eliminar en una lista vacía devuelve {new DynamicList().RemoveFirst()} (no lanza excepción)."
        };
    }

    private static string RunCase(string name, Action action)
    {
        try
        {
            action();
            return $"{name}: sin error (inesperado)";
        }
        catch (Exception ex)
        {
            return $"{name}: {ex.GetType().Name} -> {ErrorMessages.ToDisplayText(ex)}";
        }
    }

    // ---------- Comparison: insertion and memory with N elements ----------
    public static ComparisonRow Compare(int n)
    {
        WarmUp();

        var vectorTimes = new double[Repetitions];
        var listTimes = new double[Repetitions];
        long vectorMemory = 0, listMemory = 0;
        int copies = 0;

        for (int r = 0; r < Repetitions; r++)
        {
            var (runVectorTime, runVectorMemory, runCopies) = MeasureVector(n);
            var (runListTime, runListMemory) = MeasureList(n);
            vectorTimes[r] = runVectorTime;
            listTimes[r] = runListTime;
            vectorMemory = runVectorMemory;      // memory barely changes between repetitions
            listMemory = runListMemory;
            copies = runCopies;
        }

        return new ComparisonRow(n, Median(vectorTimes), Median(listTimes),
            vectorMemory / 1024.0, listMemory / 1024.0, copies);
    }

    /// <summary>Runs the code to be measured once so the JIT compiler does not distort the first measurement.</summary>
    private static void WarmUp()
    {
        MeasureVector(1_000);
        MeasureList(1_000);
    }

    private static (double TimeMs, long Memory, int Copies) MeasureVector(int n)
    {
        long before = LiveMemory();
        var stopwatch = Stopwatch.StartNew();
        var vector = new ResizableVector(1);
        for (int i = 0; i < n; i++) vector.Add(i);
        stopwatch.Stop();

        long memory = LiveMemory() - before;    // the vector is still alive here
        int copies = vector.ResizeCount;
        GC.KeepAlive(vector);
        return (stopwatch.Elapsed.TotalMilliseconds, memory, copies);
    }

    private static (double TimeMs, long Memory) MeasureList(int n)
    {
        long before = LiveMemory();
        var stopwatch = Stopwatch.StartNew();
        var list = new DynamicList();
        for (int i = 0; i < n; i++) list.Add(i);
        stopwatch.Stop();

        long memory = LiveMemory() - before;    // the list is still alive here
        GC.KeepAlive(list);
        return (stopwatch.Elapsed.TotalMilliseconds, memory);
    }

    // ---------- Comparison: reading by index ----------
    public static List<string> MeasureAccess(int n)
    {
        var vector = new ResizableVector(1);
        var list = new DynamicList();
        for (int i = 0; i < n; i++)
        {
            vector.Add(i);
            list.Add(i);
        }

        // JIT warm-up with a few reads
        ReadAll(vector.Get, Math.Min(n, 1_000));
        ReadAll(list.Get, Math.Min(n, 1_000));

        var vectorTimes = new double[AccessRepetitions];
        var listTimes = new double[AccessRepetitions];
        long sum = 0;
        for (int r = 0; r < AccessRepetitions; r++)
        {
            var (runVectorTime, vectorSum) = ReadAll(vector.Get, n);
            var (runListTime, listSum) = ReadAll(list.Get, n);
            vectorTimes[r] = runVectorTime;
            listTimes[r] = runListTime;
            sum = vectorSum + listSum;          // keeps the compiler from discarding the reads
        }

        double vectorMedian = Median(vectorTimes);
        double listMedian = Median(listTimes);
        var lines = new List<string>
        {
            $"Lectura de {n:N0} elementos por índice (mediana de {AccessRepetitions} repeticiones):",
            $"  Vector (O(1) por acceso): {vectorMedian:F2} ms",
            $"  Lista  (O(n) por acceso): {listMedian:F2} ms"
        };
        if (vectorMedian > 0)
            lines.Add($"  La lista tardó unas {listMedian / vectorMedian:N0} veces más.");
        lines.Add($"  Suma de control: {sum}");
        return lines;
    }

    /// <summary>Reads the first n elements with the given function and measures the time.</summary>
    private static (double TimeMs, long Sum) ReadAll(Func<int, int> getValue, int n)
    {
        long sum = 0;
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < n; i++) sum += getValue(i);
        stopwatch.Stop();
        return (stopwatch.Elapsed.TotalMilliseconds, sum);
    }

    // ---------- Dynamic memory: releasing objects with no references ----------
    public static List<string> DemonstrateRelease(int nodes)
    {
        long initialMemory = LiveMemory();
        WeakReference reference = CreateListAndMeasure(nodes, out long memoryWithList);

        bool aliveBefore = reference.IsAlive;      // not collected yet
        long finalMemory = LiveMemory();      // forces a collection
        bool aliveAfter = reference.IsAlive;

        return new List<string>
        {
            $"Memoria inicial: {initialMemory / 1024:N0} KB",
            $"Con {nodes:N0} nodos creados y referenciados: {memoryWithList / 1024:N0} KB (+{(memoryWithList - initialMemory) / 1024:N0} KB)",
            $"Tras soltar la referencia y recolectar: {finalMemory / 1024:N0} KB",
            $"¿La lista seguía en el Heap antes de recolectar? {(aliveBefore ? "Sí" : "No")}",
            $"¿Sigue en el Heap después de recolectar? {(aliveAfter ? "Sí" : "No")}",
            "El recolector de basura (GC) libera los objetos del Heap que ya no tienen referencias."
        };
    }

    // NoInlining: when the method ends, the list has no references left
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static WeakReference CreateListAndMeasure(int nodes, out long memoryWithList)
    {
        var list = new DynamicList();
        for (int i = 0; i < nodes; i++) list.Add(i);

        memoryWithList = LiveMemory();        // the list is still referenced here
        var reference = new WeakReference(list);
        GC.KeepAlive(list);
        return reference;
    }

    // ---------- Helpers ----------

    private static double Median(double[] values)
    {
        double[] sorted = (double[])values.Clone();
        Array.Sort(sorted);
        int middle = sorted.Length / 2;
        return sorted.Length % 2 == 1
            ? sorted[middle]
            : (sorted[middle - 1] + sorted[middle]) / 2;
    }

    /// <summary>
    /// Forces a collection to measure live memory only. Calling the GC by hand is not
    /// good practice in a normal application; here it is used only to measure.
    /// </summary>
    private static long LiveMemory()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        return GC.GetTotalMemory(true);
    }
}
