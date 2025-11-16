using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int IdCliente { get; set; } // Propiedad para el ID del cliente
        public string Documento { get; set; } // Propiedad para el documento del cliente
        public string NombreCompleto { get; set; } // Propiedad para el nombre completo del cliente
        public string Correo { get; set; } // Propiedad para el correo electrónico del cliente
        public string Telefono { get; set; } // Propiedad para el teléfono del cliente
        public bool Estado { get; set; } // Propiedad para el estado del cliente
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro del cliente
    }
}
