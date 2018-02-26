//window.onload = inicializaEventos;

window.addEventListener("load", inicia);

var arrayPersonajeConTransformacionesYHabilidades;

function inicializaEventos() {
    /*document.getElementById("btnHola").addEventListener("click", saluda, false);
    document.getElementById("btnListaPersonas").addEventListener("click", listarPersonas, false);
    document.getElementById("btnTablaPersonas").addEventListener("click", insertaTablaPersonas, false);*/

}

function inicia() {
    insertarTabla();
}

function insertarTabla() {
    var xmlhtr = new XMLHttpRequest();

    //Creamos la tabla
    var table = document.createElement("table");
    table.setAttribute("id", "table");
    //table.setAttribute("border", "collapse");

    if (xmlhtr) {
        //Prepa
        xmlhtr.open('GET', "../api/PersonajeConTransformacionesYHabilidades");

        xmlhtr.onreadystatechange = function () {
            if (xmlhtr.readyState == 4 && xmlhtr.status == 200) {
                //document.getElementById("listadoPersonas").innerHTML = xmlhtr.responseText;//

                //Deserializacion del documento JSON
                arrayPersonajeConTransformacionesYHabilidades = JSON.parse(xmlhtr.responseText);

                //Encabezado de la tabla
                table.appendChild(document.createElement("tr"));
                table.childNodes[0].setAttribute("id", "encabezado");
                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[0].appendChild(document.createTextNode("ID"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[1].appendChild(document.createTextNode("Nombre"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[2].appendChild(document.createTextNode("Habilidades"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[3].appendChild(document.createTextNode("Transformaciones"));

                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[4].appendChild(document.createTextNode("Imagen Transformación"));

                //Boton INSERTAR
                /*var buttonInsert = document.createElement("button");
                buttonInsert.setAttribute("class", "glyphicon glyphicon-plus");
                buttonInsert.setAttribute("data-toggle", "tooltip")
                buttonInsert.setAttribute("title", "Prepara una fila para insertar una nueva Persona");
                buttonInsert.addEventListener("click", insertarPersona, true);
                document.getElementById("contenedorTabla").appendChild(buttonInsert);*/

                for (var i = 0; i < arrayPersonajeConTransformacionesYHabilidades.length; i++) {

                    var personajeConTransformacionesYHabilidades;// = new PersonajeConTransformacionesYHabilidades();
                    personajeConTransformacionesYHabilidades = arrayPersonajeConTransformacionesYHabilidades[i];

                    table.appendChild(document.createElement("tr"));
                    table.childNodes[i + 1].setAttribute("id", "fila" + (i + 1));

                    table.childNodes[i + 1].appendChild(document.createElement("td"));//+1 porque el indice 0 esta ocupado por el encabezado
                    table.childNodes[i + 1].childNodes[0].appendChild(document.createTextNode(personajeConTransformacionesYHabilidades.ID));

                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    table.childNodes[i + 1].childNodes[1].appendChild(document.createTextNode(personajeConTransformacionesYHabilidades.Nombre));

                    //Habilidades
                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    var nombresHabilidades='';
                    for (var j= 0; j < personajeConTransformacionesYHabilidades.listaHabilidades.length;j++){
                        nombresHabilidades += personajeConTransformacionesYHabilidades.listaHabilidades[j].Nombre+",";
                    }
                    
                    table.childNodes[i + 1].childNodes[2].appendChild(document.createTextNode(nombresHabilidades));

                    //Transformaciones
                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    //En esta celda introducimos un desplegable para las Transformaciones
                    /*<select>
                      <option value="volvo">Volvo</option>
                      <option value="saab">Saab</option>
                      <option value="mercedes">Mercedes</option>
                      <option value="audi">Audi</option>
                    </select>
                    */
                    var select = document.createElement('select');//Creamos el elemento select
                    //Recorremos la lista de transformaciones del personaje
                    for (var j = 0; j < personajeConTransformacionesYHabilidades.listaTranformaciones.length; j++){
                        var option = document.createElement("option");
                        //Damos value y text a la opcion
                        option.value = personajeConTransformacionesYHabilidades.listaTranformaciones[j].Nombre;
                        option.text = personajeConTransformacionesYHabilidades.listaTranformaciones[j].Nombre;
                        option.setAttribute("isred", j);
                        //Añadimos la opcion al desplegable
                        select.appendChild(option);
                    }
                    select.selectedIndex = 0;
                    //select.setAttribute("selectedIdex", 0);
                    select.setAttribute("id", "select" + (i + 1));
                    select.setAttribute("tag", (i+1));
                    select.addEventListener("change", cambiaImagen, true);//Evento para cambiar la imagen
                    //Añadimos el desplegable a la celda
                    table.childNodes[i + 1].childNodes[3].appendChild(select);

                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    //Imagen por defecto 
                    var image = document.createElement("img");
                    image.setAttribute("id", "image" + (i + 1));
                    var ruta = ".." + personajeConTransformacionesYHabilidades.listaTranformaciones[0].RutaImagen;
                    image.src = ruta;
                    image.width = 300;
                    image.height = 450;
                    table.childNodes[i + 1].childNodes[4].appendChild(image);


                    //Botones
            /*        //EDITAR
                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    var buttonEdit = document.createElement("button");
                    //buttonCreate.setAttribute("id", "button" + persona.id);
                    buttonEdit.setAttribute("tag", i + 1);
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
            */
                    /*var properties = Object.keys(persona);
                    for (var j = 0; j < properties.length; j++){
                        table.childNodes[i].childNodes[j].appendChild(document.createTextNode(persona.Property(j)));
                        //table.childNodes[i].childNodes[j].textContent = persona[j];

                    }*/
                }
                document.getElementById("contenedorTabla").appendChild(table);
            }
        }
    }
    xmlhtr.send();
}


function cambiaImagen() {
    var idImgElement = this.getAttribute("tag");
    var indexOfImage = this.selectedIndex;
    var ruta = ".." + arrayPersonajeConTransformacionesYHabilidades[idImgElement - 1].listaTranformaciones[indexOfImage].RutaImagen;
    document.getElementById("image"+idImgElement).src = ruta;

}