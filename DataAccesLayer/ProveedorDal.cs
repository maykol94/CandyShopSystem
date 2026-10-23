using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class ProveedorDal
    {
        // 1. Obtener lista de proveedores
        public List<EProveedor> ObtenerProveedores()
        {
            List<EProveedor> lista = new List<EProveedor>();

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenerproveedores", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EProveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr[0]),
                                NombreProveedor = dr[1].ToString(),
                                Contacto = dr[2].ToString(),
                                Telefono = dr[3].ToString(),
                                Direccion = dr[4].ToString(),
                                IdEstado = Convert.ToInt32(dr[5])
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

        // 2. Guardar o Editar proveedor
        public bool GuardarProveedor(EProveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_guardarproveedor", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_proveedor", obj.IdProveedor);
                    cmd.Parameters.AddWithValue("@nombre_proveedor", obj.NombreProveedor ?? "");
                    cmd.Parameters.AddWithValue("@contacto", obj.Contacto ?? "");
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono ?? "");
                    cmd.Parameters.AddWithValue("@direccion", obj.Direccion ?? "");
                    cmd.Parameters.AddWithValue("@id_estado", obj.IdEstado > 0 ? obj.IdEstado : 11);

                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    respuesta = true;
                    Mensaje = obj.IdProveedor == 0 ? "Proveedor registrado correctamente." : "Proveedor actualizado correctamente.";
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        // 3. Eliminar proveedor
        public bool EliminarProveedor(int idProveedor, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminarproveedor", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);

                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    respuesta = true;
                    Mensaje = "Proveedor eliminado correctamente.";
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