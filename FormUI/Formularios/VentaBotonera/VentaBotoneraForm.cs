using Common.Core.Model;
using FormUI.Enum;
using FormUI.Formularios.Common;
using Producto.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Formularios.VentaBotonera
{
    public partial class VentaBotoneraForm : CommonForm
    {
        private VentaBotoneraViewModel ventaBotoneraViewModel = new VentaBotoneraViewModel();

        public VentaBotoneraForm()
        {
            InitializeComponent();
        }

        private void VentaBotoneraForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                botoneraCategoria.Cargar(ventaBotoneraViewModel.Categorias);
            });
        }

        private void botoneraCategoria_ClickEventHandler(string categoria)
        {
            EjecutarAsync(async () =>
            {
                await ventaBotoneraViewModel.CargarProductosAsync(categoria);
                botoneraProducto.Cargar(ventaBotoneraViewModel.Productos);
            });
        }
    }
}
