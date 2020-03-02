namespace Model
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Proveedor { get; set; }
        public bool Suelto { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public bool Habilitado { get; set; }
        public int StockMinimo { get; set; }
        public int StockOptimo { get; set; }
        public int StockActual { get; set; }
    }
}
