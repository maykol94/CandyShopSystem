namespace EntityLayer
{
    public class EFactura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdTrabajador { get; set; }
        public string FormaPago { get; set; }
        public decimal DescuentoFactura { get; set; }
        public decimal MontoTotal { get; set; }
    }
}