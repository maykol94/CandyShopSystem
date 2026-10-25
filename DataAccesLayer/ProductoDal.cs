using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductoDal
    {
        public async Task<List<EProducto>> ObtenerProductosAsync()
        {
            List<EProducto> lista = new List<EProducto>();

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtenerproductos", oConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await oConexion.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            lista.Add(new EProducto
                            {
                                IdProducto = Convert.ToInt32(dr["id_producto"]),
                                NombreProducto = dr["nombre_producto"].ToString(),
                                IdCategoria = Convert.ToInt32(dr["id_categoria"]),
                                NombreCategoria = dr["nombre_categoria"].ToString(),
                                IdMarca = dr["id_marca"] != DBNull.Value ? Convert.ToInt32(dr["id_marca"]) : (int?)null,
                                NombreMarca = dr["nombre_marca"].ToString(),
                                IdTipoProducto = Convert.ToInt32(dr["id_tipo_producto"]),
                                NombreTipo = dr["nombre_tipo"].ToString(),
                                IdEstado = Convert.ToInt32(dr["id_estado"]),
                                Estado = dr["estado"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public async Task<DataSet> ObtenerCatalogosProductoAsync()
        {
            DataSet ds = new DataSet();

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtenercatalogosproducto", oConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(ds));
                    }
                }
            }

            return ds;
        }

        public async Task<(bool Exito, string Mensaje)> GuardarProductoAsync(EProducto producto)
        {
            bool exito = false;
            string mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_guardarproducto", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_producto", producto.IdProducto);
                        cmd.Parameters.AddWithValue("@nombre_producto", producto.NombreProducto);
                        cmd.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);
                        cmd.Parameters.AddWithValue("@id_marca", (object)producto.IdMarca ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id_tipo_producto", producto.IdTipoProducto);
                        cmd.Parameters.AddWithValue("@id_estado", producto.IdEstado);

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

        public async Task<(bool Exito, string Mensaje)> EliminarProductoAsync(int idProducto)
        {
            bool exito = false;
            string mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_eliminarproducto", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_producto", idProducto);

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