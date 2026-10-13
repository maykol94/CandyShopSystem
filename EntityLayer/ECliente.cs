using System;
using System.Collections.Generic;
using System.Text;

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

        //para mostrar el tipo de cliente en la vista
        public string TipoClienteDescripcion
        {
            get => !string.IsNullOrEmpty(TipoCliente) ? TipoCliente : "";
            set => TipoCliente = value;
        }
    }
}