var url_Distritos = $("#ListDistritos").val();
var url_Cantones = $("#ListCantones").val();
$("#Id_Provincia").change(function () {
    $("#Id_Canton").empty();
    $("#Id_Distrito").empty();
    $("#Id_Canton").append('<option value="' + 0 + '">' + "--Seleccione canton--" + '</option>');
    $.ajax({
        type: 'POST',
        url: url_Cantones,
        dataType: 'json',
        data: { ID_PROVINCIA: $("#Id_Provincia").val() },
        success: function (Cantones) {
            $.each(Cantones, function (i, catalogo) {
                $("#Id_Canton").append('<option value="' + catalogo.Value + '">' + catalogo.Text + '</option>');
            });
        },
        error: function (ex) {
            alert('Problema al cargar los cantones ' + ex.message);
        }
    });
    $("#Id_Canton").prop("disabled", false);
    return false;
});
$("#Id_Canton").change(function () {
    $("#Id_Distrito").empty();
    $("#Id_Distrito").append('<option value="' + 0 + '">' + "--Seleccione distrito--" + '</option>');
    $.ajax({
        type: 'POST',
        url: url_Distritos,
        dataType: 'json',
        data: { ID_CANTON: $("#Id_Canton").val() },
        success: function (Distritos) {
            $.each(Distritos, function (i, catalogo) {
                $("#Id_Distrito").append('<option value="' + catalogo.Value + '">' + catalogo.Text + '</option>');
            });
        },
        error: function (ex) {
            alert('Problema al cargar los distritos ' + ex.message);
        }
    });
    $("#Id_Distrito").prop("disabled", false);
    return false;
});
let content = $("#Id_Provincia").html();
$("#Id_Provincia").empty();
$("#Id_Provincia").append('<option value="' + 0 + '">' + "--Seleccione una provincia--" + '</option>');
$("#Id_Provincia").append(content);
$("#Id_Canton").empty();
$("#Id_Distrito").empty();