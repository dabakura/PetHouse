var url_Persona = $("#UrlPersona").val();
var url_Distritos = $("#ListDistritos").val();
var url_Cantones = $("#ListCantones").val();

$("#Buscar").click(function () {
    $("#Nombre").empty();
    $("#Primer_Apellido").empty();
    $("#Segundo_Apellido").empty();
    $("#Id_Distrito").prop("disabled", false);
    $("#Id_Canton").prop("disabled", false);
    $("#Id_Provincia").val("0");
    $("#Id_Canton").val("0");
    $("#Id_Distrito").val("0");
    $.ajax({
        type: 'GET',
        url: url_Persona,
        dataType: 'json',
        data: { ID_CEDULA: $("#Identificacion").val() },
        success: function (persona) {
            if (persona) {
                $("#Nombre").val(persona.Nombre);
                $("#Primer_Apellido").val(persona.Primer_Apellido);
                $("#Segundo_Apellido").val(persona.Segundo_Apellido);
                $("#Id_Provincia").val(persona.ProvinciaId);
                llenarCantones(persona.ProvinciaId, persona.CantonId);
                llenarDistritos(persona.CantonId, persona.DistritoId);
            } else {
                alert('Problema al cargar la Persona verifique la identificación');
            }
        },
        error: function (ex) {
            alert('Problema al cargar la Persona verifique la identificación');
        }
    });
});

function llenarCantones(provinciaid, cantonid) {
    $("#Id_Canton").empty();
    $("#Id_Distrito").empty();
    $("#Id_Canton").append('<option value="' + 0 + '">' + "--Seleccione canton--" + '</option>');
    $.ajax({
        type: 'POST',
        url: url_Cantones,
        dataType: 'json',
        data: { ID_PROVINCIA: provinciaid },
        success: function (Cantones) {
            $.each(Cantones, function (i, catalogo) {
                $("#Id_Canton").append('<option value="' + catalogo.Value + '">' + catalogo.Text + '</option>');
            });
            $("#Id_Canton").val(cantonid);
        },
        error: function (ex) {
            alert('Problema al cargar los cantones ' + ex.message);
        }
    });
    $("#Id_Canton").prop("disabled", false);
    return false;
}

function llenarDistritos(cantonid, distritoid) {
    $("#Id_Distrito").empty();
    $("#Id_Distrito").append('<option value="' + 0 + '">' + "--Seleccione distrito--" + '</option>');
    $.ajax({
        type: 'POST',
        url: url_Distritos,
        dataType: 'json',
        data: { ID_CANTON: cantonid },
        success: function (Distritos) {
            $.each(Distritos, function (i, catalogo) {
                $("#Id_Distrito").append('<option value="' + catalogo.Value + '">' + catalogo.Text + '</option>');
            });
            $("#Id_Distrito").val(distritoid);
        },
        error: function (ex) {
            alert('Problema al cargar los distritos ' + ex.message);
        }
    });
    $("#Id_Distrito").prop("disabled", false);
    return false;
}