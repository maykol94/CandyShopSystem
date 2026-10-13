using System;
using System.Collections.Generic;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLayer
{
    public class ProveedorBl
    {
        private ProveedorDal objProveedorDal = new ProveedorDal();

        public List<EProveedor> ObtenerProveedores()
        {
            return objProveedorDal.ObtenerProveedores();
        }

        public bool RegistrarProveedor(EProveedor obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.NombreProveedor))
            {
                mensaje = "El nombre del proveedor no puede estar vacío.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                mensaje = "El teléfono del proveedor no puede estar vacío.";
                return false;
            }

            return objProveedorDal.RegistrarProveedor(obj, out mensaje);
        }

        public bool EditarProveedor(EProveedor obj, out string mensaje)
        {
            return objProveedorDal.EditarProveedor(obj, out mensaje);
        }

        public bool EliminarProveedor(int idProveedor, out string mensaje)
        {
            return objProveedorDal.EliminarProveedor(idProveedor, out mensaje);
        }
    }
}