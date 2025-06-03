<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarChofer.aspx.cs" Inherits="Rutas.Catalogos.Choferes.EditarChofer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <h3>Editar chofer</h3>
        <h4>Editando Chofer con id de Empleado:
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h4>

        <div class="col-md-12">
            <div class="form-group">

                <asp:Label ID="lblIdChofer" runat="server" Text=""></asp:Label>

                <asp:Label ID="lblLicencia" runat="server">Licencia</asp:Label>

                <asp:TextBox ID="txtLicencia" runat="server" placeholder="x-00000" MaxLength="7"
                    CssClass="form-control" />

                <asp:Label ID="lblTelefono" runat="server">Teléfono</asp:Label>

                <asp:TextBox ID="txtTelefono" runat="server" placeholder="x-00000" MaxLength="10"
                    CssClass="form-control" />

                <asp:Label ID="lblFechaNacimiento" runat="server">Fecha de Nacimiento</asp:Label>

                <asp:TextBox ID="txtFechaNacimiento" runat="server" placeholder="mm/dd/aaaa" MaxLength="10"
                    CssClass="form-control" />

                <asp:Label ID="lblDisponibilidad" runat="server">Disponibilidad</asp:Label>
                <asp:CheckBox ID="chkDisponibilidad" runat="server" />

                <asp:Label ID="lblSubeImagen" runat="server">Seleccionar Foto</asp:Label>
                <input type="file" id="SubeImagen" runat="server" class="btn btn-file" />

                <asp:Button ID="btnSubeImagen" CssClass="btn btn-primary" Text="Subir" runat="server" OnClick="btnSubeImagen_Click"
                    />

                <asp:Label ID="lblFoto" runat="server">Foto</asp:Label>
                <asp:Image ID="imgFotoChofer" Width="150" Height="100" runat="server" />
                <asp:Image ID="imgFoto" Width="100" Height="100" runat="server" />
                <asp:Label ID="urlFoto" runat="server">Aquí debe aparecer el path de la foto que seleccionaste
                </asp:Label>

                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click"
                     />
            </div>
        </div>
    </div>
</asp:Content>
