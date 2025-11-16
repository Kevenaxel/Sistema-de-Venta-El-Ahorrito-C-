using Capadatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Rol
    {
        private CD_Rol objcd_rol = new CD_Rol(); // Instancia de la clase CD_Usuario

        public List<Rol> Listar() // Método para listar todos los usuarios
        {
            return objcd_rol.listar(); // Llamar al método listar de la capa de datos
        }
    }
}
