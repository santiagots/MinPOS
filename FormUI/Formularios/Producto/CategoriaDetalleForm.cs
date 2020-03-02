using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Producto.Core.Model;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Producto
{
    public partial class CategoriaDetalleForm : CommonForm
    {
        private CategoriaDetalleViewModel categoriaDetalleViewModel = new CategoriaDetalleViewModel();
        public CategoriaDetalleForm()
        {
            InitializeComponent();
        }

        public CategoriaDetalleForm(Categoria categoria) : this()
        {
            categoriaDetalleViewModel = new CategoriaDetalleViewModel(categoria);
        }

        private void CategoriaDetalleForm_Load(object sender, EventArgs e)
        {
            categoriaDetalleViewModelBindingSource.DataSource = categoriaDetalleViewModel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await categoriaDetalleViewModel.Guardar();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                Close();
            });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
