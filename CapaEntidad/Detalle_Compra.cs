using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Compra
    {
        public int IdDetalleCompra { get; set; } // Propiedad para el ID del detalle de la compra
        public Producto oProducto { get; set; } // Propiedad para el producto asociado
        public decimal PrecioCompra { get; set; } // Propiedad para el precio de compra del producto
        public decimal PrecioVenta { get; set; } // Propiedad para el precio de venta del producto
        public int Cantidad { get; set; } // Propiedad para la cantidad comprada
        public decimal MontoTotal { get; set; } // Propiedad para el monto total de la compra
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro del detalle de la compra
    }
}
