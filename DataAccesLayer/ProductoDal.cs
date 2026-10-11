using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class ProductoDal
    {
        public List<EProducto> ObtenerProductos()
        {
            List<EProducto> lista = new List<EProducto>();

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = @"SELECT 
                                        p.id_producto AS IdProducto, 
                                        CAST(p.id_producto AS VARCHAR) AS Codigo, 
                                        p.nombre_producto AS NombreProducto, 
                                        ISNULL(c.nombre_categoria, 'Sin Categoría') AS Categoria, 
                                        15.00 AS Precio, 
                                        50 AS Stock, 
                                        'Activo' AS Estado
                                     FROM Producto p
                                     LEFT JOIN Catgoria c ON p.id_categoria = c.id_categoria";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EProducto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                NombreProducto = dr["NombreProducto"] != DBNull.Value ? dr["NombreProducto"].ToString() : "",
                                Categoria = dr["Categoria"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                Estado = dr["Estado"].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<EProducto>();
                }
            }

            return lista;
        }

        public bool RegistrarProducto(EProducto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    //se establece el valor predeterminado de id_marca y id_tipo_producto como 1
                    string query = @"INSERT INTO Producto (nombre_producto, id_categoria, id_marca, id_tipo_producto)
                                     VALUES (@NombreProducto, @IdCategoria, 1, 1)";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NombreProducto", obj.NombreProducto);
                    cmd.Parameters.AddWithValue("@IdCategoria", obj.IdCategoria > 0 ? obj.IdCategoria : 1);

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;

                    if (respuesta)
                    {
                        mensaje = "Producto registrado con éxito.";
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