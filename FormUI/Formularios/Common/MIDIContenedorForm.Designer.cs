namespace FormUI.Formularios.Common
{
    partial class MIDIContenedorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIContenedorForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusPedido = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónPersonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prodcutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarVariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gastosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tiposGastosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cierreCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenDiarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoMercaderiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRapido = new System.Windows.Forms.ToolStrip();
            this.tsbNuevaVenta = new System.Windows.Forms.ToolStripButton();
            this.tsbNuevaGasto = new System.Windows.Forms.ToolStripButton();
            this.tsbCierreCaja = new System.Windows.Forms.ToolStripButton();
            this.tsbProductos = new System.Windows.Forms.ToolStripButton();
            this.popupNotifier = new Tulpep.NotificationWindow.PopupNotifier();
            this.tsbIngresos = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.MenuRapido.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusUsuario,
            this.toolStripStatusLabel1,
            this.toolStripStatusPedido});
            this.statusStrip.Location = new System.Drawing.Point(0, 835);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusUsuario
            // 
            this.toolStripStatusUsuario.Image = global::FormUI.Properties.Resources.Usuario_Cuenta;
            this.toolStripStatusUsuario.Name = "toolStripStatusUsuario";
            this.toolStripStatusUsuario.Size = new System.Drawing.Size(181, 21);
            this.toolStripStatusUsuario.Text = "toolStripStatusUsuario";
            this.toolStripStatusUsuario.Click += new System.EventHandler(this.toolStripStatusUsuario_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(14, 21);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusPedido
            // 
            this.toolStripStatusPedido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusPedido.Image = global::FormUI.Properties.Resources.Nota_Pedido_2r;
            this.toolStripStatusPedido.Name = "toolStripStatusPedido";
            this.toolStripStatusPedido.Size = new System.Drawing.Size(174, 21);
            this.toolStripStatusPedido.Text = "toolStripStatusPedido";
            this.toolStripStatusPedido.Click += new System.EventHandler(this.toolStripStatusPedido_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentaToolStripMenuItem,
            this.adminiToolStripMenuItem,
            this.seguridadToolStripMenuItem,
            this.configuracionStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 29);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaciónPersonalToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.cuentaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cuentaToolStripMenuItem.Image = global::FormUI.Properties.Resources.usuario;
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(83, 25);
            this.cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // informaciónPersonalToolStripMenuItem
            // 
            this.informaciónPersonalToolStripMenuItem.Image = global::FormUI.Properties.Resources.Detalle_Pequeno;
            this.informaciónPersonalToolStripMenuItem.Name = "informaciónPersonalToolStripMenuItem";
            this.informaciónPersonalToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.informaciónPersonalToolStripMenuItem.Text = "Información Personal";
            this.informaciónPersonalToolStripMenuItem.Click += new System.EventHandler(this.informaciónPersonalToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Image = global::FormUI.Properties.Resources.desconectado_32;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // adminiToolStripMenuItem
            // 
            this.adminiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prodcutoToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.gastosToolStripMenuItem,
            this.cierreCajaToolStripMenuItem,
            this.ingresoMercaderiaToolStripMenuItem});
            this.adminiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminiToolStripMenuItem.Image = global::FormUI.Properties.Resources.Menu;
            this.adminiToolStripMenuItem.Name = "adminiToolStripMenuItem";
            this.adminiToolStripMenuItem.Size = new System.Drawing.Size(137, 25);
            this.adminiToolStripMenuItem.Text = "Administración";
            // 
            // prodcutoToolStripMenuItem
            // 
            this.prodcutoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarToolStripMenuItem,
            this.cargarVariosToolStripMenuItem,
            this.toolStripSeparator1,
            this.categoriaToolStripMenuItem});
            this.prodcutoToolStripMenuItem.Image = global::FormUI.Properties.Resources.Productos_32;
            this.prodcutoToolStripMenuItem.Name = "prodcutoToolStripMenuItem";
            this.prodcutoToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.prodcutoToolStripMenuItem.Text = "Producto";
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Image = global::FormUI.Properties.Resources.btn_resumen_32;
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.buscarToolStripMenuItem.Text = "Administrar";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.buscarToolStripMenuItem_Click);
            // 
            // cargarVariosToolStripMenuItem
            // 
            this.cargarVariosToolStripMenuItem.Image = global::FormUI.Properties.Resources.bt_Recibo_32;
            this.cargarVariosToolStripMenuItem.Name = "cargarVariosToolStripMenuItem";
            this.cargarVariosToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.cargarVariosToolStripMenuItem.Text = "Cargar Varios";
            this.cargarVariosToolStripMenuItem.Click += new System.EventHandler(this.cargarVariosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.Image = global::FormUI.Properties.Resources.Detalle_Pequeno;
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.categoriaToolStripMenuItem.Text = "Categoria";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.nuevaToolStripMenuItem});
            this.ventaToolStripMenuItem.Image = global::FormUI.Properties.Resources.btn_ventas_32;
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.Image = global::FormUI.Properties.Resources.btn_resumen_32;
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.administrarToolStripMenuItem.Text = "Administrar";
            this.administrarToolStripMenuItem.Click += new System.EventHandler(this.administrarToolStripMenuItem_Click);
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Image = global::FormUI.Properties.Resources.btn_ventas_32;
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.nuevaToolStripMenuItem.Text = "Nueva";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem2});
            this.proveedoresToolStripMenuItem.Image = global::FormUI.Properties.Resources.Proveedores_2;
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // administrarToolStripMenuItem2
            // 
            this.administrarToolStripMenuItem2.Image = global::FormUI.Properties.Resources.btn_resumen_32;
            this.administrarToolStripMenuItem2.Name = "administrarToolStripMenuItem2";
            this.administrarToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.administrarToolStripMenuItem2.Size = new System.Drawing.Size(206, 24);
            this.administrarToolStripMenuItem2.Text = "Administrar";
            this.administrarToolStripMenuItem2.Click += new System.EventHandler(this.administrarToolStripMenuItem2_Click);
            // 
            // gastosToolStripMenuItem
            // 
            this.gastosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem1,
            this.toolStripSeparator2,
            this.tiposGastosToolStripMenuItem});
            this.gastosToolStripMenuItem.Image = global::FormUI.Properties.Resources.bt_Gastos_32;
            this.gastosToolStripMenuItem.Name = "gastosToolStripMenuItem";
            this.gastosToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.gastosToolStripMenuItem.Text = "Gastos";
            // 
            // administrarToolStripMenuItem1
            // 
            this.administrarToolStripMenuItem1.Image = global::FormUI.Properties.Resources.btn_resumen_32;
            this.administrarToolStripMenuItem1.Name = "administrarToolStripMenuItem1";
            this.administrarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.administrarToolStripMenuItem1.Size = new System.Drawing.Size(207, 24);
            this.administrarToolStripMenuItem1.Text = "Administrar";
            this.administrarToolStripMenuItem1.Click += new System.EventHandler(this.administrarToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(204, 6);
            // 
            // tiposGastosToolStripMenuItem
            // 
            this.tiposGastosToolStripMenuItem.Image = global::FormUI.Properties.Resources.Detalle_Pequeno;
            this.tiposGastosToolStripMenuItem.Name = "tiposGastosToolStripMenuItem";
            this.tiposGastosToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.tiposGastosToolStripMenuItem.Text = "Tipos Gastos";
            this.tiposGastosToolStripMenuItem.Click += new System.EventHandler(this.tiposGastosToolStripMenuItem_Click);
            // 
            // cierreCajaToolStripMenuItem
            // 
            this.cierreCajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem3,
            this.resumenDiarioToolStripMenuItem});
            this.cierreCajaToolStripMenuItem.Image = global::FormUI.Properties.Resources.bt_Caja_32;
            this.cierreCajaToolStripMenuItem.Name = "cierreCajaToolStripMenuItem";
            this.cierreCajaToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.cierreCajaToolStripMenuItem.Text = "Cierre Caja";
            // 
            // administrarToolStripMenuItem3
            // 
            this.administrarToolStripMenuItem3.Image = global::FormUI.Properties.Resources.btn_resumen_32;
            this.administrarToolStripMenuItem3.Name = "administrarToolStripMenuItem3";
            this.administrarToolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.administrarToolStripMenuItem3.Size = new System.Drawing.Size(206, 24);
            this.administrarToolStripMenuItem3.Text = "Administrar";
            this.administrarToolStripMenuItem3.Click += new System.EventHandler(this.administrarToolStripMenuItem3_Click);
            // 
            // resumenDiarioToolStripMenuItem
            // 
            this.resumenDiarioToolStripMenuItem.Image = global::FormUI.Properties.Resources.Detalle_Pequeno;
            this.resumenDiarioToolStripMenuItem.Name = "resumenDiarioToolStripMenuItem";
            this.resumenDiarioToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.resumenDiarioToolStripMenuItem.Text = "Resumen Diario";
            this.resumenDiarioToolStripMenuItem.Click += new System.EventHandler(this.resumenDiarioToolStripMenuItem_Click);
            // 
            // ingresoMercaderiaToolStripMenuItem
            // 
            this.ingresoMercaderiaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem4});
            this.ingresoMercaderiaToolStripMenuItem.Image = global::FormUI.Properties.Resources.Stock;
            this.ingresoMercaderiaToolStripMenuItem.Name = "ingresoMercaderiaToolStripMenuItem";
            this.ingresoMercaderiaToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.ingresoMercaderiaToolStripMenuItem.Text = "Ingreso Mercaderia";
            // 
            // administrarToolStripMenuItem4
            // 
            this.administrarToolStripMenuItem4.Image = global::FormUI.Properties.Resources.btn_resumen_32;
            this.administrarToolStripMenuItem4.Name = "administrarToolStripMenuItem4";
            this.administrarToolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.administrarToolStripMenuItem4.Size = new System.Drawing.Size(201, 24);
            this.administrarToolStripMenuItem4.Text = "Administrar";
            this.administrarToolStripMenuItem4.Click += new System.EventHandler(this.administrarToolStripMenuItem4_Click);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.seguridadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.seguridadToolStripMenuItem.Image = global::FormUI.Properties.Resources.btn_CerrarCaja_32;
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.seguridadToolStripMenuItem.Text = "Seguridad";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Image = global::FormUI.Properties.Resources.usuarios;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // configuracionStripMenuItem
            // 
            this.configuracionStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configuracionStripMenuItem.Image = global::FormUI.Properties.Resources.btn_Sistema_32;
            this.configuracionStripMenuItem.Name = "configuracionStripMenuItem";
            this.configuracionStripMenuItem.Size = new System.Drawing.Size(136, 25);
            this.configuracionStripMenuItem.Text = "Configuración";
            this.configuracionStripMenuItem.Click += new System.EventHandler(this.configuracionStripMenuItem_Click);
            // 
            // MenuRapido
            // 
            this.MenuRapido.Dock = System.Windows.Forms.DockStyle.Right;
            this.MenuRapido.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuRapido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevaVenta,
            this.tsbNuevaGasto,
            this.tsbCierreCaja,
            this.tsbProductos,
            this.tsbIngresos});
            this.MenuRapido.Location = new System.Drawing.Point(818, 29);
            this.MenuRapido.Name = "MenuRapido";
            this.MenuRapido.Size = new System.Drawing.Size(66, 806);
            this.MenuRapido.TabIndex = 4;
            this.MenuRapido.Text = "Acesos Rápidos";
            // 
            // tsbNuevaVenta
            // 
            this.tsbNuevaVenta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbNuevaVenta.Image = global::FormUI.Properties.Resources.btn_ventas_32;
            this.tsbNuevaVenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNuevaVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevaVenta.Name = "tsbNuevaVenta";
            this.tsbNuevaVenta.Size = new System.Drawing.Size(63, 49);
            this.tsbNuevaVenta.Text = "Venta";
            this.tsbNuevaVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNuevaVenta.ToolTipText = "Acceso a Venta";
            this.tsbNuevaVenta.Click += new System.EventHandler(this.tsbNuevaVenta_Click);
            // 
            // tsbNuevaGasto
            // 
            this.tsbNuevaGasto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbNuevaGasto.Image = global::FormUI.Properties.Resources.bt_Gastos_32;
            this.tsbNuevaGasto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNuevaGasto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevaGasto.Name = "tsbNuevaGasto";
            this.tsbNuevaGasto.Size = new System.Drawing.Size(63, 49);
            this.tsbNuevaGasto.Text = "Gasto";
            this.tsbNuevaGasto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNuevaGasto.ToolTipText = "Acceso a Gasto";
            this.tsbNuevaGasto.Click += new System.EventHandler(this.tsbNuevaGasto_Click);
            // 
            // tsbCierreCaja
            // 
            this.tsbCierreCaja.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbCierreCaja.Image = global::FormUI.Properties.Resources.bt_Caja_32;
            this.tsbCierreCaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCierreCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCierreCaja.Name = "tsbCierreCaja";
            this.tsbCierreCaja.Size = new System.Drawing.Size(63, 49);
            this.tsbCierreCaja.Text = "Caja";
            this.tsbCierreCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCierreCaja.ToolTipText = "Acceso a Cierre Caja";
            this.tsbCierreCaja.Click += new System.EventHandler(this.tsbCierreCaja_Click);
            // 
            // tsbProductos
            // 
            this.tsbProductos.Image = global::FormUI.Properties.Resources.Productos_32;
            this.tsbProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbProductos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProductos.Name = "tsbProductos";
            this.tsbProductos.Size = new System.Drawing.Size(63, 51);
            this.tsbProductos.Text = "Productos";
            this.tsbProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbProductos.ToolTipText = "Acceso a Productos";
            this.tsbProductos.Click += new System.EventHandler(this.tsbProductos_Click);
            // 
            // popupNotifier
            // 
            this.popupNotifier.ContentFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupNotifier.ContentText = "Tiene {0} ingresos de mercaderia por ingresar.";
            this.popupNotifier.Image = null;
            this.popupNotifier.IsRightToLeft = false;
            this.popupNotifier.OptionsMenu = null;
            this.popupNotifier.Size = new System.Drawing.Size(400, 100);
            this.popupNotifier.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupNotifier.TitleText = "Ingreso Mercaderia";
            this.popupNotifier.Click += new System.EventHandler(this.toolStripStatusPedido_Click);
            // 
            // tsbIngresos
            // 
            this.tsbIngresos.Image = global::FormUI.Properties.Resources.Proveedores_2;
            this.tsbIngresos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbIngresos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIngresos.Name = "tsbIngresos";
            this.tsbIngresos.Size = new System.Drawing.Size(63, 51);
            this.tsbIngresos.Text = "Ingresos";
            this.tsbIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbIngresos.Click += new System.EventHandler(this.tsbIngresos_Click);
            // 
            // MIDIContenedorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.MenuRapido);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MIDIContenedorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MiniPOST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MIDIContenedorForm_FormClosed);
            this.Load += new System.EventHandler(this.MIDIContenedorForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.MenuRapido.ResumeLayout(false);
            this.MenuRapido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem adminiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prodcutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem gastosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tiposGastosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cierreCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem resumenDiarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoMercaderiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónPersonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarVariosToolStripMenuItem;
        private System.Windows.Forms.ToolStrip MenuRapido;
        private System.Windows.Forms.ToolStripButton tsbNuevaVenta;
        private System.Windows.Forms.ToolStripButton tsbNuevaGasto;
        private System.Windows.Forms.ToolStripButton tsbCierreCaja;
        private System.Windows.Forms.ToolStripMenuItem configuracionStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPedido;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier;
        private System.Windows.Forms.ToolStripButton tsbProductos;
        private System.Windows.Forms.ToolStripButton tsbIngresos;
    }
}

