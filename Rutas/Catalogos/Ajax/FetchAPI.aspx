<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Catalogos/Ajax/JQueryAjax.aspx.cs" Inherits="Rutas.Catalogos.Ajax.FetchAPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Ejemplo de FetchAPI</h2>
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
            <tbody id="tablaBody">
                <!-- Datos se llenarán aquí dinámicamente -->
            </tbody>
        </table>
    </div>

    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {

            document.getElementById('btnSaludar').addEventListener('click', function (e) {
                e.preventDefault();

                document.getElementById('loader').style.display = 'block';

                const nombre = document.getElementById('txtNombre').value;

                // Fetch API: Es una interfaz en JavaScript para realizar solicitudes HTTP a servidores web, 
                // se usa para realizar solicitudes AJAX(Asynchronous JavaScript and XML).
                const postData = async () => {
                    try {
                        const response = await fetch('/Catalogos/Ajax/JQueryAjax.aspx/Saludar', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json; charset=utf-8'
                            },
                            body: JSON.stringify({ nombre: nombre })
                        });

                        if (!response.ok) {
                            throw new Error('Error: ' + response.statusText);
                        }

                        const data = await response.json();
                        document.getElementById('lblSaludo').textContent = data.d;
                        document.getElementById('lblTime').textContent = new Date().toLocaleTimeString();
                        await cargarTabla();
                    }
                    catch (error) {
                        console.error('Error:', error);
                        alert('Error: ' + error.message);
                    }
                    finally {
                        document.getElementById('loader').style.display = 'none';
                    }
                };
                postData();

            });

            async function cargarTabla() {
                try {
                    const response = await fetch('/Catalogos/Ajax/JQueryAjax.aspx/ObtenerDatosTabla', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json; charset=utf-8'
                        }
                    });

                    if (!response.ok) {
                        throw new Error('Error: ' + response.statusText);
                    }

                    const data = await response.json();
                    const tablaBody = document.getElementById('tablaBody');
                    tablaBody.innerHTML = ''; // Vaciar la tabla antes de llenarla

                    // Recorrer los datos y construir filas
                    data.d.forEach(item => {
                        const fila = document.createElement('tr');
                        fila.innerHTML = `
                            <td>${item.Columna1}</td>
                            <td>${item.Columna2}</td>
                        `;
                        tablaBody.appendChild(fila);
                    });
                }
                catch (error) {
                    console.error('Error:', error);
                    alert('Error: ' + error.message);
                }
            }

        });
    </script>
</asp:Content>
