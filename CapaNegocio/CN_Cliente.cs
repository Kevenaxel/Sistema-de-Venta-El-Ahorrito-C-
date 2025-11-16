using Capadatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {

        private CD_Cliente objcd_Cliente = new CD_Cliente(); // Instancia de la clase CD_Usuar io

        public List<Cliente> Listar() // Método para listar todos los Clientes
        {
            return objcd_Cliente.listar(); // Llamar al método listar de la capa de datos
        }

        public int Registrar(Cliente obj, out string Mensaje) // Método para registrar un nuevo Cliente
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Cliente\n"; // Validar que el documento no esté vacío
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del Cliente\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario ingresar el correo del Cliente\n"; // Validar quee la clave no esté vacío
            }
            if (Mensaje != string.Empty)
            {

                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Cliente.Registrar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }

        }


        public bool Editar(Cliente obj, out string Mensaje) // Método para editar  Cliente
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Cliente\n"; // Validar que el documento no esté vacío
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del Cliente\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario ingresar el correo del Cliente\n"; // Validar quee la clave no esté vacío
            }

            if (Mensaje != string.Empty)
            {

                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }



        }


        public bool Eliminar(Cliente obj, out string Mensaje) // Método para eliminar  Cliente
        {
            return objcd_Cliente.Eliminar(obj, out Mensaje); // Llamar al método eliminar de la capa de datos
        }
    }

}

