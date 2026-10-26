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
        public async Task<(bool Exito, string Mensaje, int IdFactura)> RegistrarVentaAsync(EFactura factura, List<EDetalleFactura> carrito)
        {
            bool exito = false;
            string mensaje = string.Empty;
            int idFacturaGenerada = 0;

            try
            {
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("id_variacion", typeof(int));
                dtDetalles.Columns.Add("cantidad", typeof(int));
                dtDetalles.Columns.Add("precio_venta", typeof(decimal));
                dtDetalles.Columns.Add("descuento_unitario", typeof(decimal));

                foreach (var item in carrito)
                {
                    dtDetalles.Rows.Add(item.IdVariacion, item.Cantidad, item.PrecioVenta, item.DescuentoUnitario);
                }

                using (SqlConnection oConexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("Ventas.sp_registrar_venta", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_cliente", factura.IdCliente);
                        cmd.Parameters.AddWithValue("@id_trabajador", factura.IdTrabajador);
                        cmd.Parameters.AddWithValue("@forma_pago", factura.FormaPago);
                        cmd.Parameters.AddWithValue("@descuento_factura", factura.DescuentoFactura);

                       

                        await oConexion.OpenAsync();

                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            if (await dr.ReadAsync())
                            {
                                idFacturaGenerada = Convert.ToInt32(dr["id_factura_generada"]);
                                exito = true;
                                mensaje = "Venta registrada con éxito.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                exito = false;
                mensaje = ex.Message;
            }

            return (exito, mensaje, idFacturaGenerada);
        }
    }
}