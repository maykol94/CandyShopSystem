using System.Collections.Generic;
using DataAccesLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class PedidoBl
    {
        private PedidoDal objPedidoDal = new PedidoDal();

        public List<EPedido> ObtenerPedidosPendientes()
        {
            return objPedidoDal.ObtenerPedidosPendientes();
        }

        public bool RegistrarPedido(EPedido obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.DireccionAdicional))
            {
                mensaje = "La dirección adicional de entrega es requerida.";
                return false;
            }

            return objPedidoDal.RegistrarPedido(obj, out mensaje);
        }

        public bool DespacharPedido(int idPedido, out string mensaje)
        {
            return objPedidoDal.DespacharPedido(idPedido, out mensaje);
        }
    }
}