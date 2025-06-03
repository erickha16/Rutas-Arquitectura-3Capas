using CapaNegocio;
using RutasGen6.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rutas.Catalogos.Camiones
{
    public partial class ListarCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RefrescaGrid();
                }
                catch (Exception ex)
                {
                    UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
                }
            }
        }

        public void RefrescaGrid()
        {
            //Llenar el grid con una lista de CamionVO
            GVCamiones.DataSource = BllCamiones.GetLstCamiones(null);
            GVCamiones.DataBind();
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label lbltipoC = (Label)GVCamiones.Rows[e.NewEditIndex].FindControl("lblTipoCamion");
            string tipoC = lbltipoC.Text;
            //Ponemos el renglón seleccionado en modo edición

            GVCamiones.EditIndex = e.NewEditIndex;
            RefrescaGrid();

            DropDownList DDLTipoCamionAux = (DropDownList)GVCamiones.Rows[e.NewEditIndex].FindControl("DDLTipoCamion");
            UtilControls.EnumToListBox(typeof(Util.Enumeradores.Tipo), DDLTipoCamionAux, false);
            DDLTipoCamionAux.SelectedValue = tipoC;
        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string IdCamion = GVCamiones.DataKeys[e.RowIndex].Values["Id"].ToString();
            string Matricula = e.NewValues["Matricula"].ToString();
            //string Modelo = e.NewValues["Modelo"].ToString();
            //string Marca = e.NewValues["Marca"].ToString();

            int Capacidad = int.Parse(e.NewValues["Capacidad"].ToString());
            double Kilometraje = double.Parse(e.NewValues["Kilometraje"].ToString());

            DropDownList TipoCamionAux = (DropDownList)GVCamiones.Rows[e.RowIndex].FindControl("DDLTipoCamion");

            string TipoCamion = TipoCamionAux.SelectedValue;

            bool Disponibilidad = bool.Parse(e.NewValues["Disponibilidad"].ToString());

            try
            {
                string resultado = BllCamiones.UpdCamion(int.Parse(IdCamion), Matricula, TipoCamion, null, null, Capacidad, Kilometraje, Disponibilidad, null);
                GVCamiones.EditIndex = -1;
                RefrescaGrid();
                UtilControls.SweetBox(resultado, "", "success", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVCamiones.EditIndex = -1;
            RefrescaGrid();
        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionado")
            {  //Server.Transfer
                int index = int.Parse(e.CommandArgument.ToString());
                string IdCamion = GVCamiones.DataKeys[index].Values["Id"].ToString();
                Response.Redirect("EditarCamion.aspx?Id=" + IdCamion);
            }
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdCamion = GVCamiones.DataKeys[e.RowIndex].Values["Id"].ToString();
            try
            {
                string Resultado = BllCamiones.DelCamion(int.Parse(IdCamion));

                string mensaje = "";
                //string sub = "";
                string clase = "";

                if (Resultado == "Camión eliminado")
                {
                    mensaje = "OK!";
                    clase = "success";
                    //sub = Resultado;
                }
                else
                {
                    mensaje = "Atención!";
                    clase = "warning";
                    //sub = Resultado;
                }



                RefrescaGrid();
                UtilControls.SweetBox(mensaje, Resultado, clase, this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }

    }
}
