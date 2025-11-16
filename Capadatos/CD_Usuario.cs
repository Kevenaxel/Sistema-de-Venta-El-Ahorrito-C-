using CapaEntidad; // Importante para acceder a la clase Usuario
using System;
using System.Collections.Generic;
using System.Data; // Importante para trabajar con DataSet y DataTable
using System.Data.SqlClient; // Importante para trabajar con SQL Server
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Capadatos
{
    public class CD_Usuario
    {
        public List<Usuario> listar() // Método para listar todos los usuarios
        {
            List<Usuario> lista = new List<Usuario>(); // Lista para almacenar los usuarios

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // Crear un StringBuilder para la consulta SQL
                    query.AppendLine("select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from usuario u"); // Construir la consulta SQL
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol"); // Agregar la cláusula JOIN


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Crear el comando SQL
                    cmd.CommandType = CommandType.Text; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada registro
                        {
                            lista.Add(new Usuario() // Agregar el usuario a la lista
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]), // Convertir y asignar IdUsuario
                                Documento = dr["Documento"].ToString(), // Asignar Documento
                                NombreCompleto = dr["NombreCompleto"].ToString(), // Asignar NombreCompleto
                                Correo = dr["Correo"].ToString(), // Asignar Correo
                                Clave = dr["Clave"].ToString(), // Asignar Clave
                                Estado = Convert.ToBoolean(dr["Estado"]), // Convertir y asignar Estado
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString()} // Crear y asignar el objeto Rol
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Usuario>(); // En caso de error, retornar una lista vacía  
                }
            }
            return lista; // Retornar la lista de usuarios
        } 



        public int  Registrar(Usuario obj, out string Mensaje) {
            int idusuariogenerado = 0; 
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {

                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión
                    
                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value); // Obtener el IdUsuario generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }

            }

            catch (Exception ex) // Manejo de excepciones
            {
                idusuariogenerado = 0; // En caso de error, retornar 0
                Mensaje = ex.Message; // Asignar el mensaje de la excepción
            }



            return idusuariogenerado; 
        }



        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }

            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }



            return respuesta;
        }









        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false; 
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Abrir la conexión
                {

                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario); // Agregar el parámetro IdUsuario
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;// Parámetro de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output; // Parámetro de salida
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value); // Obtener el valor del parámetro de salida
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }

            }

            catch (Exception ex) // Manejo de excepciones
            {
                respuesta = false; // En caso de error, retornar false
                Mensaje = ex.Message; // Asignar el mensaje de la excepción
            }

            return respuesta;
        }










    }
}
