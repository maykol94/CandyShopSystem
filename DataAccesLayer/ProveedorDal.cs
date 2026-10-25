using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class ProveedorDal
    {
       
        public async Task<List<EProveedor>> ObtenerProveedoresAsync()
        {
            List<EProveedor> lista = new List<EProveedor>();

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerproveedores", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                await oconexion.OpenAsync();

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
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

            return lista;
        }

        public async Task<(bool Exito, string Mensaje)> GuardarProveedorAsync(EProveedor obj)
        {
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

                    await oconexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    string msg = obj.IdProveedor == 0 ? "Proveedor registrado correctamente." : "Proveedor actualizado correctamente.";
                    return (true, msg);
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
        }

        public async Task<(bool Exito, string Mensaje)> EliminarProveedorAsync(int idProveedor)
        {
            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminarproveedor", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);

                    await oconexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return (true, "Proveedor eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
        }
    }
}