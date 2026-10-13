namespace EntityLayer
{
    public class EProveedor
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdEstado { get; set; }

        public EProveedor()
        {
            NombreProveedor = string.Empty;
            Contacto = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            IdEstado = 11; 
        }
    }
}