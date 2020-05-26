namespace FormUI.Formularios.Saldo
{
    class ResumenDiarioItem
    {
        public string Concepto { get; internal set; }
        public decimal Monto { get; internal set; }

        public ResumenDiarioItem(string concepto, decimal monto)
        {
            Concepto = concepto;
            Monto = monto;
        }
    }
}
