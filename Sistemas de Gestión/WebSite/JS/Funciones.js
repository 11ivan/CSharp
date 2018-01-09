window.onload = inicializaEventos

function inicializaEventos() {
    document.getElementById("btnValida").addEventListener("click", validaCampos, false)
}


function validaCampos() {
    if (!validaNombre()) {
        document.getElementById("errorNombre").innerHTML = "Error en el nombre"
    } else {
        document.getElementById("errorNombre").innerHTML = ""
    }
    if (!validaFecha()) {
        document.getElementById("errorFecha").innerHTML = "Error en la fecha"
    } else {
        document.getElementById("errorFecha").innerHTML = ""
    }
}


function saluda() {
    var nombre = document.getElementById("name").value
    document.writeln("Saludos "+ nombre)
}


function validaNombre() {
    var vale = true;
    var nombre = document.getElementById("name").value;
    if (nombre == null || nombre.length == 0 || nombre.trim().length==0) {
        //document.getElementById("errorNombre").innerHTML = "Error"
        vale = false;
    }
    return vale;
}


function validaFecha() {
    vale = true;
    fecha = document.getElementById("fechaNac").value;
    valor = new Date(fecha);
    var fechaActual = Date.now;

    if (valor > fechaActual) {
        vale = false;
    }
    return vale;
}