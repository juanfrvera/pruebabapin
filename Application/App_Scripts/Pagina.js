
var x = 5000;
var Guardar;

function obtenerPosPopup(hfx, hfy, modalpopup, panelpopup) {
    if ($get(panelpopup).offsetLeft != 0 && $get(panelpopup).offsetTop != 0) {
        $get(hfx).value = $get(panelpopup).offsetLeft; //$find(modalpopup).get_X();
        $get(hfy).value = $get(panelpopup).offsetTop; //$find(modalpopup).get_Y();
    }
}

function setearPosPopup(hfx, hfy, modalpopup, panelpopup) {
    if ($get(hfx).value != '' && $get(hfy).value != '') {
        $find(modalpopup).set_X($get(hfx).value);
        $find(modalpopup).set_Y($get(hfy).value);
    }
}
function HabilitarCombo(objectName, CheckName) {
    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'select-one') {

            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }
            if (strOtherObjectName == objectName) {
                elm.disabled = !elm.disabled;

            }
        }
    }
}
function ReemplazarPuntoPorComa(tbId) {
    var tb = document.getElementById(tbId);

    var aux = tb.value.replace(".", ",");

    //Busca la primera coma y la última coma
    var index = aux.indexOf(",");
    var indexFin = aux.lastIndexOf(",");
    //Transforma todas las comas que vienen después de la coma en blanco
    if (index != -1 && indexFin != -1 && index != indexFin) {
        //La expresión regular busca todas las comas (el "todas" se expresa con la 'g')
        //Reemplaza todas las comas (o puntos que hubieran quedado) posteriores a la primera por un blanco
        aux = aux.substr(0, index + 1) + (aux.substr(index + 1).replace(/,/g, '').replace(/\./g, ''));
    }

    if (aux != tb.value) tb.value = aux;
}


function validarkey() {
    // Para que use el browse y no teclee la ruta
    alert("Presione el boton Browse para buscar una imagen")
    return false;
}



function initArray() {

    this.length = initArray.arguments.length;
    for (var i = 0; i < this.length; i++)
        this[i + 1] = initArray.arguments[i]

}

//Verifica si hay algún checkbox chequeado
function HayChequeado(objectName) {

    var ok = false;
    var newString;
    var strOtherObjectName;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'checkbox' || elm.type == 'radio') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == objectName) {
                if (elm.checked) {
                    ok = true;
                    break;
                }
            }
        }
    }
    return ok;
}

//Verifica si hay algún checkbox chequeado
function ChequearTodo(objectName, checked) {
    var ok = false;
    var newString;
    var strOtherObjectName;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'checkbox' || elm.type == 'radio') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == objectName) {
                elm.checked = checked;
            }
        }
    }
}

function HabilitarBoton(objectName, buttonName) {
    var ok = false;
    var newString;
    var strOtherObjectName;
    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == buttonName) {
                elm.disabled = !HayChequeado(objectName);
            }
        }
    }
}


function HabilitarDeshabilitarBoton(objectName, buttonName1, buttonName2) {
    var ok = false;
    var newString;
    var strOtherObjectName;
    var disabled = !HayChequeado(objectName)
    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == buttonName1) {
                elm.disabled = disabled;
            }
        }
    }

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == buttonName2) {
                elm.disabled = !disabled;
            }
        }
    }
}

function HabilitarDeshabilitarBoton2(buttonName1, buttonName2) {
    var ok = false;
    var newString;
    var strOtherObjectName;
    var disabled = false;
    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == buttonName1) {
                elm.disabled = disabled;
            }
        }
    }

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == buttonName2) {
                elm.disabled = !disabled;
            }
        }
    }
}

function HabilitarBoton(objectName, buttonNames) {
    var ok = false;
    var newString;
    var strOtherObjectName;
    var disabled = !HayChequeado(objectName)

    //string de nombres de botones a habilitar o deshabilitar según si se seleccionó un radio button
    var newButtonNames = new String(buttonNames);

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Verifica si el botón corresponde a la lista que se debe habilitar (o no) y en ese caso, realiza la accion correspondiente.
            if (newButtonNames.indexOf(";" + strOtherObjectName + ";") >= 0) {
                elm.disabled = disabled;
            }
        }
    }
}




