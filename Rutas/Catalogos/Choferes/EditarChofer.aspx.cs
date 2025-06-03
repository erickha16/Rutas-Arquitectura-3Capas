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

namespace Rutas.Catalogos.Choferes
{
    public partial class EditarChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListarChoferes.aspx");
                }
                else
                {
                    //Obtener Id del chofer
                    int IdCHofer = int.Parse(Request.QueryString["Id"]);
                    ChoferesVo chofer = BllChoferes.GetChoferById(IdCHofer);

                    //Validar que el chofer es correcto
                    if (chofer.Id == IdCHofer)
                    {
                        //Desplegar la información del chofer
                        this.lblIdChofer.Text = IdCHofer.ToString();
                        this.txtLicencia.Text = chofer.Licencia;
                        this.txtTelefono.Text = chofer.Telefono;
                        this.txtFechaNacimiento.Text = chofer.FechaNacimiento.ToString();
                        this.chkDisponibilidad.Checked = chofer.Disponibilidad;
                        this.imgFotoChofer.ImageUrl = chofer.UrlFoto;
                        this.urlFoto.Text = chofer.UrlFoto;
                    }
                    else
                    {
                        Response.Redirect("ListarChoferes.aspx");
                    }
                }
            }

        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            //Validar que el usuario haya seleccionaod un archivo
            if (SubeImagen.Value != "")
            {
                //Asignar a una variable el nombre del archivo seleccionado
                string FileName = Path.GetFileName(SubeImagen.PostedFile.FileName);

                //Validar que el archivo sea .jpg o .png
                string FileText = Path.GetExtension(FileName).ToLower();

                if ((FileText != ".jpg") && (FileText != ".png") && (FileText != ".jfif"))
                {
                    //Informamos que el archivo no es válido:
                    UtilControls.SweetBox("Error!", "Seleccione un archivo válido (jpg,png, jfif)", "error", this.Page, this.GetType());
                }
                else
                {
                    //Verificar que el directorio donde vamos a guardar el archivo exista
                    string pathDir = Server.MapPath("~/Imagenes/Choferes/");
                    if (!Directory.Exists(pathDir))
                    {
                        //Crea el arbol
                        Directory.CreateDirectory(pathDir);
                    }

                    //Guardamos la imagen en el directorio
                    SubeImagen.PostedFile.SaveAs(pathDir + FileName);
                    string urlfoto = "/Imagenes/Choferes/" + FileName;
                    this.urlFoto.Text = urlfoto;
                    this.imgFoto.ImageUrl = urlfoto;
                    this.btnGuardar.Visible = true;
                }
            }
            else
            {
                //Informamos que el archivo no es válido:
                UtilControls.SweetBox("Error!", "Por favor seleccione un archivo", "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(this.lblIdChofer.Text);
                string telefono = this.txtTelefono.Text;
                DateTime fNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);
                string licencia = this.txtLicencia.Text;
                string urlFoto = this.urlFoto.Text;
                bool disponibilidad = chkDisponibilidad.Checked;


                BllChoferes.UpdChofer(id, licencia, telefono, fNacimiento, null, null, null, urlFoto, disponibilidad);

                UtilControls.SweetBoxConfirm("Extito!", "Chofer Editado exitosamente", "success",
                    "/Catalogos/Choferes/ListarChoferes.aspx", this.Page, this.GetType());

            }
            catch (Exception ex) { 
            
            }
        }
    }
}