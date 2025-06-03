using CapaNegocio;
using RutasGen6.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Rutas.Util.Enumeradores;

namespace Rutas.Catalogos.Camiones
{
    public partial class AltaCamion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // es la primer carga de la pagina
            {
                // llenar los SELECT del formulario
                UtilControls.EnumToListBox(typeof(Marca), DDLMarca, false);
                UtilControls.EnumToListBox(typeof(Tipo), DDLTipoCamion, false);

                DDLMarca.Items.Insert(0, new ListItem("Selecciona Marca", ""));
                DDLModelo.Items.Insert(0, new ListItem("Selecciona Modelo", ""));
                DDLTipoCamion.Items.Insert(0, new ListItem("Selecciona Tipo", ""));

                DDLMarca.SelectedIndex = 0;
                DDLModelo.SelectedIndex = 0;
                DDLTipoCamion.SelectedIndex = 0;

                LlenaModelo();
            }
        }

        private void LlenaModelo()
        {
            int Minimo = DateTime.Now.Year - 20;
            int Maximo = DateTime.Now.Year + 2;
            var Rango = Enumerable.Range(Minimo, Maximo - Minimo);

            DDLModelo.DataSource = Rango;
            DDLModelo.DataBind();
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que el usuario haya seleccionado un archivo
                if (SubeImagen.Value != "")
                {
                    //Subimos el archivo  LOWER CASE    UPPER CASE
                    string FileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
                    //Validamos que el archivo sea .jpg o .png  ToUpper
                    string FileExt = Path.GetExtension(FileName).ToLower();
                    if ((FileExt != ".jpg") && (FileExt != ".png") && (FileExt != ".jfif"))
                    {
                        //Informamos al usuario que el archivo no es válido
                        UtilControls.SweetBox("Atención!", "Seleccione un archivo válido", "warning", this.Page, this.GetType());
                    }
                    else
                    {
                        //Verificar que el directorio destino exista
                        string PathDir = Server.MapPath("~/Imagenes/Camiones/");
                        if (!Directory.Exists(PathDir))
                        {
                            //Creamos el directorio
                            Directory.CreateDirectory(PathDir);
                        }
                        //Guardamos el archivo
                        SubeImagen.PostedFile.SaveAs(PathDir + FileName);
                        string urlfoto = "/Imagenes/Camiones/" + FileName;
                        this.urlFoto.Text = urlfoto;
                        this.imgFotoCamion.ImageUrl = urlfoto;
                        btnGuardar.Visible = true;
                    }
                }
                else
                {
                    //Informamos al usuario que el archivo no es válido
                    UtilControls.SweetBox("Atención!", "Seleccione un archivo válido", "warning", this.Page, this.GetType());
                }
            }
            catch (Exception ex)
            {
                //Enviar mensaje de error al usuario
                UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Matricula = txtMatricula.Text;
                string TipoCamion = DDLTipoCamion.SelectedValue;
                int Modelo = int.Parse(DDLModelo.SelectedValue);
                string Marca = DDLMarca.SelectedValue;
                int Capacidad = int.Parse(txtCapacidad.Text);
                double Kilometraje = double.Parse(txtKilometraje.Text);
                string urlFoto = this.urlFoto.Text;
                string Resultado =
                BllCamiones.InsCamion(Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, urlFoto);

                if (Resultado.IndexOf("Camión agregado") > -1)
                {
                    UtilControls.SweetBoxConfirm("OK!", Resultado, "success", "ListarCamiones.aspx", this.Page, this.GetType());
                }
                else
                {
                    //Mensaje de error
                    UtilControls.SweetBox("Atención!", Resultado, "warning", this.Page, this.GetType());
                }
            }
            catch (Exception ex)
            {
                //Enviar mensaje de error
                UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }

    }
}