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
                        string queryFactura = @"
                            INSERT INTO Ventas.Factura (id_cliente, id_trabajador, fecha_hora, forma_pago, descuento_factura, monto_total) 
                            VALUES (@id_cliente, @id_trabajador, GETDATE(), @forma_pago, @descuento_factura, 0);
                            SELECT SCOPE_IDENTITY();";

                        int idFactura = 0;
                        using (SqlCommand cmdFactura = new SqlCommand(queryFactura, oConexion, transaccion))
                        {
                            cmdFactura.CommandType = CommandType.Text;
                            cmdFactura.Parameters.AddWithValue("@id_cliente", factura.IdCliente);
                            cmdFactura.Parameters.AddWithValue("@id_trabajador", factura.IdTrabajador);
                            cmdFactura.Parameters.AddWithValue("@forma_pago", factura.FormaPago);
                            cmdFactura.Parameters.AddWithValue("@descuento_factura", factura.DescuentoFactura);

                            idFactura = Convert.ToInt32(await cmdFactura.ExecuteScalarAsync());
                        }

                        decimal montoTotalCalculado = 0;

                        foreach (var item in carrito)
                        {
                            string queryDetalle = @"
                                INSERT INTO Ventas.DetalleFactura (id_factura, id_variacion, cantidad, precio_venta, descuento_unitario) 
                                VALUES (@id_factura, @id_variacion, @cantidad, @precio_venta, @descuento_unitario);";

                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, oConexion, transaccion))
                            {
                                cmdDetalle.CommandType = CommandType.Text;
                                cmdDetalle.Parameters.AddWithValue("@id_factura", idFactura);
                                cmdDetalle.Parameters.AddWithValue("@id_variacion", item.IdVariacion);
                                cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                                cmdDetalle.Parameters.AddWithValue("@precio_venta", item.PrecioVenta);
                                cmdDetalle.Parameters.AddWithValue("@descuento_unitario", item.DescuentoUnitario);

                                await cmdDetalle.ExecuteNonQueryAsync();
                            }

                            montoTotalCalculado += (item.Cantidad * (item.PrecioVenta - item.DescuentoUnitario));

                            string queryStock = @"
                                UPDATE Inventario.Stock 
                                SET cantidad_disponible = cantidad_disponible - @cantidad 
                                WHERE id_variacion = @id_variacion AND cantidad_disponible > 0;";

                            using (SqlCommand cmdStock = new SqlCommand(queryStock, oConexion, transaccion))
                            {
                                cmdStock.CommandType = CommandType.Text;
                                cmdStock.Parameters.AddWithValue("@cantidad", item.Cantidad);
                                cmdStock.Parameters.AddWithValue("@id_variacion", item.IdVariacion);

                                await cmdStock.ExecuteNonQueryAsync();
                            }
                        }

                        montoTotalCalculado -= factura.DescuentoFactura;

                        string queryUpdate = "UPDATE Ventas.Factura SET monto_total = @monto_total WHERE id_factura = @id_factura";
                        using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, oConexion, transaccion))
                        {
                            cmdUpdate.CommandType = CommandType.Text;
                            cmdUpdate.Parameters.AddWithValue("@monto_total", montoTotalCalculado);
                            cmdUpdate.Parameters.AddWithValue("@id_factura", idFactura);

                            await cmdUpdate.ExecuteNonQueryAsync();
                        }

                        transaccion.Commit();
                        return (true, $"Venta registrada exitosamente. Factura N° {idFactura}");
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