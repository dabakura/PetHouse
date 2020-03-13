

function UpdateStatePatron(indicatorPatron) {
    if (indicatorPatron.Completo) {
        $('#subir_padron').prop("disabled", false);
        $('#text_complete_padron').css('display', 'none');
        $("#progress_padron").css('width', 0 + '%');
        $("#progress_padron").html(0 + '%');
    } else {
        $('#subir_padron').prop("disabled", true);
        $('#text_complete_padron').css('display', 'block');
        $("#progress_padron").css('width', indicatorPatron.Porcentaje + '%');
        $("#progress_padron").html(indicatorPatron.Porcentaje + '%');
    }
    $('#text_complete_padron').html(indicatorPatron.PNota);
}

function callIndicators() {
    let self = this;
    let urlpatron = window.location.origin + "/Padron/IndicatorPadron";
    console.log("Llamando");
    $.getJSON(urlpatron, function (result) {
        self.UpdateStatePatron(result);
    }).fail(function (jqxhr) {
        alert(jqxhr.responseText);
    });

    let urlregion = window.location.origin + "/Padron/IndicatorRegion";

    $.getJSON(urlregion, function (result) {
        self.UpdateStateRegion(result);
    }).fail(function (jqxhr) {
        alert(jqxhr.responseText);
    });
}

function UpdateStateRegion(indicatorRegion) {
    if (indicatorRegion.Completo) {
        $('#subir_region').prop("disabled", false);
        $('#text_complete_region').css('display', 'none');
        $("#progress_region").css('width', 0 + '%');
        $("#progress_region").html(0 + '%');
    } else {
        $('#subir_region').prop("disabled", true);
        $('#text_complete_region').css('display', 'block');
        $("#progress_region").css('width', indicatorRegion.Porcentaje + '%');
        $("#progress_region").html(indicatorRegion.Porcentaje + '%');
    }
    $('#text_complete_region').html(indicatorRegion.PNota);
}

var interval = setInterval(function () {
    try {
        callIndicators();
    }
    catch (error) {
        console.error(error);
    }
}, 500);

function verificarStart() {
    interval = setInterval(callIndicators(), 500);
}

function verificarStop() {
    clearInterval(interval);
}