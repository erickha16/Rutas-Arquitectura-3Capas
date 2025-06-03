<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarChoferes.aspx.cs" Inherits="Rutas.Catalogos.Choferes.ListarChoferes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <h3>Choferes</h3>
            <hr />
            <div class="col-12">
                <button class="btn btn-success btn-xs" onClick="location.href='AltaChoferes.aspx'; return false;">Agregar</button>
            </div>
            <!-- <asp:GridView ID="GVChoferes1" runat="server" CssClass="table table-bordered table-striped table-condensed mt-3" AutoGenerateColumns="true" DataKeyNames="Id">
            </asp:GridView> -->
            
            <!-- Atributos del  GridView:
                
                OnRowDeleting="GVChoferes_RowDeleting" //Elimina al usuario
                OnRowCommand="GVChoferes_RowCommand" //Redirecciona a una página para editar
                OnRowEditing="GVChoferes_RowEditing" //Habilita la edición sobre la misma tabla
                OnRowUpdating ="GVChoferes_RowUpdating" //Actualiza la tabla con los datos disponibles
                OnRowCancelingEdit="GVChoferes_RowCancelingEdit" //Cancelar el edit
                
                -->

            <!-- En los ButtonField DataField debe coincidir con el VO -->
            <asp:GridView ID="GVChoferes" runat="server"
                CssClass="table table-bordered table-striped table-condensed mt-3" 
                AutoGenerateColumns="false" 
                DataKeyNames="Id"
                OnRowDeleting="GVChoferes_RowDeleting"
                OnRowCommand="GVChoferes_RowCommand"
                OnRowEditing="GVChoferes_RowEditing"
                OnRowUpdating ="GVChoferes_RowUpdating"
                OnRowCancelingEdit="GVChoferes_RowCancelingEdit"
                >



                <Columns>
                  
                    <asp:ButtonField
                        ButtonType="Button"
                        CommandName="Select"
                        ShowHeader="true"
                        Text="Seleccionar"
                        ControlStyle-CssClass="btn btn-success btn-xs"
                        />

                    <asp:CommandField
                        ButtonType="Button"
                        ShowDeleteButton="True"
                        ShowHeader="True"
                        ControlStyle-CssClass="btn btn-danger btn-xs" />

                    <asp:CommandField
                        ButtonType="Button"
                        ShowEditButton="True"
                        ShowHeader="True"
                        ControlStyle-CssClass="btn btn-primary btn-xs" />



                    <asp:ImageField
                        HeaderText="Foto"
                        ReadOnly="True"
                        ItemStyle-Width="120px"
                        ControlStyle-Width="120px"
                        ControlStyle-Height="90px"
                        DataImageUrlField="URLFoto">
                    </asp:ImageField>

                    
                    <asp:BoundField
                        DataField="Id" 
                        HeaderText="Chofer"
                        ItemStyle-Width="50px"
                        ReadOnly="true" />

                    <asp:BoundField
                        DataField="Nombre"
                        HeaderText="Nombre"
                        ItemStyle-Width="50px"
                        SortExpression="Nombre" />

                    <asp:BoundField
                        DataField="ApPaterno"
                        HeaderText="Apellido Paterno"
                        ItemStyle-Width="50px"
                        SortExpression="ApPaterno" />

                    <asp:BoundField
                        DataField="ApMaterno"
                        HeaderText="Apellido Materno"
                        ItemStyle-Width="50px"
                        SortExpression="ApMaterno" />

                    <asp:BoundField
                        DataField="Licencia"
                        HeaderText="Licencia"
                        SortExpression="Licencia"
                        ItemStyle-Width="50px" />

                    <asp:TemplateField HeaderText="Disponible" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <div style="width: 100%">
                                <div style="width: 25%; margin: 0 auto;">
                                    <asp:CheckBox ID="ChkDisponible" runat="server"
                                        Checked='<%#Eval("Disponibilidad")%>'
                                        Enabled="false" />
                                </div>
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="width: 100%">
                                <div style="width: 25%; margin: 0 auto;">
                                    <asp:CheckBox ID="ChkEditDisponible" runat="server"
                                        Checked='<%#Eval("Disponibilidad")%>' />
                                </div>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
