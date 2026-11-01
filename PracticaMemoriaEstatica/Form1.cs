namespace PracticaU1Act2;

/// <summary>
/// Lógica del formulario: solo eventos y presentación de resultados.
/// Los controles están definidos en Form1.Designer.cs y las pruebas en BancoDePruebas.
/// </summary>
public partial class Form1 : Form
{
    private const int MaximoNodosVisibles = 30;

    private ArregloEnEjecucion _arreglo = new();   // estado del Programa 1
    private ListaDinamica _lista = new();          // estado del Programa 2

    private int[]? _previousBlock;                 // bloque anterior tras redimensionar (solo para dibujar)
    private int _previousBlockId;
    private InfoNodo? _detachedNode;               // último nodo eliminado (solo para dibujar)

    public Form1()
    {
        InitializeComponent();
    }

    // =====================================================================
    // Pestaña 1: arreglos en tiempo de ejecución
    // =====================================================================

    private void btnCrearArreglo_Click(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        _arreglo.Crear((int)numTamanoInicial.Value);
        _previousBlock = null;
        arrayCanvas.Invalidate();
        Escribir(txtArreglos,
            $"Arreglo creado en tiempo de ejecución con tamaño {_arreglo.Longitud} (id #{_arreglo.Identificador}).",
            $"Contenido: {_arreglo.Contenido()}");
    });

    private void btnRedimensionar_Click(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        int longitudAnterior = _arreglo.Longitud;
        int idAnterior = _arreglo.Identificador;
        int[]? bloqueAnterior = _arreglo.CopiarDatos();
        _arreglo.Redimensionar((int)numTamanoNuevo.Value);

        bool bloqueNuevo = _arreglo.Identificador != idAnterior;
        _previousBlock = bloqueNuevo ? bloqueAnterior : null;
        _previousBlockId = idAnterior;
        arrayCanvas.Invalidate();

        var lineas = new List<string> { $"Redimensionado de {longitudAnterior} a {_arreglo.Longitud} elementos." };
        lineas.Add(_arreglo.Identificador == idAnterior
            ? "El tamaño no cambió, así que no se reservó un bloque nuevo."
            : $"Se reservó un bloque nuevo (id anterior #{idAnterior}, id nuevo #{_arreglo.Identificador}) y se copiaron los datos.");
        if (_arreglo.Longitud < longitudAnterior)
            lineas.Add($"Advertencia: al reducir el arreglo se perdieron {longitudAnterior - _arreglo.Longitud} elementos.");
        lineas.Add($"Contenido: {_arreglo.Contenido()}");

        Escribir(txtArreglos, lineas.ToArray());
    });

    private async void btnArregloFijo_Click(object? sender, EventArgs e) =>
        await EjecutarAsync(() => MostrarTextoAsync(txtArreglos, "Memoria estática: arreglo de tamaño fijo en la pila", DemostracionesMemoria.ArregloFijoEnPila));

    private async void btnCrecimiento_Click(object? sender, EventArgs e) =>
        await EjecutarAsync(() => MostrarTextoAsync(txtArreglos, "Caso de prueba: crecimiento automático del vector", BancoDePruebas.CasoVector));

    private void btnLimpiarArreglos_Click(object? sender, EventArgs e)
    {
        txtArreglos.Clear();
        _arreglo = new ArregloEnEjecucion();
        _previousBlock = null;
        arrayCanvas.Invalidate();
    }

    // =====================================================================
    // Pestaña 2: memoria dinámica (Heap)
    // =====================================================================

    private void btnCrearNodos_Click(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        int cantidad = (int)numNodos.Value;
        for (int i = 0; i < cantidad; i++)
            _lista.Agregar((_lista.Cantidad + 1) * 10);
        _detachedNode = null;
        nodeCanvas.Invalidate();

        Escribir(txtDinamica,
            $"Se crearon {cantidad} nodos con new (se alojan en el Heap). Total en la lista: {_lista.Cantidad}.");
    });

    private void btnVerReferencias_Click(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        if (_lista.Cantidad == 0)
        {
            Escribir(txtDinamica, "La lista está vacía: no hay nodos en el Heap.");
            return;
        }

        var lineas = new List<string> { $"Nodos enlazados ({_lista.Cantidad}). El id identifica a cada objeto en el Heap:" };
        foreach (InfoNodo nodo in _lista.DescribirNodos(MaximoNodosVisibles))
        {
            string siguiente = nodo.IdSiguiente is int id ? $"#{id}" : "null";
            lineas.Add($"  [{nodo.Posicion}] dato {nodo.Dato,6} | id #{nodo.Id} | siguiente -> {siguiente}");
        }
        if (_lista.Cantidad > MaximoNodosVisibles)
            lineas.Add($"  ... ({_lista.Cantidad - MaximoNodosVisibles} nodos más; el último apunta a null)");

        Escribir(txtDinamica, lineas.ToArray());
    });

    private void btnEliminarPrimero_Click(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        List<InfoNodo> primero = _lista.DescribirNodos(1).ToList();
        bool eliminado = _lista.EliminarPrimero();
        if (eliminado)
            _detachedNode = primero[0];
        nodeCanvas.Invalidate();
        Escribir(txtDinamica, eliminado
            ? $"Se eliminó el primer nodo: ya nadie lo referencia y el GC puede liberarlo. Quedan {_lista.Cantidad}."
            : "La lista está vacía: no hay nada que eliminar.");
    });

    private async void btnValorReferencia_Click(object? sender, EventArgs e) =>
        await EjecutarAsync(() => MostrarTextoAsync(txtDinamica, "Valor (copia) frente a referencia (objeto en el Heap)", DemostracionesMemoria.ValorVsReferencia));

    private async void btnLiberar_Click(object? sender, EventArgs e)
    {
        int nodos = (int)numLiberar.Value;
        await EjecutarAsync(() => MostrarTextoAsync(txtDinamica, "Liberación de memoria por el recolector (GC)",
            () => BancoDePruebas.DemostrarLiberacion(nodos)));
    }

    private async void btnCasoLista_Click(object? sender, EventArgs e) =>
        await EjecutarAsync(() => MostrarTextoAsync(txtDinamica, "Caso de prueba: lista enlazada dinámica", BancoDePruebas.CasoLista));

    private void btnLimpiarDinamica_Click(object? sender, EventArgs e)
    {
        txtDinamica.Clear();
        _lista = new ListaDinamica();    // la lista anterior queda sin referencias
        _detachedNode = null;
        nodeCanvas.Invalidate();
    }

    private void arrayCanvas_Paint(object? sender, PaintEventArgs e) =>
        ArrayDrawing.Draw(e.Graphics, arrayCanvas.ClientRectangle, _arreglo.CopiarDatos(), _arreglo.Identificador,
            _previousBlock, _previousBlockId);

    private void nodeCanvas_Paint(object? sender, PaintEventArgs e) =>
        NodeDrawing.Draw(e.Graphics, nodeCanvas.ClientRectangle, _lista.DescribirNodos(MaximoNodosVisibles).ToList(),
            _lista.Cantidad, _detachedNode);

    // =====================================================================
    // Pestaña 3: comparativa y conclusión
    // =====================================================================

    private async void btnValidaciones_Click(object? sender, EventArgs e) =>
        await EjecutarAsync(() => MostrarTextoAsync(txtSalida, "Validaciones", BancoDePruebas.CasoValidaciones));

    private async void btnComparar_Click(object? sender, EventArgs e) =>
        await EjecutarAsync(AgregarFilaComparativaAsync);

    private async void btnAcceso_Click(object? sender, EventArgs e)
    {
        int lecturas = (int)numAcceso.Value;
        await EjecutarAsync(() => MostrarTextoAsync(txtSalida, "Acceso por índice",
            () => BancoDePruebas.MedirAcceso(lecturas)));
    }

    private void btnLimpiarComparativa_Click(object? sender, EventArgs e)
    {
        txtSalida.Clear();
        tabla.Rows.Clear();
    }

    // =====================================================================
    // Apoyo
    // =====================================================================

    /// <summary>Ejecuta una acción corta mostrando cualquier error en un aviso.</summary>
    private static void EjecutarSeguro(Action accion)
    {
        try
        {
            accion();
        }
        catch (Exception ex)
        {
            MessageBox.Show(MensajesError.ParaMostrar(ex), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    /// <summary>Ejecuta una prueba larga sin congelar la ventana.</summary>
    private async Task EjecutarAsync(Func<Task> prueba)
    {
        SetOcupado(true);
        try
        {
            await prueba();
        }
        catch (Exception ex)
        {
            MessageBox.Show(MensajesError.ParaMostrar(ex), "Error en la prueba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetOcupado(false);
        }
    }

    private void SetOcupado(bool ocupado)
    {
        UseWaitCursor = ocupado;
        tabControl.Enabled = !ocupado;
    }

    /// <summary>Corre la prueba en otro hilo y escribe sus líneas en el cuadro indicado.</summary>
    private async Task MostrarTextoAsync(TextBox destino, string titulo, Func<List<string>> prueba)
    {
        List<string> lineas = await Task.Run(prueba);
        Escribir(destino, [$"--- {titulo} ---", .. lineas]);
    }

    private static void Escribir(TextBox destino, params string[] lineas)
    {
        foreach (string linea in lineas)
            destino.AppendText(linea + Environment.NewLine);
        destino.AppendText(Environment.NewLine);
    }

    private async Task AgregarFilaComparativaAsync()
    {
        int n = (int)numElementos.Value;
        FilaComparativa fila = await Task.Run(() => BancoDePruebas.Comparar(n));
        tabla.Rows.Add(
            fila.N.ToString("N0"),
            fila.TiempoVectorMs.ToString("F2"),
            fila.TiempoListaMs.ToString("F2"),
            fila.MemoriaVectorKb.ToString("N0"),
            fila.MemoriaListaKb.ToString("N0"),
            fila.CopiasVector);

        if (BancoDePruebas.CompiladoEnDebug)
            Escribir(txtSalida, "Aviso: la aplicación está compilada en Debug; para mediciones representativas ejecútala en Release.");
    }
}