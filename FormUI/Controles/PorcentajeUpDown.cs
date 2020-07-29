using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace FormUI.Controles
{
    public class PorcentajeUpDown : NumericUpDown
    {
        private static readonly Decimal DefaultValue = new Decimal(0.0);      // 0%
        private static readonly Decimal DefaultMinimum = new Decimal(0.0);    // 0%
        private static readonly Decimal DefaultMaximum = new Decimal(1.0);    // 100%
        private static readonly Decimal DefaultIncrement = new Decimal(0.01); // 1%

        private decimal _Value;
        public new decimal Value {
            get { return _Value; }
            set {
                _Value = value;
                Text = value.ToString(string.Format("p{0}", DecimalPlaces));
            }
        }

        public PorcentajeUpDown()
        {
            Value = DefaultValue;
            Minimum = DefaultMinimum;
            Maximum = DefaultMaximum;
            Increment = DefaultIncrement;
        }

        protected override void UpdateEditText()
        {
            if (UserEdit)
                ParseEditText();

            Text = Value.ToString(string.Format("p{0}", DecimalPlaces));
            this.OnValueChanged(EventArgs.Empty);
        }

        public override void UpButton()
        {
            Value = Constrain(Value + DefaultIncrement);
            UpdateEditText();
        }

        public override void DownButton()
        {
            Value = Constrain(Value - DefaultIncrement);
            UpdateEditText();
        }

        private new void ParseEditText()
        {
            Debug.Assert(UserEdit == true, "ParseEditText() - UserEdit == false");

            try
            {
                if (!string.IsNullOrWhiteSpace(Text) && !(Text.Length == 1 && Text.Equals("-")))
                    Value = Constrain(decimal.Parse(Text.Replace("%", string.Empty), NumberStyles.Any, CultureInfo.CurrentCulture) / (decimal)100);
            }
            catch (Exception ex)
            {
            }
            // Leave value as it is
            finally
            {
                UserEdit = false;
            }
        }

        private Decimal Constrain(Decimal origValue)
        {
            Debug.Assert(Minimum <= Maximum, "minimum > maximum");

            if (origValue < Minimum)
                return Minimum;
            if (origValue > Maximum)
                return Maximum;

            return origValue;
        }

        protected override void OnEnter(EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                this.Select(0, Text.Length);
            });
        }
    }
}

