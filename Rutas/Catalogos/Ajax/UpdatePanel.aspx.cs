using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rutas.Catalogos.Ajax
{
    public partial class UpdatePanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarHora();
            }
        }

        protected void btnSaludar_Click(object sender, EventArgs e)
        {
            // Simulamos un retardo para ver el UpdateProgress
            System.Threading.Thread.Sleep(1000);

            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                lblSaludo.Text = "Por favor ingresa un nombre";
            }
            else
            {
                lblSaludo.Text = $"¡Hola {nombre}! Bienvenido";
            }

            ActualizarHora();
            CargarTabla();
        }

        private void ActualizarHora()
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void CargarTabla()
        {
            // Simulamos la carga de datos en una tabla con dos columnas
            var datos = new List<DatosTabla>
            {
                new DatosTabla { Columna1 = "Dato 1", Columna2 = "Detalle 1" },
                new DatosTabla { Columna1 = "Dato 2", Columna2 = "Detalle 2" },
                new DatosTabla { Columna1 = "Dato 3", Columna2 = "Detalle 3" }
            };

            gvDatos.DataSource = datos;
            gvDatos.DataBind();
        }

        public class DatosTabla
        {
            public string Columna1 { get; set; }
            public string Columna2 { get; set; }
        }
    }
}