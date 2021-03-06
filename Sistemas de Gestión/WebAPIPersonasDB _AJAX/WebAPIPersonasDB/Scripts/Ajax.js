﻿//Faltan validaciones de fecha correcta;
//nombre, apellidos no vacios y no numeros;
//telefono numero con longitud de 9;
//direccion si está vacía se le asignará "Sin direccion" por defecto

window.addEventListener("load", inicia);

//var editando;
var filaEnEdicion;//Si el valor es -1 es que no se está editando ni insertando una nueva persona, //si su valor es 0 es que se está insertando una nueva persona

function inicia() {
    //document.getElementById()

    //Funcion para insertar tabla
    insertarTabla();
    //editando = false;
    filaEnEdicion = -1;
}



function insertarTabla() {
    var xmlhtr = new XMLHttpRequest();

    //Creamos la tabla
    var table = document.createElement("table");
    table.setAttribute("id", "table");
    //table.setAttribute("border", "collapse");

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
                table.childNodes[0].setAttribute("id", "encabezado");
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

                //Boton INSERTAR
                var buttonInsert = document.createElement("button");
                buttonInsert.setAttribute("class", "glyphicon glyphicon-plus");
                buttonInsert.setAttribute("data-toggle", "tooltip")
                buttonInsert.setAttribute("title", "Prepara una fila para insertar una nueva Persona");
                buttonInsert.addEventListener("click", insertarPersona, true);
                document.getElementById("listadoPersonas").appendChild(buttonInsert);

                for (var i = 0; i < arrayPersonas.length; i++) {

                    var persona = new Persona();
                    persona = arrayPersonas[i];

                    table.appendChild(document.createElement("tr"));
                    table.childNodes[i + 1].setAttribute("id", "fila"+(i+1));

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

                    //Botones
                    //EDITAR
                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    var buttonEdit = document.createElement("button");
                    //buttonCreate.setAttribute("id", "button" + persona.id);
                    buttonEdit.setAttribute("tag", i+1);
                    buttonEdit.setAttribute("value", persona.id);
                    buttonEdit.setAttribute("class", "glyphicon glyphicon-edit");
                    buttonEdit.setAttribute("data-toggle", "tooltip")
                    buttonEdit.setAttribute("title", "Editar Persona");
                    //buttonEdit.innerHTML = "Editar";
                    buttonEdit.addEventListener("click", editarPersona, true); 
                    table.childNodes[i + 1].childNodes[6].appendChild(buttonEdit);

                    //GUARDAR
                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    var buttonSave = document.createElement("button");
                    buttonSave.setAttribute("tag", i + 1);
                    buttonSave.setAttribute("value", persona.id);
                    buttonSave.setAttribute("class", "glyphicon glyphicon-floppy-disk");
                    buttonSave.setAttribute("data-toggle", "tooltip")
                    buttonSave.setAttribute("title", "Guardar Persona");
                    buttonSave.addEventListener("click", guardarPersona, true);
                    table.childNodes[i + 1].childNodes[7].appendChild(buttonSave);

                    //ELIMINAR
                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    var buttonDelete = document.createElement("button");
                    buttonDelete.setAttribute("tag", i + 1);
                    buttonDelete.setAttribute("value", persona.id);
                    buttonDelete.setAttribute("class", "glyphicon glyphicon-trash");
                    buttonDelete.setAttribute("data-toggle", "tooltip")
                    buttonDelete.setAttribute("title", "Eliminar Persona");
                    buttonDelete.addEventListener("click", eliminarPersona, true);
                    table.childNodes[i + 1].childNodes[8].appendChild(buttonDelete);

                    /*var properties = Object.keys(persona);
                    for (var j = 0; j < properties.length; j++){
                        table.childNodes[i].childNodes[j].appendChild(document.createTextNode(persona.Property(j)));
                        //table.childNodes[i].childNodes[j].textContent = persona[j];

                    }*/
                }
                document.getElementById("listadoPersonas").appendChild(table);
            }   
        }
    }
    xmlhtr.send();
}

