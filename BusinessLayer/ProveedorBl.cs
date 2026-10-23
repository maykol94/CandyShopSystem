using System.Collections.Generic;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ProveedorBl
    {
        private ProveedorDal objProveedorDal = new ProveedorDal();

        // Obtener lista de proveedores
        public List<EProveedor> ObtenerProveedores()
        {
            return objProveedorDal.ObtenerProveedores();
        }

        // Guardar o Editar proveedor con validaciones de negocio
        public bool GuardarProveedor(EProveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.NombreProveedor))
            {
                Mensaje = "El nombre del proveedor no puede estar vacío.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.Contacto))
            {
                Mensaje = "El nombre de contacto no puede estar vacío.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "El teléfono no puede estar vacío.";
                return false;
            }

            return objProveedorDal.GuardarProveedor(obj, out Mensaje);
        }

        // Eliminar proveedor
        public bool EliminarProveedor(int idProveedor, out string Mensaje)
        {
            return objProveedorDal.EliminarProveedor(idProveedor, out Mensaje);
        }
    }
}