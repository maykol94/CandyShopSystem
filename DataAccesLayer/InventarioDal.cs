using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class InventarioDal
    {
        public async Task<List<EInventario>> ObtenerInventarioAsync()
        {
            List<EInventario> lista = new List<EInventario>();

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtenerinventario", oConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await oConexion.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            lista.Add(new EInventario
                            {
                                IdStock = Convert.ToInt32(dr["id_stock"]),
                                Producto = dr["nombre_producto"].ToString(),
                                Categoria = dr["categoria"].ToString(),
                                CantidadDisponible = Convert.ToInt32(dr["cantidad_disponible"]),
                                PrecioCompra = Convert.ToDecimal(dr["precio_compra"]),
                                PrecioVenta = Convert.ToDecimal(dr["precio_venta"]),
                                FechaIngreso = dr["fecha_ingreso"].ToString(),
                                DiasAlerta = Convert.ToInt32(dr["dias_alerta"]),
                                Estado = dr["estado"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public async Task<(bool Exito, string Mensaje)> AjustarStockAsync(int idStock, int cantidadCambio)
        {
            bool exito = false;
            string mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ajustarstock", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_stock", idStock);
                        cmd.Parameters.AddWithValue("@cantidad_cambio", cantidadCambio);

                        await oConexion.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
                exito = false;
                mensaje = ex.Message;
            }

            return (exito, mensaje);
        }

        public async Task<(bool Exito, string Mensaje)> EliminarStockAsync(int idStock)
        {
            bool exito = false;
            string mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_eliminarstock", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_stock", idStock);

                        await oConexion.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
                exito = false;
                mensaje = ex.Message;
            }

            return (exito, mensaje);
        }
    }
}