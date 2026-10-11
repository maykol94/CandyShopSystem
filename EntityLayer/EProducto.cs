using System;

namespace EntityLayer
{
    public class EProducto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }
}
