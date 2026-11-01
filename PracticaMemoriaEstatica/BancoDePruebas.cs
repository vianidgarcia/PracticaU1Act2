using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PracticaU1Act2;

/// <summary>Una fila de la tabla comparativa (tiempos como mediana de varias repeticiones).</summary>
public record FilaComparativa(
    int N,
    double TiempoVectorMs,
    double TiempoListaMs,
    double MemoriaVectorKb,
    double MemoriaListaKb,
    int CopiasVector);

/// <summary>
/// Casos de prueba y mediciones de la práctica. No usa controles ni Console:
/// devuelve los resultados para que el formulario los muestre.
/// </summary>
public static class BancoDePruebas
{
    public const int Repeticiones = 5;            // repeticiones por medición (se reporta la mediana)
    private const int RepeticionesAcceso = 3;     // menos, porque leer la lista es O(n²) en total

#if DEBUG
    public static bool CompiladoEnDebug { get; } = true;
#else
    public static bool CompiladoEnDebug { get; } = false;
#endif

    // ---------- Caso de prueba: crecimiento automático del vector ----------
    public static List<string> CasoVector()
    {
        var lineas = new List<string>();
        var vector = new VectorRedimensionable(2);
        for (int i = 1; i <= 9; i++)
        {
            vector.Agregar(i * 10);
            lineas.Add($"Agregado {i * 10,3} | cantidad {vector.Cantidad} | capacidad {vector.Capacidad,2} | copias {vector.Redimensiones}");
        }
        lineas.Add($"Espacios reservados sin usar: {vector.EspaciosLibres}");
        lineas.Add($"Elemento en índice 4 (acceso directo): {vector.Obtener(4)}");
        return lineas;
    }

    // ---------- Caso de prueba: nodos creados en el Heap ----------
    public static List<string> CasoLista()
    {
        var lineas = new List<string>();
        var lista = new ListaDinamica();
        for (int i = 1; i <= 5; i++) lista.Agregar(i * 10);
        lineas.Add($"Nodos creados: {lista.Cantidad}");
        lineas.Add($"Elemento en índice 4 (recorriendo enlaces): {lista.Obtener(4)}");
        lista.EliminarPrimero();
        lineas.Add($"Tras eliminar el primero: {lista.Cantidad} nodos, nuevo primero = {lista.Obtener(0)}");
        return lineas;
    }

    // ---------- Validaciones: casos extremos ----------
    public static List<string> CasoValidaciones()
    {
        var listaConDatos = new ListaDinamica();
        for (int i = 1; i <= 3; i++) listaConDatos.Agregar(i * 10);

        return new List<string>
        {
            Probar("Vector con capacidad inicial 0", () => new VectorRedimensionable(0)),
            Probar("Leer el índice 5 de un vector vacío", () => new VectorRedimensionable(3).Obtener(5)),
            Probar("Leer el índice 0 de una lista vacía", () => new ListaDinamica().Obtener(0)),
            Probar("Leer el índice -1 de una lista con 3 nodos", () => listaConDatos.Obtener(-1)),
            Probar("Crear un arreglo de tamaño 0", () => new ArregloEnEjecucion().Crear(0)),
            Probar("Redimensionar sin haber creado el arreglo", () => new ArregloEnEjecucion().Redimensionar(5)),
            $"Eliminar en una lista vacía devuelve {new ListaDinamica().EliminarPrimero()} (no lanza excepción)."
        };
    }

    private static string Probar(string nombre, Action accion)
    {
        try
        {
            accion();
            return $"{nombre}: sin error (inesperado)";
        }
        catch (Exception ex)
        {
            return $"{nombre}: {ex.GetType().Name} -> {MensajesError.ParaMostrar(ex)}";
        }
    }

    // ---------- Comparativa: inserción y memoria con N elementos ----------
    public static FilaComparativa Comparar(int n)
    {
        Calentar();

        var tiemposVector = new double[Repeticiones];
        var tiemposLista = new double[Repeticiones];
        long memoriaVector = 0, memoriaLista = 0;
        int copias = 0;

        for (int r = 0; r < Repeticiones; r++)
        {
            var (tiempoV, memoriaV, copiasV) = MedirVector(n);
            var (tiempoL, memoriaL) = MedirLista(n);
            tiemposVector[r] = tiempoV;
            tiemposLista[r] = tiempoL;
            memoriaVector = memoriaV;      // la memoria casi no varía entre repeticiones
            memoriaLista = memoriaL;
            copias = copiasV;
        }

        return new FilaComparativa(n, Mediana(tiemposVector), Mediana(tiemposLista),
            memoriaVector / 1024.0, memoriaLista / 1024.0, copias);
    }

    /// <summary>Ejecuta una vez el código a medir para que el compilador JIT no altere la primera medición.</summary>
    private static void Calentar()
    {
        MedirVector(1_000);
        MedirLista(1_000);
    }

    private static (double TiempoMs, long Memoria, int Copias) MedirVector(int n)
    {
        long antes = MemoriaActual();
        var cronometro = Stopwatch.StartNew();
        var vector = new VectorRedimensionable(1);
        for (int i = 0; i < n; i++) vector.Agregar(i);
        cronometro.Stop();

        long memoria = MemoriaActual() - antes;    // el vector sigue vivo aquí
        int copias = vector.Redimensiones;
        GC.KeepAlive(vector);
        return (cronometro.Elapsed.TotalMilliseconds, memoria, copias);
    }

