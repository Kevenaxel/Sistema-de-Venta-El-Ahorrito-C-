using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; } // Propiedad para el ID de la venta
        public Usuario oUsuario { get; set; } // Propiedad para el usuario asociado a la venta
        public string TipoDocumento { get; set; } // Propiedad para el tipo de documento de la venta
        public string NumeroDocumento { get; set; } // Propiedad para el número de documento de la venta
        public string FechaRegistro { get; set; }
        public string DocumentoCliente { get; set; } // Propiedad para el documento del cliente
        public string NombreCliente { get; set; } // Propiedad para el nombre del cliente
        public decimal MontoPago { get; set; } // Propiedad para el monto pagado en la venta
        public decimal MontoCambio { get; set; } // Propiedad para el monto de cambio en la venta
        public decimal MontoTotal { get; set; } // Propiedad para el monto total de la venta
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro de la venta
        public List<Detalle_Venta> oDetalle_Venta { get; set; }

    }
}
