using Capadatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_permiso = new CD_Permiso(); // Instancia de la clase CD_Usuario

        public List<Permiso> Listar(int IdUsuario) // Método para listar todos los usuarios
        {
            return objcd_permiso.listar(IdUsuario); // Llamar al método listar de la capa de datos
        }
    }
}