    private static (double TiempoMs, long Memoria) MedirLista(int n)
    {
        long antes = MemoriaActual();
        var cronometro = Stopwatch.StartNew();
        var lista = new ListaDinamica();
        for (int i = 0; i < n; i++) lista.Agregar(i);
        cronometro.Stop();

        long memoria = MemoriaActual() - antes;    // la lista sigue viva aquí
        GC.KeepAlive(lista);
        return (cronometro.Elapsed.TotalMilliseconds, memoria);
    }

    // ---------- Comparativa: lectura por índice ----------
    public static List<string> MedirAcceso(int n)
    {
        var vector = new VectorRedimensionable(1);
        var lista = new ListaDinamica();
        for (int i = 0; i < n; i++)
        {
            vector.Agregar(i);
            lista.Agregar(i);
        }

        // Calentamiento del JIT con pocas lecturas
        LeerTodo(vector.Obtener, Math.Min(n, 1_000));
        LeerTodo(lista.Obtener, Math.Min(n, 1_000));

        var tiemposVector = new double[RepeticionesAcceso];
        var tiemposLista = new double[RepeticionesAcceso];
        long suma = 0;
        for (int r = 0; r < RepeticionesAcceso; r++)
        {
            var (tiempoV, sumaV) = LeerTodo(vector.Obtener, n);
            var (tiempoL, sumaL) = LeerTodo(lista.Obtener, n);
            tiemposVector[r] = tiempoV;
            tiemposLista[r] = tiempoL;
            suma = sumaV + sumaL;          // evita que el compilador descarte las lecturas
        }

        double medianaVector = Mediana(tiemposVector);
        double medianaLista = Mediana(tiemposLista);
        var lineas = new List<string>
        {
            $"Lectura de {n:N0} elementos por índice (mediana de {RepeticionesAcceso} repeticiones):",
            $"  Vector (O(1) por acceso): {medianaVector:F2} ms",
            $"  Lista  (O(n) por acceso): {medianaLista:F2} ms"
        };
        if (medianaVector > 0)
            lineas.Add($"  La lista tardó unas {medianaLista / medianaVector:N0} veces más.");
        lineas.Add($"  Suma de control: {suma}");
        return lineas;
    }

    /// <summary>Lee los n primeros elementos con la función dada y mide el tiempo.</summary>
    private static (double TiempoMs, long Suma) LeerTodo(Func<int, int> obtener, int n)
    {
        long suma = 0;
        var cronometro = Stopwatch.StartNew();
        for (int i = 0; i < n; i++) suma += obtener(i);
        cronometro.Stop();
        return (cronometro.Elapsed.TotalMilliseconds, suma);
    }

    // ---------- Memoria dinámica: liberación de objetos sin referencias ----------
    public static List<string> DemostrarLiberacion(int nodos)
    {
        long memoriaInicial = MemoriaActual();
        WeakReference referencia = CrearListaYMedir(nodos, out long memoriaConLista);

        bool vivoAntes = referencia.IsAlive;      // todavía no se recolectó
        long memoriaFinal = MemoriaActual();      // fuerza la recolección
        bool vivoDespues = referencia.IsAlive;

        return new List<string>
        {
            $"Memoria inicial: {memoriaInicial / 1024:N0} KB",
            $"Con {nodos:N0} nodos creados y referenciados: {memoriaConLista / 1024:N0} KB (+{(memoriaConLista - memoriaInicial) / 1024:N0} KB)",
            $"Tras soltar la referencia y recolectar: {memoriaFinal / 1024:N0} KB",
            $"¿La lista seguía en el Heap antes de recolectar? {(vivoAntes ? "Sí" : "No")}",
            $"¿Sigue en el Heap después de recolectar? {(vivoDespues ? "Sí" : "No")}",
            "El recolector de basura (GC) libera los objetos del Heap que ya no tienen referencias."
        };
    }

    // NoInlining: al terminar el método, la lista queda sin referencias
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static WeakReference CrearListaYMedir(int nodos, out long memoriaConLista)
    {
        var lista = new ListaDinamica();
        for (int i = 0; i < nodos; i++) lista.Agregar(i);

        memoriaConLista = MemoriaActual();        // la lista sigue referenciada aquí
        var referencia = new WeakReference(lista);
        GC.KeepAlive(lista);
        return referencia;
    }

    // ---------- Apoyo ----------

    private static double Mediana(double[] valores)
    {
        double[] ordenados = (double[])valores.Clone();
        Array.Sort(ordenados);
        int mitad = ordenados.Length / 2;
        return ordenados.Length % 2 == 1
            ? ordenados[mitad]
            : (ordenados[mitad - 1] + ordenados[mitad]) / 2;
    }

    /// <summary>
    /// Fuerza la recolección para medir solo la memoria viva. Llamar al GC a mano no es
    /// una buena práctica en una aplicación normal; aquí se usa únicamente para medir.
    /// </summary>
    private static long MemoriaActual()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        return GC.GetTotalMemory(true);
    }
}
