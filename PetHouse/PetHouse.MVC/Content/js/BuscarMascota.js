var url_Busqueda = $("#Busqueda_Uri").val();
$("#CuerpoMascota").html(`<h4>Busqueda por ID</h4>`);
$("#Buscar").click(function () {
    $("#CuerpoMascota").empty();
    $.ajax({
        type: 'GET',
        url: url_Busqueda,
        dataType: 'json',
        data: { id: $("#Id").val() },
        success: function (mascota) {
            llenarCuerpoMascota(mascota)
        },
        error: function (ex) {
            $("#CuerpoMascota").html('<h4>No se encontraron resultados</h4>');
        }
    });
});