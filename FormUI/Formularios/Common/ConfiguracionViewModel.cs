using Dispositivos;
using FormUI.Imprimir.Documento;
using FormUI.Properties;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing.Printing;
using Venta.Core.Enum;
using Modelo = Venta.Core.Model;

namespace FormUI.Formularios.Common
{
    class ConfiguracionViewModel : CommonViewModel
    {
        public string NombreSucursal { get; set; }
        public string DireccionSucursal { get; set; }
        public int CantidadElementosPorPagina { get; set; }
        public int AnticipacionAvisoIngresoMercaderia { get; set; }
        public string ImpresoraSeleccionada { get; set; }
        public List<string> Impresoras { get; set; } = new List<string>();
        public string CabeceraTicket { get; set; }
        public string PieTicket { get; set; }
        public string SeparadorTicket { get; set; }
        public int VentaCategoriaNumeroFilas { get; set; }
        public int VentaCategoriaNumeroColumnas { get; set; }
        public int VentaCategoriaProductosFilas { get; set; }
        public int VentaCategoriaProductosColumnas { get; set; }

        public ConfiguracionViewModel()
        {
            NombreSucursal = Settings.Default.NombreFantasia;
            DireccionSucursal = Settings.Default.Direccion;
            CantidadElementosPorPagina = Settings.Default.PaginadoCantidadElementosPorPagina;
            ImpresoraSeleccionada = Settings.Default.ImpresoraNombre;
            CabeceraTicket = Settings.Default.ComprobanteCompraCabecera;
            PieTicket = Settings.Default.ComprobanteCompraPie;
            SeparadorTicket = Settings.Default.ComprobanteCompraSeparador;
            AnticipacionAvisoIngresoMercaderia = Settings.Default.AnticipacionAvisoIngresoMercaderia;
            VentaCategoriaNumeroFilas = Settings.Default.VentaCategoriaNumeroFilas;
            VentaCategoriaNumeroColumnas = Settings.Default.VentaCategoriaNumeroColumnas;
            VentaCategoriaProductosFilas = Settings.Default.VentaCategoriaProductosFilas;
            VentaCategoriaProductosColumnas = Settings.Default.VentaCategoriaProductosColumnas;
        }

        internal void Guardar()
        {
            Settings.Default.NombreFantasia = NombreSucursal;
            Settings.Default.Direccion = DireccionSucursal;
            Settings.Default.PaginadoCantidadElementosPorPagina = CantidadElementosPorPagina;
            Settings.Default.AnticipacionAvisoIngresoMercaderia = AnticipacionAvisoIngresoMercaderia;
            Settings.Default.ImpresoraNombre = ImpresoraSeleccionada;
            Settings.Default.ComprobanteCompraCabecera = CabeceraTicket;
            Settings.Default.ComprobanteCompraPie = PieTicket;
            Settings.Default.ComprobanteCompraSeparador = SeparadorTicket;
            Settings.Default.VentaCategoriaNumeroFilas = VentaCategoriaNumeroFilas;
            Settings.Default.VentaCategoriaNumeroColumnas = VentaCategoriaNumeroColumnas;
            Settings.Default.VentaCategoriaProductosFilas = VentaCategoriaProductosFilas;
            Settings.Default.VentaCategoriaProductosColumnas = VentaCategoriaProductosColumnas;

            Settings.Default.Save();
        }

        internal void CargarImpresoras()
        {
            foreach (String impresora in PrinterSettings.InstalledPrinters)
                Impresoras.Add(impresora);

            NotifyPropertyChanged(nameof(Impresoras));
        }

        internal void PruebaTicket()
        {
            Modelo.Producto productoPrueba = new Modelo.Producto("0123456789", "Producto prueba ticket", false, 100, 1, true);
            List<Modelo.VentaItem> ventaItems = new List<Modelo.VentaItem>();
            ventaItems.Add(new Modelo.VentaItem(productoPrueba, 1, 100));
            ventaItems.Add(new Modelo.VentaItem(productoPrueba, 2, 100));
            ventaItems.Add(new Modelo.VentaItem(productoPrueba, 3, 100));
            ventaItems.Add(new Modelo.VentaItem(productoPrueba, 4, 100));
            Modelo.Pago pago = new Modelo.Pago(FormaPago.Efectivo, 1000, 1200, 0, 0);
            Modelo.Venta venta = new Modelo.Venta("Prueba", 0, ventaItems, pago, 0);

            string[] cabeceras = CabeceraTicket.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] pie = PieTicket.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Ticket ticket = new Ticket(NombreSucursal, DireccionSucursal, SeparadorTicket, cabeceras, pie, venta);

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, ticket);
            impresora.Imprimir();
        }
    }
}
