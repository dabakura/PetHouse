var url_Busqueda = $("#CreateVacuna_Uri").val();
$('#CreateVacuna').click(function () {
    var ExpedienteId = $("#ExpedienteId").val();
    var VacunaId = $("#VacunaId").val();
    var Fecha_Vacunacion = $("#Fecha_Vacunacion").val();
    $.ajax({
        type: 'POST',
        url: url_Busqueda,
        dataType: 'json',
        data: {
            ExpedienteId: ExpedienteId, VacunaId: VacunaId, Fecha_Vacunacion: Fecha_Vacunacion, Expediente: { Id: ExpedienteId }, Vacuna: { Id: VacunaId }
        },
        success: function (carnet) {
            llenarCuerpoVacuna(carnet);
        },
        error: function (ex) {
            alert(ex.responseJSON.Error);
        }
    });
});

function llenarCuerpoVacuna(carnet) {
    $("#lista_vacunas").append(`
                <li class="item">
                    <div class="product-info" style="margin-left: 0px;">
                        <a href="#" class="product-title">
                               ${carnet.Vacuna.Nombre}
                               <span class="label label-warning pull-right">$${carnet.Vacuna.Precio}</span>
                         </a>
                         <span class="product-description">
                               ${ToJavaScriptDate(carnet.Fecha_Vacunacion)}
                         </span>
                     </div>
                </li>
            `);
}

function ToJavaScriptDate(value) {
    if (!value)
        return "No Registra";
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    if (!results)
        return value;
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}