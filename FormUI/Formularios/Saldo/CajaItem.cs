namespace FormUI.Formularios.Saldo
{
    class CajaItem
    {
        public string Concepto { get; internal set; }
        public decimal Monto { get; internal set; }

        public CajaItem(string concepto, decimal monto)
        {
            Concepto = concepto;
            Monto = monto;
        }
    }
}
