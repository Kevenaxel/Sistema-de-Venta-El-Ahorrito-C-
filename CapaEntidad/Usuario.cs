using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; } //   Propiedad para el ID del usuario
        public string Documento { get; set; } // Propiedad para el documento del usuario
        public string NombreCompleto { get; set; } // Propiedad para el nombre completo del usuario
        public string Correo { get; set; } // Propiedad para el correo electrónico
        public string Clave { get; set; } // Propiedad para la clave de usuario
        public Rol oRol { get; set; } // Propiedad para el rol del usuario
        public bool Estado { get; set; } // Propiedad para el estado del usuario
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro del usuario
    }
}
