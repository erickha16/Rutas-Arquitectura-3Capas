<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePanel.aspx.cs" Inherits="Rutas.Catalogos.Ajax.UpdatePanel" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-5">
        <h2>Ejemplo de UpdatePanel</h2>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    Última actualización: 
                    <asp:Label ID="lblTime" runat="server" CssClass="badge badge-info" />
                </div>
                
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingresa un nombre" />
                
                <asp:Button ID="btnSaludar" runat="server" 
                            CssClass="btn btn-primary mt-3" 
                            Text="Saludar" 
                            OnClick="btnSaludar_Click" />
                
                <br /><br />

                <!--Respuesta1-->
                <asp:Label ID="lblSaludo" runat="server" CssClass="alert alert-success mt-3" />

                <br /><br />

                <!--Respuesta2: Tabla con datos simulados-->
                <asp:GridView ID="gvDatos" runat="server" CssClass="table table-bordered mt-3" />

            </ContentTemplate>
        </asp:UpdatePanel>

        <!--<asp:UpdateProgress> se activará cuando se realice una solicitud asincrónica en el UpdatePanel1.-->
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <button id="loader" class="btn btn-primary" type="button" disabled>
                    <span class="spinner-border spinner-border-sm" aria-hidden="true"></span>
                    <span role="status" class="sr-only">Procesando...</span>
                </button>
            </ProgressTemplate>
        </asp:UpdateProgress>

    </div>
</asp:Content>
