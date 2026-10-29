using System;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public static class Conexion
    {
        public static string cadena = "Server=localhost; Database=candy_shop_2; Integrated Security=True; TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}