function grabarPos(objectLb, objectHf) {
    try {
        var lb = document.getElementById(objectLb);
        var hf = document.getElementById(objectHf);

        hf.value = lb.scrollTop;
    }
    catch (err) {
    }
}

function setearPos(objectLb, objectHf) {
    try {
        var lb = document.getElementById(objectLb);
        var hf = document.getElementById(objectHf);

        lb.scrollTop = hf.value;
    }
    catch (err) {
    }
}

function resetearPos(objectLb, objectHf) {
    try {
        var lb = document.getElementById(objectLb);
        var hf = document.getElementById(objectHf);

        hf.value = 0;
        lb.scrollTop = hf.value;
    }
    catch (err) {
    }
}

function setearPosDirecto(objectLb, valor) {
    try {
        var lb = document.getElementById(objectLb);

        lb.scrollTop = valor;
    }
    catch (err) {
    }
}


function cancelClick(pagina) {
    location.href = pagina;
}

function HabilitarCombo(objectName, CheckName) {
    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'select-one') {

            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }
            if (strOtherObjectName == objectName) {
                elm.disabled = !elm.disabled;
            }
        }
    }
}

function HabilitarBotonAsignar(objectName, comboName, buttonName) {
    var ok = false;
    var newString;
    var strOtherObjectName;
    var habilitado = false;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'select-one') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == comboName) {
                habilitado = !elm.disabled;
            }
        }
    }

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == buttonName && habilitado) {
                elm.disabled = !HayChequeado(objectName);
            }
        }
    }
}

function desmarcarTodo(objectId, objectName, buttonDisabledNames, buttonNames) {

    //Marca o desmarca un grupo de checkboxes de acuerdo a su nombre en comun
    var str = objectId.replace(/_/g, "$");
    var newString;
    var strOtherObjectName;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'checkbox' || elm.type == 'radio') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == objectName) {
                if (elm.name == str) {
                    elm.checked = true;
                }
                else {

                    elm.checked = false;
                }
            }
        }
    }

    var disabled = !HayChequeado(objectName)

    //string de nombres de botones a habilitar o deshabilitar según si se seleccionó un radio button
    var newButtonDisabledNames = new String(buttonDisabledNames);

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Verifica si el botón corresponde a la lista que se debe habilitar (o no) y en ese caso, realiza la accion correspondiente.
            if (newButtonDisabledNames.indexOf(";" + strOtherObjectName + ";") >= 0) {
                elm.disabled = !disabled;
            }
        }
    }

    HabilitarBotones(objectName, buttonNames);
}

//Para un grid view: deja chequeado un radio button (correspondiente al objectId) y desmarca el resto
//Además si se marcó un radio button habilita los botones que se hayan enviado por parámetros (separados por punto y coma, ejemplo ";boton1;boton2;boton3;"
function DesmarcarRadioHabilitarBotones(objectId, objectName, buttonNames) {

    //Marca el radio button correspondiente al objectId y desmarca el resto
    var str = objectId.replace(/_/g, "$");
    var newString;
    var strOtherObjectName;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'checkbox' || elm.type == 'radio') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Compara si el checkbox es del mismo grupo que se quiere desmarcar verificando si el nombre "extraido"
            //(en el ej. "cbSeleccion" corresponde al nombre que se le asignó en la pagina
            if (strOtherObjectName == objectName) {
                if (elm.name == str) {
                    elm.checked = true;
                }
                else {

                    elm.checked = false;
                }
            }
        }
    }

    var disabled = !HayChequeado(objectName)

    //string de nombres de botones a habilitar o deshabilitar según si se seleccionó un radio button
    var newButtonNames = new String(buttonNames);

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Verifica si el botón corresponde a la lista que se debe habilitar (o no) y en ese caso, realiza la accion correspondiente.
            if (newButtonNames.indexOf(";" + strOtherObjectName + ";") >= 0) {
                elm.disabled = disabled;
            }
        }
    }
}

//si se marcó un check habilita los botones que se hayan enviado por parámetros (separados por punto y coma, ejemplo ";boton1;boton2;boton3;"
function HabilitarBotones(objectName, buttonNames) {
    var newString;
    var strOtherObjectName;
    var disabled = !HayChequeado(objectName)

    //string de nombres de botones a habilitar o deshabilitar según si se seleccionó un radio button
    var newButtonNames = new String(buttonNames);

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Verifica si el botón corresponde a la lista que se debe habilitar (o no) y en ese caso, realiza la accion correspondiente.
            if (newButtonNames.indexOf(";" + strOtherObjectName + ";") >= 0) {
                elm.disabled = disabled;
            }
        }
    }
}

