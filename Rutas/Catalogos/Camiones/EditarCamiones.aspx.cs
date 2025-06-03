using CapaNegocio;
using RutasGen6.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;
using static Rutas.Util.Enumeradores;

namespace Rutas.Catalogos.Camiones
{
    public partial class EditarCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Primera carga de la página
            {
                //Llena las lista del formulario
                UtilControls.EnumToListBox(typeof(Marca), DDLMarca, false);
                UtilControls.EnumToListBox(typeof(Tipo), DDLTipoCamion, false);
                LlenaModelo();
                DDLMarca.Items.Insert(0, new ListItem("Selecciona Marca", ""));
                DDLModelo.Items.Insert(0, new ListItem("Selecciona Modelo", ""));
                DDLTipoCamion.Items.Insert(0, new ListItem("Selecciona Tipo", ""));
                DDLMarca.SelectedIndex = 0;
                DDLModelo.SelectedIndex = 0;
                DDLTipoCamion.SelectedIndex = 0;

                //Obtenemos la información del Camión seleccionado
                string Id = Request.QueryString["Id"];
                if ((Id == null))
                {
                    Response.Redirect("ListarCamiones.aspx");
                }
                else
                {
                    //Verificamos que el camion exista
                    CamionesVo Camion = BllCamiones.GetCamionById(int.Parse(Id));
                    if (Camion.Id == int.Parse(Id))
                    {
                        //Desplegamos la información del camion
                        lblIdCamion.Text = Camion.Id.ToString();
                        txtMatricula.Text = Camion.Matricula;
                        txtCapacidad.Text = Camion.Capacidad.ToString();
                        txtKilometraje.Text = Camion.Kilometraje.ToString();
                        DDLTipoCamion.SelectedValue = Camion.TipoCamion;
                        DDLMarca.SelectedValue = Camion.Marca;
                        DDLModelo.SelectedValue = Camion.Modelo.ToString();
                        imgFotoCamion.ImageUrl = Camion.UrlFoto;
                        this.urlFoto.Text = Camion.UrlFoto;
                        chkDisponibilidad.Checked = Camion.Disponibilidad;
                    }
                    else
                    {
                        Response.Redirect("ListarCamiones.aspx");
                    }
                }
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdCamion = int.Parse(lblIdCamion.Text);
                string Matricula = txtMatricula.Text;
                string TipoCamion = DDLTipoCamion.SelectedValue;
                int Modelo = int.Parse(DDLModelo.SelectedValue);
                string Marca = DDLMarca.SelectedValue;
                int Capacidad = int.Parse(txtCapacidad.Text);
                double Kilometraje = double.Parse(txtKilometraje.Text);
                string urlfoto = this.urlFoto.Text;
                bool Disponibilidad = chkDisponibilidad.Checked;
                string Resultado =
                BllCamiones.UpdCamion(IdCamion, Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, Disponibilidad, urlfoto);
                if (Resultado.IndexOf("Camión actualizado correctamente") > -1)
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

                UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            //Guardar foto.
            try
            {
                //Validar que el usuario haya seleccionado un archivo
                if (SubeImagen.Value != "")
                {
                    //Subimos el archivo
                    string FileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
                    //Validamos que el archivo sea .jpg o .png
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
                        imgFotoCamion.ImageUrl = urlfoto;
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

    }
}