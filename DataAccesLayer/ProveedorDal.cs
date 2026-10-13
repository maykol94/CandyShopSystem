using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class ProveedorDal
    {
        public List<EProveedor> ObtenerProveedores()
        {
            List<EProveedor> lista = new List<EProveedor>();

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenerproveedores", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EProveedor
                            {
                                IdProveedor = Convert.ToInt32(dr["id_proveedor"]),
                                NombreProveedor = dr["nombre_proveedor"].ToString(),
                                Contacto = dr["contacto"] != DBNull.Value ? dr["contacto"].ToString() : string.Empty,
                                Telefono = dr["telefono"] != DBNull.Value ? dr["telefono"].ToString() : string.Empty,
                                Direccion = dr["direccion"] != DBNull.Value ? dr["direccion"].ToString() : string.Empty,
                                IdEstado = Convert.ToInt32(dr["id_estado"])
                            });
                        }
                    }
                }
                catch
                {
                    //en caso de q falle el procedimiedo almacenado
                    lista = ObtenerProveedoresDirecto(oConexion);
                }
            }

            return lista;
        }

        private List<EProveedor> ObtenerProveedoresDirecto(SqlConnection oConexion)
        {
            List<EProveedor> lista = new List<EProveedor>();
            try
            {
                if (oConexion.State != ConnectionState.Open)
                    oConexion.Open();

                string query = "SELECT id_proveedor, nombre_proveedor, contacto, telefono, direccion, id_estado FROM proveedor.proveedor ORDER BY id_proveedor DESC";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.CommandType = CommandType.Text;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new EProveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["id_proveedor"]),
                            NombreProveedor = dr["nombre_proveedor"].ToString(),
                            Contacto = dr["contacto"] != DBNull.Value ? dr["contacto"].ToString() : string.Empty,
                            Telefono = dr["telefono"] != DBNull.Value ? dr["telefono"].ToString() : string.Empty,
                            Direccion = dr["direccion"] != DBNull.Value ? dr["direccion"].ToString() : string.Empty,
                            IdEstado = Convert.ToInt32(dr["id_estado"])
                        });
                    }
                }
            }
            catch
            {
                lista = new List<EProveedor>();
            }
            return lista;
        }

        public bool RegistrarProveedor(EProveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_registrarproveedor", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre_proveedor", obj.NombreProveedor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@contacto", string.IsNullOrWhiteSpace(obj.Contacto) ? (object)DBNull.Value : obj.Contacto);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", string.IsNullOrWhiteSpace(obj.Direccion) ? (object)DBNull.Value : obj.Direccion);
                    cmd.Parameters.AddWithValue("@id_estado", obj.IdEstado);

                    // parametrp de salida id prveedor generado
                    SqlParameter paramIdGenerado = new SqlParameter("@id_proveedor_generado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramIdGenerado);

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    if (paramIdGenerado.Value != DBNull.Value && Convert.ToInt32(paramIdGenerado.Value) > 0)
                    {
                        obj.IdProveedor = Convert.ToInt32(paramIdGenerado.Value);
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

        public bool EliminarProveedor(int idProveedor, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminarproveedor", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);

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


        public bool EditarProveedor(EProveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_editarproveedor", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_proveedor", obj.IdProveedor);
                    cmd.Parameters.AddWithValue("@nombre_proveedor", obj.NombreProveedor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@contacto", string.IsNullOrWhiteSpace(obj.Contacto) ? (object)DBNull.Value : obj.Contacto);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", string.IsNullOrWhiteSpace(obj.Direccion) ? (object)DBNull.Value : obj.Direccion);
                    cmd.Parameters.AddWithValue("@id_estado", obj.IdEstado);

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
    }
}