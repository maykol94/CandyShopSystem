using DataAccessLayer;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccesLayer
{
    public class PedidoDal
    {
        private string cadenaConexion = Conexion.cadena;

        public List<EPedido> ObtenerPedidosPendientes()
        {
            List<EPedido> lista = new List<EPedido>();

            using (SqlConnection oconexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerPedidosPendientes", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EPedido()
                            {
                                IdPedido = Convert.ToInt32(dr["id_pedido"]),
                                IdFactura = Convert.ToInt32(dr["id_factura"]),
                                FechaEntrega = dr["fecha_entrega"].ToString(),
                                DireccionAdicional = dr["direccion_adicional"].ToString(),
                                IdEstado = Convert.ToInt32(dr["id_estado"])
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<EPedido>();
                }
            }

            return lista;
        }

        public bool RegistrarPedido(EPedido obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarPedido", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //para q la fecga de entrega sea valida, si no lo es se asigna la fecha actual
                    if (!DateTime.TryParse(obj.FechaEntrega, out DateTime fechaValida))
                    {
                        fechaValida = DateTime.Now;
                    }

                    cmd.Parameters.AddWithValue("id_factura", obj.IdFactura);
                    cmd.Parameters.AddWithValue("fecha_entrega", fechaValida);
                    cmd.Parameters.AddWithValue("direccion_adicional", obj.DireccionAdicional);
                    cmd.Parameters.AddWithValue("id_estado", obj.IdEstado);
                    cmd.Parameters.Add("id_pedido_generado", SqlDbType.Int).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    obj.IdPedido = Convert.ToInt32(cmd.Parameters["id_pedido_generado"].Value);
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        public bool DespacharPedido(int idPedido, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DespacharPedido", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id_pedido", idPedido);

                    oconexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        respuesta = true;
                    }
                    else
                    {
                        mensaje = $"No se encontró el registro con id_pedido = {idPedido} en la tabla Ventas.Pedido.";
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
