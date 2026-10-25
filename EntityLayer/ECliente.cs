namespace EntityLayer
{
    public class ECliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string NombreNegocio { get; set; }
        public string Contacto { get; set; }
        public string Direccion { get; set; }
        public int IdTipoCliente { get; set; }
        public string TipoCliente { get; set; }
    }

    //DEJAR UNA OPCION DE DESACTIVAR CLIENTE, PARA QUE NO SE ELIMINE DE LA BASE DE DATOS, SOLO SE DESACTIVE Y NO APAREZCA EN LA LISTA DE CLIENTES   
}