<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JQueryAjax.aspx.cs" Inherits="Rutas.Catalogos.Ajax.JQueryAjax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Ejemplo de jQuery AJAX</h2>
        <div class="mb-3">
            Última actualización:
            <span id="lblTime" class="badge badge-info"></span>
        </div>
        <div class="form-group">
            <input type="text" id="txtNombre" class="form-control" placeholder="Ingresa un nombre" />
        </div>
        <button type="button" id="btnSaludar" class="btn btn-primary">Saludar</button>
        <br /><br />

        <!--Respuesta1-->
        <div id="lblSaludo" class="alert alert-success" role="alert"></div>

        <button id="loader" class="btn btn-primary" type="button" disabled style="display:none;">
            <span class="spinner-border spinner-border-sm" aria-hidden="true"></span>
            <span role="status" class="sr-only">Procesando...</span>
        </button>

        <br /><br />

        <!--Respuesta2: Tabla con datos simulados-->
        <table id="tablaDatos" class="table table-bordered">
            <thead class="thead-dark">
                <tr>
                    <th>Columna 1</th>
                    <th>Columna 2</th>
                </tr>
            </thead>
            <tbody>
                <!-- Datos se llenarán aquí dinámicamente -->
            </tbody>
        </table>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnSaludar").click(function (e) {
                e.preventDefault();
                $("#loader").show();

                let nombre = $("#txtNombre").val();

                 //JQuery
                $.ajax({
                    type: "POST",
                    url: "/Catalogos/Ajax/JQueryAjax.aspx/Saludar",
                    data: JSON.stringify({ nombre: nombre }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        $("#lblSaludo").text(response.d);
                        $("#lblTime").text(new Date().toLocaleTimeString());
                        cargarTabla();
                    },
                    error: function (error) {
                        console.log(error);
                        alert("Error: " + error.responseText);
                    },
                    complete: function () {
                        $("#loader").hide();
                    }
                });

            });

            function cargarTabla() {
                $.ajax({
                    type: "POST",
                    url: "/Catalogos/Ajax/JQueryAjax.aspx/ObtenerDatosTabla",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        let tablaBody = $("#tablaDatos tbody");
                        tablaBody.empty();

                        //response.d contiene la lista de objetos DatosTabla que se devuelve desde el método ObtenerDatosTabla
                        $.each(response.d, function (index, item) {
                            let fila = `<tr>
                                          <td>${item.Columna1}</td>
                                          <td>${item.Columna2}</td>
                                        </tr>`;
                            tablaBody.append(fila);
                        });
                    },
                    error: function (error) {
                        console.log(error);
                        alert("Error: " + error.responseText);
                    }
                });
            }

        });
    </script>
</asp:Content>
