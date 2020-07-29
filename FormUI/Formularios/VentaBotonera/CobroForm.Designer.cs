namespace FormUI.Formularios.VentaBotonera
{
    partial class CobroForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cobroViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formaPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numeroTextBox1 = new FormUI.Controles.NumeroTextBox();
            this.textBox3 = new FormUI.Controles.NumeroTextBox();
            this.numeroTextBox3 = new FormUI.Controles.NumeroTextBox();
            this.textBox2 = new FormUI.Controles.NumeroTextBox();
            this.porcentajeUpDown1 = new FormUI.Controles.PorcentajeUpDown();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cobroViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.porcentajeUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::FormUI.Properties.Resources.desconectado_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(279, 363);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(175, 55);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Image = global::FormUI.Properties.Resources.conectado_32;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(460, 363);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(135, 55);
            this.btnPagar.TabIndex = 1;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 345);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pagos";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numeroTextBox1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numeroTextBox3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.porcentajeUpDown1, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 308);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monto";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma Pago";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descuento";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.comboBox1, 2);
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.cobroViewModelBindingSource, "FormaPagoSeleccionado", true));
            this.comboBox1.DataSource = this.formaPagosBindingSource;
            this.comboBox1.DisplayMember = "Value";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(214, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(366, 39);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "Key";
            // 
            // cobroViewModelBindingSource
            // 
            this.cobroViewModelBindingSource.DataSource = typeof(FormUI.Formularios.VentaBotonera.CobroViewModel);
            // 
            // formaPagosBindingSource
            // 
            this.formaPagosBindingSource.DataMember = "FormaPagos";
            this.formaPagosBindingSource.DataSource = this.cobroViewModelBindingSource;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 31);
            this.label5.TabIndex = 8;
            this.label5.Text = "Paga Con";
            // 
            // numeroTextBox1
            // 
            this.numeroTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numeroTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.numeroTextBox1.CantidadDecimales = 2;
            this.numeroTextBox1.CantidadEnteros = 9;
            this.tableLayoutPanel1.SetColumnSpan(this.numeroTextBox1, 2);
            this.numeroTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cobroViewModelBindingSource, "Total", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.numeroTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroTextBox1.Location = new System.Drawing.Point(214, 206);
            this.numeroTextBox1.MostrarNullConValorCero = true;
            this.numeroTextBox1.Name = "numeroTextBox1";
            this.numeroTextBox1.PermiteNegativos = false;
            this.numeroTextBox1.ReadOnly = true;
            this.numeroTextBox1.Size = new System.Drawing.Size(366, 38);
            this.numeroTextBox1.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.CantidadDecimales = 2;
            this.textBox3.CantidadEnteros = 9;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cobroViewModelBindingSource, "DescuentoMonto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(214, 106);
            this.textBox3.MostrarNullConValorCero = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.PermiteNegativos = false;
            this.textBox3.Size = new System.Drawing.Size(253, 38);
            this.textBox3.TabIndex = 2;
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // numeroTextBox3
            // 
            this.numeroTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numeroTextBox3.CantidadDecimales = 2;
            this.numeroTextBox3.CantidadEnteros = 9;
            this.tableLayoutPanel1.SetColumnSpan(this.numeroTextBox3, 2);
            this.numeroTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cobroViewModelBindingSource, "PagaCon", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.numeroTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroTextBox3.Location = new System.Drawing.Point(214, 260);
            this.numeroTextBox3.MostrarNullConValorCero = true;
            this.numeroTextBox3.Name = "numeroTextBox3";
            this.numeroTextBox3.PermiteNegativos = false;
            this.numeroTextBox3.Size = new System.Drawing.Size(366, 38);
            this.numeroTextBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.CantidadDecimales = 2;
            this.textBox2.CantidadEnteros = 9;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox2, 2);
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cobroViewModelBindingSource, "SubTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(214, 56);
            this.textBox2.MostrarNullConValorCero = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.PermiteNegativos = false;
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(366, 38);
            this.textBox2.TabIndex = 1;
            // 
            // porcentajeUpDown1
            // 
            this.porcentajeUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.porcentajeUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cobroViewModelBindingSource, "DescuentoPorcentaje", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "p"));
            this.porcentajeUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.porcentajeUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.porcentajeUpDown1.Location = new System.Drawing.Point(473, 106);
            this.porcentajeUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.porcentajeUpDown1.Name = "porcentajeUpDown1";
            this.porcentajeUpDown1.Size = new System.Drawing.Size(107, 38);
            this.porcentajeUpDown1.TabIndex = 9;
            this.porcentajeUpDown1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.porcentajeUpDown1.Leave += new System.EventHandler(this.porcentajeUpDown1_Leave);
            // 
            // CobroForm
            // 
            this.AcceptButton = this.btnPagar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(607, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPagar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CobroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobro";
            this.Load += new System.EventHandler(this.CobroForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cobroViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.porcentajeUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Controles.NumeroTextBox textBox2;
        private System.Windows.Forms.Label label2;
        private Controles.NumeroTextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Controles.NumeroTextBox numeroTextBox1;
        private Controles.NumeroTextBox numeroTextBox3;
        private System.Windows.Forms.BindingSource cobroViewModelBindingSource;
        private System.Windows.Forms.BindingSource formaPagosBindingSource;
        private Controles.PorcentajeUpDown porcentajeUpDown1;
    }
}