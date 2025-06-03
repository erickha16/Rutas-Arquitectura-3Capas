<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarCamiones.aspx.cs" Inherits="Rutas.Catalogos.Camiones.ListarCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="row">
            
            <h3>Lista de Camiones</h3>
            <hr />

            <div class="col-md-12 table-responsive">

                <div class="col-12">
                    <button class="btn btn-success btn-xs"
                        onclick="location.href='AltaCamion.aspx'; return false;">
                        Agregar</button>
                </div>

                <asp:GridView ID="GVCamiones" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-bordered table-striped mt-3 table-condensed&quot;"
                    DataKeyNames="Id"
                    OnRowEditing="GVCamiones_RowEditing"
                    OnRowUpdating="GVCamiones_RowUpdating"
                    OnRowCancelingEdit="GVCamiones_RowCancelingEdit"
                    OnRowCommand="GVCamiones_RowCommand"
                    OnRowDeleting="GVCamiones_RowDeleting">
                    <Columns>
                        <asp:ButtonField 
                            ButtonType="Button" 
                            CommandName="Seleccionado" 
                            Text="Seleccionar"
                            ControlStyle-CssClass="btn btn-success btn-xs">
                            <%--<ControlStyle CssClass="btn btn-success btn-xs"></ControlStyle>--%>
                        </asp:ButtonField>

                        <asp:CommandField 
                            ButtonType="Button" 
                            CancelText="Cancelar" 
                            DeleteText="Eliminar"
                            EditText="Editar" 
                            ShowDeleteButton="True" 
                            ControlStyle-CssClass="btn btn-danger btn-xs">
                            <%--<ControlStyle CssClass="btn btn-danger btn-xs"></ControlStyle>--%>
                        </asp:CommandField>

                        <asp:CommandField 
                            ButtonType="Button" 
                            ShowEditButton="True"
                            ControlStyle-CssClass="btn btn-primary btn-xs">
                            <%--<ControlStyle CssClass="btn btn-primary btn-xs"></ControlStyle>--%>
                        </asp:CommandField>

                        <asp:ImageField 
                            DataImageUrlField="UrlFoto" 
                            HeaderText="Fotografia" 
                            ReadOnly="True"
                            ItemStyle-Width="120px"
                            ControlStyle-Width="120px"
                            ControlStyle-Height="90px">
                            <%--<ControlStyle Height="90px" Width="120px"></ControlStyle>--%>
                            <%--<ItemStyle Width="120px"></ItemStyle>--%>
                        </asp:ImageField>

                        <asp:BoundField 
                            DataField="id" 
                            HeaderText="Id" 
                            ReadOnly="True" />

                        <asp:BoundField 
                            DataField="Matricula" 
                            HeaderText="Matrícula" />

                        <asp:TemplateField HeaderText="Tipo Camion">
                            <ItemTemplate>
                                <asp:Label ID="lblTipoCamion" Text='<%#Eval("TipoCamion")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DDLTipoCamion" CssClass="form-control" runat="server"
                                    Width="300px">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField 
                            DataField="Modelo" 
                            HeaderText="Modelo" 
                            ReadOnly="True" />

                        <asp:BoundField 
                            DataField="Marca" 
                            HeaderText="Marca" 
                            ReadOnly="True" />

                        <asp:BoundField 
                            DataField="Capacidad" 
                            HeaderText="Capacidad" />

                        <asp:BoundField 
                            DataField="Kilometraje" 
                            HeaderText="Kilometraje" />

                        <asp:CheckBoxField 
                            DataField="Disponibilidad" 
                            HeaderText="Disponibilidad" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>
</asp:Content>
