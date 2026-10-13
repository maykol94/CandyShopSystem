using DataAccessLayer;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccesLayer
{
    public class ClienteDAL
    {
        public List<ECliente> ObtenerClientes()
        {
            List<ECliente> lista = new List<ECliente>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerClientes", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ECliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                NombreNegocio = dr["NombreNegocio"].ToString(),
                                Contacto = dr["Contacto"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                IdTipoCliente = Convert.ToInt32(dr["IdTipoCliente"]),
                                TipoClienteDescripcion = dr["TipoClienteDescripcion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ECliente>();
                }
            }

            return lista;
        }

        //para registrar un cliente en la base de datos usando un procedimiento almacenado
        public bool RegistrarCliente(ECliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GuardarCliente", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure; // Indica que se usa un procedimiento almacenado

                    //estos son los parametros que se van a enviar al procedimiento almacenado
                    cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("@NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("@NombreNegocio", (object)obj.NombreNegocio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Contacto", (object)obj.Contacto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", (object)obj.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdTipoCliente", obj.IdTipoCliente);

                    // Parámetros de salida
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        public bool EliminarCliente(int idCliente, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarCliente", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return respuesta;
        }
    }
}