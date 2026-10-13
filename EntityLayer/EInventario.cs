namespace EntityLayer
{
    public class EInventario
    {
        public int IdStock { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string Estado { get; set; } 
    }
}