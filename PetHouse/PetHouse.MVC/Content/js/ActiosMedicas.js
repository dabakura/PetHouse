var url_BusquedaCarnets = $("#url_BusquedaCarnets").val();
var url_EliminaCarnet = $("#url_EliminaCarnet").val();
var url_BusquedaProcedimientos = $("#url_BusquedaProcedimientos").val();
var url_EditProcedimientos = $("#url_EditProcedimientos").val();
var url_DetailsProcedimientos = $("#url_DetailsProcedimientos").val();
var url_DeleteProcedimientos = $("#url_DeleteProcedimientos").val();
var url_BusquedaTratamientos = $("#url_BusquedaTratamientos").val();
var url_EditTratamientos = $("#url_EditTratamientos").val();
var url_DetailsTratamientos = $("#url_DetailsTratamientos").val();
var url_DeleteTratamientos = $("#url_DeleteTratamientos").val();
var url_BusquedaMascota = $("#url_BusquedaMascota").val();
$("#table_procedimientos").hide();
$("#table_tratamientos").hide();
function SelectedExpediente(ExpedienteId) {
    $("#ExpedienteIdSelected").val(ExpedienteId);
    $("#table_procedimientos").show();
    $("#table_tratamientos").show();
    ObtenerMascota(ExpedienteId);
    ObtenerCarnets(ExpedienteId);
    ObtenerProcedimientos(ExpedienteId);
    ObtenerTratamientos(ExpedienteId);
}