using PracticaU1Act2.Models;
using PracticaU1Act2.UI;

namespace PracticaU1Act2;

/// <summary>
/// Form logic: only events and result display.
/// The controls are defined in Form1.Designer.cs and the tests in TestBench.
/// </summary>
public partial class Form1 : Form
{
    private const int MaxVisibleNodes = 30;

    private RuntimeArray _array = new();   // state of Program 1
    private DynamicList _list = new();          // state of Program 2

    private int[]? _previousBlock;                 // block before the resize (only used for drawing)
    private int _previousBlockId;
    private NodeInfo? _detachedNode;               // last removed node (only used for drawing)

    public Form1()
    {
        InitializeComponent();
        ConfigureCustomStyles();
    }

    private void ConfigureCustomStyles()
    {
        // Personalización de renderizado para DataGridView sin alterar lógica
        comparisonGrid.EnableHeadersVisualStyles = false;
        comparisonGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
        comparisonGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        comparisonGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        comparisonGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(203, 213, 225);
        comparisonGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        comparisonGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
    }

    // =====================================================================
    // Tab 1: arrays at run time
    // =====================================================================

    private void btnCreateArray_Click(object? sender, EventArgs e) => RunSafely(() =>
    {
        _array.Create((int)numInitialSize.Value);
        _previousBlock = null;
        arrayCanvas.Invalidate();
        AppendLines(txtArrays,
            $"Arreglo creado en tiempo de ejecución con tamaño {_array.Length} (id #{_array.Identifier}).",
            $"Contenido: {_array.GetContent()}");
    });

    private void btnResize_Click(object? sender, EventArgs e) => RunSafely(() =>
    {
        int previousLength = _array.Length;
        int previousId = _array.Identifier;
        int[]? previousBlock = _array.CopyData();
        _array.Resize((int)numNewSize.Value);

        bool isNewBlock = _array.Identifier != previousId;
        _previousBlock = isNewBlock ? previousBlock : null;
        _previousBlockId = previousId;
        arrayCanvas.Invalidate();

        var lines = new List<string> { $"Redimensionado de {previousLength} a {_array.Length} elementos." };
        lines.Add(_array.Identifier == previousId
            ? "El tamaño no cambió, así que no se reservó un bloque nuevo."
            : $"Se reservó un bloque nuevo (id anterior #{previousId}, id nuevo #{_array.Identifier}) y se copiaron los datos.");
        if (_array.Length < previousLength)
            lines.Add($"Advertencia: al reducir el arreglo se perdieron {previousLength - _array.Length} elementos.");
        lines.Add($"Contenido: {_array.GetContent()}");

        AppendLines(txtArrays, lines.ToArray());
    });

    private async void btnFixedArray_Click(object? sender, EventArgs e) =>
        await RunAsync(() => ShowTextAsync(txtArrays, "Memoria estática: arreglo de tamaño fijo en la pila", MemoryDemos.FixedArrayOnStack));

    private async void btnGrowthCase_Click(object? sender, EventArgs e) =>
        await RunAsync(() => ShowTextAsync(txtArrays, "Caso de prueba: crecimiento automático del vector", TestBench.VectorCase));

    private void btnClearArrays_Click(object? sender, EventArgs e)
    {
        txtArrays.Clear();
        _array = new RuntimeArray();
        _previousBlock = null;
        arrayCanvas.Invalidate();
    }

    // =====================================================================
    // Tab 2: dynamic memory (Heap)
    // =====================================================================

    private void btnCreateNodes_Click(object? sender, EventArgs e) => RunSafely(() =>
    {
        int count = (int)numNodes.Value;
        for (int i = 0; i < count; i++)
            _list.Add((_list.Count + 1) * 10);
        _detachedNode = null;
        nodeCanvas.Invalidate();

        AppendLines(txtDynamic,
            $"Se crearon {count} nodos con new (se alojan en el Heap). Total en la lista: {_list.Count}.");
    });

    private void btnShowReferences_Click(object? sender, EventArgs e) => RunSafely(() =>
    {
        if (_list.Count == 0)
        {
            AppendLines(txtDynamic, "La lista está vacía: no hay nodos en el Heap.");
            return;
        }

        var lines = new List<string> { $"Nodos enlazados ({_list.Count}). El id identifica a cada objeto en el Heap:" };
        foreach (NodeInfo node in _list.DescribeNodes(MaxVisibleNodes))
        {
            string next = node.NextId is int id ? $"#{id}" : "null";
            lines.Add($"  [{node.Position}] dato {node.Value,6} | id #{node.Id} | siguiente -> {next}");
        }
        if (_list.Count > MaxVisibleNodes)
            lines.Add($"  ... ({_list.Count - MaxVisibleNodes} nodos más; el último apunta a null)");

        AppendLines(txtDynamic, lines.ToArray());
    });

