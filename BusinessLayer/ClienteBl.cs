
using System.Collections.Generic;
using DataAccesLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ClienteBL
    {
        private ClienteDAL objClienteDAL = new ClienteDAL();

        public List<ECliente> ObtenerClientes()
        {
            return objClienteDAL.ObtenerClientes();
        }

        public bool RegistrarCliente(ECliente obj, out string Mensaje)
        {
            return objClienteDAL.RegistrarCliente(obj, out Mensaje);
        }

        public bool EliminarCliente(int idCliente, out string Mensaje)
        {
            return objClienteDAL.EliminarCliente(idCliente, out Mensaje);
        }
    }
}