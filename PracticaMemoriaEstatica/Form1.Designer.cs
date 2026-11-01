namespace PracticaU1Act2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabArreglos = new TabPage();
            txtArreglos = new TextBox();
            arrayCanvas = new DrawingPanel();
            panelArreglos = new FlowLayoutPanel();
            lblTamanoInicial = new Label();
            numTamanoInicial = new NumericUpDown();
            btnCrearArreglo = new Button();
            lblTamanoNuevo = new Label();
            numTamanoNuevo = new NumericUpDown();
            btnRedimensionar = new Button();
            btnArregloFijo = new Button();
            btnCrecimiento = new Button();
            btnLimpiarArreglos = new Button();
            tabDinamica = new TabPage();
            txtDinamica = new TextBox();
            nodeCanvas = new DrawingPanel();
            panelDinamica = new FlowLayoutPanel();
            lblNodos = new Label();
            numNodos = new NumericUpDown();
            btnCrearNodos = new Button();
            btnVerReferencias = new Button();
            btnEliminarPrimero = new Button();
            btnValorReferencia = new Button();
            lblLiberar = new Label();
            numLiberar = new NumericUpDown();
            btnLiberar = new Button();
            btnCasoLista = new Button();
            btnLimpiarDinamica = new Button();
            tabComparativa = new TabPage();
            txtSalida = new TextBox();
            tabla = new DataGridView();
            colN = new DataGridViewTextBoxColumn();
            colTiempoVector = new DataGridViewTextBoxColumn();
            colTiempoLista = new DataGridViewTextBoxColumn();
            colMemoriaVector = new DataGridViewTextBoxColumn();
            colMemoriaLista = new DataGridViewTextBoxColumn();
            colCopias = new DataGridViewTextBoxColumn();
            panelComparativa = new FlowLayoutPanel();
            btnValidaciones = new Button();
            lblN = new Label();
            numElementos = new NumericUpDown();
            btnComparar = new Button();
            lblLecturas = new Label();
            numAcceso = new NumericUpDown();
            btnAcceso = new Button();
            btnLimpiarComparativa = new Button();
            tabControl.SuspendLayout();
            tabArreglos.SuspendLayout();
            panelArreglos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTamanoInicial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTamanoNuevo).BeginInit();
            tabDinamica.SuspendLayout();
            panelDinamica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNodos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLiberar).BeginInit();
            tabComparativa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabla).BeginInit();
            panelComparativa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numElementos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAcceso).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabArreglos);
            tabControl.Controls.Add(tabDinamica);
            tabControl.Controls.Add(tabComparativa);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(3, 2, 3, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(875, 480);
            tabControl.TabIndex = 0;
            // 
            // tabArreglos
            // 
            tabArreglos.Controls.Add(txtArreglos);
            tabArreglos.Controls.Add(arrayCanvas);
            tabArreglos.Controls.Add(panelArreglos);
            tabArreglos.Location = new Point(4, 24);
            tabArreglos.Margin = new Padding(3, 2, 3, 2);
            tabArreglos.Name = "tabArreglos";
            tabArreglos.Padding = new Padding(3, 2, 3, 2);
            tabArreglos.Size = new Size(867, 452);
            tabArreglos.TabIndex = 0;
            tabArreglos.Text = "Programa 1: Arreglos en tiempo de ejecución";
            tabArreglos.UseVisualStyleBackColor = true;
            // 
            // txtArreglos
            // 
            txtArreglos.BackColor = Color.White;
            txtArreglos.Dock = DockStyle.Fill;
            txtArreglos.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtArreglos.Location = new Point(3, 269);
            txtArreglos.Margin = new Padding(3, 2, 3, 2);
            txtArreglos.Multiline = true;
            txtArreglos.Name = "txtArreglos";
            txtArreglos.ReadOnly = true;
            txtArreglos.ScrollBars = ScrollBars.Vertical;
            txtArreglos.Size = new Size(861, 181);
            txtArreglos.TabIndex = 0;
            // 
            // arrayCanvas
            // 
            arrayCanvas.BorderStyle = BorderStyle.FixedSingle;
            arrayCanvas.Dock = DockStyle.Top;
            arrayCanvas.Location = new Point(3, 68);
            arrayCanvas.Margin = new Padding(3, 2, 3, 2);
            arrayCanvas.Name = "arrayCanvas";
            arrayCanvas.Size = new Size(861, 201);
            arrayCanvas.TabIndex = 2;
            arrayCanvas.Paint += arrayCanvas_Paint;
            // 
            // panelArreglos
            // 
            panelArreglos.AutoSize = true;
            panelArreglos.Controls.Add(lblTamanoInicial);
            panelArreglos.Controls.Add(numTamanoInicial);
            panelArreglos.Controls.Add(btnCrearArreglo);
            panelArreglos.Controls.Add(lblTamanoNuevo);
            panelArreglos.Controls.Add(numTamanoNuevo);
            panelArreglos.Controls.Add(btnRedimensionar);
            panelArreglos.Controls.Add(btnArregloFijo);
            panelArreglos.Controls.Add(btnCrecimiento);
            panelArreglos.Controls.Add(btnLimpiarArreglos);
            panelArreglos.Dock = DockStyle.Top;
            panelArreglos.Location = new Point(3, 2);
            panelArreglos.Margin = new Padding(3, 2, 3, 2);
            panelArreglos.Name = "panelArreglos";
            panelArreglos.Padding = new Padding(5, 4, 5, 4);
            panelArreglos.Size = new Size(861, 66);
            panelArreglos.TabIndex = 1;
            // 
            // lblTamanoInicial
            // 
            lblTamanoInicial.AutoSize = true;
            lblTamanoInicial.Location = new Point(15, 10);
            lblTamanoInicial.Margin = new Padding(10, 6, 0, 0);
            lblTamanoInicial.Name = "lblTamanoInicial";
            lblTamanoInicial.Size = new Size(86, 15);
            lblTamanoInicial.TabIndex = 0;
            lblTamanoInicial.Text = "Tamaño inicial:";
            // 
            // numTamanoInicial
            // 
            numTamanoInicial.Location = new Point(104, 6);
            numTamanoInicial.Margin = new Padding(3, 2, 3, 2);
            numTamanoInicial.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numTamanoInicial.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTamanoInicial.Name = "numTamanoInicial";
            numTamanoInicial.Size = new Size(61, 23);
            numTamanoInicial.TabIndex = 1;
            numTamanoInicial.ThousandsSeparator = true;
            numTamanoInicial.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnCrearArreglo
            // 
            btnCrearArreglo.AutoSize = true;
            btnCrearArreglo.Location = new Point(171, 6);
            btnCrearArreglo.Margin = new Padding(3, 2, 3, 2);
            btnCrearArreglo.Name = "btnCrearArreglo";
            btnCrearArreglo.Size = new Size(96, 25);
            btnCrearArreglo.TabIndex = 2;
            btnCrearArreglo.Text = "Crear arreglo";
            btnCrearArreglo.UseVisualStyleBackColor = true;
            btnCrearArreglo.Click += btnCrearArreglo_Click;
            // 
            // lblTamanoNuevo
            // 
            lblTamanoNuevo.AutoSize = true;
            lblTamanoNuevo.Location = new Point(280, 10);
            lblTamanoNuevo.Margin = new Padding(10, 6, 0, 0);
            lblTamanoNuevo.Name = "lblTamanoNuevo";
            lblTamanoNuevo.Size = new Size(89, 15);
            lblTamanoNuevo.TabIndex = 3;
            lblTamanoNuevo.Text = "Nuevo tamaño:";
            // 
            // numTamanoNuevo
            // 
            numTamanoNuevo.Location = new Point(372, 6);
            numTamanoNuevo.Margin = new Padding(3, 2, 3, 2);
            numTamanoNuevo.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numTamanoNuevo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTamanoNuevo.Name = "numTamanoNuevo";
            numTamanoNuevo.Size = new Size(61, 23);
            numTamanoNuevo.TabIndex = 4;
            numTamanoNuevo.ThousandsSeparator = true;
            numTamanoNuevo.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // btnRedimensionar
            // 
            btnRedimensionar.AutoSize = true;
            btnRedimensionar.Location = new Point(439, 6);
            btnRedimensionar.Margin = new Padding(3, 2, 3, 2);
            btnRedimensionar.Name = "btnRedimensionar";
            btnRedimensionar.Size = new Size(105, 25);
            btnRedimensionar.TabIndex = 5;
            btnRedimensionar.Text = "Redimensionar";
            btnRedimensionar.UseVisualStyleBackColor = true;
            btnRedimensionar.Click += btnRedimensionar_Click;
            // 
            // btnArregloFijo
            // 
            btnArregloFijo.AutoSize = true;
            btnArregloFijo.Location = new Point(550, 6);
            btnArregloFijo.Margin = new Padding(3, 2, 3, 2);
            btnArregloFijo.Name = "btnArregloFijo";
            btnArregloFijo.Size = new Size(228, 25);
            btnArregloFijo.TabIndex = 6;
            btnArregloFijo.Text = "Memoria estática: arreglo fijo en pila";
            btnArregloFijo.UseVisualStyleBackColor = true;
            btnArregloFijo.Click += btnArregloFijo_Click;
            // 
            // btnCrecimiento
            // 
            btnCrecimiento.AutoSize = true;
            btnCrecimiento.Location = new Point(8, 35);
            btnCrecimiento.Margin = new Padding(3, 2, 3, 2);
            btnCrecimiento.Name = "btnCrecimiento";
            btnCrecimiento.Size = new Size(245, 25);
            btnCrecimiento.TabIndex = 7;
            btnCrecimiento.Text = "Caso de prueba: crecimiento automático";
            btnCrecimiento.UseVisualStyleBackColor = true;
            btnCrecimiento.Click += btnCrecimiento_Click;
            // 
            // btnLimpiarArreglos
            // 
            btnLimpiarArreglos.AutoSize = true;
            btnLimpiarArreglos.Location = new Point(259, 35);
            btnLimpiarArreglos.Margin = new Padding(3, 2, 3, 2);
            btnLimpiarArreglos.Name = "btnLimpiarArreglos";
            btnLimpiarArreglos.Size = new Size(66, 25);
            btnLimpiarArreglos.TabIndex = 8;
            btnLimpiarArreglos.Text = "Limpiar";
            btnLimpiarArreglos.UseVisualStyleBackColor = true;
            btnLimpiarArreglos.Click += btnLimpiarArreglos_Click;
            // 
            // tabDinamica
            // 
            tabDinamica.Controls.Add(txtDinamica);
            tabDinamica.Controls.Add(nodeCanvas);
            tabDinamica.Controls.Add(panelDinamica);
            tabDinamica.Location = new Point(4, 24);
            tabDinamica.Margin = new Padding(3, 2, 3, 2);
            tabDinamica.Name = "tabDinamica";
            tabDinamica.Padding = new Padding(3, 2, 3, 2);
            tabDinamica.Size = new Size(867, 452);
            tabDinamica.TabIndex = 1;
            tabDinamica.Text = "Programa 2: Memoria dinámica (Heap)";
            tabDinamica.UseVisualStyleBackColor = true;
            // 
            // txtDinamica
            // 
            txtDinamica.BackColor = Color.White;
            txtDinamica.Dock = DockStyle.Fill;
            txtDinamica.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDinamica.Location = new Point(3, 278);
            txtDinamica.Margin = new Padding(3, 2, 3, 2);
            txtDinamica.Multiline = true;
            txtDinamica.Name = "txtDinamica";
            txtDinamica.ReadOnly = true;
            txtDinamica.ScrollBars = ScrollBars.Vertical;
            txtDinamica.Size = new Size(861, 172);
            txtDinamica.TabIndex = 0;
            // 
            // nodeCanvas
            // 
            nodeCanvas.BorderStyle = BorderStyle.FixedSingle;
            nodeCanvas.Dock = DockStyle.Top;
            nodeCanvas.Location = new Point(3, 68);
            nodeCanvas.Margin = new Padding(3, 2, 3, 2);
            nodeCanvas.Name = "nodeCanvas";
            nodeCanvas.Size = new Size(861, 210);
            nodeCanvas.TabIndex = 2;
            nodeCanvas.Paint += nodeCanvas_Paint;
            // 
            // panelDinamica
            // 
            panelDinamica.AutoSize = true;
            panelDinamica.Controls.Add(lblNodos);
            panelDinamica.Controls.Add(numNodos);
            panelDinamica.Controls.Add(btnCrearNodos);
            panelDinamica.Controls.Add(btnVerReferencias);
            panelDinamica.Controls.Add(btnEliminarPrimero);
            panelDinamica.Controls.Add(btnValorReferencia);
            panelDinamica.Controls.Add(lblLiberar);
            panelDinamica.Controls.Add(numLiberar);
            panelDinamica.Controls.Add(btnLiberar);
            panelDinamica.Controls.Add(btnCasoLista);
            panelDinamica.Controls.Add(btnLimpiarDinamica);
            panelDinamica.Dock = DockStyle.Top;
            panelDinamica.Location = new Point(3, 2);
            panelDinamica.Margin = new Padding(3, 2, 3, 2);
            panelDinamica.Name = "panelDinamica";
            panelDinamica.Padding = new Padding(5, 4, 5, 4);
            panelDinamica.Size = new Size(861, 66);
            panelDinamica.TabIndex = 1;
            // 
            // lblNodos
            // 
            lblNodos.AutoSize = true;
            lblNodos.Location = new Point(15, 10);
            lblNodos.Margin = new Padding(10, 6, 0, 0);
            lblNodos.Name = "lblNodos";
            lblNodos.Size = new Size(83, 15);
            lblNodos.TabIndex = 0;
            lblNodos.Text = "Nodos a crear:";
            // 
            // numNodos
            // 
            numNodos.Location = new Point(101, 6);
            numNodos.Margin = new Padding(3, 2, 3, 2);
            numNodos.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numNodos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNodos.Name = "numNodos";
            numNodos.Size = new Size(61, 23);
            numNodos.TabIndex = 1;
            numNodos.ThousandsSeparator = true;
            numNodos.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnCrearNodos
            // 
            btnCrearNodos.AutoSize = true;
            btnCrearNodos.Location = new Point(168, 6);
            btnCrearNodos.Margin = new Padding(3, 2, 3, 2);
            btnCrearNodos.Name = "btnCrearNodos";
            btnCrearNodos.Size = new Size(122, 25);
            btnCrearNodos.TabIndex = 2;
            btnCrearNodos.Text = "Crear nodos (new)";
            btnCrearNodos.UseVisualStyleBackColor = true;
            btnCrearNodos.Click += btnCrearNodos_Click;
            // 
            // btnVerReferencias
            // 
            btnVerReferencias.AutoSize = true;
            btnVerReferencias.Location = new Point(296, 6);
            btnVerReferencias.Margin = new Padding(3, 2, 3, 2);
            btnVerReferencias.Name = "btnVerReferencias";
            btnVerReferencias.Size = new Size(114, 25);
            btnVerReferencias.TabIndex = 3;
            btnVerReferencias.Text = "Ver referencias";
            btnVerReferencias.UseVisualStyleBackColor = true;
            btnVerReferencias.Click += btnVerReferencias_Click;
            // 
            // btnEliminarPrimero
            // 
            btnEliminarPrimero.AutoSize = true;
            btnEliminarPrimero.Location = new Point(416, 6);
            btnEliminarPrimero.Margin = new Padding(3, 2, 3, 2);
            btnEliminarPrimero.Name = "btnEliminarPrimero";
            btnEliminarPrimero.Size = new Size(114, 25);
            btnEliminarPrimero.TabIndex = 4;
            btnEliminarPrimero.Text = "Eliminar primero";
            btnEliminarPrimero.UseVisualStyleBackColor = true;
            btnEliminarPrimero.Click += btnEliminarPrimero_Click;
            // 
            // btnValorReferencia
            // 
            btnValorReferencia.AutoSize = true;
            btnValorReferencia.Location = new Point(536, 6);
            btnValorReferencia.Margin = new Padding(3, 2, 3, 2);
            btnValorReferencia.Name = "btnValorReferencia";
            btnValorReferencia.Size = new Size(131, 25);
            btnValorReferencia.TabIndex = 5;
            btnValorReferencia.Text = "Valor vs. referencia";
            btnValorReferencia.UseVisualStyleBackColor = true;
            btnValorReferencia.Click += btnValorReferencia_Click;
            // 
            // lblLiberar
            // 
            lblLiberar.AutoSize = true;
            lblLiberar.Location = new Point(680, 10);
            lblLiberar.Margin = new Padding(10, 6, 0, 0);
            lblLiberar.Name = "lblLiberar";
            lblLiberar.Size = new Size(107, 15);
            lblLiberar.TabIndex = 6;
            lblLiberar.Text = "Nodos para liberar:";
            // 
            // numLiberar
            // 
            numLiberar.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numLiberar.Location = new Point(8, 35);
            numLiberar.Margin = new Padding(3, 2, 3, 2);
            numLiberar.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numLiberar.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numLiberar.Name = "numLiberar";
            numLiberar.Size = new Size(79, 23);
            numLiberar.TabIndex = 7;
            numLiberar.ThousandsSeparator = true;
            numLiberar.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // btnLiberar
            // 
            btnLiberar.AutoSize = true;
            btnLiberar.Location = new Point(93, 35);
            btnLiberar.Margin = new Padding(3, 2, 3, 2);
            btnLiberar.Name = "btnLiberar";
            btnLiberar.Size = new Size(166, 25);
            btnLiberar.TabIndex = 8;
            btnLiberar.Text = "Liberar y recolectar (GC)";
            btnLiberar.UseVisualStyleBackColor = true;
            btnLiberar.Click += btnLiberar_Click;
            // 
            // btnCasoLista
            // 
            btnCasoLista.AutoSize = true;
            btnCasoLista.Location = new Point(265, 35);
            btnCasoLista.Margin = new Padding(3, 2, 3, 2);
            btnCasoLista.Name = "btnCasoLista";
            btnCasoLista.Size = new Size(105, 25);
            btnCasoLista.TabIndex = 9;
            btnCasoLista.Text = "Caso de prueba";
            btnCasoLista.UseVisualStyleBackColor = true;
            btnCasoLista.Click += btnCasoLista_Click;
            // 
            // btnLimpiarDinamica
            // 
            btnLimpiarDinamica.AutoSize = true;
            btnLimpiarDinamica.Location = new Point(376, 35);
            btnLimpiarDinamica.Margin = new Padding(3, 2, 3, 2);
            btnLimpiarDinamica.Name = "btnLimpiarDinamica";
            btnLimpiarDinamica.Size = new Size(66, 25);
            btnLimpiarDinamica.TabIndex = 10;
            btnLimpiarDinamica.Text = "Limpiar";
            btnLimpiarDinamica.UseVisualStyleBackColor = true;
            btnLimpiarDinamica.Click += btnLimpiarDinamica_Click;
            // 
            // tabComparativa
            // 
            tabComparativa.Controls.Add(txtSalida);
            tabComparativa.Controls.Add(tabla);
            tabComparativa.Controls.Add(panelComparativa);
            tabComparativa.Location = new Point(4, 24);
            tabComparativa.Margin = new Padding(3, 2, 3, 2);
            tabComparativa.Name = "tabComparativa";
            tabComparativa.Padding = new Padding(3, 2, 3, 2);
            tabComparativa.Size = new Size(867, 452);
            tabComparativa.TabIndex = 2;
            tabComparativa.Text = "Comparativa y conclusión";
            tabComparativa.UseVisualStyleBackColor = true;
            // 
            // txtSalida
            // 
            txtSalida.BackColor = Color.White;
            txtSalida.Dock = DockStyle.Fill;
            txtSalida.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSalida.Location = new Point(3, 39);
            txtSalida.Margin = new Padding(3, 2, 3, 2);
            txtSalida.Multiline = true;
            txtSalida.Name = "txtSalida";
            txtSalida.ReadOnly = true;
            txtSalida.ScrollBars = ScrollBars.Vertical;
            txtSalida.Size = new Size(861, 283);
            txtSalida.TabIndex = 0;
            // 
            // tabla
            // 
            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabla.Columns.AddRange(new DataGridViewColumn[] { colN, colTiempoVector, colTiempoLista, colMemoriaVector, colMemoriaLista, colCopias });
            tabla.Dock = DockStyle.Bottom;
            tabla.Location = new Point(3, 322);
            tabla.Margin = new Padding(3, 2, 3, 2);
            tabla.Name = "tabla";
            tabla.ReadOnly = true;
            tabla.RowHeadersVisible = false;
            tabla.RowHeadersWidth = 51;
            tabla.Size = new Size(861, 128);
            tabla.TabIndex = 1;
            // 
            // colN
            // 
            colN.HeaderText = "N";
            colN.MinimumWidth = 6;
            colN.Name = "colN";
            colN.ReadOnly = true;
            // 
            // colTiempoVector
            // 
            colTiempoVector.HeaderText = "Inserción vector (ms, mediana)";
            colTiempoVector.MinimumWidth = 6;
            colTiempoVector.Name = "colTiempoVector";
            colTiempoVector.ReadOnly = true;
            // 
            // colTiempoLista
            // 
            colTiempoLista.HeaderText = "Inserción lista (ms, mediana)";
            colTiempoLista.MinimumWidth = 6;
            colTiempoLista.Name = "colTiempoLista";
            colTiempoLista.ReadOnly = true;
            // 
            // colMemoriaVector
            // 
            colMemoriaVector.HeaderText = "Memoria vector (KB)";
            colMemoriaVector.MinimumWidth = 6;
            colMemoriaVector.Name = "colMemoriaVector";
            colMemoriaVector.ReadOnly = true;
            // 
            // colMemoriaLista
            // 
            colMemoriaLista.HeaderText = "Memoria lista (KB)";
            colMemoriaLista.MinimumWidth = 6;
            colMemoriaLista.Name = "colMemoriaLista";
            colMemoriaLista.ReadOnly = true;
            // 
            // colCopias
            // 
            colCopias.HeaderText = "Copias del vector";
            colCopias.MinimumWidth = 6;
            colCopias.Name = "colCopias";
            colCopias.ReadOnly = true;
            // 
            // panelComparativa
            // 
            panelComparativa.AutoSize = true;
            panelComparativa.Controls.Add(btnValidaciones);
            panelComparativa.Controls.Add(lblN);
            panelComparativa.Controls.Add(numElementos);
            panelComparativa.Controls.Add(btnComparar);
            panelComparativa.Controls.Add(lblLecturas);
            panelComparativa.Controls.Add(numAcceso);
            panelComparativa.Controls.Add(btnAcceso);
            panelComparativa.Controls.Add(btnLimpiarComparativa);
            panelComparativa.Dock = DockStyle.Top;
            panelComparativa.Location = new Point(3, 2);
            panelComparativa.Margin = new Padding(3, 2, 3, 2);
            panelComparativa.Name = "panelComparativa";
            panelComparativa.Padding = new Padding(5, 4, 5, 4);
            panelComparativa.Size = new Size(861, 37);
            panelComparativa.TabIndex = 2;
            // 
            // btnValidaciones
            // 
            btnValidaciones.AutoSize = true;
            btnValidaciones.Location = new Point(8, 6);
            btnValidaciones.Margin = new Padding(3, 2, 3, 2);
            btnValidaciones.Name = "btnValidaciones";
            btnValidaciones.Size = new Size(96, 25);
            btnValidaciones.TabIndex = 0;
            btnValidaciones.Text = "Validaciones";
            btnValidaciones.UseVisualStyleBackColor = true;
            btnValidaciones.Click += btnValidaciones_Click;
            // 
            // lblN
            // 
            lblN.AutoSize = true;
            lblN.Location = new Point(117, 10);
            lblN.Margin = new Padding(10, 6, 0, 0);
            lblN.Name = "lblN";
            lblN.Size = new Size(19, 15);
            lblN.TabIndex = 1;
            lblN.Text = "N:";
            // 
            // numElementos
            // 
            numElementos.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numElementos.Location = new Point(139, 6);
            numElementos.Margin = new Padding(3, 2, 3, 2);
            numElementos.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            numElementos.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numElementos.Name = "numElementos";
            numElementos.Size = new Size(79, 23);
            numElementos.TabIndex = 2;
            numElementos.ThousandsSeparator = true;
            numElementos.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // btnComparar
            // 
            btnComparar.AutoSize = true;
            btnComparar.Location = new Point(224, 6);
            btnComparar.Margin = new Padding(3, 2, 3, 2);
            btnComparar.Name = "btnComparar";
            btnComparar.Size = new Size(192, 25);
            btnComparar.TabIndex = 3;
            btnComparar.Text = "Comparar inserción y memoria";
            btnComparar.UseVisualStyleBackColor = true;
            btnComparar.Click += btnComparar_Click;
            // 
            // lblLecturas
            // 
            lblLecturas.AutoSize = true;
            lblLecturas.Location = new Point(429, 10);
            lblLecturas.Margin = new Padding(10, 6, 0, 0);
            lblLecturas.Name = "lblLecturas";
            lblLecturas.Size = new Size(54, 15);
            lblLecturas.TabIndex = 4;
            lblLecturas.Text = "Lecturas:";
            // 
            // numAcceso
            // 
            numAcceso.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numAcceso.Location = new Point(486, 6);
            numAcceso.Margin = new Padding(3, 2, 3, 2);
            numAcceso.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numAcceso.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numAcceso.Name = "numAcceso";
            numAcceso.Size = new Size(70, 23);
            numAcceso.TabIndex = 5;
            numAcceso.ThousandsSeparator = true;
            numAcceso.Value = new decimal(new int[] { 20000, 0, 0, 0 });
            // 
            // btnAcceso
            // 
            btnAcceso.AutoSize = true;
            btnAcceso.Location = new Point(562, 6);
            btnAcceso.Margin = new Padding(3, 2, 3, 2);
            btnAcceso.Name = "btnAcceso";
            btnAcceso.Size = new Size(122, 25);
            btnAcceso.TabIndex = 6;
            btnAcceso.Text = "Acceso por índice";
            btnAcceso.UseVisualStyleBackColor = true;
            btnAcceso.Click += btnAcceso_Click;
            // 
            // btnLimpiarComparativa
            // 
            btnLimpiarComparativa.AutoSize = true;
            btnLimpiarComparativa.Location = new Point(690, 6);
            btnLimpiarComparativa.Margin = new Padding(3, 2, 3, 2);
            btnLimpiarComparativa.Name = "btnLimpiarComparativa";
            btnLimpiarComparativa.Size = new Size(66, 25);
            btnLimpiarComparativa.TabIndex = 7;
            btnLimpiarComparativa.Text = "Limpiar";
            btnLimpiarComparativa.UseVisualStyleBackColor = true;
            btnLimpiarComparativa.Click += btnLimpiarComparativa_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 480);
            Controls.Add(tabControl);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Práctica 1.2: Memoria estática vs. memoria dinámica";
            tabControl.ResumeLayout(false);
            tabArreglos.ResumeLayout(false);
            tabArreglos.PerformLayout();
            panelArreglos.ResumeLayout(false);
            panelArreglos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTamanoInicial).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTamanoNuevo).EndInit();
            tabDinamica.ResumeLayout(false);
            tabDinamica.PerformLayout();
            panelDinamica.ResumeLayout(false);
            panelDinamica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNodos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLiberar).EndInit();
            tabComparativa.ResumeLayout(false);
            tabComparativa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabla).EndInit();
            panelComparativa.ResumeLayout(false);
            panelComparativa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numElementos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAcceso).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabArreglos;
        private FlowLayoutPanel panelArreglos;
        private Label lblTamanoInicial;
        private NumericUpDown numTamanoInicial;
        private Button btnCrearArreglo;
        private Label lblTamanoNuevo;
        private NumericUpDown numTamanoNuevo;
        private Button btnRedimensionar;
        private Button btnArregloFijo;
        private Button btnCrecimiento;
        private Button btnLimpiarArreglos;
        private TextBox txtArreglos;
        private DrawingPanel arrayCanvas;
        private TabPage tabDinamica;
        private FlowLayoutPanel panelDinamica;
        private Label lblNodos;
        private NumericUpDown numNodos;
        private Button btnCrearNodos;
        private Button btnVerReferencias;
        private Button btnEliminarPrimero;
        private Button btnValorReferencia;
        private Label lblLiberar;
        private NumericUpDown numLiberar;
        private Button btnLiberar;
        private Button btnCasoLista;
        private Button btnLimpiarDinamica;
        private TextBox txtDinamica;
        private DrawingPanel nodeCanvas;
        private TabPage tabComparativa;
        private FlowLayoutPanel panelComparativa;
        private Button btnValidaciones;
        private Label lblN;
        private NumericUpDown numElementos;
        private Button btnComparar;
        private Label lblLecturas;
        private NumericUpDown numAcceso;
        private Button btnAcceso;
        private Button btnLimpiarComparativa;
        private TextBox txtSalida;
        private DataGridView tabla;
        private DataGridViewTextBoxColumn colN;
        private DataGridViewTextBoxColumn colTiempoVector;
        private DataGridViewTextBoxColumn colTiempoLista;
        private DataGridViewTextBoxColumn colMemoriaVector;
        private DataGridViewTextBoxColumn colMemoriaLista;
        private DataGridViewTextBoxColumn colCopias;
    }
}