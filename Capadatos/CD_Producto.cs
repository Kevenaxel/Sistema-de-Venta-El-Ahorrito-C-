using CapaEntidad; // Importante para acceder a la clase Producto
using System;
using System.Collections.Generic;
using System.Data; // Importante para trabajar con DataSet y DataTable
using System.Data.SqlClient; // Importante para trabajar con SQL Server
using System.Linq;
using System.Text;
using System.Threading.Tasks; 





namespace Capadatos
{
    public class CD_Producto
    {
        public List<Producto> Listar() // Método para listar todos los Productos
        {
            List<Producto> lista = new List<Producto>(); // Lista para almacenar los Productos

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder(); // Crear un StringBuilder para la consulta SQL
                    query.AppendLine("select IdProducto, Codigo, Nombre, p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioCompra,PrecioVenta,p.Estado from PRODUCTO p"); // Construir la consulta SQL
                    query.AppendLine("inner join CATEGORIA c on c.IdCategoria = p.IdCategoria"); // Agregar la cláusula JOIN
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Crear el comando SQL
                    cmd.CommandType = CommandType.Text; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada fila del resultado
                        {
                            lista.Add(new Producto() // Agregar un nuevo Producto a la lista
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]), 
                                Codigo = dr["Codigo"].ToString(), 
                                Nombre = dr["Nombre"].ToString(), 
                                Descripcion = dr["Descripcion"].ToString(), 
                                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DescripcionCategoria"].ToString() },
                                Stock = Convert.ToInt32(dr["Stock"].ToString()),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()), 
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()), 
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Producto>(); // En caso de error, retornar una lista vacía  
                }
            }
            return lista; // Retornar la lista de Productos
        }



        public int Registrar(Producto obj, out string Mensaje)
        {
            int idProductogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando

                    oconexion.Open(); // Abrir la conexión

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    idProductogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value); // Obtener el IdProducto generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }

            }

            catch (Exception ex) // Manejo de excepciones
            {
                idProductogenerado = 0; // En caso de error, retornar 0
                Mensaje = ex.Message; // Asignar el mensaje de la excepción
            }



            return idProductogenerado;
        }



        public bool Editar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto); // Agregar el parámetro IdProducto
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo); // Agregar el parámetro Código
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Agregar el parámetro Nombre
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion); // Agregar el parámetro Descripción
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria); // Agregar el parámetro IdCategoria
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









        public bool Eliminar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Abrir la conexión
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", oconexion); // Crear el comando SQL
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto); // Agregar el parámetro IdProducto
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;// Parámetro de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida
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