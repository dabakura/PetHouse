$("#CuerpoAdoptante").html(`<h4>Seleccione una Adopción</h4>`);
$("#CuerpoMascota").html(`<h4>Seleccione una Adopción</h4>`);
function CargarInfo(adopcion) {
    $("#CuerpoAdoptante").empty();
    $("#CuerpoMascota").empty();
    llenarCuerpoMascota(adopcion.Mascota);
    llenarCuerpoAdoptante(adopcion.Adoptante);
}