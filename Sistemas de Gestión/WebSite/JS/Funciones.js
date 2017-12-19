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
    var nombre = document.getElementById("name").value
    if (nombre == null || nombre.length == 0 || nombre.trim().length==0) {
        //document.getElementById("errorNombre").innerHTML = "Error"
        vale = false;
    }
    return vale;
}


function validaFecha() {
    vale = true;
    /*var ano = document.getElementById("ano").value;
    var mes = document.getElementById("mes").value;
    var dia = document.getElementById("dia").value;*/

    //valor = new Date(ano, mes, dia);
    fecha = document.getElementById("fechaNac").value
    valor = new Date(fecha);
    if (!isNaN(valor)) {
        vale=false
    }
    return vale
}