window.onload = inicializaEventos;

function inicializaEventos() {
    document.getElementById("btnHola").addEventListener("click", saluda, false);
    document.getElementById("btnListaPersonas").addEventListener("click", listarPersonas, false);
    document.getElementById("btnTablaPersonas").addEventListener("click", insertaTablaPersonas, false);

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
        document.getElementById("divSaludo").innerHTML = "Cargando";
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


function listarPersonas() {
    //Paso 1 instanciar objeto
    var miPeticion = new XMLHttpRequest();

    //Paso 2 Preparar la Peticion
    miPeticion.open("GET", "../Server/personas.xml", true);

    //Paso 3 Cabeceras

    //Paso 4 Prepara lo que quiero hacer cuando cambie el estado
    miPeticion.onreadystatechange = function () {
        //alert(miPeticion.readyState + "," + miPeticion.status);
        document.getElementById("divListaPersonas").innerHTML = "Cargando";
        if (miPeticion.readyState == 4 && miPeticion.status == 200) {
            //Paso 6 Tratamiento de la informacion cuando se recibe
            //document.getElementById("divListaPersonas").innerHTML = miPeticion.responseText;
            var misDatosXML = miPeticion.responseXML;
            document.getElementById("divListaPersonas").innerHTML = misDatosXML.getElementsByTagName("persona")[1].getElementsByTagName("nombre")[0].textContent;
        }
    }

    //Paso 5 Enviar la solititud
    miPeticion.send();
}


function insertaTablaPersonas() {
    //Creamos la tabla
    var table = document.createElement("table");

    //Paso 1 instanciar objeto
    var miPeticion = new XMLHttpRequest();

    //Paso 2 Preparar la Peticion
    miPeticion.open("GET", "../Server/personas.xml", true);

    //Paso 3 Cabeceras

    //Paso 4 Prepara lo que quiero hacer cuando cambie el estado
    miPeticion.onreadystatechange = function () {
        //alert(miPeticion.readyState + "," + miPeticion.status);
        document.getElementById("divListaPersonas").innerHTML = "Cargando";
        if (miPeticion.readyState == 4 && miPeticion.status == 200) {
            //Paso 6 Tratamiento de la informacion cuando se recibe
            //document.getElementById("divListaPersonas").innerHTML = miPeticion.responseText;
            var misDatosXML = miPeticion.responseXML;
            var arrayPersonas = misDatosXML.getElementsByTagName("persona");

            for (var i = 0; i < arrayPersonas.length; i++){
                var persona = arrayPersonas[i];
                table.appendChild(document.createElement("tr"));

                for (var j = 0; j < persona.children.length; j++){
                    table.childNodes[i].appendChild(document.createElement("td"));
                    
                    //table.childNodes[i].childNodes[j].appendChild(persona.children[j]);//Con este metodo se mueve el nodo del array a la tabla, ya que lo hace por referencia

                    table.childNodes[i].childNodes[j].appendChild(persona.children[j].cloneNode(false));

                    //table.childNodes[i].childNodes[j].appendChild(document.createTextNode(persona.children[j].firstChild.nodeValue));

                    /*if (persona.childNodes[j].nodeType === 1) {
                        //alert(table.childNodes[i].childNodes[j]);
                        table.childNodes[i].childNodes[j].appendChild(persona.childNodes[j]);
                    }*/
                }

                /*var fila = table.insertRow(i);
                var td1 = document.createElement("td");
                var td2 = document.createElement("td");

                td1.innerHTML = persona.getElementsByTagName("nombre")[0].firstChild.nodeValue;
                td2.innerHTML = persona.getElementsByTagName("apellidos")[0].firstChild.nodeValue;

                fila.appendChild(td1);
                fila.appendChild(td2);
                table.appendChild(fila);*/
            }
            document.getElementById("divTablaPersonas").appendChild(table);
        }
    }

    //Paso 5 Enviar la solititud
    miPeticion.send();
}


function fillTablePersonas(arrayPersonas) {

}