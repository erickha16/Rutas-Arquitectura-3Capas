using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos{
    internal class Configuracion{
        //El @es para evitar escapes en la cadena de conección (\\)
        private static readonly string _cadenaConexion = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=RutasDB; Integrated Security=True";

        //Obtener caden d econexión a la BD
        public static string cadenaConeccion {
            get { return _cadenaConexion; }
        }
    }
}
