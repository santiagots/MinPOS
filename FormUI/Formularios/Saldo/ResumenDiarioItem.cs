namespace FormUI.Formularios.Saldo
{
    class ResumenDiarioItem
    {
        public int Id { get; internal set; }
        public string Concepto { get; internal set; }
        public decimal Monto { get; internal set; }

        public ResumenDiarioItem(int id, string concepto, decimal monto)
        {
            Id = id;
            Concepto = concepto;
            Monto = monto;
        }
    }
}
