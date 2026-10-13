using System.Data;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class HomeBl
    {
        private HomeDal objHomeDal = new HomeDal();

        public EDashboard ObtenerTotalesDashboard()
        {
            return objHomeDal.ObtenerTotalesDashboard();
        }

        public DataTable ObtenerVentasRecientes()
        {
            return objHomeDal.ObtenerVentasRecientes();
        }

        public DataTable ObtenerProductosMasVendidos()
        {
            return objHomeDal.ObtenerProductosMasVendidos();
        }

        public DataTable ObtenerPedidosPendientes()
        {
            return objHomeDal.ObtenerPedidosPendientes();
        }
    }
}