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
    public class CD_Proveedor
    {

        public List<Proveedor> listar() // Método para listar todos los Proveedors
        {
            List<Proveedor> lista = new List<Proveedor>(); // Lista para almacenar los Proveedors

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // Crear un StringBuilder para la consulta SQL
                    query.AppendLine("select IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado from PROVEEDOR"); // Construir la consulta SQL

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Crear el comando SQL
                    cmd.CommandType = CommandType.Text; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada registro
                        {
                            lista.Add(new Proveedor() // Agregar el Proveedor a la lista
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]), // Convertir y asignar IdProveedor
                                Documento = dr["Documento"].ToString(), // Asignar Documento
                                RazonSocial = dr["RazonSocial"].ToString(), // Asignar NombreCompleto
                                Correo = dr["Correo"].ToString(), // Asignar Correo
                                Telefono = dr["Telefono"].ToString(), // Asignar Clave
                                Estado = Convert.ToBoolean(dr["Estado"]), // Convertir y asignar Estado
                                
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Proveedor>(); // En caso de error, retornar una lista vacía  
                }
            }
            return lista; // Retornar la lista de Proveedors
        }



        public int Registrar(Proveedor obj, out string Mensaje)
        {
            int idProveedorgenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    idProveedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value); // Obtener el IdProveedor generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }

            }

            catch (Exception ex) // Manejo de excepciones
            {
                idProveedorgenerado = 0; // En caso de error, retornar 0
                Mensaje = ex.Message; // Asignar el mensaje de la excepción
            }



            return idProveedorgenerado;
        }



        public bool Editar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_ModificarProveedor", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
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









        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Abrir la conexión
                {

                    SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor); // Agregar el parámetro IdProveedor
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

