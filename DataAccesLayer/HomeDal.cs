using System;
using System.Data;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class HomeDal
    {
        //para ver los datos de las tarjetas
        public EDashboard ObtenerTotalesDashboard()
        {
            EDashboard datos = new EDashboard();

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = @"
                        SELECT 
                            (SELECT COUNT(*) FROM vw_clientes) AS TotalClientes,
                            (SELECT COUNT(*) FROM vw_productos_registrados) AS TotalProductos,
                            (SELECT COALESCE(SUM(monto_total), 0) FROM vw_ventas_dia) AS VentasHoy,
                            (SELECT COUNT(*) FROM vw_pedidos_pendientes) AS PedidosPendientes,
                            (SELECT COALESCE(stock_disponible, 0) FROM vw_resumen_inventario) AS StockDisponible,
                            (SELECT COALESCE(por_reponer, 0) FROM vw_resumen_inventario) AS PorReponer;";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            datos.TotalClientes = dr["TotalClientes"] != DBNull.Value ? Convert.ToInt32(dr["TotalClientes"]) : 0;
                            datos.TotalProductos = dr["TotalProductos"] != DBNull.Value ? Convert.ToInt32(dr["TotalProductos"]) : 0;
                            datos.VentasHoy = dr["VentasHoy"] != DBNull.Value ? Convert.ToDecimal(dr["VentasHoy"]) : 0.00m;
                            datos.PedidosPendientes = dr["PedidosPendientes"] != DBNull.Value ? Convert.ToInt32(dr["PedidosPendientes"]) : 0;
                            datos.StockDisponible = dr["StockDisponible"] != DBNull.Value ? Convert.ToInt32(dr["StockDisponible"]) : 0;
                            datos.PorReponer = dr["PorReponer"] != DBNull.Value ? Convert.ToInt32(dr["PorReponer"]) : 0;
                        }
                    }
                }
                catch
                {
                    datos = new EDashboard();
                }
            }

            return datos;
        }

        //ventas recientes
        public DataTable ObtenerVentasRecientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = "SELECT TOP 5 FORMAT(fecha_hora, 'dd/MM/yyyy') AS FECHA, nombre_cliente AS CLIENTE, tipo_cliente AS TIPO, monto_total AS TOTAL FROM vw_ventas_recientes ORDER BY fecha_hora DESC;";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch { }
            }
            return dt;
        }

        //productos más vendidos
        public DataTable ObtenerProductosMasVendidos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = "SELECT TOP 5 nombre_producto AS PRODUCTO, total_vendido AS CANTIDAD FROM vw_productos_mas_vendidos ORDER BY total_vendido DESC;";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch { }
            }
            return dt;
        }

        //pedidos pendientes
        public DataTable ObtenerPedidosPendientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = "SELECT TOP 5 FORMAT(fecha_entrega, 'dd/MM/yyyy') AS FECHA, nombre_cliente AS CLIENTE, monto_total AS TOTAL FROM vw_pedidos_pendientes ORDER BY fecha_entrega ASC;";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch { }
            }
            return dt;
        }
    }
}