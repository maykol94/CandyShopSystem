using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class ProductoDal
    {
        public List<EProducto> ObtenerProductos()
        {
            List<EProducto> lista = new List<EProducto>();

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenerproductos", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EProducto
                            {
                                IdProducto = Convert.ToInt32(dr["id_producto"]),
                                NombreProducto = dr["nombre_producto"].ToString(),
                                IdCategoria = dr["id_categoria"] != DBNull.Value ? Convert.ToInt32(dr["id_categoria"]) : 0,
                                NombreCategoria = dr["nombre_categoria"] != DBNull.Value ? dr["nombre_categoria"].ToString() : string.Empty,
                                IdMarca = dr["id_marca"] != DBNull.Value ? Convert.ToInt32(dr["id_marca"]) : 0,
                                NombreMarca = dr["nombre_marca"] != DBNull.Value ? dr["nombre_marca"].ToString() : string.Empty,
                                IdTipoProducto = dr["id_tipo_producto"] != DBNull.Value ? Convert.ToInt32(dr["id_tipo_producto"]) : 0,
                                TipoProductoDescripcion = dr["tipo_producto_descripcion"] != DBNull.Value ? dr["tipo_producto_descripcion"].ToString() : string.Empty
                            });
                        }
                    }
                }
                catch
                {
                    lista = new List<EProducto>();
                }
            }

            return lista;
        }

        public bool RegistrarProducto(EProducto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_registrarproducto", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre_producto", obj.NombreProducto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_categoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("@id_marca", obj.IdMarca);
                    cmd.Parameters.AddWithValue("@id_tipo_producto", obj.IdTipoProducto);

                    SqlParameter paramIdGenerado = new SqlParameter("@id_producto_generado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramIdGenerado);

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    if (paramIdGenerado.Value != DBNull.Value && Convert.ToInt32(paramIdGenerado.Value) > 0)
                    {
                        obj.IdProducto = Convert.ToInt32(paramIdGenerado.Value);
                        respuesta = true;
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

        public bool EditarProducto(EProducto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_editarproducto", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_producto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("@nombre_producto", obj.NombreProducto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_categoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("@id_marca", obj.IdMarca);
                    cmd.Parameters.AddWithValue("@id_tipo_producto", obj.IdTipoProducto);

                    SqlParameter paramRespuesta = new SqlParameter("@respuesta", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter paramMensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(paramRespuesta);
                    cmd.Parameters.Add(paramMensaje);

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    if (paramRespuesta.Value != DBNull.Value)
                        respuesta = Convert.ToBoolean(paramRespuesta.Value);

                    if (paramMensaje.Value != DBNull.Value)
                        mensaje = paramMensaje.Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        public bool EliminarProducto(int idProducto, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminarproducto", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_producto", idProducto);

                    SqlParameter paramRespuesta = new SqlParameter("@respuesta", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter paramMensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(paramRespuesta);
                    cmd.Parameters.Add(paramMensaje);

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    if (paramRespuesta.Value != DBNull.Value)
                        respuesta = Convert.ToBoolean(paramRespuesta.Value);

                    if (paramMensaje.Value != DBNull.Value)
                        mensaje = paramMensaje.Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        public DataTable ObtenerCategoriasCombo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT id_categoria, nombre_categoria FROM Catalogo.Catgoria ORDER BY nombre_categoria ASC", oConexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch { }
            }
            return dt;
        }

        public DataTable ObtenerMarcasCombo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT id_marca, nombre_marca FROM Catalogo.Marca ORDER BY nombre_marca ASC", oConexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch { }
            }
            return dt;
        }

        public DataTable ObtenerTiposProductoCombo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT id_tipo_producto, nombre_tipo FROM Producto.TipoProducto ORDER BY nombre_tipo ASC", oConexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch { }
            }
            return dt;
        }
    }
}