using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class ReporteDAL
    {
        public DataTable ObtenerVentasRecientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    oconexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_reporte_ventas_recientes", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el reporte: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ObtenerVentasDelDia()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    oconexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_reporte_ventas_dia", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las ventas del día: " + ex.Message);
                }
            }
            return dt;
        }
    }
}