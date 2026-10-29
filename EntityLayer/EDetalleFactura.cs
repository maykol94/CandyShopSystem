namespace EntityLayer
{
    public class EDetalleFactura
    {
        public int IdStock { get; set; }
        public int IdVariacion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal DescuentoUnitario { get; set; }
    }
}