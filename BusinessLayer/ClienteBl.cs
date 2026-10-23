using DataAccessLayer;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ClienteBl
    {
        private ClienteDal objDal = new ClienteDal();

        //lista de clientes
        public List<ECliente> ObtenerClientes()
        {
            return objDal.ObtenerClientes();
        }

        //guarda y edita cliente
        public bool GuardarCliente(ECliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.NombreCliente))
            {
                mensaje = "El nombre del cliente no puede estar vacío.";
                return false;
            }

            if (obj.IdTipoCliente <= 0)
            {
                mensaje = "Debe seleccionar un tipo de cliente válido.";
                return false;
            }

            return objDal.GuardarCliente(obj, out mensaje);
        }

        //Validar y eliminar cliente
        public bool EliminarCliente(int idCliente, out string mensaje)
        {
            mensaje = string.Empty;

            if (idCliente <= 0)
            {
                mensaje = "Debe seleccionar un cliente válido para eliminar.";
                return false;
            }

            return objDal.EliminarCliente(idCliente, out mensaje);
        }
    }
}