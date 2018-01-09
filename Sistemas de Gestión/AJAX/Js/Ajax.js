window.onload = inicializaEventos;

function inicializaEventos() {
    document.getElementById("btnHola").addEventListener("click", saluda, false);
}

function saluda() {
    //document.writeln("Holaaaaaaaaaaaaa");

    //Paso 1 instanciar objeto
    var miPeticion = new XMLHttpRequest();

    //Paso 2 Preparar la Peticion
    miPeticion.open("GET", "../Server/TextoEnServidor.html", true);

    //Paso 3 Cabeceras


    //Paso 4 Prepara lo que quiero hacer cuando cambie el estado
    miPeticion.onreadystatechange = function () {
        //alert(miPeticion.readyState + "," + miPeticion.status);
        document.getElementById("divSaludo").innerHTML = "Cagando";
        if (miPeticion.readyState == 4 && miPeticion.status == 200) {
            //Paso 6 Tratamiento de la informacion cuando se recibe
            document.getElementById("divSaludo").innerHTML = miPeticion.responseText;
        }

    }

    //Paso 5 Enviar la solititud
    miPeticion.send();

    

    /*if (window.XMLHttpRequest) {
        miPeticion = new XMLHttpRequest();
    } else {
        miPeticion = new ActiveXObject('Microsoft.XMLHTTP');
    }*/
}


