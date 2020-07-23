namespace FormUI.Controles
{
    partial class Botonera
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(316, 276);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnterior.BackColor = System.Drawing.Color.Transparent;
            this.btnAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.Image = global::FormUI.Properties.Resources.arrows_left48;
            this.btnAnterior.Location = new System.Drawing.Point(3, 285);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(50, 50);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguente
            // 
            this.btnSiguente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSiguente.BackColor = System.Drawing.Color.Transparent;
            this.btnSiguente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSiguente.FlatAppearance.BorderSize = 0;
            this.btnSiguente.Image = global::FormUI.Properties.Resources.arrows_right48;
            this.btnSiguente.Location = new System.Drawing.Point(59, 285);
            this.btnSiguente.Name = "btnSiguente";
            this.btnSiguente.Size = new System.Drawing.Size(50, 50);
            this.btnSiguente.TabIndex = 2;
            this.btnSiguente.UseVisualStyleBackColor = false;
            this.btnSiguente.Click += new System.EventHandler(this.btnSiguente_Click);
            // 
            // Botonera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSiguente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "Botonera";
            this.Size = new System.Drawing.Size(322, 334);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguente;
    }
}