function editarPersona() {
    //Quito la tabla y vuelvo a generarla con la persona a editar, o inserto directamente en la fila correspondiente los input

    //alert(this.value + " " + this.getAttribute("tag"));
    var xmlhtr = new XMLHttpRequest();
    var fila = this.getAttribute("tag");
    var idPersona = this.value;  

    if (filaEnEdicion==-1) {//si es -1 no se está editando
        if (xmlhtr) {

            xmlhtr.open('GET', "../api/personas/" + idPersona);

            xmlhtr.onreadystatechange = function () {
                if (xmlhtr.readyState == 4 && xmlhtr.status == 200) {
                    //document.getElementById("listadoPersonas").innerHTML = xmlhtr.responseText;//

                    //Deserializacion del documento JSON
                    var persona = new Persona();
                    persona = JSON.parse(xmlhtr.responseText);

                    removeRowText(fila);//Preferiría acoplamiento a otro bucle para vaciar el texto

                    var inputNombre = document.createElement("input");
                    inputNombre.setAttribute("type", "text");
                    inputNombre.setAttribute("id", "inputNombre");
                    inputNombre.setAttribute("value", persona.nombre);
                    //document.getElementById("table").childNodes[fila].childNodes[1].innerHTML="";//quitamos el texto que habia en la celda 
                    document.getElementById("table").childNodes[fila].childNodes[1].appendChild(inputNombre);

                    var inputApellidos = document.createElement("input");
                    inputApellidos.setAttribute("type", "text");
                    inputApellidos.setAttribute("id", "inputApellidos");
                    inputApellidos.setAttribute("value", persona.apellidos);
                    document.getElementById("table").childNodes[fila].childNodes[2].appendChild(inputApellidos);

                    var inputFechaNac = document.createElement("input");
                    inputFechaNac.setAttribute("type", "date");
                    inputFechaNac.setAttribute("id", "inputFecha");
                    inputFechaNac.setAttribute("value", persona.fechaNac);
                    document.getElementById("table").childNodes[fila].childNodes[3].appendChild(inputFechaNac);

                    var inputTelefono = document.createElement("input");
                    inputTelefono.setAttribute("type", "text");
                    inputTelefono.setAttribute("id", "inputTelefono");
                    inputTelefono.setAttribute("value", persona.telefono);
                    document.getElementById("table").childNodes[fila].childNodes[4].appendChild(inputTelefono);

                    var inputDireccion = document.createElement("input");
                    inputDireccion.setAttribute("type", "text");
                    inputDireccion.setAttribute("id", "inputDireccion");
                    inputDireccion.setAttribute("value", persona.direccion);
                    document.getElementById("table").childNodes[fila].childNodes[5].appendChild(inputDireccion);
                }
            }
        }
        xmlhtr.send();
        //editando = true;
        filaEnEdicion = fila;
    } else {
        alert("Sólo se puede editar una Persona al mismo tiempo");
    }
}


/**
 * Elimina el texto que hay en todas las celdas de una fila de la tabla de Personas
                 excepto la celda 0 ya que es el ID de la persona

 * @param {any} row
 */
function removeRowText(row) {
    for (var i = 1; i <= 5;i++){
        document.getElementById("table").childNodes[row].childNodes[i].innerHTML = "";//quitamos el texto que habia en la celda 
    }
    //document.getElementById("table").childNodes[row].childNodes[i].textContent.replace;
}


/**
 * Elimina los input Text y date después de modificar una persona y pone como texto las propiedades
   de la persona.
 * @param {any} row
 * @param {any} persona
 */
function replaceInputs(row, persona) {
    var table = document.getElementById("table");
    for (var i = 1; i <= 5; i++) {
        table.childNodes[row].childNodes[i].removeChild(table.childNodes[row].childNodes[i].firstChild);       
    }
    table.childNodes[row].childNodes[1].innerHTML = persona.nombre;
    table.childNodes[row].childNodes[2].innerHTML = persona.apellidos;
    table.childNodes[row].childNodes[3].innerHTML = persona.fechaNac;
    table.childNodes[row].childNodes[4].innerHTML = persona.telefono;
    table.childNodes[row].childNodes[5].innerHTML = persona.direccion;
}

