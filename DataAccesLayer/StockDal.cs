using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class StockDal
    {
    
        public List<EInventario> ObtenerInventario()
        {
            List<EInventario> lista = new List<EInventario>();

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenerinventario", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EInventario
                            {
                                IdStock = Convert.ToInt32(dr["id_stock"]),
                                NombreProducto = dr["nombre_producto"] != DBNull.Value ? dr["nombre_producto"].ToString() : "Sin Producto",
                                Categoria = dr["categoria"] != DBNull.Value ? dr["categoria"].ToString() : "Sin Categoría",
                                StockActual = dr["stock_actual"] != DBNull.Value ? Convert.ToInt32(dr["stock_actual"]) : 0,
                                StockMinimo = dr["stock_minimo"] != DBNull.Value ? Convert.ToInt32(dr["stock_minimo"]) : 0,
                                Estado = dr["estado"] != DBNull.Value ? dr["estado"].ToString() : "Disponible"
                            });
                        }
                    }
                }
                catch
                {
                    lista = new List<EInventario>();
                }
            }

            return lista;
        }

        // Ajustar existencias del stock de un producto
        public bool AjustarStock(int idStock, int cambio, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ajustarstock", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_stock", idStock);
                    cmd.Parameters.AddWithValue("@cantidad_cambio", cambio);

                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        respuesta = true;
                    }
                    else
                    {
                        mensaje = $"No se encontró el registro de stock con ID = {idStock}.";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }
    }
}