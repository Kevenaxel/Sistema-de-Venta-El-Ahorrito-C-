using Capadatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objcd_Proveedor = new CD_Proveedor(); // Instancia de la clase CD_Usuar io

        public List<Proveedor> Listar() // Método para listar todos los Proveedors
        {
            return objcd_Proveedor.listar(); // Llamar al método listar de la capa de datos
        }

        public int Registrar(Proveedor obj, out string Mensaje) // Método para registrar un nuevo Proveedor
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Proveedor\n"; // Validar que el documento no esté vacío
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesaria la razon social del Proveedor\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del Proveedor\n"; // Validar quee la clave no esté vacío
            }
            if (Mensaje != string.Empty)
            {

                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Proveedor.Registrar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }

        }


        public bool Editar(Proveedor obj, out string Mensaje) // Método para editar  Proveedor
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Proveedor\n"; // Validar que el documento no esté vacío
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesaria la razon social del Proveedor\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del Proveedor\n"; // Validar quee la clave no esté vacío
            }
            if (Mensaje != string.Empty)
            {

                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Proveedor.Editar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }



        }


        public bool Eliminar(Proveedor obj, out string Mensaje) // Método para eliminar  Proveedor
        {
            return objcd_Proveedor.Eliminar(obj, out Mensaje); // Llamar al método eliminar de la capa de datos
        }
    }

}
