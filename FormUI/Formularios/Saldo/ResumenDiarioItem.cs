namespace FormUI.Formularios.Saldo
{
    class ResumenDiarioItem
    {
        public int Id { get; internal set; }
        public bool ModificaCaja { get; internal set; }
        public string Concepto { get; internal set; }
        public decimal Monto { get; internal set; }

        public ResumenDiarioItem(int id, bool modificaCaja, string concepto, decimal monto)
        {
            Id = id;
            ModificaCaja = modificaCaja;
            Concepto = concepto;
            Monto = monto;
        }
    }
}
