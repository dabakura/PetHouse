function ObtenerTratamientos(ExpedienteId) {
    $.ajax({
        type: 'POST',
        url: url_BusquedaTratamientos,
        dataType: 'json',
        data: { id: ExpedienteId },
        success: function (tratamientos) {
            llenarCuervoTratamientos(tratamientos);
        },
        error: function (ex) {
            $("#lista_tratamientos").empty();
            $("#lista_tratamientos").html(`<h4>${ex.responseJSON.Error}</h4>`);
        }
    });
}

function llenarCuervoTratamientos(tratamientos) {
    $("#lista_tratamientos").empty();
    $.each(tratamientos, function (index, value) {
        $("#lista_tratamientos").append(getContentTratamiento(value));
    });
}

function getContentTratamiento(tratamiento) {
    return `
            <tr>
                <td>
                    ${tratamiento.ExpedienteId}
                </td>
                <td>
                    ${tratamiento.Descripcion}
                </td>
                <td>
                    ${ToJavaScriptDate(tratamiento.Fecha)}
                </td>
                <td>
                    ${tratamiento.Empleado.Identificacion}
                </td>
                <td style="text-align: center; min-width: 160px;">
                    <a href="${url_EditTratamientos}/${tratamiento.Id}" class="btn btn-warning">
                        <i class="fa fa-edit"></i>
                    </a>|
                    <a href="${url_DetailsTratamientos}/${tratamiento.Id}" class="btn btn-info">
                        <i class="fa fa-search"></i>
                    </a>|
                    <a href="${url_DeleteTratamientos}/${tratamiento.Id}" class="btn btn-danger">
                        <i class="fa fa-eraser"></i>
                    </a>
                </td>
            </tr>`;
}