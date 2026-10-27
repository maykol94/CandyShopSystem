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

                    // Parámetro de salida que devuelve el ID del pedido creado
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

        // 1. Método para obtener los pedidos (usando tu vista o consulta a la base de datos)
        public DataTable ObtenerPedidosPendientes()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    //para obtener los pedidos pendientes se usa la vista de pedidos pendientes (Ventas.vw_PedidosPendientes)
                    string query = "SELECT id_pedido, id_factura, fecha_entrega, direccion_adicional, id_estado AS IdEstado, 'Pendiente' AS estado_texto FROM Ventas.Pedido";

                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabla);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Manejo de errores si es necesario
            }
            return tabla;
        }

        // 2. Método para despachar o cambiar el estado del pedido en la base de datos
        public bool DespacharPedido(int idPedido, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    //al despachar se cambia el estado a 15 y ya no sale en la tabla
                    string query = "UPDATE Ventas.Pedido SET id_estado = 15 WHERE id_pedido = @id_pedido";

                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@id_pedido", idPedido);
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
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