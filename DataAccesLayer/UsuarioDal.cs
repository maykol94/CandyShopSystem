using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccessLayer
{
    public class UsuarioDAL
    {
        public EUsuario ValidarUsuario(string usuario, string clave, out string mensaje)
        {
            EUsuario oUsuario = null;
            mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    cmd.Parameters.Add("@EsValido", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@IdRol", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    bool esValido = Convert.ToBoolean(cmd.Parameters["@EsValido"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value != DBNull.Value ? cmd.Parameters["@Mensaje"].Value.ToString() : string.Empty;

                    if (esValido)
                    {
                        oUsuario = new EUsuario()
                        {
                            IdUsuario = Convert.ToInt32(cmd.Parameters["@IdUsuario"].Value),
                            NombreUsuario = usuario,
                            IdRol = Convert.ToInt32(cmd.Parameters["@IdRol"].Value)
                        };
                    }
                }
                catch (Exception ex)
                {
                    oUsuario = null;
                    mensaje = "Error de conexión: " + ex.Message;
                }
            }

            return oUsuario;
        }

        public bool RegistrarUsuario(string usuario, string clave, int idRol, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario);
                    cmd.Parameters.AddWithValue("@Clave", clave);
                    cmd.Parameters.AddWithValue("@IdRol", idRol);

                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value != DBNull.Value ? cmd.Parameters["@Mensaje"].Value.ToString() : string.Empty;
                }
                catch (Exception ex)
                {
                    resultado = false;
                    mensaje = "Error al guardar el usuario: " + ex.Message;
                }
            }

            return resultado;
        }
    }
}