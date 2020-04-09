var Medicamentos = [];
function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    var elemento = document.getElementById(ev.target.id);
    ev.dataTransfer.setData("info", elemento.dataset.info);
    ev.dataTransfer.setData("text", ev.target.id);
}

function dropInsert(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    var dd = ev.dataTransfer.getData("info")
    var datainfo = JSON.parse(dd);
    Medicamentos.push(datainfo);
    ev.target.appendChild(document.getElementById(data));
    console.log(Medicamentos);
}

function dropDelete(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    var dd = ev.dataTransfer.getData("info")
    var datainfo = JSON.parse(dd);
    Medicamentos = removeItemFromArr(Medicamentos, datainfo);
    ev.target.appendChild(document.getElementById(data));
    console.log(Medicamentos);
}
var removeItemFromArr = (arr, item) => {
    return arr.filter(e => e.Id !== item.Id);
};

var url_BusquedaTratamiento = $("#CreateTratamiento_Uri").val();
$('#CreateTratamiento').click(function () {
    var ExpedienteId = $("#ExpedienteId_Tratamiento").val();
    var EmpleadoId = $("#EmpleadoId_Tratamiento").val();
    var Descripcion = $("#Descripcion_Tratamiento").val();
    $.ajax({
        type: 'POST',
        url: url_BusquedaTratamiento,
        dataType: 'json',
        data: {
            ExpedienteId: ExpedienteId, EmpleadoId: EmpleadoId, Descripcion: Descripcion, Expediente: { Id: ExpedienteId }, Empleado: { Identificacion: EmpleadoId }, Medicamentos: Medicamentos
        },
        success: function (tratamiento) {
            llenarCuerpoTratamiento(tratamiento);
        },
        error: function (ex) {
            alert(ex.responseJSON.Error);
        }
    });
});

function llenarCuerpoTratamiento(tratamiento) {
    $("#lista_Tratamientos").append(`
                <li class="item">
                    <div class="product-info" style="margin-left: 0px;">
                        <a href="#" class="product-title col-md-12">
                               Igresado por ${tratamiento.EmpleadoId}
                               <span class="label label-warning pull-right">Fecha: ${ToJavaScriptDate(tratamiento.Fecha)}</span>
                         </a>
                        <div class="col-md-8">
                            <span class="product-description" style="height:122px; overflow-y:scroll;">
                               ${tratamiento.Descripcion}
                            </span>
                        </div>
                        <div class="col-md-4" style="height:122px; overflow-y:scroll; border-color: #d2d6de; border-style: solid;">
                            <ul class="col-md-12 products-list product-list-in-box" >
                                ${llenarMedicamentos(tratamiento.Medicamentos)}
                            </ul>
                        </div>
                     </div>
                </li>
            `);
}

function llenarMedicamentos(medicamentos) {
    var cuerpo = "";
    $.each(medicamentos, function (index, value) {
        cuerpo += `<li class="item">
                        <a href="#" class="product-title">
                               ${value.Nombre}
                            <span class="label label-warning pull-right">${value.Precio}</span>
                         </a>
                        <span class="product-description">
                            ${value.Descripcion}
                        </span>
                    </li>`;
    });
    return cuerpo;
}