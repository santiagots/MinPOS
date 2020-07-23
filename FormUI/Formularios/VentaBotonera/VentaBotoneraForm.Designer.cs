namespace FormUI.Formularios.VentaBotonera
{
    partial class VentaBotoneraForm
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
            this.botoneraCategoria = new FormUI.Controles.Botonera();
            this.botoneraProducto = new FormUI.Controles.Botonera();
            this.SuspendLayout();
            // 
            // botoneraCategoria
            // 
            this.botoneraCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.botoneraCategoria.BotonSize = new System.Drawing.Size(90, 90);
            this.botoneraCategoria.FuenteBoton = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.botoneraCategoria.Location = new System.Drawing.Point(12, 12);
            this.botoneraCategoria.Name = "botoneraCategoria";
            this.botoneraCategoria.Size = new System.Drawing.Size(236, 431);
            this.botoneraCategoria.TabIndex = 6;
            this.botoneraCategoria.ClickEventHandler += new System.Action<string>(this.botoneraCategoria_ClickEventHandler);
            // 
            // botoneraProducto
            // 
            this.botoneraProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.botoneraProducto.BotonSize = new System.Drawing.Size(90, 90);
            this.botoneraProducto.FuenteBoton = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.botoneraProducto.Location = new System.Drawing.Point(254, 12);
            this.botoneraProducto.Name = "botoneraProducto";
            this.botoneraProducto.Size = new System.Drawing.Size(236, 431);
            this.botoneraProducto.TabIndex = 7;
            // 
            // VentaBotoneraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.botoneraProducto);
            this.Controls.Add(this.botoneraCategoria);
            this.Name = "VentaBotoneraForm";
            this.Text = "VentaBotoneraForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VentaBotoneraForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Controles.Botonera botoneraCategoria;
        private Controles.Botonera botoneraProducto;
    }
}