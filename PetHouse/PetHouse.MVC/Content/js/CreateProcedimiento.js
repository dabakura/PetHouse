var url_BusquedaProcedimiento = $("#CreateProcedimiento_Uri").val();
$('#CreateProcedimiento').click(function () {
    var ExpedienteId = $("#ExpedienteId_Procedimiento").val();
    var EmpleadoId = $("#EmpleadoId_Procedimiento").val();
    var Nombre_Procedimiento = $("#Nombre_Procedimiento").val();
    var Descripcion = $("#Descripcion_Procedimiento").val();
    $.ajax({
        type: 'POST',
        url: url_BusquedaProcedimiento,
        dataType: 'json',
        data: {
            ExpedienteId: ExpedienteId, EmpleadoId: EmpleadoId, Nombre_Procedimiento: Nombre_Procedimiento, Descripcion: Descripcion, Expediente: { Id: ExpedienteId }, Empleado: { Identificacion: EmpleadoId }
        },
        success: function (procedimiento) {
            llenarCuerpoProcedimiento(procedimiento);
        },
        error: function (ex) {
            alert(ex.responseJSON.Error);
        }
    });
});

function llenarCuerpoProcedimiento(procedimiento) {
    $("#lista_Procedimientos").append(`
                <li class="item">
                    <div class="product-info" style="margin-left: 0px;">
                        <a href="#" class="product-title">
                               ${procedimiento.Nombre_Procedimiento}
                               <span class="label label-warning pull-right">${procedimiento.Empleado.Identificacion} ${procedimiento.Empleado.Nombre} ${procedimiento.Empleado.Primer_Apellido}</span>
                         </a>
                         <span class="product-description">
                               ${procedimiento.Descripcion}
                         </span>
                     </div>
                </li>
            `);
}