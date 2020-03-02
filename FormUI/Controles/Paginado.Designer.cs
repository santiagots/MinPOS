namespace FormUI.Controles
{
    partial class Paginado
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPaginaInical = new System.Windows.Forms.ToolStripButton();
            this.btnPaginaAnterior = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbTotalPaginas = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPaginaSiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnPaginaFinal = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPaginaInical,
            this.btnPaginaAnterior,
            this.toolStripSeparator1,
            this.lbTotalPaginas,
            this.toolStripSeparator2,
            this.btnPaginaSiguiente,
            this.btnPaginaFinal});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(282, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPaginaInical
            // 
            this.btnPaginaInical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaginaInical.Image = global::FormUI.Properties.Resources.NavigatorFirstItem;
            this.btnPaginaInical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaginaInical.Name = "btnPaginaInical";
            this.btnPaginaInical.Size = new System.Drawing.Size(23, 24);
            this.btnPaginaInical.Text = "btnPaginaInicalClick";
            this.btnPaginaInical.ToolTipText = "Primer Pagina";
            this.btnPaginaInical.Click += new System.EventHandler(this.btnPaginaInical_Click);
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaginaAnterior.Image = global::FormUI.Properties.Resources.NavigatorPreviousItem;
            this.btnPaginaAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(23, 24);
            this.btnPaginaAnterior.Text = "toolStripButton2";
            this.btnPaginaAnterior.ToolTipText = "Pagina Anterior";
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // lbTotalPaginas
            // 
            this.lbTotalPaginas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPaginas.Name = "lbTotalPaginas";
            this.lbTotalPaginas.Size = new System.Drawing.Size(70, 24);
            this.lbTotalPaginas.Text = "{0} de {1}";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnPaginaSiguiente
            // 
            this.btnPaginaSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaginaSiguiente.Image = global::FormUI.Properties.Resources.NavigatorNextItem;
            this.btnPaginaSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(23, 24);
            this.btnPaginaSiguiente.Text = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.ToolTipText = "Siguiente Pagina";
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            // 
            // btnPaginaFinal
            // 
            this.btnPaginaFinal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaginaFinal.Image = global::FormUI.Properties.Resources.NavigatorLastItem;
            this.btnPaginaFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaginaFinal.Name = "btnPaginaFinal";
            this.btnPaginaFinal.Size = new System.Drawing.Size(23, 24);
            this.btnPaginaFinal.Text = "toolStripButton4";
            this.btnPaginaFinal.ToolTipText = "Ultima Pagina";
            this.btnPaginaFinal.Click += new System.EventHandler(this.btnPaginaFinal_Click);
            // 
            // Paginado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "Paginado";
            this.Size = new System.Drawing.Size(282, 27);
            this.Load += new System.EventHandler(this.Paginado_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPaginaInical;
        private System.Windows.Forms.ToolStripButton btnPaginaAnterior;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbTotalPaginas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPaginaSiguiente;
        private System.Windows.Forms.ToolStripButton btnPaginaFinal;
    }
}
