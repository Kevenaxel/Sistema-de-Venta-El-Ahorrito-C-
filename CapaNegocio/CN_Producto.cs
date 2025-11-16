using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capadatos; // Importante para acceder a la clase CD_PERMISO

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objcd_Producto = new CD_Producto(); // Instancia de la clase CD_Producto
        public List<Producto> Listar() // Método para listar todos los Productos
        {
            return objcd_Producto.Listar(); // Llamar al método listar de la capa de datos
        }

        public int Registrar(Producto obj, out string Mensaje) // Método para registrar un nuevo Producto
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del Producto\n"; // Validar que el documento no esté vacío
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la Descripcion del Producto\n"; // Validar quee la clave no esté vacío
            }

            if (Mensaje != string.Empty)
            {

                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Producto.Registrar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }

        }


        public bool Editar(Producto obj, out string Mensaje) // Método para editar  Producto
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía
            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del Producto\n"; // Validar que el documento no esté vacío
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la Descripcion del Producto\n"; // Validar quee la clave no esté vacío
            }

            if (Mensaje != string.Empty)
            {

                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Producto.Editar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }
        }


        public bool Eliminar(Producto obj, out string Mensaje) // Método para eliminar  Producto
        {
            return objcd_Producto.Eliminar(obj, out Mensaje); // Llamar al método eliminar de la capa de datos
        }
    }
}
