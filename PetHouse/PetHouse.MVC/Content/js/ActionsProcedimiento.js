function ObtenerProcedimientos(ExpedienteId) {
    $.ajax({
        type: 'POST',
        url: url_BusquedaProcedimientos,
        dataType: 'json',
        data: { id: ExpedienteId },
        success: function (procedimientos) {
            llenarCuervoProcedimientos(procedimientos);
        },
        error: function (ex) {
            $("#lista_procedimientos").empty();
            $("#lista_procedimientos").html(`<h4>${ex.responseJSON.Error}</h4>`);
        }
    });
}

function llenarCuervoProcedimientos(procedimientos) {
    $("#lista_procedimientos").empty();
    $.each(procedimientos, function (index, value) {
        $("#lista_procedimientos").append(getContentProcedimiento(value));
    });
}

function getContentProcedimiento(procedimiento) {
    return `
            <tr>
                <td>
                    ${procedimiento.ExpedienteId}
                </td>
                <td>
                    ${procedimiento.Nombre_Procedimiento}
                </td>
                <td>
                    ${procedimiento.Descripcion}
                </td>
                <td>
                    ${procedimiento.Empleado.Identificacion}
                </td>
                <td>
                    ${procedimiento.Empleado.Nombre}
                </td>
                <td>
                    ${procedimiento.Empleado.Primer_Apellido}
                </td>
                <td style="text-align: center; min-width: 160px;">
                    <a href="${url_EditProcedimientos}/${procedimiento.Id}" class="btn btn-warning">
                        <i class="fa fa-edit"></i>
                    </a>|
                    <a href="${url_DetailsProcedimientos}/${procedimiento.Id}" class="btn btn-info">
                        <i class="fa fa-search"></i>
                    </a>|
                    <a href="${url_DeleteProcedimientos}/${procedimiento.Id}" class="btn btn-danger">
                        <i class="fa fa-eraser"></i>
                    </a>
                </td>
            </tr>`;
}