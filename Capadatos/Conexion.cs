using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // Importante para acceder a la configuración

namespace Capadatos
{
    public class Conexion
    {
        public static string cadena = ConfigurationManager
            .ConnectionStrings["cadena_conexion"]
            .ConnectionString;
    }
}
