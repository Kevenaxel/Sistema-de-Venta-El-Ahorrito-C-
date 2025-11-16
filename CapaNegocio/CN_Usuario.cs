using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capadatos; // Importante para acceder a la clase CD_PERMISO
using CapaEntidad; // Importante para acceder a la clase Permiso


namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario(); // Instancia de la clase CD_Usuar io

        public List<Usuario> Listar() // Método para listar todos los usuarios
        {
            return objcd_usuario.listar(); // Llamar al método listar de la capa de datos
        }

        public int Registrar(Usuario obj, out string Mensaje) // Método para registrar un nuevo usuario
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía

            if (obj.Documento == "")
            {
                Mensaje +="Es necesario el documento del usuario\n"; // Validar que el documento no esté vacío
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n"; // Validar quee la clave no esté vacío
            }
            if (Mensaje != string.Empty) { 

                return 0; // Si hay mensajes de error, retornar 0
            }
            else { 
                return objcd_usuario.Registrar(obj,out Mensaje); // Llamar al método Registrar de la capa de datos
            }
               
        }


        public bool Editar(Usuario obj, out string Mensaje) // Método para editar  usuario
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del usuario\n"; // Validar que el documento no esté vacío
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n"; // Validar quee la clave no esté vacío
            }

            if (Mensaje != string.Empty)
            {

                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }



        }


        public bool Eliminar(Usuario obj, out string Mensaje) // Método para eliminar  usuario
        {
            return objcd_usuario.Eliminar(obj, out Mensaje); // Llamar al método eliminar de la capa de datos
        }
    }
}
