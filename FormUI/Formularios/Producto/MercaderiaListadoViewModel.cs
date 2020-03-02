using Common.Core.Enum;
using Common.Core.Extension;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Producto.Core.Enum;
using Producto.Core.Model;
using Producto.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormUI.Formularios.Producto
{
    class MercaderiaListadoViewModel : CommonViewModel
    {
        public DateTime FechaAlta { get; set; }
        public Boolean FechaAltaFiltroHabilitado { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public Boolean FechaRecepcionFiltroHabilitado { get; set; }
        public KeyValuePair<Proveedor, string> ProveedorSeleccionado { get; set; }
        public List<KeyValuePair<Proveedor, string>> Proveedores { get; set; } = new List<KeyValuePair<Proveedor, string>>();
        public KeyValuePair<MercaderiaEstado?, string> MercaderiaEstadoSeleccionado { get; set; }
        public List<KeyValuePair<MercaderiaEstado?, string>> MercaderiaEstados { get; set; } = new List<KeyValuePair<MercaderiaEstado?, string>>();
        public List<MercaderiaListadoItem> MercaderiaListadoItem { get; set; } = new List<MercaderiaListadoItem>();
        public string OrdenadoPor { get; set; } = "Fecha";
        public DireccionOrdenamiento DireccionOrdenamiento { get; set; }
        public int PaginaActual { get; set; } = 1;
        public int ElementosPorPagina { get; set; }
        public int TotalElementos { get; set; }

        internal async Task BuscarAsync()
        {
            this.MercaderiaListadoItem = new List<MercaderiaListadoItem>();

            DateTime? fechaAlta = FechaAltaFiltroHabilitado ? FechaAlta : (DateTime?) null;
            DateTime? fechaRecepcion = FechaRecepcionFiltroHabilitado ? FechaRecepcion : (DateTime?)null;
            int totalElementos = 0;

            List<Mercaderia> mercaderias = await MercaderiaService.Buscar(fechaAlta, fechaRecepcion, ProveedorSeleccionado.Key, MercaderiaEstadoSeleccionado.Key, OrdenadoPor, DireccionOrdenamiento, PaginaActual, ElementosPorPagina, out totalElementos);
            mercaderias.ForEach(x => MercaderiaListadoItem.Add(new MercaderiaListadoItem(x)));
            TotalElementos = totalElementos;

            NotifyPropertyChanged(nameof(MercaderiaListadoItem));
            NotifyPropertyChanged(nameof(TotalElementos));
        }

        internal async Task ModificarAsync(MercaderiaListadoItem mercaderiaListadoItem)
        {
            Mercaderia mercaderia = await MercaderiaService.Obtener(mercaderiaListadoItem.Mercaderia.Id);
            MercaderiaDetalleForm mercaderiaDetalleForm = new MercaderiaDetalleForm(mercaderia);
            mercaderiaDetalleForm.ShowDialog();
        }

        internal async Task BorrarAsync(MercaderiaListadoItem mercaderiaListadoItem)
        {
            await MercaderiaService.Borrar(mercaderiaListadoItem.Mercaderia);

        }

        internal async Task CargarAsync()
        {
            CargarEstado();
            await CargarProveedorAsync();
        }

        internal void CargarEstado()
        {
            MercaderiaEstados = Enum<MercaderiaEstado>.ToKeyValuePairList().ToList();
            MercaderiaEstados.Insert(0, new KeyValuePair<MercaderiaEstado?, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(MercaderiaEstadoSeleccionado));
        }

        internal async Task CargarProveedorAsync()
        {
            IList<Proveedor> proveedores = await ProveedorService.Buscar(null, true);
            this.Proveedores.AddRange(proveedores.Select(x => new KeyValuePair<Proveedor, string>(x, x.RazonSocial)));
            this.Proveedores.Insert(0, new KeyValuePair<Proveedor, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(Proveedores));
        }

    }
}
