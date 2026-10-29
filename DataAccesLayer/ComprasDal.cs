using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccessLayer
{
    public class ComprasDal
    {
        public DataTable ObtenerCompras()
        {
            DataTable dtResultado = new DataTable("Compra");

            try
            {
                using (SqlConnection sqlCon = Conexion.ObtenerConexion())
                {
                    sqlCon.Open();
                    SqlCommand comando = new SqlCommand("Compras.sp_obtenercompras", sqlCon);
                    comando.CommandType = CommandType.StoredProcedure;

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
                using (SqlConnection sqlCon = Conexion.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("sp_obtenerproveedores", sqlCon))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(comando))
                        {
                            da.Fill(dtResultado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de error, puedes manejarlo limpiamente
            }

            return dtResultado;
        }

        public string RegistrarCompra(ECompra compra, EDetalleCompra detalle)
        {
            try
            {
                using (SqlConnection sqlCon = Conexion.ObtenerConexion())
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Compras.sp_registrar_compra", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_proveedor", compra.IdProveedor);
                    cmd.Parameters.AddWithValue("@id_usuario", compra.IdUsuario);
                    cmd.Parameters.AddWithValue("@descuento_factura", compra.DescuentoFactura);
                    cmd.Parameters.AddWithValue("@id_variacion", detalle.IdVariacion);
                    cmd.Parameters.AddWithValue("@cantidad", detalle.CantidadCompra);
                    cmd.Parameters.AddWithValue("@costo_unitario", detalle.CostoUnitario);
                    cmd.Parameters.AddWithValue("@precio_venta", detalle.PrecioVenta);

                    SqlParameter outputId = new SqlParameter("@id_compra_generada", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputId);

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
                using (SqlConnection sqlCon = Conexion.ObtenerConexion())
                {
                    sqlCon.Open();
                    SqlCommand comando = new SqlCommand("Producto.sp_obtenervariaciones", sqlCon);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@solo_activas", 1);

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
                using (SqlConnection sqlCon = Conexion.ObtenerConexion())
                {
                    sqlCon.Open();
                    SqlCommand comando = new SqlCommand("Compras.sp_cambiar_estado_pago", sqlCon);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@id_compra", idCompra);
                    comando.Parameters.AddWithValue("@estado_pago", nuevoEstado);

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