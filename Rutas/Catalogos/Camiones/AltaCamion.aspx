<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCamion.aspx.cs" Inherits="Rutas.Catalogos.Camiones.AltaCamion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Alta camión</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">

                <div class="form-group">
                    <label for="<%=txtMatricula.ClientID%>">Matricula</label>
                    <asp:TextBox ID="txtMatricula" CssClass="form-control" runat="server" MaxLength="8"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px">
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RequiredFieldValidator ID="RFVMatricula" ControlToValidate="txtMatricula" CssClass="text-danger" runat="server"
                                ErrorMessage="Matricula requerida"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="form-group">

                    <label for="<%=DDLTipoCamion.ClientID%>">Tipo Camion</label>
                    <asp:DropDownList ID="DDLTipoCamion" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVTipoCamion" ControlToValidate="DDLTipoCamion" CssClass="text-danger" runat="server"
                        ErrorMessage="Selecciona el tipo de camión"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%=DDLModelo.ClientID%>">Modelo</label>
                    <asp:DropDownList ID="DDLModelo" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVModelo" ControlToValidate="DDLModelo" CssClass="text-danger" runat="server"
                        ErrorMessage="Selecciona el modelo de camión"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%=DDLMarca.ClientID%>">Marca</label>
                    <asp:DropDownList ID="DDLMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVMarca" ControlToValidate="DDLMarca" CssClass="text-danger" runat="server"
                        ErrorMessage="Selecciona la marca de camión"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="<%=txtCapacidad.ClientID%>">Capacidad</label>
                    <asp:TextBox ID="txtCapacidad" CssClass="form-control" runat="server"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px">
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RequiredFieldValidator ID="RFVCapacidad" ControlToValidate="txtCapacidad" CssClass="text-danger" runat="server"
                                ErrorMessage="Capacidad requerida"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="<%=txtKilometraje.ClientID%>">Kilometraje</label>
                    <asp:TextBox ID="txtKilometraje" CssClass="form-control" runat="server"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px">
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RequiredFieldValidator ID="RFVKilometraje" ControlToValidate="txtKilometraje" CssClass="text-danger" runat="server"
                                ErrorMessage="Kilometraje requerido"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="">Seleccionar Foto</label>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="input-group">
                                <label class="input-group-btn">
                                    <span class="btn btn-primary">Buscar
                                        <input type="file" id="SubeImagen" runat="server" class="btn btn-file" style="display: none;" />
                                    </span>
                                </label>
                                <input type="text" id="InfoImg" readonly style="background-color: transparent; border: 0; margin-left: 10px;" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="btnSubeImagen" runat="server" Text="Subir" CssClass="btn btn-primary btn-xs" OnClick="btnSubeImagen_Click"
                                OnClientClick="MuestraFoto();" />
                        </div>
                    </div>
                </div>

                <div class="form-group" id="imgFoto" style="display: none;">
                    <asp:Label ID="lblFoto" runat="server">Foto</asp:Label>
                    <asp:Image ID="imgFotoCamion" Width="150" Height="100" runat="server" />
                    <asp:Label ID="urlFoto" runat="server">Aquí aparece el path de la foto que seleccionaste</asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6 col-md-offset-6">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" Visible="false" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            if ($("#<%=urlFoto.ClientID%>").html() != "") {
            $("#imgFoto").show();
        }

        $("#<%=SubeImagen.ClientID%>").on('change', function () {
            var label = $(this)["0"].files["0"].name;

            $("#InfoImg").val(label);
        });
    });

    </script>
    <script>

        function MuestraFoto() {
            $("#imgFoto").show();
            return true;
        }
    </script>

</asp:Content>

