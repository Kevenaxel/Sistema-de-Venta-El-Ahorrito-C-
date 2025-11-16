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
    public class CD_Cliente
    {

        public List<Cliente> listar() // Método para listar todos los Clientes
        {
            List<Cliente> lista = new List<Cliente>(); // Lista para almacenar los Clientes

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // Crear un StringBuilder para la consulta SQL
                    query.AppendLine("select IdCliente,Documento,NombreCompleto,Correo,Telefono,Estado from CLIENTE"); // Construir la consulta SQL
                    


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Crear el comando SQL
                    cmd.CommandType = CommandType.Text; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada registro
                        {
                            lista.Add(new Cliente() // Agregar el Cliente a la lista
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]), // Convertir y asignar IdCliente
                                Documento = dr["Documento"].ToString(), // Asignar Documento
                                NombreCompleto = dr["NombreCompleto"].ToString(), // Asignar NombreCompleto
                                Correo = dr["Correo"].ToString(), // Asignar Correo
                                Telefono = dr["Telefono"].ToString(), // Asignar Clave
                                Estado = Convert.ToBoolean(dr["Estado"]), // Convertir y asignar Estado
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Cliente>(); // En caso de error, retornar una lista vacía  
                }
            }
            return lista; // Retornar la lista de Clientes
        }



        public int Registrar(Cliente obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarCliente", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    idClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value); // Obtener el IdCliente generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }

            }

            catch (Exception ex) // Manejo de excepciones
            {
                idClientegenerado = 0; // En caso de error, retornar 0
                Mensaje = ex.Message; // Asignar el mensaje de la excepción
            }



            return idClientegenerado;
        }



        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_ModificarCliente", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                   
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
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
        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Abrir la conexión
                {

                    SqlCommand cmd = new SqlCommand("delete from cliente where IdCliente = @id", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);
                    cmd.CommandType = CommandType.Text; // Tipo de comando
                    oconexion.Open(); // Abrir la conexión

                   respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
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

