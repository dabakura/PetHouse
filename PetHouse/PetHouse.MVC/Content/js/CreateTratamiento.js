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