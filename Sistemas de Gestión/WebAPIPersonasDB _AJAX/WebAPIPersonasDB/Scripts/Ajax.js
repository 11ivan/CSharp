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
    //
    table.setAttribute("border", "collapse");

    if (xmlhtr) {
        //Prepa
        xmlhtr.open('GET', "../api/personas");

        xmlhtr.onreadystatechange = function () {
            if (xmlhtr.readyState == 4 && xmlhtr.status == 200) {
                //document.getElementById("listadoPersonas").innerHTML = xmlhtr.responseText;//

                //Deserializacion del documento JSON
                var arrayPersonas = JSON.parse(xmlhtr.responseText);

                //Encabezado de la tabla
                table.appendChild(document.createElement("tr"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[0].appendChild(document.createTextNode("ID"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[1].appendChild(document.createTextNode("Nombre"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[2].appendChild(document.createTextNode("Apellidos"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[3].appendChild(document.createTextNode("Fecha de nacimiento"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[4].appendChild(document.createTextNode("Telefono"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[5].appendChild(document.createTextNode("Direccion"));

                for (var i = 0; i < arrayPersonas.length; i++) {

                    var persona = new Persona();
                    persona = arrayPersonas[i];

                    table.appendChild(document.createElement("tr"));

                    table.childNodes[i+1].appendChild(document.createElement("td"));//+1 porque el iondice 0 esta ocupado
                    table.childNodes[i+1].childNodes[0].appendChild(document.createTextNode(persona.id));

                    table.childNodes[i+1].appendChild(document.createElement("td"));
                    table.childNodes[i+1].childNodes[1].appendChild(document.createTextNode(persona.nombre));

                    table.childNodes[i+1].appendChild(document.createElement("td"));
                    table.childNodes[i+1].childNodes[2].appendChild(document.createTextNode(persona.apellidos));

                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    table.childNodes[i + 1].childNodes[3].appendChild(document.createTextNode(persona.fechaNac.split("T", 1)));

                    table.childNodes[i+1].appendChild(document.createElement("td"));
                    table.childNodes[i+1].childNodes[4].appendChild(document.createTextNode(persona.telefono));

                    table.childNodes[i+1].appendChild(document.createElement("td"));
                    table.childNodes[i+1].childNodes[5].appendChild(document.createTextNode(persona.direccion));

                    /*var properties = Object.keys(persona);
                    for (var j = 0; j < properties.length; j++){
                        table.childNodes[i].childNodes[j].appendChild(document.createTextNode(persona.Property(j)));
                        //table.childNodes[i].childNodes[j].textContent = persona[j];

                    }*/

                    //Object.keys(persona);

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



