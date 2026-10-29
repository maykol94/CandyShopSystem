using System;
using System.Data;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class HomeDal
    {
        // 1. Totales para las tarjetas del Dashboard
        public EDashboard ObtenerTotalesDashboard()
        {
            EDashboard datos = new EDashboard();

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_obtener_totales_dashboard", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
                }
                catch
                {
                    datos = new EDashboard();
                }
            }

            return datos;
        }

        // 2. Ventas recientes usando SP
        public DataTable ObtenerVentasRecientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_obtener_ventas_recientes_home", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        oConexion.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch { }
            }
            return dt;
        }

        // 3. Productos más vendidos usando SP
        public DataTable ObtenerProductosMasVendidos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_obtener_productos_mas_vendidos_home", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        oConexion.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch { }
            }
            return dt;
        }

        // 4. Pedidos pendientes usando SP
        public DataTable ObtenerPedidosPendientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_obtener_pedidos_pendientes_home", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        oConexion.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch { }
            }
            return dt;
        }
    }
}