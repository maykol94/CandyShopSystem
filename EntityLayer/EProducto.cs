namespace EntityLayer
{
    public class EProducto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public int? IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public int IdTipoProducto { get; set; }
        public string NombreTipo { get; set; }
        public int IdEstado { get; set; } = 1;
        public string Estado { get; set; }
    }
}