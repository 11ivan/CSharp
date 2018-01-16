window.addEventListener("load", inicia);


function inicia() {
    //document.getElementById()

    //Funcion para insertar tabla
    insertarTabla();

}



function insertarTabla() {

    var xmlhtr = new XMLHttpRequest();
    //Creamos la tabla
    var table = document.createElement("table");

    if (xmlhtr) {

        xmlhtr.open('GET', "../api/personas");

        xmlhtr.onreadystatechange = function () {

            if (xmlhtr.readyState == 4 && xmlhtr.status == 200) {
                document.getElementById("listadoPersonas").innerHTML = xmlhtr.responseText;//

                var arrayPersonas = JSON.parse(xmlhtr.responseText);

                for (var i = 0; i < arrayPersonas.length; i++) {
                    var persona = new Persona();
                    persona = arrayPersonas[i];
                    table.appendChild(document.createElement("tr"));

                    table.childNodes[i].appendChild(document.createElement("td"));
                    table.childNodes[i].childNodes[0].appendChild(document.createTextNode(persona.nombre));

                    Object.keys(persona);

                    /*for (var j = 0; j < persona.; j++) {
                        table.childNodes[i].appendChild(document.createElement("td"));
                        table.childNodes[i].childNodes[j].appendChild(persona.children[j].cloneNode(false));
                    }*/
                }
                document.getElementById("listadoPersonas").appendChild(table);
            }   
        }
    }
    xmlhtr.send();
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

            for (var i = 0; i < arrayPersonas.length; i++) {
                var persona = arrayPersonas[i];
                table.appendChild(document.createElement("tr"));

                for (var j = 0; j < persona.children.length; j++) {
                    table.childNodes[i].appendChild(document.createElement("td"));
                    table.childNodes[i].childNodes[j].appendChild(persona.children[j].cloneNode(false));
                }
            }
            document.getElementById("divTablaPersonas").appendChild(table);
        }
    }

    //Paso 5 Enviar la solititud
    miPeticion.send();
}

