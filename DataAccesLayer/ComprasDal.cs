using DataAccessLayer;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccesLayer
{
    public class ComprasDal
    {
        private string cadena = Conexion.cadena;

        public DataTable ObtenerCompras()
        {
            DataTable dtResultado = new DataTable("Compra");

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();

                    // Usamos CAST(... AS DATE) para omitir la hora y mostrar solo la fecha limpia
                    string query = @"SELECT 
                                        c.id_compra AS [ID Compra], 
                                        pr.nombre_proveedor AS [Proveedor], 
                                        CAST(c.fecha_compra AS DATE) AS [Fecha], 
                                        c.total_monto AS [Total (C$)],
                                        c.estado_pago AS [Estado Pago]
                                     FROM compras.compra c
                                     INNER JOIN proveedor.proveedor pr ON c.id_proveedor = pr.id_proveedor
                                     ORDER BY c.fecha_compra DESC";

                    SqlCommand comando = new SqlCommand(query, sqlCon);
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(dtResultado);
                }
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable ObtenerProveedores()
        {
            DataTable dtResultado = new DataTable("Proveedor");

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    string query = "SELECT id_proveedor, nombre_proveedor FROM proveedor.proveedor";
                    SqlCommand comando = new SqlCommand(query, sqlCon);
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(dtResultado);
                }
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string RegistrarCompra(ECompra compra, EDetalleCompra detalle)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("compras.sp_registrar_compra", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_proveedor", compra.IdProveedor);
                    cmd.Parameters.AddWithValue("@id_usuario", compra.IdUsuario);
                    cmd.Parameters.AddWithValue("@descuento_factura", compra.DescuentoFactura);
                    cmd.Parameters.AddWithValue("@id_variacion", detalle.IdVariacion);
                    cmd.Parameters.AddWithValue("@cantidad", detalle.CantidadCompra);
                    cmd.Parameters.AddWithValue("@costo_unitario", detalle.CostoUnitario);
                    cmd.Parameters.AddWithValue("@precio_venta", detalle.PrecioVenta);

                    cmd.ExecuteNonQuery();
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable ObtenerVariaciones()
        {
            DataTable dtResultado = new DataTable("Variacion");

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    string query = @"SELECT v.id_variacion, 
                                    p.nombre_producto + ' - ' + v.descripcion AS nombre_completo,
                                    s.precio_compra
                             FROM producto.variacion v
                             INNER JOIN producto.producto p ON v.id_producto = p.id_producto
                             LEFT JOIN inventario.stock s ON v.id_variacion = s.id_variacion
                             ORDER BY p.nombre_producto";

                    SqlCommand comando = new SqlCommand(query, sqlCon);
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(dtResultado);
                }
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string CambiarEstadoCompra(int idCompra, string nuevoEstado)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Conexion.cadena))
                {
                    sqlCon.Open();
                    string query = "UPDATE compras.compra SET estado_pago = @estado WHERE id_compra = @id";
                    SqlCommand comando = new SqlCommand(query, sqlCon);
                    comando.Parameters.AddWithValue("@estado", nuevoEstado);
                    comando.Parameters.AddWithValue("@id", idCompra);

                    comando.ExecuteNonQuery();
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}