using CapaNegocio;
using RutasGen6.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rutas.Catalogos.Choferes
{
    public partial class ListarChoferes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Es true si se acaba de recargar la página utilizando algín evento. en este caso, el false indica que es la priemra vez que se carga la página.
            {
                try {
                    RefrescarGrid();
                }
                catch(Exception ex){
                    UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
                }
            }
        }



        public void RefrescarGrid() {
            //Llenar el GVChoferes con la lista de ChoferesVo
            GVChoferes.DataSource = BllChoferes.GetListChoferes(null);

            //Actualiza el contenido del grid
            GVChoferes.DataBind();
        }

        protected void GVChoferes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdChofer = GVChoferes.DataKeys[e.RowIndex].Values["Id"].ToString();
            string Resultado = BllChoferes.DelChofer(int.Parse(IdChofer));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Chofer Eliminado con éxito";
                    sub = "";
                    clase = "success";
                    break;
                default:
                    mensaje = "Chofer no puede ser eliminado";
                    sub = "Los choferes en Ruta no pueden ser eliminados";
                    clase = "warning";
                    break;
            }
            UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVChoferes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //este boton va a redireccionar a un nuevo aspx llamado EditarChofer
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string IdChofer = GVChoferes.DataKeys[index].Values["Id"].ToString();
                Response.Redirect("EditarChofer.aspx?Id=" + IdChofer);
            }
        }

        protected void GVChoferes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVChoferes.EditIndex = e.NewEditIndex;
            RefrescarGrid();

        }

        protected void GVChoferes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string IdChofer = GVChoferes.DataKeys[e.RowIndex].Values["Id"].ToString();
            string Nombre = e.NewValues["Nombre"].ToString();
            string ApPaterno = e.NewValues["ApPaterno"].ToString();
            string ApMaterno = e.NewValues["ApMaterno"].ToString();
            string Licencia = e.NewValues["Licencia"].ToString();

            CheckBox ChkAux = (CheckBox)GVChoferes.Rows[e.RowIndex].FindControl("ChkEditDisponible");
            bool Disponibilidad = ChkAux.Checked;

            BllChoferes.UpdChofer(int.Parse(IdChofer), Licencia, null, null, Nombre, ApPaterno, ApMaterno, null, Disponibilidad);

            GVChoferes.EditIndex = -1;
            RefrescarGrid();
            UtilControls.SweetBox("Registro actualizado", "", "success", this.Page, this.GetType());
        }

        protected void GVChoferes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVChoferes.EditIndex = -1;
            RefrescarGrid();
        }

    }
}