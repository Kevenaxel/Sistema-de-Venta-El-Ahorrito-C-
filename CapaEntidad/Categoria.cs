using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Categoria
    {
        public int IdCategoria { get; set; } // Propiedad para el ID de la categoría
        public string Descripcion { get; set; } // Propiedad para la descripción de la categoría
        public bool Estado { get; set; } // Propiedad para el estado de la categoría
        public string FechaCreacion { get; set; } // Propiedad para la fecha de registro de la categoría
    }
}
