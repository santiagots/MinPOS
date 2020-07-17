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
        public DateTime FechaAltaDesde { get; set; } = DateTime.Now.AddDays(-7);
        public DateTime FechaAltaHasta { get; set; } = DateTime.Now;
        public Boolean FechaAltaFiltroHabilitado { get; set; } = true;
        public DateTime FechaRecepcionDesde { get; set; } = DateTime.Now;
        public DateTime FechaRecepcionHasta { get; set; } = DateTime.Now.AddDays(7);
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

        public MercaderiaListadoViewModel()
        {
        }

        public MercaderiaListadoViewModel(DateTime fechaRecepcionHasta)
        {
            FechaRecepcionHasta = fechaRecepcionHasta;
            FechaRecepcionFiltroHabilitado = true;
            FechaAltaFiltroHabilitado = false;
            MercaderiaEstadoSeleccionado = new KeyValuePair<MercaderiaEstado?, string>(MercaderiaEstado.Guardada, MercaderiaEstado.Guardada.ToString());
        }

        internal async Task BuscarAsync()
        {
            this.MercaderiaListadoItem = new List<MercaderiaListadoItem>();

            DateTime? fechaAltaDesde = FechaAltaFiltroHabilitado ? FechaAltaDesde : (DateTime?) null;
            DateTime? fechaAltaHasta = FechaAltaFiltroHabilitado ? FechaAltaHasta : (DateTime?) null;
            DateTime? fechaRecepcionDesde = FechaRecepcionFiltroHabilitado ? FechaRecepcionDesde : (DateTime?) null;
            DateTime? fechaRecepcionHasta = FechaRecepcionFiltroHabilitado ? FechaRecepcionHasta : (DateTime?) null;
            int totalElementos = 0;

            List<Mercaderia> mercaderias = await MercaderiaService.Buscar(fechaAltaDesde, fechaAltaHasta, fechaRecepcionDesde, fechaRecepcionHasta, ProveedorSeleccionado.Key, MercaderiaEstadoSeleccionado.Key, OrdenadoPor, DireccionOrdenamiento, PaginaActual, ElementosPorPagina, out totalElementos);
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
            MercaderiaEstados = Enum<MercaderiaEstado>.ToKeyValuePairList().Where(x => x.Key != MercaderiaEstado.Nuevo).ToList();
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
