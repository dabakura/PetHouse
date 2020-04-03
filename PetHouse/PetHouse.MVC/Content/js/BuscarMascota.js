var url_Busqueda = $("#Busqueda_Uri").val();

$("#Buscar").click(function () {
    $("#Cuerpo").empty();
    $.ajax({
        type: 'GET',
        url: url_Busqueda,
        dataType: 'json',
        data: { id: $("#Id").val() },
        success: function (mascota) {
            llenarCuerpo(mascota)
        },
        error: function (ex) {
            $("#Cuerpo").html('<h4>No se encontraron resultados</h4>');
        }
    });
});

function llenarCuerpo(Mascota) {
    if (!Mascota) {
        $("#Cuerpo").html("<h4>No se encontraron resultados</h4>")
    } else {
        $("#Cuerpo").html(`<dl class="dl-horizontal">
                <div style="font-weight: 700;" >
                    Identificación
                </div>
                <div>
                    ${Mascota.Identificacion}
                </div>
                <div style="font-weight: 700;">
                    Id Expediente
                </div>
                <div>
                    ${Mascota.ExpedienteId}
                </div>
                <div style="font-weight: 700;">
                    Nombre
                </div>
                <div>
                     ${Mascota.Nombre}
                </div>
                <div style="font-weight: 700;">
                    Tipo
                </div>
                <div>
                    ${Mascota.Tipo}
                </div>
                <div style="font-weight: 700;">
                    Genero
                </div>
                <div>
                    ${Mascota.Genero}
                </div>
                <div style="font-weight: 700;">
                    Raza
                </div>
                <div>
                    ${Mascota.Raza}
                </div>
                <div style="font-weight: 700;">
                    Fecha Nacimiento
                </div>
                <div>
                    ${ToJavaScriptDate(Mascota.Fecha_Nacimiento)}
                </div>
                <div style="font-weight: 700;">
                    Edad
                </div>
                <div>
                     ${Mascota.Expediente.Edad}
                </div>
                <div style="font-weight: 700;">
                    Castración
                </div>
                <div>
                    <div class="icheckbox_minimal-blue disabled" style="position: relative;" aria-checked="${Mascota.Expediente.Castracion}" aria-disabled="true"><input class="check-box" disabled="disabled" type="checkbox" style="position: absolute; opacity: 0;"><ins class="iCheck-helper" style="position: absolute; top: 0%; left: 0%; display: block; widiv style=""h: 100%; height: 100%; margin: 0px; padding: 0px; background: rgb(255, 255, 255) none repeat scroll 0% 0%; border: 0px none; opacity: 0;"></ins></div>
                </div>
                <div style="font-weight: 700;">
                    Peso
                </div>
                <div>
                    ${Mascota.Expediente.Peso}
                </div>
                <div style="font-weight: 700;">
                    Fecha Ingreso
                </div>
                <div>
                    ${ToJavaScriptDate(Mascota.Expediente.Fecha_Ingreso)}
                </div>
                <div style="font-weight: 700;">
                    Fecha Fallecimiento
                </div>
                <div>
                    ${ToJavaScriptDate(Mascota.Expediente.Fecha_Fallecimiento)}
                </div>
            </dl>`);
    }
}

function ToJavaScriptDate(value) {
    if (!value)
        return "No Registra";
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}