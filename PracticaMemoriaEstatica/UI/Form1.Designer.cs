using PracticaU1Act2.UI;

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
            tabArrays = new TabPage();
            txtArrays = new TextBox();
            arrayCanvas = new DrawingPanel();
            panelArrays = new FlowLayoutPanel();
            lblInitialSize = new Label();
            numInitialSize = new NumericUpDown();
            btnCreateArray = new Button();
            lblNewSize = new Label();
            numNewSize = new NumericUpDown();
            btnResize = new Button();
            btnFixedArray = new Button();
            btnGrowthCase = new Button();
            btnClearArrays = new Button();
            tabDynamic = new TabPage();
            txtDynamic = new TextBox();
            nodeCanvas = new DrawingPanel();
            panelDynamic = new FlowLayoutPanel();
            lblNodes = new Label();
            numNodes = new NumericUpDown();
            btnCreateNodes = new Button();
            btnShowReferences = new Button();
            btnRemoveFirst = new Button();
            btnValueVsReference = new Button();
            lblRelease = new Label();
            numRelease = new NumericUpDown();
            btnRelease = new Button();
            btnListCase = new Button();
            btnClearDynamic = new Button();
            tabComparison = new TabPage();
            txtOutput = new TextBox();
            comparisonGrid = new DataGridView();
            colN = new DataGridViewTextBoxColumn();
            colVectorTime = new DataGridViewTextBoxColumn();
            colListTime = new DataGridViewTextBoxColumn();
            colVectorMemory = new DataGridViewTextBoxColumn();
            colListMemory = new DataGridViewTextBoxColumn();
            colCopies = new DataGridViewTextBoxColumn();
            panelComparison = new FlowLayoutPanel();
            btnValidations = new Button();
            lblN = new Label();
            numElements = new NumericUpDown();
            btnCompare = new Button();
            lblReads = new Label();
            numAccess = new NumericUpDown();
            btnAccess = new Button();
            btnClearComparison = new Button();
            tabControl.SuspendLayout();
            tabArrays.SuspendLayout();
            panelArrays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numInitialSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNewSize).BeginInit();
            tabDynamic.SuspendLayout();
            panelDynamic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNodes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRelease).BeginInit();
            tabComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comparisonGrid).BeginInit();
            panelComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numElements).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAccess).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabArrays);
            tabControl.Controls.Add(tabDynamic);
            tabControl.Controls.Add(tabComparison);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(3, 2, 3, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(875, 480);
            tabControl.TabIndex = 0;
            // 
            // tabArrays
            // 
            tabArrays.Controls.Add(txtArrays);
            tabArrays.Controls.Add(arrayCanvas);
            tabArrays.Controls.Add(panelArrays);
            tabArrays.Location = new Point(4, 24);
            tabArrays.Margin = new Padding(3, 2, 3, 2);
            tabArrays.Name = "tabArrays";
            tabArrays.Padding = new Padding(3, 2, 3, 2);
            tabArrays.Size = new Size(867, 452);
            tabArrays.TabIndex = 0;
            tabArrays.Text = "Programa 1: Arreglos en tiempo de ejecución";
            tabArrays.UseVisualStyleBackColor = true;
            // 
            // txtArrays
            // 
            txtArrays.BackColor = Color.White;
            txtArrays.Dock = DockStyle.Fill;
            txtArrays.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtArrays.Location = new Point(3, 269);
            txtArrays.Margin = new Padding(3, 2, 3, 2);
            txtArrays.Multiline = true;
            txtArrays.Name = "txtArrays";
            txtArrays.ReadOnly = true;
            txtArrays.ScrollBars = ScrollBars.Vertical;
            txtArrays.Size = new Size(861, 181);
            txtArrays.TabIndex = 0;
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
            // panelArrays
            // 
            panelArrays.AutoSize = true;
            panelArrays.Controls.Add(lblInitialSize);
            panelArrays.Controls.Add(numInitialSize);
            panelArrays.Controls.Add(btnCreateArray);
            panelArrays.Controls.Add(lblNewSize);
            panelArrays.Controls.Add(numNewSize);
            panelArrays.Controls.Add(btnResize);
            panelArrays.Controls.Add(btnFixedArray);
            panelArrays.Controls.Add(btnGrowthCase);
            panelArrays.Controls.Add(btnClearArrays);
            panelArrays.Dock = DockStyle.Top;
            panelArrays.Location = new Point(3, 2);
            panelArrays.Margin = new Padding(3, 2, 3, 2);
            panelArrays.Name = "panelArrays";
            panelArrays.Padding = new Padding(5, 4, 5, 4);
            panelArrays.Size = new Size(861, 66);
            panelArrays.TabIndex = 1;
            // 
            // lblInitialSize
            // 
            lblInitialSize.AutoSize = true;
            lblInitialSize.Location = new Point(15, 10);
            lblInitialSize.Margin = new Padding(10, 6, 0, 0);
            lblInitialSize.Name = "lblInitialSize";
            lblInitialSize.Size = new Size(86, 15);
            lblInitialSize.TabIndex = 0;
            lblInitialSize.Text = "Tamaño inicial:";
            // 
            // numInitialSize
            // 
            numInitialSize.Location = new Point(104, 6);
            numInitialSize.Margin = new Padding(3, 2, 3, 2);
            numInitialSize.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numInitialSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numInitialSize.Name = "numInitialSize";
            numInitialSize.Size = new Size(61, 23);
            numInitialSize.TabIndex = 1;
            numInitialSize.ThousandsSeparator = true;
            numInitialSize.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnCreateArray
            // 
            btnCreateArray.AutoSize = true;
            btnCreateArray.Location = new Point(171, 6);
            btnCreateArray.Margin = new Padding(3, 2, 3, 2);
            btnCreateArray.Name = "btnCreateArray";
            btnCreateArray.Size = new Size(96, 25);
            btnCreateArray.TabIndex = 2;
            btnCreateArray.Text = "Crear arreglo";
            btnCreateArray.UseVisualStyleBackColor = true;
            btnCreateArray.Click += btnCreateArray_Click;
            // 
            // lblNewSize
            // 
            lblNewSize.AutoSize = true;
            lblNewSize.Location = new Point(280, 10);
            lblNewSize.Margin = new Padding(10, 6, 0, 0);
            lblNewSize.Name = "lblNewSize";
            lblNewSize.Size = new Size(89, 15);
            lblNewSize.TabIndex = 3;
            lblNewSize.Text = "Nuevo tamaño:";
            // 
            // numNewSize
            // 
            numNewSize.Location = new Point(372, 6);
            numNewSize.Margin = new Padding(3, 2, 3, 2);
            numNewSize.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numNewSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNewSize.Name = "numNewSize";
            numNewSize.Size = new Size(61, 23);
            numNewSize.TabIndex = 4;
            numNewSize.ThousandsSeparator = true;
            numNewSize.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // btnResize
            // 
            btnResize.AutoSize = true;
            btnResize.Location = new Point(439, 6);
            btnResize.Margin = new Padding(3, 2, 3, 2);
            btnResize.Name = "btnResize";
            btnResize.Size = new Size(105, 25);
            btnResize.TabIndex = 5;
            btnResize.Text = "Redimensionar";
            btnResize.UseVisualStyleBackColor = true;
            btnResize.Click += btnResize_Click;
            // 
            // btnFixedArray
            // 
            btnFixedArray.AutoSize = true;
            btnFixedArray.Location = new Point(550, 6);
            btnFixedArray.Margin = new Padding(3, 2, 3, 2);
            btnFixedArray.Name = "btnFixedArray";
            btnFixedArray.Size = new Size(228, 25);
            btnFixedArray.TabIndex = 6;
            btnFixedArray.Text = "Memoria estática: arreglo fijo en pila";
            btnFixedArray.UseVisualStyleBackColor = true;
            btnFixedArray.Click += btnFixedArray_Click;
            // 
            // btnGrowthCase
            // 
            btnGrowthCase.AutoSize = true;
            btnGrowthCase.Location = new Point(8, 35);
            btnGrowthCase.Margin = new Padding(3, 2, 3, 2);
            btnGrowthCase.Name = "btnGrowthCase";
            btnGrowthCase.Size = new Size(245, 25);
            btnGrowthCase.TabIndex = 7;
            btnGrowthCase.Text = "Caso de prueba: crecimiento automático";
            btnGrowthCase.UseVisualStyleBackColor = true;
            btnGrowthCase.Click += btnGrowthCase_Click;
            // 
            // btnClearArrays
            // 
            btnClearArrays.AutoSize = true;
            btnClearArrays.Location = new Point(259, 35);
            btnClearArrays.Margin = new Padding(3, 2, 3, 2);
            btnClearArrays.Name = "btnClearArrays";
            btnClearArrays.Size = new Size(66, 25);
            btnClearArrays.TabIndex = 8;
            btnClearArrays.Text = "Limpiar";
            btnClearArrays.UseVisualStyleBackColor = true;
            btnClearArrays.Click += btnClearArrays_Click;
            // 
            // tabDynamic
            // 
            tabDynamic.Controls.Add(txtDynamic);
            tabDynamic.Controls.Add(nodeCanvas);
            tabDynamic.Controls.Add(panelDynamic);
            tabDynamic.Location = new Point(4, 24);
            tabDynamic.Margin = new Padding(3, 2, 3, 2);
            tabDynamic.Name = "tabDynamic";
            tabDynamic.Padding = new Padding(3, 2, 3, 2);
            tabDynamic.Size = new Size(867, 452);
            tabDynamic.TabIndex = 1;
            tabDynamic.Text = "Programa 2: Memoria dinámica (Heap)";
            tabDynamic.UseVisualStyleBackColor = true;
            // 
            // txtDynamic
            // 
            txtDynamic.BackColor = Color.White;
            txtDynamic.Dock = DockStyle.Fill;
            txtDynamic.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDynamic.Location = new Point(3, 278);
            txtDynamic.Margin = new Padding(3, 2, 3, 2);
            txtDynamic.Multiline = true;
            txtDynamic.Name = "txtDynamic";
            txtDynamic.ReadOnly = true;
            txtDynamic.ScrollBars = ScrollBars.Vertical;
            txtDynamic.Size = new Size(861, 172);
            txtDynamic.TabIndex = 0;
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
            // panelDynamic
            // 
            panelDynamic.AutoSize = true;
            panelDynamic.Controls.Add(lblNodes);
            panelDynamic.Controls.Add(numNodes);
            panelDynamic.Controls.Add(btnCreateNodes);
            panelDynamic.Controls.Add(btnShowReferences);
            panelDynamic.Controls.Add(btnRemoveFirst);
            panelDynamic.Controls.Add(btnValueVsReference);
            panelDynamic.Controls.Add(lblRelease);
            panelDynamic.Controls.Add(numRelease);
            panelDynamic.Controls.Add(btnRelease);
            panelDynamic.Controls.Add(btnListCase);
            panelDynamic.Controls.Add(btnClearDynamic);
            panelDynamic.Dock = DockStyle.Top;
            panelDynamic.Location = new Point(3, 2);
            panelDynamic.Margin = new Padding(3, 2, 3, 2);
            panelDynamic.Name = "panelDynamic";
            panelDynamic.Padding = new Padding(5, 4, 5, 4);
            panelDynamic.Size = new Size(861, 66);
            panelDynamic.TabIndex = 1;
            // 
            // lblNodes
            // 
            lblNodes.AutoSize = true;
            lblNodes.Location = new Point(15, 10);
            lblNodes.Margin = new Padding(10, 6, 0, 0);
            lblNodes.Name = "lblNodes";
            lblNodes.Size = new Size(83, 15);
            lblNodes.TabIndex = 0;
            lblNodes.Text = "Nodos a crear:";
            // 
            // numNodes
            // 
            numNodes.Location = new Point(101, 6);
            numNodes.Margin = new Padding(3, 2, 3, 2);
            numNodes.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numNodes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNodes.Name = "numNodes";
            numNodes.Size = new Size(61, 23);
            numNodes.TabIndex = 1;
            numNodes.ThousandsSeparator = true;
            numNodes.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnCreateNodes
            // 
            btnCreateNodes.AutoSize = true;
            btnCreateNodes.Location = new Point(168, 6);
            btnCreateNodes.Margin = new Padding(3, 2, 3, 2);
            btnCreateNodes.Name = "btnCreateNodes";
            btnCreateNodes.Size = new Size(122, 25);
            btnCreateNodes.TabIndex = 2;
            btnCreateNodes.Text = "Crear nodos (new)";
            btnCreateNodes.UseVisualStyleBackColor = true;
            btnCreateNodes.Click += btnCreateNodes_Click;
            // 
            // btnShowReferences
            // 
            btnShowReferences.AutoSize = true;
            btnShowReferences.Location = new Point(296, 6);
            btnShowReferences.Margin = new Padding(3, 2, 3, 2);
            btnShowReferences.Name = "btnShowReferences";
            btnShowReferences.Size = new Size(114, 25);
            btnShowReferences.TabIndex = 3;
            btnShowReferences.Text = "Ver referencias";
            btnShowReferences.UseVisualStyleBackColor = true;
            btnShowReferences.Click += btnShowReferences_Click;
            // 
            // btnRemoveFirst
            // 
            btnRemoveFirst.AutoSize = true;
            btnRemoveFirst.Location = new Point(416, 6);
            btnRemoveFirst.Margin = new Padding(3, 2, 3, 2);
            btnRemoveFirst.Name = "btnRemoveFirst";
            btnRemoveFirst.Size = new Size(114, 25);
            btnRemoveFirst.TabIndex = 4;
            btnRemoveFirst.Text = "Eliminar primero";
            btnRemoveFirst.UseVisualStyleBackColor = true;
            btnRemoveFirst.Click += btnRemoveFirst_Click;
            // 
            // btnValueVsReference
            // 
            btnValueVsReference.AutoSize = true;
            btnValueVsReference.Location = new Point(536, 6);
            btnValueVsReference.Margin = new Padding(3, 2, 3, 2);
            btnValueVsReference.Name = "btnValueVsReference";
            btnValueVsReference.Size = new Size(131, 25);
            btnValueVsReference.TabIndex = 5;
            btnValueVsReference.Text = "Valor vs. referencia";
            btnValueVsReference.UseVisualStyleBackColor = true;
            btnValueVsReference.Click += btnValueVsReference_Click;
            // 
            // lblRelease
            // 
            lblRelease.AutoSize = true;
            lblRelease.Location = new Point(680, 10);
            lblRelease.Margin = new Padding(10, 6, 0, 0);
            lblRelease.Name = "lblRelease";
            lblRelease.Size = new Size(107, 15);
            lblRelease.TabIndex = 6;
            lblRelease.Text = "Nodos para liberar:";
            // 
            // numRelease
            // 
            numRelease.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numRelease.Location = new Point(8, 35);
            numRelease.Margin = new Padding(3, 2, 3, 2);
            numRelease.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numRelease.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numRelease.Name = "numRelease";
            numRelease.Size = new Size(79, 23);
            numRelease.TabIndex = 7;
            numRelease.ThousandsSeparator = true;
            numRelease.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // btnRelease
            // 
            btnRelease.AutoSize = true;
            btnRelease.Location = new Point(93, 35);
            btnRelease.Margin = new Padding(3, 2, 3, 2);
            btnRelease.Name = "btnRelease";
            btnRelease.Size = new Size(166, 25);
            btnRelease.TabIndex = 8;
            btnRelease.Text = "Liberar y recolectar (GC)";
            btnRelease.UseVisualStyleBackColor = true;
            btnRelease.Click += btnRelease_Click;
            // 
            // btnListCase
            // 
            btnListCase.AutoSize = true;
            btnListCase.Location = new Point(265, 35);
            btnListCase.Margin = new Padding(3, 2, 3, 2);
            btnListCase.Name = "btnListCase";
            btnListCase.Size = new Size(105, 25);
            btnListCase.TabIndex = 9;
            btnListCase.Text = "Caso de prueba";
            btnListCase.UseVisualStyleBackColor = true;
            btnListCase.Click += btnListCase_Click;
            // 
            // btnClearDynamic
            // 
            btnClearDynamic.AutoSize = true;
            btnClearDynamic.Location = new Point(376, 35);
            btnClearDynamic.Margin = new Padding(3, 2, 3, 2);
            btnClearDynamic.Name = "btnClearDynamic";
            btnClearDynamic.Size = new Size(66, 25);
            btnClearDynamic.TabIndex = 10;
            btnClearDynamic.Text = "Limpiar";
            btnClearDynamic.UseVisualStyleBackColor = true;
            btnClearDynamic.Click += btnClearDynamic_Click;
            // 
            // tabComparison
            // 
            tabComparison.Controls.Add(txtOutput);
            tabComparison.Controls.Add(comparisonGrid);
            tabComparison.Controls.Add(panelComparison);
            tabComparison.Location = new Point(4, 24);
            tabComparison.Margin = new Padding(3, 2, 3, 2);
            tabComparison.Name = "tabComparison";
            tabComparison.Padding = new Padding(3, 2, 3, 2);
            tabComparison.Size = new Size(867, 452);
            tabComparison.TabIndex = 2;
            tabComparison.Text = "Comparativa y conclusión";
            tabComparison.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = Color.White;
            txtOutput.Dock = DockStyle.Fill;
            txtOutput.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOutput.Location = new Point(3, 39);
            txtOutput.Margin = new Padding(3, 2, 3, 2);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(861, 283);
            txtOutput.TabIndex = 0;
            // 
            // comparisonGrid
            // 
            comparisonGrid.AllowUserToAddRows = false;
            comparisonGrid.AllowUserToDeleteRows = false;
            comparisonGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comparisonGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            comparisonGrid.Columns.AddRange(new DataGridViewColumn[] { colN, colVectorTime, colListTime, colVectorMemory, colListMemory, colCopies });
            comparisonGrid.Dock = DockStyle.Bottom;
            comparisonGrid.Location = new Point(3, 322);
            comparisonGrid.Margin = new Padding(3, 2, 3, 2);
            comparisonGrid.Name = "comparisonGrid";
            comparisonGrid.ReadOnly = true;
            comparisonGrid.RowHeadersVisible = false;
            comparisonGrid.RowHeadersWidth = 51;
            comparisonGrid.Size = new Size(861, 128);
            comparisonGrid.TabIndex = 1;
            // 
            // colN
            // 
            colN.HeaderText = "N";
            colN.MinimumWidth = 6;
            colN.Name = "colN";
            colN.ReadOnly = true;
            // 
            // colVectorTime
            // 
            colVectorTime.HeaderText = "Inserción vector (ms, mediana)";
            colVectorTime.MinimumWidth = 6;
            colVectorTime.Name = "colVectorTime";
            colVectorTime.ReadOnly = true;
            // 
            // colListTime
            // 
            colListTime.HeaderText = "Inserción lista (ms, mediana)";
            colListTime.MinimumWidth = 6;
            colListTime.Name = "colListTime";
            colListTime.ReadOnly = true;
            // 
            // colVectorMemory
            // 
            colVectorMemory.HeaderText = "Memoria vector (KB)";
            colVectorMemory.MinimumWidth = 6;
            colVectorMemory.Name = "colVectorMemory";
            colVectorMemory.ReadOnly = true;
            // 
            // colListMemory
            // 
            colListMemory.HeaderText = "Memoria lista (KB)";
            colListMemory.MinimumWidth = 6;
            colListMemory.Name = "colListMemory";
            colListMemory.ReadOnly = true;
            // 
            // colCopies
            // 
            colCopies.HeaderText = "Copias del vector";
            colCopies.MinimumWidth = 6;
            colCopies.Name = "colCopies";
            colCopies.ReadOnly = true;
            // 
            // panelComparison
            // 
            panelComparison.AutoSize = true;
            panelComparison.Controls.Add(btnValidations);
            panelComparison.Controls.Add(lblN);
            panelComparison.Controls.Add(numElements);
            panelComparison.Controls.Add(btnCompare);
            panelComparison.Controls.Add(lblReads);
            panelComparison.Controls.Add(numAccess);
            panelComparison.Controls.Add(btnAccess);
            panelComparison.Controls.Add(btnClearComparison);
            panelComparison.Dock = DockStyle.Top;
            panelComparison.Location = new Point(3, 2);
            panelComparison.Margin = new Padding(3, 2, 3, 2);
            panelComparison.Name = "panelComparison";
            panelComparison.Padding = new Padding(5, 4, 5, 4);
            panelComparison.Size = new Size(861, 37);
            panelComparison.TabIndex = 2;
            // 
            // btnValidations
            // 
            btnValidations.AutoSize = true;
            btnValidations.Location = new Point(8, 6);
            btnValidations.Margin = new Padding(3, 2, 3, 2);
            btnValidations.Name = "btnValidations";
            btnValidations.Size = new Size(96, 25);
            btnValidations.TabIndex = 0;
            btnValidations.Text = "Validaciones";
            btnValidations.UseVisualStyleBackColor = true;
            btnValidations.Click += btnValidations_Click;
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
            // numElements
            // 
            numElements.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numElements.Location = new Point(139, 6);
            numElements.Margin = new Padding(3, 2, 3, 2);
            numElements.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            numElements.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numElements.Name = "numElements";
            numElements.Size = new Size(79, 23);
            numElements.TabIndex = 2;
            numElements.ThousandsSeparator = true;
            numElements.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // btnCompare
            // 
            btnCompare.AutoSize = true;
            btnCompare.Location = new Point(224, 6);
            btnCompare.Margin = new Padding(3, 2, 3, 2);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(192, 25);
            btnCompare.TabIndex = 3;
            btnCompare.Text = "Comparar inserción y memoria";
            btnCompare.UseVisualStyleBackColor = true;
            btnCompare.Click += btnCompare_Click;
            // 
            // lblReads
            // 
            lblReads.AutoSize = true;
            lblReads.Location = new Point(429, 10);
            lblReads.Margin = new Padding(10, 6, 0, 0);
            lblReads.Name = "lblReads";
            lblReads.Size = new Size(54, 15);
            lblReads.TabIndex = 4;
            lblReads.Text = "Lecturas:";
            // 
            // numAccess
            // 
            numAccess.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numAccess.Location = new Point(486, 6);
            numAccess.Margin = new Padding(3, 2, 3, 2);
            numAccess.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numAccess.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numAccess.Name = "numAccess";
            numAccess.Size = new Size(70, 23);
            numAccess.TabIndex = 5;
            numAccess.ThousandsSeparator = true;
            numAccess.Value = new decimal(new int[] { 20000, 0, 0, 0 });
            // 
            // btnAccess
            // 
            btnAccess.AutoSize = true;
            btnAccess.Location = new Point(562, 6);
            btnAccess.Margin = new Padding(3, 2, 3, 2);
            btnAccess.Name = "btnAccess";
            btnAccess.Size = new Size(122, 25);
            btnAccess.TabIndex = 6;
            btnAccess.Text = "Acceso por índice";
            btnAccess.UseVisualStyleBackColor = true;
            btnAccess.Click += btnAccess_Click;
            // 
            // btnClearComparison
            // 
            btnClearComparison.AutoSize = true;
            btnClearComparison.Location = new Point(690, 6);
            btnClearComparison.Margin = new Padding(3, 2, 3, 2);
            btnClearComparison.Name = "btnClearComparison";
            btnClearComparison.Size = new Size(66, 25);
            btnClearComparison.TabIndex = 7;
            btnClearComparison.Text = "Limpiar";
            btnClearComparison.UseVisualStyleBackColor = true;
            btnClearComparison.Click += btnClearComparison_Click;
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
            tabArrays.ResumeLayout(false);
            tabArrays.PerformLayout();
            panelArrays.ResumeLayout(false);
            panelArrays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numInitialSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNewSize).EndInit();
            tabDynamic.ResumeLayout(false);
            tabDynamic.PerformLayout();
            panelDynamic.ResumeLayout(false);
            panelDynamic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNodes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRelease).EndInit();
            tabComparison.ResumeLayout(false);
            tabComparison.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)comparisonGrid).EndInit();
            panelComparison.ResumeLayout(false);
            panelComparison.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numElements).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAccess).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabArrays;
        private FlowLayoutPanel panelArrays;
        private Label lblInitialSize;
        private NumericUpDown numInitialSize;
        private Button btnCreateArray;
        private Label lblNewSize;
        private NumericUpDown numNewSize;
        private Button btnResize;
        private Button btnFixedArray;
        private Button btnGrowthCase;
        private Button btnClearArrays;
        private TextBox txtArrays;
        private DrawingPanel arrayCanvas;
        private TabPage tabDynamic;
        private FlowLayoutPanel panelDynamic;
        private Label lblNodes;
        private NumericUpDown numNodes;
        private Button btnCreateNodes;
        private Button btnShowReferences;
        private Button btnRemoveFirst;
        private Button btnValueVsReference;
        private Label lblRelease;
        private NumericUpDown numRelease;
        private Button btnRelease;
        private Button btnListCase;
        private Button btnClearDynamic;
        private TextBox txtDynamic;
        private DrawingPanel nodeCanvas;
        private TabPage tabComparison;
        private FlowLayoutPanel panelComparison;
        private Button btnValidations;
        private Label lblN;
        private NumericUpDown numElements;
        private Button btnCompare;
        private Label lblReads;
        private NumericUpDown numAccess;
        private Button btnAccess;
        private Button btnClearComparison;
        private TextBox txtOutput;
        private DataGridView comparisonGrid;
        private DataGridViewTextBoxColumn colN;
        private DataGridViewTextBoxColumn colVectorTime;
        private DataGridViewTextBoxColumn colListTime;
        private DataGridViewTextBoxColumn colVectorMemory;
        private DataGridViewTextBoxColumn colListMemory;
        private DataGridViewTextBoxColumn colCopies;
    }
}