
//Obtener los permisos de vista
async function obtenerPermisosJS(Controlador) {
    //Obtener los elementos y cortarlos
    var elementos = document.getElementsByClassName("Permisos");
    var arreglo = [];
    for (var i = 0; i < elementos.length; i++) {
        arreglo.push(elementos[i].id);
    }

    //Crear arreglo y enviar al controlador
    var registros = [];
    registros.push(Controlador);
    registros.push(arreglo);
    var data = "[" + registros.join() + "]";

    Permiso = await revisionPermisosPorPantalla(data);      
    concederPermisos(Controlador, arreglo);
}

//Ajax para revisar los permisos por pantalla
function revisionPermisosPorPantalla(data) {
    return $.ajax({
        async: true,
        type: "POST",
        url: '/AccesoOpcionPermiso/revisionPermisosPorPantalla/?data=' + data,
        dataType: "text"
    }).done(function (data) {

    });
}

//Función para obtener los permisos del usuario y concederlos
async function concederPermisos(Controlador, arreglo) {
    PermisosUsuario = await ajaxConcederPermisos(Controlador);
    if (PermisosUsuario != "{}") {
        for (var i = 0; i < arreglo.length; i++) {
            var objeto = arreglo[i];
            for (var j = 0; j < PermisosUsuario.length; j++) {
                if (objeto == PermisosUsuario[j].clase) {
                    $("#" + arreglo[i]).prop("hidden", false);
                    j = PermisosUsuario.length;
                }
            }
        }
    }
}

//Ajax para obtener los permisos del ussuario en la pantalla
function ajaxConcederPermisos(Controlador) {
    return $.ajax({
        async: true,
        type: "POST",
        url: '/AccesoOpcionPermiso/ajaxConcederPermisos/?Controlador=' + Controlador,
        dataType: "json"
    }).done(function (data) {

    });
}
