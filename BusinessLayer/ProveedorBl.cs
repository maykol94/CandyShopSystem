using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ProveedorBl
    {
        private ProveedorDal objProveedorDal = new ProveedorDal();

        //obtener lista de proveedores
        public async Task<List<EProveedor>> ObtenerProveedoresAsync()
        {
            return await objProveedorDal.ObtenerProveedoresAsync();
        }

        // Guardar o Editar proveedor con validaciones
        public async Task<(bool Exito, string Mensaje)> GuardarProveedorAsync(EProveedor obj)
        {
            if (string.IsNullOrWhiteSpace(obj.NombreProveedor))
            {
                return (false, "El nombre del proveedor no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(obj.Contacto))
            {
                return (false, "El nombre de contacto no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                return (false, "El teléfono no puede estar vacío.");
            }

            return await objProveedorDal.GuardarProveedorAsync(obj);
        }

        // Eliminar proveedor
        public async Task<(bool Exito, string Mensaje)> EliminarProveedorAsync(int idProveedor)
        {
            return await objProveedorDal.EliminarProveedorAsync(idProveedor);
        }
    }
}