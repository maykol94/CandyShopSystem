using System;
using System.Data;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class PedidoBl
    {
        private PedidosDal objPedidosDal = new PedidosDal();

        // Método para registrar el pedido
        public string RegistrarPedido(EPedido pedido, out int idPedidoGenerado)
        {
            return objPedidosDal.RegistrarPedido(pedido, out idPedidoGenerado);
        }

        // Método para obtener la tabla de pedidos pendientes (Soluciona el primer error)
        public DataTable ObtenerTablaPedidosPendientes()
        {
            // Llama al método correspondiente de tu capa de datos (o la vista de la BD)
            return objPedidosDal.ObtenerPedidosPendientes();
        }

        // Método para despachar o cambiar el estado del pedido (Soluciona el segundo error)
        public bool DespacharPedido(int idPedido, out string mensaje)
        {
            return objPedidosDal.DespacharPedido(idPedido, out mensaje);
        }
    }
}