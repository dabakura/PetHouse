function llenarCuerpoAdoptante(Adoptante) {
    if (!Adoptante) {
        $("#CuerpoAdoptante").html("<h4>No se encontraron resultados</h4>")
    } else {
        $("#CuerpoAdoptante").html(`<dl class="dl-horizontal">
                <div style="font-weight: 700;" >
                    Identificación
                </div>
                <div>
                    ${Adoptante.Identificacion}
                </div>
                <div style="font-weight: 700;">
                    Nombre
                </div>
                <div>
                    ${Adoptante.Nombre}
                </div>
                <div style="font-weight: 700;">
                    Primer Apellido
                </div>
                <div>
                     ${Adoptante.Primer_Apellido}
                </div>
                <div style="font-weight: 700;">
                    Segundo Apellido
                </div>
                <div>
                    ${Adoptante.Segundo_Apellido}
                </div>
                <div style="font-weight: 700;">
                    Teléfono
                </div>
                <div>
                    ${Adoptante.Telefono}
                </div>
                <div style="font-weight: 700;">
                    Email
                </div>
                <div>
                    ${Adoptante.Correo}
                </div>
                <div style="font-weight: 700;">
                    Fecha Nacimiento
                </div>
                <div>
                    ${ToJavaScriptDate(Adoptante.Fecha_Nacimiento)}
                </div>
                <div style="font-weight: 700;">
                    Provincia
                </div>
                <div>
                     ${Adoptante.Domicilio.Distrito.Canton.Provincia.Nombre}
                </div>
                <div style="font-weight: 700;">
                    Cantón
                </div>
                <div>
                     ${Adoptante.Domicilio.Distrito.Canton.Nombre}
                </div>
                <div style="font-weight: 700;">
                    Distrito
                </div>
                <div>
                     ${Adoptante.Domicilio.Distrito.Nombre}
                </div>
                <div style="font-weight: 700;">
                    Dirección
                </div>
                <div>
                     ${Adoptante.Domicilio.Direccion}
                </div>
            </dl>`);
    }
}
