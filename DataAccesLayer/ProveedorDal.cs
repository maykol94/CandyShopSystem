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

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = @"SELECT 
                                        p.id_proveedor AS IdProveedor, 
                                        p.nombre_proveedor AS NombreProveedor, 
                                        ISNULL(p.contacto, '') AS Contacto, 
                                        ISNULL(p.telefono, '') AS Telefono, 
                                        ISNULL(p.direccion, '') AS Direccion, 
                                        CASE WHEN p.id_estado = 11 THEN 'Activo' ELSE 'Inactivo' END AS Estado
                                     FROM Proveedor p";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EProveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                NombreProveedor = dr["NombreProveedor"] != DBNull.Value ? dr["NombreProveedor"].ToString() : "",
                                Contacto = dr["Contacto"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Estado = dr["Estado"].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<EProveedor>();
                }
            }

            return lista;
        }

        public bool RegistrarProveedor(EProveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = @"INSERT INTO Proveedor (nombre_proveedor, contacto, telefono, direccion, id_estado)
                                     VALUES (@NombreProveedor, @Contacto, @Telefono, @Direccion, 11)";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NombreProveedor", obj.NombreProveedor);
                    cmd.Parameters.AddWithValue("@Contacto", string.IsNullOrEmpty(obj.Contacto) ? DBNull.Value : (object)obj.Contacto);
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(obj.Telefono) ? DBNull.Value : (object)obj.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(obj.Direccion) ? DBNull.Value : (object)obj.Direccion);

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;

                    if (respuesta)
                    {
                        mensaje = "Proveedor registrado con éxito.";
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
