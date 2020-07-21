using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace FormUI.Formularios.Venta
{
    public partial class VentaForm : CommonForm
    {
        private VentaViewModel ventaViewModel = new VentaViewModel();
        public VentaForm()
        {
            InitializeComponent();
        }

        private void VentaForm_Load(object sender, System.EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaViewModelBindingSource.DataSource = ventaViewModel;
                this.WindowState = FormWindowState.Maximized;
                await ventaViewModel.CargarAutocompletadoAsync();
            });
        }

        private void btnCobrar_Click(object sender, System.EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaViewModelBindingSource.DataSource = ventaViewModel;
                await ventaViewModel.GuardarAsyn();
            });
        }

        private void txtCodigoDescirpcion_KeyDown(object sender, KeyEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    await ventaViewModel.AgregarAsync();
                    dgProductos.FirstDisplayedScrollingRowIndex = dgProductos.RowCount - 1;
                }
            });
        }

        private void btnAgregarProducto_Click(object sender, System.EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await ventaViewModel.AgregarAsync();
                dgProductos.FirstDisplayedScrollingRowIndex = dgProductos.RowCount - 1;
            });
        }

        private void dgProductos_CellMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            Ejecutar(() =>
            {
                if (e.RowIndex < 0)
                    return;

                VentaItem ventaItems = (VentaItem)dgProductos.CurrentRow.DataBoundItem;
                if (dgProductos.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.quitarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                    {
                        ventaViewModel.Quitar(ventaItems);
                    }
                }
            });
        }

        private void dgProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoDescirpcion.Focus();
            ventaViewModelBindingSource.ResetBindings(false);
        }

        private void VentaForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!txtCodigoDescirpcion.Focused && dgProductos.IsCurrentCellInEditMode && char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //    return;
            //}

            //if (!txtCodigoDescirpcion.Focused && (char.IsLetterOrDigit(e.KeyChar) || char.IsSeparator(e.KeyChar)))
            //{
            //    txtCodigoDescirpcion.Text += e.KeyChar.ToString();
            //    txtCodigoDescirpcion.SelectionStart = txtCodigoDescirpcion.Text.Length;
            //    txtCodigoDescirpcion.Focus();
            //    e.Handled = false;
            //    return;
            //}
        }

        private void VentaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtCodigoDescirpcion.AutoCompleteShowing &&
                (e.KeyCode == Keys.Down ||
                 e.KeyCode == Keys.Up ||
                 e.KeyCode == Keys.Left ||
                 e.KeyCode == Keys.Right))
            {
                dgProductos.Focus();
                int RowSeleccionada = dgProductos.SelectedRows[0].Index;
                if (e.KeyCode == Keys.Up && RowSeleccionada > 0)
                {
                    dgProductos.ClearSelection();
                    dgProductos.Rows[RowSeleccionada - 1].Selected = true;
                }
                if (e.KeyCode == Keys.Down && RowSeleccionada < dgProductos.Rows.Count - 1)
                {
                    dgProductos.ClearSelection();
                    dgProductos.Rows[RowSeleccionada + 1].Selected = true;
                }
            }

            if (e.KeyCode == Keys.Escape && dgProductos.CurrentRow != null)
            {
                VentaItem ventaItems = (VentaItem)dgProductos.CurrentRow.DataBoundItem;
                if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.quitarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                {
                    ventaViewModel.Quitar(ventaItems);
                }
            }

            if (e.KeyCode == Keys.F12)
            {
                btnCobrar.PerformClick();
            }
        }

        private void dgProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Red;
            e.CellStyle.ForeColor = Color.White;
            e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold);
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
