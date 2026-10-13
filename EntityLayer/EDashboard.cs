namespace EntityLayer
{
    public class EDashboard
    {
        // Tarjetas Superiores
        public int TotalClientes { get; set; }
        public int TotalProductos { get; set; }
        public decimal VentasHoy { get; set; }
        public int PedidosPendientes { get; set; }

        // Tarjetas Resumen Inventario
        public int StockDisponible { get; set; }
        public int PorReponer { get; set; }
    }
}