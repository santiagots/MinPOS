using Common.Core.Enum;
using Common.Core.Extension;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venta.Core.Enum;
using Venta.Data.Service;
using Model = Venta.Core.Model;

namespace FormUI.Formularios.Venta
{
    class VentaListadoViewModel : CommonViewModel
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public KeyValuePair<FormaPago?, string> FormaDePagoSeleccionada { get; set; }
        public List<KeyValuePair<FormaPago?, string>> FormasDePago { get; set; } = new List<KeyValuePair<FormaPago?, string>>();
        public KeyValuePair<bool?, string> AnuladaSeleccionado { get; set; }
        public List<KeyValuePair<bool?, string>> Anulada { get; set; } = new List<KeyValuePair<bool?, string>>();
        public List<VentaListadoItem> VentaListadoItems { get; set; } = new List<VentaListadoItem>();
        public string OrdenadoPor { get; set; } = "FechaAlta";
        public DireccionOrdenamiento DireccionOrdenamiento { get; set; }
        public int PaginaActual { get; set; } = 1;
        public int ElementosPorPagina { get; set; }
        public int TotalElementos { get; set; }

        public VentaListadoViewModel()
        {
            Anulada.Add(new KeyValuePair<bool?, string>(null, "Todos"));
            Anulada.Add(new KeyValuePair<bool?, string>(true, "Si"));
            Anulada.Add(new KeyValuePair<bool?, string>(false, "No"));
        }

        internal async Task BuscarAsync()
        {
            VentaListadoItems.Clear();

            int totalElementos = 0;
            List<Model.Venta> ventas = await VentaService.Buscar(Fecha, FormaDePagoSeleccionada.Key, AnuladaSeleccionado.Key, OrdenadoPor, DireccionOrdenamiento, PaginaActual, ElementosPorPagina, out totalElementos);
            ventas.ForEach(x => VentaListadoItems.Add(new VentaListadoItem(x)));
            TotalElementos = totalElementos;

            NotifyPropertyChanged(nameof(VentaListadoItems));
            NotifyPropertyChanged(nameof(TotalElementos));
        }

        internal void CargarFormasDePago()
        {
            FormasDePago = Enum<FormaPago>.ToKeyValuePairList().ToList();
            FormasDePago.Insert(0, new KeyValuePair<FormaPago?, string>(null, Resources.comboTodos));

            NotifyPropertyChanged(nameof(FormasDePago));
        }

        internal async Task ModificarAsync(VentaListadoItem ventaListadoItem)
        {
            Model.Venta venta = await VentaService.Obtener(ventaListadoItem.Venta.Id);
            VentaDetalleForm ventaDetalleForm = new VentaDetalleForm(venta);
            ventaDetalleForm.ShowDialog();
        }
    }
}
