using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Capadatos
{
    public class CD_Permiso
    {
        public List<Permiso> listar(int idusuario) // Método para listar todos los usuarios
        {
            List<Permiso> lista = new List<Permiso>(); // Lista para almacenar los usuarios

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder(); // Usar StringBuilder para construir la consulta SQL
                    query.AppendLine("select p.IdPermiso, p.NombreMenu from PERMISO p"); // Consulta SQL para obtener los usuarios
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol"); // Crear el comando SQL
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol"); // Tipo de comando
                    query.AppendLine("where u.IdUsuario = @idusuario"); // Abrir la conexión
        

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("@idusuario", idusuario); // Agregar el parámetro idusuario
                    cmd.CommandType = CommandType.Text; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada registro
                        {
                            lista.Add(new Permiso() // Agregar el usuario a la lista
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdPermiso"]) }, // Convertir y asignar IdUsuario
                                NombreMenu = dr["NombreMenu"].ToString(), // Asignar Documento
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Permiso>(); // En caso de error, retornar una lista vacía  
                }
            }
            return lista; // Retornar la lista de usuarios
        }
    }
}
