using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedor
    {
        public int IdProveedor { get; set; } // Propiedad para el ID del proveedor
        public string Documento { get; set; } // Propiedad para el documento del proveedor
        public string RazonSocial { get; set; } // Propiedad para la razón social del proveedor
        public string Correo { get; set; } // Propiedad para el correo electrónico del proveedor
        public string Telefono { get; set; } // Propiedad para el teléfono del proveedor
        public bool Estado { get; set; } // Propiedad para el estado del proveedor
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro del proveedor

    }
}
