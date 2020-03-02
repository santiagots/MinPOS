using FormUI.Formularios.Common;
using Modelo = Producto.Core.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FormUI.Properties;
using System.Drawing;
using Producto.Core.Model;
using FormUI.Enum;

namespace FormUI.Formularios.Producto
{
    public partial class MercaderiaDetalleForm : CommonForm
    {
        MercaderiaDetalleViewModel mercaderiaDetalleViewModel = new MercaderiaDetalleViewModel();

        public MercaderiaDetalleForm()
        {
            InitializeComponent();
        }

        public MercaderiaDetalleForm(List<Modelo.Producto> productos, Modelo.Proveedor proveedor) : this()
        {
            mercaderiaDetalleViewModel = new MercaderiaDetalleViewModel(productos, proveedor);
        }

        public MercaderiaDetalleForm(Mercaderia mercaderia) : this()
        {
            mercaderiaDetalleViewModel = new MercaderiaDetalleViewModel(mercaderia);
        }

        private void MercaderiaDetalleForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                mercaderiaDetalleViewModelBindingSource.DataSource = mercaderiaDetalleViewModel;
                await mercaderiaDetalleViewModel.CargarAsync();
            });
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await mercaderiaDetalleViewModel.IngresarAsync();
                CustomMessageBox.ShowDialog(Resources.ingresoMercaderiaOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                Close();
            });
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await mercaderiaDetalleViewModel.GuardarAsync();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                Close();
            });
        }

        private void cbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                KeyValuePair<Modelo.Proveedor, string> valorSeleccionado = (KeyValuePair<Modelo.Proveedor, string>)cbProveedores.SelectedItem;
                if (mercaderiaDetalleViewModel.ProveedorSeleccionado.Key != valorSeleccionado.Key)
                {
                    mercaderiaDetalleViewModel.ProveedorSeleccionado = valorSeleccionado;
                    await mercaderiaDetalleViewModel.CargarAutocompletadoAsync();
                    mercaderiaDetalleViewModel.LimpiarGrilla();
                }
            });
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await mercaderiaDetalleViewModel.AgregarAsync();
            });
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.KeyCode == Keys.Enter)
                    await mercaderiaDetalleViewModel.AgregarAsync();
            });
        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                MercaderiaDetalleItem mercaderiaDetalleItem = (MercaderiaDetalleItem)dgProductos.CurrentRow.DataBoundItem;

                if (dgProductos.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await mercaderiaDetalleViewModel.ModificarAsync(mercaderiaDetalleItem);
                }
                if (dgProductos.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.quitarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                        mercaderiaDetalleViewModel.Borrar(mercaderiaDetalleItem);
                }
            });
        }

        private void dgProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                MercaderiaDetalleItem mercaderiaDetalleItem = (MercaderiaDetalleItem)dgProductos.CurrentRow.DataBoundItem;
                await mercaderiaDetalleViewModel.ModificarAsync(mercaderiaDetalleItem);
            });
        }

        private void dgProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnCantidad_KeyPress);
            if (dgProductos.Columns[dgProductos.CurrentCell.ColumnIndex].Name == "Cantidad")
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(ColumnCantidad_KeyPress);
                }
            }

            e.CellStyle.BackColor = Color.Coral;
            e.CellStyle.ForeColor = Color.White;
            e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold);
        }

        private void ColumnCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void dgProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            mercaderiaDetalleViewModel.Actualizar();
        }
    }
}