//si se marcó un check habilita los botones que se hayan enviado por parámetros (separados por punto y coma, ejemplo ";boton1;boton2;boton3;"
function DeshabilitarBotones(obj, objectName, buttonNames, state) {
    var newString;
    var strOtherObjectName;
    var disabled = !HayChequeado(objectName)

    //string de nombres de botones a habilitar o deshabilitar según si se seleccionó un radio button
    var newButtonNames = new String(buttonNames);

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'submit') {

            //Ubica y extrae el nombre "real" correspondiente al item que se evalua
            //Ej. el control se llama ctl00$ContentPlaceHolder1$GridView1$ctl02$cbSeleccion, pero el nombre asignado en la página es cbSeleccion
            //Entonces se obtiene "cbSeleccion"
            newString = elm.name;
            j = newString.lastIndexOf("$");
            if (j >= 0) {
                strOtherObjectName = newString.substr(j + 1);
            }
            else {
                strOtherObjectName = newString;
            }

            //Verifica si el botón corresponde a la lista que se debe habilitar (o no) y en ese caso, realiza la accion correspondiente.
            if (state == 1 && obj.checked == false && newButtonNames.indexOf(";" + strOtherObjectName + ";") >= 0) {
                elm.disabled = true;
            }
        }
    }

}

function disableSelect(ControlId) {
    //document.getElementById(disableIt).disabled = true;
    ControlId.disabled = true;
}

function enableSelect(ControlId) {
    //document.getElementById(ControlId).disabled = false;
    ControlId.disabled = false;
}

function toggleSelect(ControlId, habilitado) {
    document.getElementById(ControlId).disabled = habilitado;
}

function FechaPaqueteItem(gridViewId, txtId, etapa, labor, accion) {
    if (ValidarFechaPorId(txtId)) {
        var gridView = document.getElementById(gridViewId);

        if (gridView != null) {

            elm = document.getElementById(txtId)
            var rCountRanking = gridView.rows.length;
            var rowIdx = 1;

            //grilla Paquete
            for (rowIdx; rowIdx <= rCountRanking - 1; rowIdx++) {
                var row = gridView.rows[rowIdx];
                if (row.cells[1].innerHTML == HtmlDecode(etapa) && row.cells[2].innerHTML == HtmlDecode(labor) && row.cells[3].innerHTML == HtmlDecode(accion)) {
                    row.cells[6].all[0].value = elm.value;
                }
            }
        }
    }
}

function PadNumber(nro, objeto, defaultStr) {
    /*
    nro: cantidad de digitos que debe tener el objeto
    objeto: objeto a cuyo valor hay que realizar el pad number; el valor viene en formato ___1 (si "nro" fuera 4), debe ser transformado a 0001
    defaultStr: el default contral el cual se compara, si el valor del objeto es igual al default no se realiza el padding
    */
    var content = new String(document.getElementById(objeto).value);
    var regExpStr = new RegExp('_', 'g');

    if (content != defaultStr)
        content = content.replace(regExpStr, '');
    var str = content;
    while (str.length < nro) {
        str = '0' + str;
    }

    document.getElementById(objeto).value = str;
}

function ReemplazarMascaraNumero(objeto) {
    var content = new String(document.getElementById(objeto).value);
    var regExpStr = new RegExp('_', 'g');

    var pad4 = content.substring(0, 4);
    var pad8 = content.substring(5, 13);

    if (pad4 != "____")
        pad4 = pad4.replace(regExpStr, '');
    var str4 = pad4;
    while (str4.length < 4) {
        str4 = '0' + str4;
    }

    if (pad8 != "________")
        pad8 = pad8.replace(regExpStr, '');
    var str8 = pad8;
    while (str8.length < 8) {
        str8 = '0' + str8;
    }

    document.getElementById(objeto).value = str4 + '-' + str8;
}

function Truncate(nro, objeto) {

    var content = new String(document.getElementById(objeto).value);
    if (content.length > nro)
        document.getElementById(objeto).value = content.substr(0, nro);

}