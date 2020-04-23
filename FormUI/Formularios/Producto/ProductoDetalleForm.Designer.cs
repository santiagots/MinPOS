namespace FormUI.Formularios.Producto
{
    partial class ProductoDetalleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductoDetalleForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.proveedoresBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productoDetalleViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.categoriasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAgregarProveedor = new System.Windows.Forms.Button();
            this.proveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEtiquetaGondola = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkSuelto = new FormUI.Controles.SiNo();
            this.chkHabilitado = new FormUI.Controles.SiNo();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoDetalleViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel3.SetRowSpan(this.groupBox1, 4);
            this.groupBox1.Size = new System.Drawing.Size(436, 464);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Producto";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgProveedor, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarProveedor, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkSuelto, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkHabilitado, 1, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 439);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AutoGenerateColumns = false;
            this.dgProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.razonSocialDataGridViewTextBoxColumn,
            this.Eliminar});
            this.dgProveedor.DataSource = this.proveedoresBindingSource1;
            this.dgProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProveedor.Location = new System.Drawing.Point(103, 108);
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            this.dgProveedor.RowHeadersVisible = false;
            this.dgProveedor.ShowCellErrors = false;
            this.dgProveedor.ShowCellToolTips = false;
            this.dgProveedor.ShowEditingIcon = false;
            this.dgProveedor.ShowRowErrors = false;
            this.dgProveedor.Size = new System.Drawing.Size(324, 136);
            this.dgProveedor.TabIndex = 14;
            this.dgProveedor.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_CellMouseClick);
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razón Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = global::FormUI.Properties.Resources.btn_eliminar;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 5;
            // 
            // proveedoresBindingSource1
            // 
            this.proveedoresBindingSource1.DataMember = "Proveedores";
            this.proveedoresBindingSource1.DataSource = this.productoDetalleViewModelBindingSource;
            // 
            // productoDetalleViewModelBindingSource
            // 
            this.productoDetalleViewModelBindingSource.DataSource = typeof(FormUI.Formularios.Producto.ProductoDetalleViewModel);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox1.Location = new System.Drawing.Point(103, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 26);
            this.textBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "Descripcion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox2.Location = new System.Drawing.Point(103, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(324, 26);
            this.textBox2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(3, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Proveedor";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.productoDetalleViewModelBindingSource, "CategoriaSeleccionada", true));
            this.comboBox2.DataSource = this.categoriasBindingSource;
            this.comboBox2.DisplayMember = "Value";
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(103, 73);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(324, 28);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.ValueMember = "Key";
            // 
            // categoriasBindingSource
            // 
            this.categoriasBindingSource.DataMember = "Categorias";
            this.categoriasBindingSource.DataSource = this.productoDetalleViewModelBindingSource;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(3, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Categoria";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(3, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Habilitado";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(3, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Precio";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "Precio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.productoDetalleViewModelBindingSource, "Empaquetado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox6.Location = new System.Drawing.Point(103, 370);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(324, 26);
            this.textBox6.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(3, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Costo";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "Costo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox5.Location = new System.Drawing.Point(103, 335);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(324, 26);
            this.textBox5.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(3, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Suelto";
            // 
            // btnAgregarProveedor
            // 
            this.btnAgregarProveedor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAgregarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProveedor.Image = global::FormUI.Properties.Resources.btn_agregar_241;
            this.btnAgregarProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarProveedor.Location = new System.Drawing.Point(322, 250);
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.Size = new System.Drawing.Size(105, 40);
            this.btnAgregarProveedor.TabIndex = 15;
            this.btnAgregarProveedor.Text = "Agregar Proveedor";
            this.btnAgregarProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarProveedor.UseVisualStyleBackColor = true;
            this.btnAgregarProveedor.Click += new System.EventHandler(this.btnAgregarProveedor_Click);
            // 
            // proveedoresBindingSource
            // 
            this.proveedoresBindingSource.DataMember = "Proveedores";
            this.proveedoresBindingSource.DataSource = this.productoDetalleViewModelBindingSource;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(445, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Stock";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.textBox7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(418, 108);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "StockActual", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.productoDetalleViewModelBindingSource, "Empaquetado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox7.Location = new System.Drawing.Point(103, 76);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(312, 26);
            this.textBox7.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Minimo";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "StockMinimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.productoDetalleViewModelBindingSource, "Empaquetado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox3.Location = new System.Drawing.Point(103, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(312, 26);
            this.textBox3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(3, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Óptimo";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "StockOptimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.productoDetalleViewModelBindingSource, "Empaquetado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox4.Location = new System.Drawing.Point(103, 39);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(312, 26);
            this.textBox4.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(3, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Actual";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = global::FormUI.Properties.Resources.conectado_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(236, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(105, 40);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Guardar";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::FormUI.Properties.Resources.desconectado_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(120, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.73787F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.72816F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.53398F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(884, 470);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(445, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ultima Actualización";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox9, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBox10, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(418, 75);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "Usuario";
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "UsuarioActualizacion", true));
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox9.Location = new System.Drawing.Point(103, 4);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(312, 26);
            this.textBox9.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label13.Location = new System.Drawing.Point(3, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Fecha";
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productoDetalleViewModelBindingSource, "FechaActualizacion", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "g"));
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox10.Location = new System.Drawing.Point(103, 42);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(312, 26);
            this.textBox10.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.btnEtiquetaGondola, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnNuevo, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(537, 421);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(344, 46);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // btnEtiquetaGondola
            // 
            this.btnEtiquetaGondola.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEtiquetaGondola.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtiquetaGondola.Image = global::FormUI.Properties.Resources.icono_imprimir;
            this.btnEtiquetaGondola.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEtiquetaGondola.Location = new System.Drawing.Point(6, 3);
            this.btnEtiquetaGondola.Name = "btnEtiquetaGondola";
            this.btnEtiquetaGondola.Size = new System.Drawing.Size(105, 40);
            this.btnEtiquetaGondola.TabIndex = 2;
            this.btnEtiquetaGondola.Text = "Etiqueta Góndola";
            this.btnEtiquetaGondola.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEtiquetaGondola.UseVisualStyleBackColor = true;
            this.btnEtiquetaGondola.Click += new System.EventHandler(this.btnEtiquetaGondola_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(462, 249);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 159);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // chkSuelto
            // 
            this.chkSuelto.DataBindings.Add(new System.Windows.Forms.Binding("Valor", this.productoDetalleViewModelBindingSource, "Suelto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkSuelto.Location = new System.Drawing.Point(104, 297);
            this.chkSuelto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSuelto.Name = "chkSuelto";
            this.chkSuelto.Size = new System.Drawing.Size(111, 30);
            this.chkSuelto.TabIndex = 16;
            this.chkSuelto.Valor = false;
            this.chkSuelto.CheckedChanged += new System.EventHandler(this.chkSuelto_CheckedChanged);
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.DataBindings.Add(new System.Windows.Forms.Binding("Valor", this.productoDetalleViewModelBindingSource, "Habilitado", true));
            this.chkHabilitado.Location = new System.Drawing.Point(105, 406);
            this.chkHabilitado.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(111, 28);
            this.chkHabilitado.TabIndex = 17;
            this.chkHabilitado.Valor = false;
            // 
            // ProductoDetalleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 470);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductoDetalleForm";
            this.Text = "Producto Detalle";
            this.Load += new System.EventHandler(this.ProductoDetalleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoDetalleViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource productoDetalleViewModelBindingSource;
        private System.Windows.Forms.BindingSource proveedoresBindingSource;
        private System.Windows.Forms.BindingSource categoriasBindingSource;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.DataGridView dgProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource proveedoresBindingSource1;
        private System.Windows.Forms.Button btnAgregarProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.Button btnEtiquetaGondola;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controles.SiNo chkSuelto;
        private Controles.SiNo chkHabilitado;
    }
}