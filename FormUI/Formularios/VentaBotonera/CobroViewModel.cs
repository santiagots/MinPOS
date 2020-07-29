using Common.Core.Exception;
using Common.Core.Extension;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venta.Core.Enum;

namespace FormUI.Formularios.VentaBotonera
{
    class CobroViewModel : CommonViewModel
    {
        public KeyValuePair<FormaPago?, string> FormaPagoSeleccionado { get; set; } = new KeyValuePair<FormaPago?, string>(FormaPago.Efectivo, FormaPago.Efectivo.ToString());
        public List<KeyValuePair<FormaPago?, string>> FormaPagos { get; set; } = new List<KeyValuePair<FormaPago?, string>>();
        public decimal SubTotal { get; private set; }
        private decimal _DescuentoMonto;
        public decimal DescuentoMonto 
        { 
            get { return _DescuentoMonto; }
            set {
                if (SubTotal >= value)
                    _DescuentoMonto = value;
                else
                    _DescuentoMonto = SubTotal;
                }
        }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal Total => SubTotal - DescuentoMonto;
        public decimal PagaCon { get; set; }

        public CobroViewModel(decimal totalACobrar)
        {
            SubTotal = totalACobrar;
        }

        internal void ActualizarPorcentajeDescuento()
        {

            decimal porcentaje = DescuentoMonto / SubTotal;
            if (porcentaje >= 0 && porcentaje <= 1)
            {
                DescuentoPorcentaje = porcentaje;
                NotifyPropertyChanged(nameof(DescuentoPorcentaje));
            }
        }

        internal void ActualizarMontoDescuento()
        {
            decimal monto = SubTotal * DescuentoPorcentaje;
            if (monto >= 0 && monto <= SubTotal)
            {
                DescuentoMonto = monto;
                NotifyPropertyChanged(nameof(DescuentoMonto));
            }
        }

        internal bool CobroValido()
        {
            if (PagaCon >= Total)
                return true;
            else
                throw new NegocioException($"El monto ingresado es menor al total de la venta. Por favor ingrese un monto igual o mayor a {Total.ToString("c2")}");
        }

        internal void CargarFormasDePago()
        {
            FormaPagos = Enum<FormaPago>.ToKeyValuePairList().ToList();
            FormaPagos.Insert(0, new KeyValuePair<FormaPago?, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(FormaPagos));
        }


    }
}
