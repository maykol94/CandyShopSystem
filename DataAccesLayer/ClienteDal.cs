using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class ClienteDal
    {
        private string cadena = Conexion.cadena;

        //lista de clientes
        public List<ECliente> ObtenerClientes()
        {
            List<ECliente> lista = new List<ECliente>();

            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenerclientes", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ECliente()
                            {
                                IdCliente = Convert.ToInt32(dr[0]),
                                NombreCliente = dr[1].ToString(),
                                NombreNegocio = dr[2].ToString(),
                                Contacto = dr[3].ToString(),
                                Direccion = dr[4].ToString(),
                                IdTipoCliente = Convert.ToInt32(dr[5]),
                                TipoCliente = dr[6].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return lista;
        }

        //guardar cliente y edutar cliente
        public bool GuardarCliente(ECliente obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_guardarcliente", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("@nombre_cliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("@nombre_negocio", obj.NombreNegocio ?? "");
                    cmd.Parameters.AddWithValue("@contacto", obj.Contacto ?? "");
                    cmd.Parameters.AddWithValue("@direccion", obj.Direccion ?? "");
                    cmd.Parameters.AddWithValue("@id_tipo_cliente", obj.IdTipoCliente);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = true;
                    mensaje = "Cliente guardado correctamente.";
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        //Eliminar cliente
        public bool EliminarCliente(int idCliente, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminarcliente", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = true;
                    mensaje = "Cliente eliminado correctamente.";
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