function insertarPersona() {
    //document.getElementById("table").insertRow(1);
    //var table = document.getElementById("table");

    if (filaEnEdicion==-1) {//Si no se está insertando una nueva persona o editando en este momento
        document.getElementById("table").insertBefore(document.createElement("tr"), document.getElementById("fila1"));

        document.getElementById("table").childNodes[1].appendChild(document.createElement("td"));//celda del idPersona
        document.getElementById("table").childNodes[1].appendChild(document.createElement("td"));
        var inputNombre = document.createElement("input");
        inputNombre.setAttribute("type", "text");
        inputNombre.setAttribute("id", "inputNombre");
        inputNombre.setAttribute("placeholder", "Nombre");
        document.getElementById("table").childNodes[1].childNodes[1].appendChild(inputNombre);

        document.getElementById("table").childNodes[1].appendChild(document.createElement("td"));
        var inputApellidos = document.createElement("input");
        inputApellidos.setAttribute("type", "text");
        inputApellidos.setAttribute("id", "inputApellidos");
        inputApellidos.setAttribute("placeholder", "Apellidos");
        document.getElementById("table").childNodes[1].childNodes[2].appendChild(inputApellidos);

        document.getElementById("table").childNodes[1].appendChild(document.createElement("td"));
        var inputFechaNac = document.createElement("input");
        inputFechaNac.setAttribute("type", "date");
        inputFechaNac.setAttribute("id", "inputFecha");
        document.getElementById("table").childNodes[1].childNodes[3].appendChild(inputFechaNac);

        document.getElementById("table").childNodes[1].appendChild(document.createElement("td"));
        var inputTelefono = document.createElement("input");
        inputTelefono.setAttribute("type", "text");
        inputTelefono.setAttribute("id", "inputTelefono");
        inputTelefono.setAttribute("placeholder", "Telefono");
        document.getElementById("table").childNodes[1].childNodes[4].appendChild(inputTelefono);

        document.getElementById("table").childNodes[1].appendChild(document.createElement("td"));
        var inputDireccion = document.createElement("input");
        inputDireccion.setAttribute("type", "text");
        inputDireccion.setAttribute("id", "inputDireccion");
        inputDireccion.setAttribute("placeholder", "Direccion");
        document.getElementById("table").childNodes[1].childNodes[5].appendChild(inputDireccion);

        //GUARDAR
        document.getElementById("table").childNodes[1].appendChild(document.createElement("td"));
        var buttonSave = document.createElement("button");
        buttonSave.setAttribute("tag", 1);
        buttonSave.setAttribute("value", -1);
        buttonSave.setAttribute("class", "glyphicon glyphicon-floppy-disk");
        buttonSave.setAttribute("data-toggle", "tooltip")
        buttonSave.setAttribute("title", "Guardar Persona");
        buttonSave.addEventListener("click", guardarPersona, true);
        document.getElementById("table").childNodes[1].childNodes[6].appendChild(buttonSave);

        //ELIMINAR
        table.childNodes[1].appendChild(document.createElement("td"));
        var buttonDelete = document.createElement("button");
        buttonDelete.setAttribute("tag", 1);
        buttonDelete.setAttribute("value", -1);
        buttonDelete.setAttribute("class", "glyphicon glyphicon-trash");
        buttonDelete.setAttribute("data-toggle", "tooltip")
        buttonDelete.setAttribute("title", "Eliminar Persona");
        buttonDelete.addEventListener("click", eliminarPersona, true);
        document.getElementById("table").childNodes[1].childNodes[7].appendChild(buttonDelete);

        filaEnEdicion = 0;
    } else {
        alert("No se han guardado las modificaciones");
    }
}


/**
 * 
 */
function guardarPersona() {
    var xmlhtr = new XMLHttpRequest();
    var fila = this.getAttribute("tag");//es la fila del botón; Si viene de editar la fila será la 0
    var idPersona = this.value;  //Si viene de editar el id será el de la persona a editar

    var nombre = document.getElementById("inputNombre").value;
    var apellidos = document.getElementById("inputApellidos").value;
    //var fechaNac = new Date(document.getElementById("inputFecha").value);
    var fechaNac = document.getElementById("inputFecha").value;
    var telefono = document.getElementById("inputTelefono").value;
    var direccion = document.getElementById("inputDireccion").value;

    if (filaEnEdicion == 0) {//Si filaEnEdicion es 0 es una inserción 
        if (xmlhtr) {        

            xmlhtr.open('POST', "../api/personas");
            xmlhtr.setRequestHeader("Content-type", "application/json");

            var persona = new Persona(1, nombre, apellidos, fechaNac, telefono, direccion);
            var body = JSON.stringify(persona);

            xmlhtr.send(body);

            //document.getElementById("table").deleteRow(1);         

            //Añadir a la persona insertada en la última fila de la tabla
            //insertarPersonaAlFinal(persona);//El método está bien el problema es que necesitaría el id de la persona realizando una peticion a la api

            var contenedor = document.getElementById("listadoPersonas");

            contenedor.removeChild(contenedor.childNodes[1]);
            contenedor.removeChild(contenedor.childNodes[1]);

            insertarTabla();//De éste modo a penas se entera que ha hecho una petición POST y no se ve la nueva persona al insertar la tabla

            filaEnEdicion = -1;
        }
    } else if (filaEnEdicion == fila) {//Sino si filaEnEdicion es igual a la fila del boton es una modificacion
        if (xmlhtr) {

            xmlhtr.open('PUT', "../api/personas/" + idPersona);
            xmlhtr.setRequestHeader("Content-type", "application/json");

            var persona = new Persona(idPersona, nombre, apellidos, fechaNac, telefono, direccion);
            var body = JSON.stringify(persona);

            xmlhtr.send(body);

            replaceInputs(filaEnEdicion, persona);

            filaEnEdicion = -1;
        }
    } else {
        alert("La Persona a guardar no se ha editado");
    }
}


