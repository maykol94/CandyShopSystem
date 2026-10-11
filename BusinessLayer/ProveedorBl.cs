using System;
using System.Collections.Generic;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ProveedorBL
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
                mensaje = "Debe ingresar el nombre de la empresa o proveedor.";
                return false;
            }

            return objProveedorDal.RegistrarProveedor(obj, out mensaje);
        }
    }
}