using FormUI.Enum;
using FormUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormUI.Formularios.Common
{
    public partial class CustomMessageBox : Form
    {
        private static Font DEFAULT_FONT = new Font("Microsoft Sans Serif", 11);
        private List<Button> Botones = new List<Button>();
        private Button DefaultBoton = null;

        private CustomMessageBox()
        {
            InitializeComponent();
        }

        public static DialogResult ShowDialog(string texto, string titulo, MessageBoxButtons messageBoxButtons, CustomMessageBoxIcon customMessageBoxIcon)
        {
            return ShowDialog(texto, titulo, messageBoxButtons, customMessageBoxIcon, DialogResult.None, DEFAULT_FONT, null);
        }

        public static DialogResult ShowDialog(string texto, string titulo, MessageBoxButtons messageBoxButtons, CustomMessageBoxIcon customMessageBoxIcon, DialogResult defaultButton, Font fuente, int? timeOut)
        {
            CustomMessageBox messageBoxTest = InicializarMessageBox(texto, titulo, fuente);

            messageBoxTest.Botones = messageBoxTest.ObtenerBotones(messageBoxButtons, fuente, defaultButton);
            messageBoxTest.AgregarImagen(customMessageBoxIcon);
            messageBoxTest.AgregarBoton();
            messageBoxTest.PonerFocoEnDefaultButton();

            if (timeOut.HasValue) messageBoxTest.InicializarTimeOut(timeOut.Value);

            return messageBoxTest.ShowDialog();
        }

        private void PonerFocoEnDefaultButton()
        {
            if (DefaultBoton != null)
            {
                DefaultBoton.Select();
                DefaultBoton.Focus();
            }
        }

        private void InicializarTimeOut(int timeOut)
        {
            Timer timer = new Timer();
            timer.Tick += CheckForTime_Elapsed;
            timer.Interval = timeOut;
            timer.Start();
        }

        private void CheckForTime_Elapsed(object sender, EventArgs e)
        {
            if (DefaultBoton != null)
            {
                DefaultBoton.PerformClick();
            }
        }

        private static CustomMessageBox InicializarMessageBox(string texto, string titulo, Font fuente)
        {
            CustomMessageBox messageBoxTest = new CustomMessageBox();
            messageBoxTest.lblMensaje.Text = texto;
            messageBoxTest.lblMensaje.Font = fuente;
            messageBoxTest.Text = titulo;
            return messageBoxTest;
        }

        private void AgregarImagen(CustomMessageBoxIcon customMessageBoxIcon)
        {
            switch (customMessageBoxIcon)
            {
                case CustomMessageBoxIcon.Info: pbIcon.Image = Resources.info; break;
                case CustomMessageBoxIcon.Error: pbIcon.Image = Resources.error; break;
                case CustomMessageBoxIcon.Warning: pbIcon.Image = Resources.warning; break;
                case CustomMessageBoxIcon.Success: pbIcon.Image = Resources.success; break;
                default: throw new InvalidOperationException($"No se encuentra implementado el tipo {customMessageBoxIcon.ToString()}");
            }
        }

        private void AgregarBoton()
        {
            int posicion = 0;
            tlpBotones.ColumnCount = Botones.Count;
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Botones.ForEach(x => tlpBotones.Controls.Add(x, posicion++, 0));
        }

        private List<Button> ObtenerBotones(MessageBoxButtons messageBoxButtons, Font fuente, DialogResult defaultButton)
        {
            List<Button> botones = new List<Button>();

            switch (messageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    botones.Add(ObtenerBoton("Aceptar", AnchorStyles.None, fuente, Ok_Click, defaultButton == DialogResult.OK));
                    break;
                case MessageBoxButtons.YesNo:
                    botones.Add(ObtenerBoton("Si", AnchorStyles.Right, fuente, Yes_Click, defaultButton == DialogResult.Yes));
                    botones.Add(ObtenerBoton("No", AnchorStyles.Left, fuente, No_Click, defaultButton == DialogResult.No));
                    break;
                case MessageBoxButtons.OKCancel:
                    botones.Add(ObtenerBoton("Aceptar", AnchorStyles.Right, fuente, Ok_Click, defaultButton == DialogResult.OK));
                    botones.Add(ObtenerBoton("Cancelar", AnchorStyles.Left, fuente, Cancel_Click, defaultButton == DialogResult.Cancel));
                    break;
                default: throw new InvalidOperationException($"No se encuentra implementado el tipo {messageBoxButtons.ToString()}");
            }
            return botones;
        }

        private Button ObtenerBoton(string texto, AnchorStyles ancla, Font fuente, EventHandler onClick, bool esDefaultButton)
        {
            Button boton = new Button();
            boton.Anchor = ancla;
            boton.AutoSize = true;
            boton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            boton.MinimumSize = new Size(75, 25);
            boton.Font = fuente;
            boton.Text = texto;
            boton.UseVisualStyleBackColor = true;
            boton.Click += onClick;
            if (esDefaultButton)
                DefaultBoton = boton;

            return boton;
        }

        private void Ok_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Yes_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void No_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
