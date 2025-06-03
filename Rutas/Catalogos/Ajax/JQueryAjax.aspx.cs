using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rutas.Catalogos.Ajax
{
    public partial class JQueryAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Saludar(string nombre)
        {
            // Simula una pequeña demora para el procesamiento.
            System.Threading.Thread.Sleep(1000);

            if (string.IsNullOrEmpty(nombre))
            {
                return "Por favor ingresa un nombre";
            }

            return $"¡Hola {nombre}! Bienvenido";
        }

        [WebMethod]
        public static List<DatosTabla> ObtenerDatosTabla()
        {
            // Simula la carga de datos en una tabla
            var datos = new List<DatosTabla>
            {
                new DatosTabla { Columna1 = "Dato 1", Columna2 = "Detalle 1" },
                new DatosTabla { Columna1 = "Dato 2", Columna2 = "Detalle 2" },
                new DatosTabla { Columna1 = "Dato 3", Columna2 = "Detalle 3" }
            };

            return datos;
        }

        public class DatosTabla
        {
            public string Columna1
            {
                get; set;
            }
            public string Columna2
            {
                get; set;
            }
        }
    }
}