using System.Data;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class CompraBl
    {
        private ComprasDal objCompraDal;

        public CompraBl()
        {
            objCompraDal = new ComprasDal();
        }

        public DataTable ObtenerCompras()
        {
            return objCompraDal.ObtenerCompras();
        }

        public DataTable ObtenerProveedores()
        {
            return objCompraDal.ObtenerProveedores();
        }

        public string RegistrarCompra(ECompra compra, EDetalleCompra detalle)
        {
            ComprasDal objComprasDal = new ComprasDal();
            return objComprasDal.RegistrarCompra(compra, detalle);
        }

        public DataTable ObtenerVariaciones()
        {
            return objCompraDal.ObtenerVariaciones();
        }

        public string CambiarEstadoCompra(int idCompra, string nuevoEstado)
        {
            return objCompraDal.CambiarEstadoCompra(idCompra, nuevoEstado);
        }
    }
}