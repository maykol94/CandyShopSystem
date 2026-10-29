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
                using (SqlCommand cmd = new SqlCommand("dbo.sp_obtenerinventario", oConexion))
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
                                IdVariacion = Convert.ToInt32(dr["id_variacion"]),
                                Producto = dr["nombre_producto"].ToString(),
                                Categoria = dr["categoria"].ToString(),
                                PrecioCompra = Convert.ToDecimal(dr["precio_compra"]),
                                PrecioVenta = Convert.ToDecimal(dr["precio_venta"]),
                                CantidadDisponible = Convert.ToInt32(dr["cantidad_disponible"]),
                                FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]),
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
            try
            {
                if (idStock == 0) return (false, "El producto no tiene un registro de stock previo para ajustar.");

                using (SqlConnection oConexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_ajustarstock", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_stock", idStock);
                        cmd.Parameters.AddWithValue("@cantidad_cambio", cantidadCambio);

                        await oConexion.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return (true, "Stock ajustado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, "Error al ajustar stock: " + ex.Message);
            }
        }

        public async Task<(bool Exito, string Mensaje)> EliminarStockAsync(int idStock)
        {
            try
            {
                if (idStock == 0) return (false, "No hay registro de stock para eliminar.");

                using (SqlConnection oConexion = Conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM Inventario.Stock WHERE id_stock = @id_stock";
                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id_stock", idStock);

                        await oConexion.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return (true, "Registro de stock eliminado.");
            }
            catch (Exception ex)
            {
                return (false, "Error al eliminar stock: " + ex.Message);
            }
        }
    }
}