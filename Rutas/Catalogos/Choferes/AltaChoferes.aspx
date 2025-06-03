<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaChoferes.aspx.cs" Inherits="Rutas.Catalogos.Choferes.AltaChoferes" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Alta de chofer</h3>
            <hr />

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtNombre" ControlToValidate="txtNombre" CssClass="txt-danger" runat="server" ErrorMessage="Nombre del chofer requerido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblApPaterno" runat="server" Text="Apellido Paterno"></asp:Label>
                    <asp:TextBox ID="txtApPaterno" runat="server" placeholder="Apellido Paterno" MaxLength="150"
                        CssClass="form-control">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtApPaterno"
                        CssClass="text-danger" runat="server" ErrorMessage="Ap. paterno de chofer requerido">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblApMaterno" runat="server" Text="Apellido Materno"></asp:Label>
                    <asp:TextBox ID="txtApMaterno" runat="server" placeholder="Apellido Materno" MaxLength="150"
                        CssClass="form-control">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtApMaterno"
                        CssClass="text-danger"
                        runat="server" ErrorMessage="Ap. materno de chofer requerido"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblLicencia" runat="server" Text="Licencia"></asp:Label>
                    <asp:TextBox ID="txtLicencia" runat="server" placeholder="X-00000" MaxLength="7"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtLicencia" ControlToValidate="txtLicencia"
                        CssClass="text-danger" runat="server"
                        ErrorMessage="Número de Licencia de chofer requerido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" placeholder="(999) 999-9999" MaxLength="10"
                        CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento"></asp:Label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" placeholder="" MaxLength="10"
                        CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">

                    <asp:Label ID="lblSubirImagen" runat="server" Text="Seleccionar Foto"></asp:Label>
                    <div class="row">
                        <div class="col-md-3">
                            <input type="file" id="SubeImagen" runat="server" class="btn btn-file" />
                        </div>
                        <div class="col-md-9">
                            <asp:Button ID="btnSubeImagen" CssClass="btn btn-primary" Text="Subir" runat="server" OnClick="btnSubeImagen_Click"
                                />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblFoto" runat="server">Foto</asp:Label>
                    <asp:Image ID="imgFotoChofer" Width="150" Height="100" runat="server" />
                    <asp:Label ID="urlFoto" runat="server">Aquí aparece el path de la foto que seleccionaste
                    </asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" Visible="false" CssClass="btn btn-primary" runat="server"
                        Text="Guardar" OnClick="btnGuardar_Click" />
                </div>
            </div>
            </div>
        </div>
</asp:Content>
