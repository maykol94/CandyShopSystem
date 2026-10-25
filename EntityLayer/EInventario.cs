namespace EntityLayer
{
    public class EInventario
    {
        public int IdStock { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string FechaIngreso { get; set; }
        public int DiasAlerta { get; set; }
        public string Estado { get; set; }
    }
}