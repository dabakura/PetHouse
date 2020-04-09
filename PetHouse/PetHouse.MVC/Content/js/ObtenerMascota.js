function ObtenerMascota(ExpedienteId) {
    $("#CuerpoMascota").empty();
    $.ajax({
        type: 'GET',
        url: url_BusquedaMascota,
        dataType: 'json',
        data: { id: ExpedienteId },
        success: function (mascota) {
            llenarCuerpoMascota(mascota)
        },
        error: function (ex) {
            $("#CuerpoMascota").html('<h4>No se encontraron resultados</h4>');
        }
    });
};