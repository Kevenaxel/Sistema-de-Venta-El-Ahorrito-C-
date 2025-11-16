using Capadatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocios objcd_negocio = new CD_Negocios(); // Instancia de la clase CD_Usuar io

        public Negocio ObtenerDatos() // Método para listar todos los usuarios
        {
            return objcd_negocio.ObtenerDatos(); // Llamar al método listar de la capa de datos
        }

        public bool GuardarDatos(Negocio obj, out string Mensaje) // Método para registrar un nuevo usuario
        {
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre \n"; // Validar que el documento no esté vacío
            }

            if (obj.RUC == "")
            {
                Mensaje += "Es necesario el numero de RUC\n"; // Validar que el nombre completo no esté vacío
            }
            if (obj.Direccion == "")
            {
                Mensaje += "Es necesario la direccion \n"; // Validar quee la clave no esté vacío
            }
            if (Mensaje != string.Empty)
            {

                return false; 
            }
            else
            {
                return objcd_negocio.GuardarDatos(obj, out Mensaje); // Llamar al método Registrar de la capa de datos
            }

        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objcd_negocio.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            return objcd_negocio.ActualizarLogo(imagen, out mensaje);
        }
    }
}
