using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Permiso
    {
        public int IdPermiso { get; set; } // Propiedad para el ID del permiso
        public Rol oRol{ get; set; } // Propiedad para el objeto Rol asociado al permiso
        public string NombreMenu { get; set; } // Propiedad para el nombre del menú
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro del permiso
    }
}
