using Capadatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objcd_Categoria = new CD_Categoria(); // Instancia de la clase CD_Usuar io

        public List<Categoria> Listar() // Método para listar todos los Categorias
        {
            return objcd_Categoria.listar(); // Llamar al método listar de la capa de datos
        }

        public int Registrar(Categoria obj, out string Mensaje) // Método para registrar un nuevo Categoria
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la Categoria\n"; // Validar que el descripcion no esté vacío
            }
            if (Mensaje != string.Empty)
            {

                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Categoria.Registrar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }

        }


        public bool Editar(Categoria obj, out string Mensaje) // Método para editar  Categoria
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la Categoria\n"; // Validar que el descripcion no esté vacío
            }

            if (Mensaje != string.Empty)
            {

                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Categoria.Editar(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }



        }


        public bool Eliminar(Categoria obj, out string Mensaje) // Método para eliminar  Categoria
        {
            return objcd_Categoria.Eliminar(obj, out Mensaje); // Llamar al método eliminar de la capa de datos
        }
    }

}