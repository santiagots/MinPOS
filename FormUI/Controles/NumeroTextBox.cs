using Common.Core.Helper;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace FormUI.Controles
{
    public class NumeroTextBox : TextBox
    {
        private static char SeparadorDecimales = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        private bool TeclaBorrado = false;

        /// <summary>
        /// Indica los lugares totales para valores decimales.
        /// </summary>
        public int CantidadDecimales { get; set; } = 2;


        /// <summary>
        /// Indica si se permiten numero negativos.
        /// </summary>
        public bool PermiteNegativos { get; set; } = true;

        public bool MostrarNullConValorCero { get; set; } = true;

        private string TextoSinSeleccionar => SelectedText.Length > 0? Text.Replace(SelectedText, string.Empty) : Text;

        private decimal Value()
        {
            decimal value = 0;
            
            if (!Decimal.TryParse(Text, NumberStyles.Currency, Thread.CurrentThread.CurrentCulture, out value))
                Decimal.TryParse(Text, out value);
            
            return value;
        }

        private bool AceptaDecimales(char caracter)
        {
            if (caracter == SeparadorDecimales && CantidadDecimales == 0)
                return false;

            string textoSinFormato = Value().ToString();
            textoSinFormato += caracter;

            int totalDecimalesTextoSeleccionado = ObtenerCantidadDecimales(SelectedText);

            int totalDecimalesTexto = ObtenerCantidadDecimales(textoSinFormato);

            return totalDecimalesTexto - totalDecimalesTextoSeleccionado <= CantidadDecimales;
        }

        private int ObtenerCantidadDecimales(string texto)
        {
            int indiceInicianDecimales = texto.IndexOf(SeparadorDecimales);
            if (indiceInicianDecimales == -1) 
                return 0;
            else 
                return texto.Substring(indiceInicianDecimales + 1).Length;
        }

        private bool EsDigitoValido(char caracter)
        {
            if (TextoSinSeleccionar.Length == 0 && caracter == '-' && PermiteNegativos)
                return true;

            if(EsSeparadorDecimales(caracter) && !TextoSinSeleccionar.Contains(SeparadorDecimales.ToString()))
                return true;

            return EsNumero(caracter);
        }

        private bool EsNumero(char caracter)
        {
            return Char.IsDigit(caracter);
        }

        private bool EsSeparadorDecimales(char caracter)
        {
            return caracter == SeparadorDecimales;
        }

        //private string _text;
        //public override string Text
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_text) && MostrarNullConValorCero)
        //            _text = "0";
        //        return _text;

        //    }
        //    set
        //    {
        //        _text = value;
        //    }
        //}

        protected override void OnGotFocus(EventArgs e)
        {
            Text = Value().ToString();
            SelectAll();
            base.OnGotFocus(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
            {
                TeclaBorrado = true;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
            {
                TeclaBorrado = false;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (EsDigitoValido(e.KeyChar) && AceptaDecimales(e.KeyChar))
            {
                //Lo hago asi porque es mas facil de leer el if
            }
            else
            {
                if (!TeclaBorrado)
                    e.Handled = true;

            }

            base.OnKeyPress(e);
        }
    }
}
