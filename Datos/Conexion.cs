using System.Data;
using Microsoft.Data.SqlClient;

namespace Tarea3POO2
{
    public class Conexion
    {
        // Cambiar SQLEXPRESS si mi servidor tiene otro nombre.
        public string cadena = @"Server=.\SQLEXPRESS;Database=pubs;Integrated Security=True;TrustServerCertificate=True;";

        public DataTable Consultar(string consulta)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                adaptador.Fill(tabla);
            }
            return tabla;
        }

        public bool ValidarUsuario(string usuario, string clave)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                string sql = "SELECT COUNT(*) FROM app_users WHERE username=@usuario " +
                             "AND password_hash=HASHBYTES('SHA2_256', @clave) AND active=1";
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@clave", clave);
                    return Convert.ToInt32(comando.ExecuteScalar()) > 0;
                }
            }
        }
    }
}
