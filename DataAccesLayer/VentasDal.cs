using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VentasDal
    {
        public async Task<(bool Exito, string Mensaje)> RegistrarVentaAsync(EFactura factura, List<EDetalleFactura> carrito)
        {
            using (SqlConnection oConexion = Conexion.ObtenerConexion())
            {
                await oConexion.OpenAsync();
                using (SqlTransaction transaccion = oConexion.BeginTransaction())
                {
                    try
                    {
                        int idFacturaGenerada = 0;

                        foreach (var item in carrito)
                        {
                            using (SqlCommand cmd = new SqlCommand("Ventas.sp_registrar_venta", oConexion, transaccion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@id_cliente", factura.IdCliente);
                                cmd.Parameters.AddWithValue("@id_trabajador", factura.IdTrabajador);
                                cmd.Parameters.AddWithValue("@forma_pago", factura.FormaPago);
                                cmd.Parameters.AddWithValue("@descuento_factura", factura.DescuentoFactura);

                                cmd.Parameters.AddWithValue("@id_stock", item.IdStock);

                                cmd.Parameters.AddWithValue("@id_variacion", item.IdVariacion);
                                cmd.Parameters.AddWithValue("@cantidad", item.Cantidad);
                                cmd.Parameters.AddWithValue("@precio_venta", item.PrecioVenta);
                                cmd.Parameters.AddWithValue("@descuento_unitario", item.DescuentoUnitario);

                                SqlParameter outputId = new SqlParameter("@id_factura_generada", SqlDbType.Int)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                cmd.Parameters.Add(outputId);

                                await cmd.ExecuteNonQueryAsync();

                                idFacturaGenerada = Convert.ToInt32(outputId.Value);
                            }
                        }

                        transaccion.Commit();
                        return (true, $"Venta registrada exitosamente. Factura N° {idFacturaGenerada}");
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        return (false, "Error al registrar la venta: " + ex.Message);
                    }
                }
            }
        }
    }
}