/**
 * Elimina una persona de la base de datos
 */
function eliminarPersona() {
    var xmlhtr = new XMLHttpRequest();
    var fila = this.getAttribute("tag");
    var idPersona = this.value;

    if (idPersona == -1) {
        document.getElementById("table").deleteRow(1);
        filaEnEdicion = -1;
    } else {
        if (confirm("Seguro que quiere eliminar a la Persona?")) {
            if (xmlhtr) {
                xmlhtr.open("DELETE", "../api/personas/" + idPersona);

                xmlhtr.onreadystatechange = function () {
                    if (xmlhtr.readyState == 4 && xmlhtr.status == 204) {
                        document.getElementById("table").deleteRow(fila);
                        filaEnEdicion = -1;
                        alert("La Persona se eliminó correctamente");
                    }
                }
            }
            xmlhtr.send();
        }
    }
}


/**
 * Cuando se añade una nueva persona a la api, este metodo inserta esa persona al final de la tabla sin necesidad de recargar la pagina
 * @param {any} persona
 */
function insertarPersonaAlFinal(persona) {

    var table = document.getElementById("table");
    var childs = table.childElementCount;

    table.appendChild(document.createElement("tr"));
    table.childNodes[childs].setAttribute("id", "fila" + childs);

    table.childNodes[childs].appendChild(document.createElement("td"));
    table.childNodes[childs].childNodes[0].appendChild(document.createTextNode(persona.id));

    table.childNodes[childs].appendChild(document.createElement("td"));
    table.childNodes[childs].childNodes[1].appendChild(document.createTextNode(persona.nombre));

    table.childNodes[childs].appendChild(document.createElement("td"));
    table.childNodes[childs].childNodes[2].appendChild(document.createTextNode(persona.apellidos));

    table.childNodes[childs].appendChild(document.createElement("td"));
    table.childNodes[childs].childNodes[3].appendChild(document.createTextNode(persona.fechaNac.split("T", 1)));

    table.childNodes[childs].appendChild(document.createElement("td"));
    table.childNodes[childs].childNodes[4].appendChild(document.createTextNode(persona.telefono));

    table.childNodes[childs].appendChild(document.createElement("td"));
    table.childNodes[childs].childNodes[5].appendChild(document.createTextNode(persona.direccion));

    //Botones
    //EDITAR
    table.childNodes[childs].appendChild(document.createElement("td"));
    var buttonEdit = document.createElement("button");
    //buttonCreate.setAttribute("id", "button" + persona.id);
    buttonEdit.setAttribute("tag", childs);
    buttonEdit.setAttribute("value", persona.id);
    buttonEdit.setAttribute("class", "glyphicon glyphicon-edit");
    buttonEdit.setAttribute("data-toggle", "tooltip")
    buttonEdit.setAttribute("title", "Editar Persona");
    //buttonEdit.innerHTML = "Editar";
    buttonEdit.addEventListener("click", editarPersona, true);
    table.childNodes[childs].childNodes[6].appendChild(buttonEdit);

    //GUARDAR
    table.childNodes[childs].appendChild(document.createElement("td"));
    var buttonSave = document.createElement("button");
    buttonSave.setAttribute("tag", childs);
    buttonSave.setAttribute("value", persona.id);
    buttonSave.setAttribute("class", "glyphicon glyphicon-floppy-disk");
    buttonSave.setAttribute("data-toggle", "tooltip")
    buttonSave.setAttribute("title", "Guardar Persona");
    buttonSave.addEventListener("click", guardarPersona, true);
    table.childNodes[childs].childNodes[7].appendChild(buttonSave);

    //ELIMINAR
    table.childNodes[childs].appendChild(document.createElement("td"));
    var buttonDelete = document.createElement("button");
    buttonDelete.setAttribute("tag", childs);
    buttonDelete.setAttribute("value", persona.id);
    buttonDelete.setAttribute("class", "glyphicon glyphicon-trash");
    buttonDelete.setAttribute("data-toggle", "tooltip")
    buttonDelete.setAttribute("title", "Eliminar Persona");
    buttonDelete.addEventListener("click", eliminarPersona, true);
    table.childNodes[childs].childNodes[8].appendChild(buttonDelete);
}


function insertarPersonaEnFila(fila, persona) {

}

function createButtonSave(row, column) {

}