using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; } // Propiedad para el ID del producto
        public string Codigo { get; set; } // Propiedad para el código del producto
        public string Nombre { get; set; } // Propiedad para el nombre del producto
        public string Descripcion { get; set; } // Propiedad para la descripción del producto
        public Categoria oCategoria { get; set; } // Propiedad para la categoría del producto
        public int Stock{ get; set; } // Propiedad para el stock del producto
        public decimal PrecioCompra { get; set; } // Propiedad para el precio de compra del producto
        public decimal PrecioVenta { get; set; } // Propiedad para el precio de venta del producto
        public bool Estado { get; set; } // Propiedad para el estado del producto
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro del producto
    }
}
