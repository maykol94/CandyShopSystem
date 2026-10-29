using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccessLayer
{
    public class PedidosDal
    {
        public string RegistrarPedido(EPedido pedido, out int idPedidoGenerado)
        {
            idPedidoGenerado = 0;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarPedido", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_factura", pedido.IdFactura);
                    cmd.Parameters.AddWithValue("@fecha_entrega", pedido.FechaEntrega);
                    cmd.Parameters.AddWithValue("@direccion_adicional", pedido.DireccionAdicional);
                    cmd.Parameters.AddWithValue("@id_estado", pedido.IdEstado);

                    SqlParameter outParam = new SqlParameter("@id_pedido_generado", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    idPedidoGenerado = Convert.ToInt32(outParam.Value);
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //metodo para obtener los pedidos pendientes usando su Procedimiento Almacenado
        public DataTable ObtenerPedidosPendientes()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerPedidosPendientes", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabla);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Opcional: se puede manejar o loguear el error si lo requiere
            }
            return tabla;
        }

        public bool DespacharPedido(int idPedido, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DespacharPedido", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pedido", idPedido);

                        cmd.Parameters.AddWithValue("@nuevo_estado", 15);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0 || filasAfectadas == -1) // -1 ocurre a veces con ExecuteNonQuery en algunos SPs con SET NOCOUNT ON
                        {
                            return true;
                        }
                        else
                        {
                            mensaje = "No se encontró el pedido a actualizar.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
    }
}