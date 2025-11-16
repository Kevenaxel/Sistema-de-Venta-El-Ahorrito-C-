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
    public class CD_Categoria
    {
        public List<Categoria> listar() // Método para listar todos los Categorias
        {
            List<Categoria> lista = new List<Categoria>(); // Lista para almacenar los Categorias

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // Crear un StringBuilder para la consulta SQL
                    query.AppendLine("select IdCategoria,Descripcion,Estado from CATEGORIA"); // Construir la consulta SQL
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Crear el comando SQL
                    cmd.CommandType = CommandType.Text; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada registro
                        {
                            lista.Add(new Categoria() // Agregar el Categoria a la lista
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]), // Convertir y asignar IdCategoria
                                Descripcion = dr["Descripcion"].ToString(), // Asignar Descripcion
                                Estado = Convert.ToBoolean(dr["Estado"]) // Convertir y asignar Estado

                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Categoria>(); // En caso de error, retornar una lista vacía  
                }
            }
            return lista; // Retornar la lista de Categorias
        }



        public int Registrar(Categoria obj, out string Mensaje)
        {
            int idCategoriagenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarCategoria", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("descripcion", obj.Descripcion); // Agregar el parámetro Descripcion
                    cmd.Parameters.AddWithValue("Estado", obj.Estado); // Agregar el parámetro Estado
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el IdCategoria generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    idCategoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value); // Obtener el IdCategoria generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }

            }

            catch (Exception ex) // Manejo de excepciones
            {
                idCategoriagenerado = 0; // En caso de error, retornar 0
                Mensaje = ex.Message; // Asignar el mensaje de la excepción
            }



            return idCategoriagenerado;
        }



        public bool Editar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarCategoria", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria); // Agregar el parámetro IdCategoria
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion); // Agregar el parámetro Descripcion
                    cmd.Parameters.AddWithValue("Estado", obj.Estado); // Agregar el parámetro Estado
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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









        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Abrir la conexión
                {

                    SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria); // Agregar el parámetro IdCategoria
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;// Parámetro de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtener el valor del parámetro de salida
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