    private void btnRemoveFirst_Click(object? sender, EventArgs e) => RunSafely(() =>
    {
        List<NodeInfo> first = _list.DescribeNodes(1).ToList();
        bool removed = _list.RemoveFirst();
        if (removed)
            _detachedNode = first[0];
        nodeCanvas.Invalidate();
        AppendLines(txtDynamic, removed
            ? $"Se eliminó el primer nodo: ya nadie lo referencia y el GC puede liberarlo. Quedan {_list.Count}."
            : "La lista está vacía: no hay nada que eliminar.");
    });

    private async void btnValueVsReference_Click(object? sender, EventArgs e) =>
        await RunAsync(() => ShowTextAsync(txtDynamic, "Valor (copia) frente a referencia (objeto en el Heap)", MemoryDemos.ValueVsReference));

    private async void btnRelease_Click(object? sender, EventArgs e)
    {
        int nodes = (int)numRelease.Value;
        await RunAsync(() => ShowTextAsync(txtDynamic, "Liberación de memoria por el recolector (GC)",
            () => TestBench.DemonstrateRelease(nodes)));
    }

    private async void btnListCase_Click(object? sender, EventArgs e) =>
        await RunAsync(() => ShowTextAsync(txtDynamic, "Caso de prueba: lista enlazada dinámica", TestBench.ListCase));

    private void btnClearDynamic_Click(object? sender, EventArgs e)
    {
        txtDynamic.Clear();
        _list = new DynamicList();    // the previous list is left without references
        _detachedNode = null;
        nodeCanvas.Invalidate();
    }

    private void arrayCanvas_Paint(object? sender, PaintEventArgs e) =>
        ArrayDrawing.Draw(e.Graphics, arrayCanvas.ClientRectangle, _array.CopyData(), _array.Identifier,
            _previousBlock, _previousBlockId);

    private void nodeCanvas_Paint(object? sender, PaintEventArgs e) =>
        NodeDrawing.Draw(e.Graphics, nodeCanvas.ClientRectangle, _list.DescribeNodes(MaxVisibleNodes).ToList(),
            _list.Count, _detachedNode);

    // =====================================================================
    // Tab 3: comparison and conclusion
    // =====================================================================

    private async void btnValidations_Click(object? sender, EventArgs e) =>
        await RunAsync(() => ShowTextAsync(txtOutput, "Validaciones", TestBench.ValidationCases));

    private async void btnCompare_Click(object? sender, EventArgs e) =>
        await RunAsync(AddComparisonRowAsync);

    private async void btnAccess_Click(object? sender, EventArgs e)
    {
        int reads = (int)numAccess.Value;
        await RunAsync(() => ShowTextAsync(txtOutput, "Acceso por índice",
            () => TestBench.MeasureAccess(reads)));
    }

    private void btnClearComparison_Click(object? sender, EventArgs e)
    {
        txtOutput.Clear();
        comparisonGrid.Rows.Clear();
    }

    // =====================================================================
    // Helpers
    // =====================================================================

    private static void RunSafely(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorMessages.ToDisplayText(ex), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private async Task RunAsync(Func<Task> test)
    {
        SetBusy(true);
        try
        {
            await test();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorMessages.ToDisplayText(ex), "Error en la prueba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetBusy(false);
        }
    }

    private void SetBusy(bool busy)
    {
        UseWaitCursor = busy;
        tabControl.Enabled = !busy;
    }

    private async Task ShowTextAsync(TextBox target, string title, Func<List<string>> test)
    {
        List<string> lines = await Task.Run(test);
        AppendLines(target, [$"--- {title} ---", .. lines]);
    }

    private static void AppendLines(TextBox target, params string[] lines)
    {
        foreach (string line in lines)
            target.AppendText(line + Environment.NewLine);
        target.AppendText(Environment.NewLine);
    }

    private async Task AddComparisonRowAsync()
    {
        int n = (int)numElements.Value;
        ComparisonRow row = await Task.Run(() => TestBench.Compare(n));
        comparisonGrid.Rows.Add(
            row.N.ToString("N0"),
            row.VectorTimeMs.ToString("F2"),
            row.ListTimeMs.ToString("F2"),
            row.VectorMemoryKb.ToString("N0"),
            row.ListMemoryKb.ToString("N0"),
            row.VectorCopies);

        if (TestBench.IsDebugBuild)
            AppendLines(txtOutput, "Aviso: la aplicación está compilada en Debug; para mediciones representativas ejecútala en Release.");
    }
}