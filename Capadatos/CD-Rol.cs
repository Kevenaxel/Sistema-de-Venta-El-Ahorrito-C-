using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capadatos
{
    public class CD_Rol
    {
        public List<Rol> listar() // Método para listar todos los usuarios
        {
            List<Rol> lista = new List<Rol>(); // Lista para almacenar los usuarios

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder(); // Usar StringBuilder para construir la consulta SQL
                    query.AppendLine("select IdRol,Descripcion from ROL"); // Consulta SQL para obtener los usuarios

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Crear el comando SQL
                    cmd.CommandType = CommandType.Text; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada registro
                        {
                            lista.Add(new Rol() // Agregar el usuario a la lista
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]), // Convertir y asignar IdUsuario
                                Descripcion = dr["Descripcion"].ToString(), // Asignar Documento
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Rol>(); // En caso de error, retornar una lista vacía  
                }
            }
            return lista; // Retornar la lista de usuarios
        }
    }
}
