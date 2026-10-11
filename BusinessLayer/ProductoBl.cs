using System;
using System.Collections.Generic;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ProductoBL
    {
        private ProductoDal objProductoDal = new ProductoDal();

        public List<EProducto> ObtenerProductos()
        {
            return objProductoDal.ObtenerProductos();
        }

        public bool RegistrarProducto(EProducto obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.NombreProducto))
            {
                mensaje = "Debe ingresar el nombre del dulce o producto.";
                return false;
            }

            return objProductoDal.RegistrarProducto(obj, out mensaje);
        }
    }
}
