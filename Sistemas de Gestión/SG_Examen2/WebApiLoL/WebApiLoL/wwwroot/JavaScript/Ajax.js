//alert("dd");
window.addEventListener("load", inicia);

//Variables Globales
var contadorChecks = 0;//Contador de checkBox marcados
var idChecksMarcados = new Array();//Cada vez que se pulse un check se añadirá su id al array (el id coincide con la fila en la tabla)
var arrayPersonajes;//Array de los personajes que vienen de la API

/**
 * Evento que se llama al cargar la pagina, éste carga la tabla de los personajes y
 * el botón para ver los detalles de los personajes.
 */
function inicia() {
    insertaBotonDetalles();
    insertarTabla();
}

/**
 * Inserta la una tabla con los personajes de la base de datos
 */
function insertarTabla() {
    var xmlhtr = new XMLHttpRequest();

    //Creamos la tabla
    var table = document.createElement("table");
    table.setAttribute("id", "table");
    //table.setAttribute("border", "collapse");

    if (xmlhtr) {
        xmlhtr.open('GET', "../api/Personajes");

        xmlhtr.onreadystatechange = function () {
            if (xmlhtr.readyState == 4 && xmlhtr.status == 200) {
                //Deserializacion del documento JSON
                arrayPersonajes = JSON.parse(xmlhtr.responseText);

                //Encabezado de la tabla
                table.appendChild(document.createElement("tr"));
                table.childNodes[0].setAttribute("id", "encabezado");
                table.childNodes[0].appendChild(document.createElement("th"));
                table.childNodes[0].childNodes[0].appendChild(document.createTextNode("Nombre"));

                table.childNodes[0].appendChild(document.createElement("th"));

                for (var i = 0; i < arrayPersonajes.length; i++) {
                    var personaje;
                    personaje = arrayPersonajes[i];

                    table.appendChild(document.createElement("tr"));
                    table.childNodes[i + 1].setAttribute("id", "fila" + (i + 1));

                    table.childNodes[i + 1].appendChild(document.createElement("td"));//+1 porque el indice 0 esta ocupado por el encabezado
                    table.childNodes[i + 1].childNodes[0].appendChild(document.createTextNode(personaje.nombre));

                    //CheckBox
                    table.childNodes[i + 1].appendChild(document.createElement("td"));
                    var checkBox = document.createElement('input');
                    checkBox.setAttribute("id", (i + 1));//El ID será el número de la fila
                    checkBox.setAttribute("type", "checkbox");
                    //checkBox.setAttribute("checked", "");
                    checkBox.addEventListener('click', compruebaCheck, true);
                    table.childNodes[i + 1].childNodes[1].appendChild(checkBox);              
                }
                document.getElementById("contenedorTabla").appendChild(table);
            }
        }
    }
    xmlhtr.send();
}

/**
 * Inserta el boton para ver detalles de los personajes
 */
function insertaBotonDetalles() {
    //Boton Detalles
    var buttonDetails = document.createElement("button");
    //buttonDetails.setAttribute("tag", i + 1);
    //buttonDetails.setAttribute("value", persona.id);
    //buttonDetails.setAttribute("class", "glyphicon glyphicon-de");
    buttonDetails.setAttribute("data-toggle", "tooltip")
    buttonDetails.setAttribute("title", "Detalles Personajes");
    buttonDetails.innerHTML = "Detalles";
    buttonDetails.addEventListener("click", muestraDetalles, true);
    document.getElementById("divBotonDetalles").appendChild(buttonDetails);
}

/**
 * Cuando se marca un checkBox comprueba que no se hayan marcado más de cuatro
 * si es así lo desmarcará.
 */
function compruebaCheck() {
    var idCheck = this.getAttribute("id");
    var checkBox = document.getElementById(idCheck);
    var activo = checkBox.checked;  

    if (activo) {
        contadorChecks++;
        if (contadorChecks == 5) {//Si ha marcado el quinto lo desmarcamos
            checkBox.checked = false;
            contadorChecks--;
        } else {
            idChecksMarcados.push(idCheck);
        }      
    } else {
        contadorChecks--;
        var indiceADesmarcar = idChecksMarcados.indexOf(idCheck);
        //idChecksMarcados[indiceADesmarcar] = -1;//Se puede mejorar 
        idChecksMarcados.splice(indiceADesmarcar);
    }
}

/**
 * Muestra los detalles de los Personajes seleccionados
 */
function muestraDetalles() {
    removeDetalles();
    for (var i = 0; i < idChecksMarcados.length; i++){
        //if (idChecksMarcados[i] != -1) {
            insertaDetalle(idChecksMarcados[i]-1);//
        //}
    }
}

/**
 * Inserta los detalles de un personaje
 * @param {any} indicePersonaje
 */
function insertaDetalle(indicePersonaje) {
    var p = document.createElement("p");
    var p2 = document.createElement("p");
    var nombre = arrayPersonajes[indicePersonaje].nombre;
    var rutaImagen = "../Images/" + nombre + ".png";
    var alias = arrayPersonajes[indicePersonaje].alias;
    var vida = arrayPersonajes[indicePersonaje].vida;
    var regeneracion = arrayPersonajes[indicePersonaje].regeneracion;
    var velAtaque = arrayPersonajes[indicePersonaje].velAtaque;
    var resistencia = arrayPersonajes[indicePersonaje].resistencia;
    var velMovimiento = arrayPersonajes[indicePersonaje].velMovimiento;

    //P para nombre y alias
    p.appendChild(document.createTextNode("Nombre: " + nombre + "     Alias: " + alias));

    //P para valores habilidades
    p2.appendChild(document.createTextNode("Vida: " + vida + "   Regeneración: " + regeneracion +
        "  Velocidad de Ataque: " + velAtaque + "  Resistencia: " + resistencia + "  Velocidad de Movimiento: " + velMovimiento ));

    //IMG
    var img = document.createElement("img");
    img.src = rutaImagen;
    img.height = 300;
    img.width = 200;

    document.getElementById("divDetalles").appendChild(p);
    document.getElementById("divDetalles").appendChild(p2);
    document.getElementById("divDetalles").appendChild(img);
    document.getElementById("divDetalles").appendChild(document.createElement("hr"));
}

/**
 * Elimina los childsNodes del div de detalles
 */
function removeDetalles() {  
    var divDetalles = document.getElementById("divDetalles");
    var hijos = divDetalles.childElementCount;
    if (hijos > 0) {
        for (var i = hijos; i > 0; i--) {
            divDetalles.removeChild(divDetalles.childNodes[i]);
        }
    }
}