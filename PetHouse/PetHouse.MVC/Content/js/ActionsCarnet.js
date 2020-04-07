function ObtenerCarnets(ExpedienteId) {
    $.ajax({
        type: 'POST',
        url: url_BusquedaCarnets,
        dataType: 'json',
        data: { id: ExpedienteId },
        success: function (Carnets) {
            llenarCuervoCarnet(Carnets);
        },
        error: function (ex) {
            $("#lista_vacunas").empty();
            $("#lista_vacunas").html(`<h4>${ex.responseJSON.Error}</h4>`);
        }
    });
}

function llenarCuervoCarnet(carnets) {
    $("#lista_vacunas").empty();
    $.each(carnets, function (index, value) {
        $("#lista_vacunas").append(getContentCarnet(value));
    });
}

function getContentCarnet(carnet) {
    var data = JSON.stringify(carnet);
    return `
                                <li class="item">
                                    <div class="col-md-2">
                                        <button type="button" class="btn btn-danger" onclick='DeleteCarnet(${data})'><i class="fa fa-eraser"></i></button>
                                    </div >
                                    <div class="col-md-10">
                                        <div class="product-info" style="margin-left: 0px;">
                                            <a href="#" class="product-title">
                                                ${carnet.Vacuna.Nombre}
                                                <span class="label label-warning pull-right">$${carnet.Vacuna.Precio}</span >
                                            </a >
                                            <span class="product-description">
                                                ${ToJavaScriptDate(carnet.Fecha_Vacunacion)}
                                            </span>
                                        </div >
                                    </div >
                                </li >`;
}


function DeleteCarnet(carnet) {
    $.ajax({
        type: 'POST',
        url: url_EliminaCarnet,
        dataType: 'json',
        data: carnet,
        success: function (carnet) {
            ObtenerCarnets(carnet.ExpedienteId);
        },
        error: function (ex) {
            $("#lista_vacunas").empty();
            $("#lista_vacunas").html(`<h4>${ex.responseJSON.Error}</h4>`);
        }
    });
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