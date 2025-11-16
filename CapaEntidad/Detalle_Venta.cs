using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Venta
    {
        public int IdVenta { get; set; } // Identificador único de la venta
        public Producto oProducto { get; set; } // Producto asociado al detalle de venta
        public decimal PrecioVenta { get; set; } // Precio de venta del producto
        public int Cantidad { get; set; } // Cantidad de productos vendidos
        public decimal SubTotal { get; set; } // Subtotal calculado (PrecioVenta * Cantidad)
        public string FechaCreacion { get; set; } // Fecha de registro del detalle de venta
    }
}
