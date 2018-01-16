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

        //Prepa
        xmlhtr.open('GET', "../api/personas");

        xmlhtr.onreadystatechange = function () {

            if (xmlhtr.readyState == 4 && xmlhtr.status == 200) {
                document.getElementById("listadoPersonas").innerHTML = xmlhtr.responseText;//

                var arrayPersonas = JSON.parse(xmlhtr.responseText);

                for (var i = 0; i < arrayPersonas.length; i++) {
                    //var persona = new Persona();
                    var persona = arrayPersonas[i];
                    table.appendChild(document.createElement("tr"));

                    table.childNodes[i].appendChild(document.createElement("td"));
                    //table.childNodes[i].childNodes[0].appendChild(document.createTextNode(persona.nombre));

                    var properties = Object.keys(persona);
                    for (var j = 0; j < properties.length; j++){
                        table.childNodes[i].childNodes[j].appendChild(document.createTextNode(persona.Property(j)));
                        //table.childNodes[i].childNodes[j].textContent = persona[j];

                    }

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



