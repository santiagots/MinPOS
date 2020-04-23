using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FormUI.Controles
{
    [DefaultBindingProperty("Valor")]
    public partial class SiNo : UserControl, INotifyPropertyChanged
    {
        public event EventHandler CheckedChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool Valor
        {
            get { return rbSi.Checked; }
            set { rbSi.Checked = value; rbNo.Checked = !value; NotifyPropertyChanged(nameof(Valor)); }
        }

        public SiNo()
        {
            InitializeComponent();
        }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        internal void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            Valor = rbSi.Checked;
            CheckedChanged?.Invoke(sender, e);
        }
    }
}
