using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int IdCompra { get; set; } // Propiedad para el ID de la compra
        public Usuario oUsuario { get; set; } // Propiedad para el usuario asociado a la compra
        public Proveedor oProveedor { get; set; } // Propiedad para el proveedor asociado a la compra
        public string TipoDocumento { get; set; } // Propiedad para el tipo de documento de la compra
        public string NumeroDocumento { get; set; } // Propiedad para el número de documento de la compra
        public decimal MontoTotal { get; set; } // Propiedad para el monto total de la compra
        public List<Detalle_Compra> oDetalleCompra{ get; set; } // Propiedad para la lista de detalles de la compra
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro de la compra
    }
}
