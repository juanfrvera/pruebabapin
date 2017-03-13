var textBoxError = '#ffcccc'
var textBoxValidado = '#ffffff'

//Validadores javascript
function ValidarCuitEvento(obj, args) {
    args.IsValid = ValidarCuit(args.Value);
}

function ValidarCuit(cuit) {
    if (typeof (cuit) == 'undefined')
        return true;
    cuit = cuit.toString().replace(/[-_]/g, "");
    if (cuit == '')
        return true;
    if (cuit.length != 11)
        return false;
    else {
        var mult = [5, 4, 3, 2, 7, 6, 5, 4, 3, 2];
        var total = 0;
        for (var i = 0; i < mult.length; i++) {
            total += parseInt(cuit.substr(i, 1)) * mult[i];
        }
        var mod = total % 11;
        var digito = mod == 0 ? 0 : mod == 1 ? 9 : 11 - mod;
    }
    return digito == parseInt(cuit.substr(10, 1));
}

function ValidarRequerido(objectName) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                if (elm.value.replace(" ", "") == "") {
                    elm.style.backgroundColor = textBoxError;
                    ok = false;
                }
                else {
                    elm.style.backgroundColor = textBoxValidado;
                }
            }
        }
    }
    return ok;
}

function ValidarRequeridoPorId(objectName) {
    var ok = true;

    elm = document.getElementById(objectName)

    if (elm.value.replace(" ", "") == "") {
        elm.style.backgroundColor = textBoxError;
        ok = false;
    }
    else {
        elm.style.backgroundColor = textBoxValidado;
    }

    return ok;
}

function ValidarDecimalMayorACero(objectName, decimales) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                if (elm.value.replace(",", "") == "") {
                    elm.style.backgroundColor = textBoxError;
                    ok = false;
                }
                else {
                    if ((elm.value.replace(/,/g, "").length + 1) == elm.value.length) {
                        if (elm.value.length > decimales) {
                            if (elm.value.indexOf(",") < elm.value.length - (parseInt(decimales, 10) + 1)) {
                                ok = false;
                                elm.style.backgroundColor = textBoxError;
                            }
                        }
                    }

                    if ((elm.value.replace(/,/g, "").length + 1) < elm.value.length) {
                        ok = false;
                        elm.style.backgroundColor = textBoxError;
                    }

                    if (ok) {
                        if (parseFloat(elm.value) > 9999999.999 || parseFloat(elm.value) <= 0) {
                            ok = false;
                            elm.style.backgroundColor = textBoxError;
                        }
                        else
                            elm.style.backgroundColor = textBoxValidado;
                    }
                }
            }
        }
    }
    return ok;
}

function ValidarDecimal(objectName, decimales) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                if (elm.value.replace(",", "") == "") {
                    elm.style.backgroundColor = textBoxError;
                    ok = false;
                }
                else {
                    if ((elm.value.replace(/,/g, "").length + 1) == elm.value.length) {
                        if (elm.value.length > decimales) {
                            if (elm.value.indexOf(",") < elm.value.length - (parseInt(decimales, 10) + 1)) {
                                ok = false;
                                elm.style.backgroundColor = textBoxError;
                            }
                        }
                    }

                    if ((elm.value.replace(/,/g, "").length + 1) < elm.value.length) {
                        ok = false;
                        elm.style.backgroundColor = textBoxError;
                    }

                    if (ok) {
                        if (parseFloat(elm.value) > 9999999.999) {
                            ok = false;
                            elm.style.backgroundColor = textBoxError;
                        }
                        else
                            elm.style.backgroundColor = textBoxValidado;
                    }
                }
            }
        }
    }
    return ok;
}

function ValidarDecimalPorId(objectName, decimales) {
    var ok = true;

    elm = document.getElementById(objectName)

    if (elm.value.replace(",", "") == "") {
        elm.style.backgroundColor = textBoxError;
        ok = false;
    }
    else {
        if ((elm.value.replace(/,/g, "").length + 1) == elm.value.length) {
            if (elm.value.length > decimales) {
                if (elm.value.indexOf(",") < elm.value.length - (parseInt(decimales, 10) + 1)) {
                    ok = false;
                    elm.style.backgroundColor = textBoxError;
                }
            }
        }

        if ((elm.value.replace(/,/g, "").length + 1) < elm.value.length) {
            ok = false;
            elm.style.backgroundColor = textBoxError;
        }

        if (ok) {
            if (parseFloat(elm.value) > 9999999.999) {
                ok = false;
                elm.style.backgroundColor = textBoxError;
            }
            else
                elm.style.backgroundColor = textBoxValidado;
        }
    }
    return ok;
}

function ValidarRango(objectName, minimo, maximo) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                if (elm.value == "" || (parseFloat(elm.value.replace(",", ".")) < parseFloat(minimo) || parseFloat(elm.value.replace(",", ".")) > parseFloat(maximo))) {
                    elm.style.backgroundColor = textBoxError;
                    ok = false;
                }
                else {
                    if (ValidarDecimalPorId(newString, 2))
                        elm.style.backgroundColor = textBoxValidado;
                    else {
                        elm.style.backgroundColor = textBoxError;
                        ok = false;
                    }
                }
            }
        }
    }
    return ok;
}

function ValidarRangoPorId(objectName, minimo, maximo) {
    var ok = true;

    elm = document.getElementById(objectName)

    if (elm.value == "" || (elm.value < minimo || elm.value > maximo)) {
        elm.style.backgroundColor = textBoxError;
        ok = false;
    }
    else {
        elm.style.backgroundColor = textBoxValidado;
    }

    return ok;
}

function ValidarFecha(objectName) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                if (!ValidarDiaMes(elm.value)) {
                    elm.style.backgroundColor = textBoxError;
                    ok = false;
                }
                else {
                    elm.style.backgroundColor = textBoxValidado;
                }
            }
        }
    }
    return ok;
}

function ValidarFechaPorId(objectName) {
    var ok = true;

    elm = document.getElementById(objectName)

    if (!ValidarDiaMes(elm.value)) {
        elm.style.backgroundColor = textBoxError;
        ok = false;
    }
    else {
        elm.style.backgroundColor = textBoxValidado;
    }

    return ok;
}

function ValidarDiaMes(value) {
    value = value.replace("_", "")
    straux = value

    h = straux.indexOf("/")

    val_ent = 0

    dia_ent = straux.substring(0, h)

    if (dia_ent.length == 1) {
        dia_ent = '0' + dia_ent
        straux = '0' + straux
        h = straux.indexOf("/")
    }
    straux = straux.substring(h + 1, straux.length)

    mes_ent = straux

    if (mes_ent.length == 1) {
        mes_ent = '0' + mes_ent
        straux = '0' + straux
    }

    var ok = true;

    if ((parseInt(dia_ent, 10) < 1) || (parseInt(dia_ent, 10) > 31) || (isNaN(dia_ent))) ok = false;

    var diasxmes = new initArray(31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

    if (parseInt(mes_ent, 10) < 1 || parseInt(mes_ent, 10) > 12 || (isNaN(mes_ent))) ok = false;

    if (dia_ent > diasxmes[parseInt(mes_ent, 10)]) ok = false;

    return ok;
}

function ValidarAnioMesPorNombre(objectName) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                if (!ValidarAnioMes(elm.value)) {
                    elm.style.backgroundColor = textBoxError;
                    ok = false;
                }
                else {
                    elm.style.backgroundColor = textBoxValidado;
                }
            }
        }
    }
    return ok;
}

function ValidarAnioMesPorId(objectName) {
    var ok = true;

    elm = document.getElementById(objectName)

    if (!ValidarAnioMes(elm.value)) {
        elm.style.backgroundColor = textBoxError;
        ok = false;
    }
    else {
        elm.style.backgroundColor = textBoxValidado;
    }
    return ok;
}


function ValidarAnioMes(value) {

    //formato de entrada YYYY/MM (anio/mes)
    value = value.replace(/_/g, "")
    straux = value

    //ubicar la posicion de la barra separadora
    h = straux.indexOf("/")

    val_ent = 0

    //extraer el anio
    anio_ent = straux.substring(0, h)

    //extraer el mes y si es necesario antecederle un cero
    straux = straux.substring(h + 1, straux.length)
    mes_ent = straux

    if (mes_ent.length == 1) {
        mes_ent = '0' + mes_ent
        straux = '0' + straux
    }

    var ok = true;

    if (value != "/") {
        //Verifica que el anio no sea de 3 digitos y que sea mayor a 2000 y no sea la máscara de ingreso
        if (parseInt(anio_ent, 10) < 2000 || parseInt(anio_ent, 10) >= 3000 || anio_ent.length < 4 || (isNaN(anio_ent))) ok = false;

        //Verifica que el mes ingresado sea entre 1 y 12
        if (parseInt(mes_ent, 10) < 1 || parseInt(mes_ent, 10) > 12 || (isNaN(mes_ent))) ok = false;
    }


    return ok;
}

function ValidarMascara(objectName) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                if (elm.value.replace("_", "").length != elm.value.length) {
                    elm.style.backgroundColor = textBoxError;
                    ok = false;
                }
                else {
                    elm.style.backgroundColor = textBoxValidado;
                }
            }
        }
    }
    return ok;
}

function ValidarMascaraPorId(objectName) {
    var ok = true;

    elm = document.getElementById(objectName)

    if (elm.value.replace("_", "").length != elm.value.length) {
        elm.style.backgroundColor = textBoxError;
        ok = false;
    }
    else {
        elm.style.backgroundColor = textBoxValidado;
    }

    return ok;
}

function ValidarFechaCompletaPorId(objectName) {
    var ok = true;

    elm = document.getElementById(objectName)

    straux = elm.value
    h = elm.value.indexOf("/")

    val_ent = 0

    if (h == -1) {
        ok = false;
    }
    else {

        dia_ent = straux.substring(0, h)

        if (isNaN(parseInt(dia_ent, 10))) {
            ok = false;
        }

        if (dia_ent.length == 1) {
            dia_ent = '0' + dia_ent
            straux = '0' + straux
            h = straux.indexOf("/")
        }
        straux = straux.substring(h + 1, straux.length)

        h = straux.indexOf("/")

        if (h == -1) {
            ok = false;
        }
        else {

            mes_ent = straux.substring(0, h)

            if (isNaN(parseInt(mes_ent, 10))) {
                ok = false;
            }

            if (mes_ent.length == 1) {
                mes_ent = '0' + mes_ent
                straux = '0' + straux
                h = straux.indexOf("/")
            }
            straux = straux.substring(h + 1, straux.length)


            anio_ent = straux

            if (anio_ent.length < 4) {
                ok = false;
            }
            else {


                if ((parseInt(dia_ent, 10) < 1) || (parseInt(dia_ent, 10) > 31) || (isNaN(dia_ent))) {
                    val_ent = 1
                }

                var diasxmes = new initArray(31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

                if (parseInt(mes_ent, 10) < 1 || parseInt(mes_ent, 10) > 12 || (isNaN(mes_ent)))
                    val_ent = 2;

                if (dia_ent > diasxmes[parseInt(mes_ent, 10)]) val_ent = 1;


                if (parseInt(anio_ent, 10) < 1 || parseInt(anio_ent, 10) > 9999 || (isNaN(anio_ent)))
                    val_ent = 3;

                resto = anio_ent % 400;
                if (resto == 0) cuatrocientos = true;
                else cuatrocientos = false;
                resto = anio_ent % 100;
                if (resto == 0) cien = true;
                else cien = false;
                resto = anio_ent % 4;
                if (resto == 0) cuatro = true;
                else cuatro = false;

                bisiesto = (cuatrocientos || (cuatro && !(cien)));



                if ((dia_ent == 29) && (mes_ent == 02) && !(bisiesto)) ok = false;

                var anio_ent_aux;
                anio_ent_aux = Number(anio_ent);
                if (anio_ent < 1900) val_ent = 3;

                if (val_ent == 1) ok = false;
                if (val_ent == 2) ok = false;
                if (val_ent == 3) ok = false;
            }
        }
    }

    if (ok)
        elm.style.backgroundColor = textBoxValidado;
    else
        elm.style.backgroundColor = textBoxError;

    return ok;
}

function ValidarFechaCompleta(objectName) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                straux = elm.value
                h = elm.value.indexOf("/")

                val_ent = 0

                if (h == -1) {
                    ok = false;
                }
                else {

                    dia_ent = straux.substring(0, h)

                    if (isNaN(parseInt(dia_ent, 10))) {
                        ok = false;
                    }

                    if (dia_ent.length == 1) {
                        dia_ent = '0' + dia_ent
                        straux = '0' + straux
                        h = straux.indexOf("/")
                    }
                    straux = straux.substring(h + 1, straux.length)

                    h = straux.indexOf("/")

                    if (h == -1) {
                        ok = false;
                    }
                    else {

                        mes_ent = straux.substring(0, h)

                        if (isNaN(parseInt(mes_ent, 10))) {
                            ok = false;
                        }

                        if (mes_ent.length == 1) {
                            mes_ent = '0' + mes_ent
                            straux = '0' + straux
                            h = straux.indexOf("/")
                        }
                        straux = straux.substring(h + 1, straux.length)


                        anio_ent = straux

                        if (anio_ent.length < 4) {
                            ok = false;
                        }
                        else {


                            if ((parseInt(dia_ent, 10) < 1) || (parseInt(dia_ent, 10) > 31) || (isNaN(dia_ent))) {
                                val_ent = 1
                            }

                            var diasxmes = new initArray(31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

                            if (parseInt(mes_ent, 10) < 1 || parseInt(mes_ent, 10) > 12 || (isNaN(mes_ent)))
                                val_ent = 2;

                            if (dia_ent > diasxmes[parseInt(mes_ent, 10)]) val_ent = 1;


                            if (parseInt(anio_ent, 10) < 1 || parseInt(anio_ent, 10) > 9999 || (isNaN(anio_ent)))
                                val_ent = 3;

                            resto = anio_ent % 400;
                            if (resto == 0) cuatrocientos = true;
                            else cuatrocientos = false;
                            resto = anio_ent % 100;
                            if (resto == 0) cien = true;
                            else cien = false;
                            resto = anio_ent % 4;
                            if (resto == 0) cuatro = true;
                            else cuatro = false;

                            bisiesto = (cuatrocientos || (cuatro && !(cien)));



                            if ((dia_ent == 29) && (mes_ent == 02) && !(bisiesto)) ok = false;

                            var anio_ent_aux;
                            anio_ent_aux = Number(anio_ent);
                            if (anio_ent < 1900) val_ent = 3;

                            if (val_ent == 1) ok = false;
                            if (val_ent == 2) ok = false;
                            if (val_ent == 3) ok = false;
                        }
                    }
                }

                if (ok)
                    elm.style.backgroundColor = textBoxValidado;
                else
                    elm.style.backgroundColor = textBoxError;
            }
        }
    }
    return ok;
}

function ValidarFechaAnteriorCompleta(objectName) {
    var ok = true;

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];

        if (elm.name != null) {
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
                straux = elm.value
                h = elm.value.indexOf("/")

                val_ent = 0

                if (h == -1) {
                    ok = false;
                }
                else {

                    dia_ent = straux.substring(0, h)

                    if (isNaN(parseInt(dia_ent, 10))) {
                        ok = false;
                    }

                    if (dia_ent.length == 1) {
                        dia_ent = '0' + dia_ent
                        straux = '0' + straux
                        h = straux.indexOf("/")
                    }
                    straux = straux.substring(h + 1, straux.length)

                    h = straux.indexOf("/")

                    if (h == -1) {
                        ok = false;
                    }
                    else {

                        mes_ent = straux.substring(0, h)

                        if (isNaN(parseInt(mes_ent, 10))) {
                            ok = false;
                        }

                        if (mes_ent.length == 1) {
                            mes_ent = '0' + mes_ent
                            straux = '0' + straux
                            h = straux.indexOf("/")
                        }
                        straux = straux.substring(h + 1, straux.length)


                        anio_ent = straux

                        if (anio_ent.length < 4) {
                            ok = false;
                        }
                        else {


                            if ((parseInt(dia_ent, 10) < 1) || (parseInt(dia_ent, 10) > 31) || (isNaN(dia_ent))) {
                                val_ent = 1
                            }

                            var diasxmes = new initArray(31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

                            if (parseInt(mes_ent, 10) < 1 || parseInt(mes_ent, 10) > 12 || (isNaN(mes_ent)))
                                val_ent = 2;

                            if (dia_ent > diasxmes[parseInt(mes_ent, 10)]) val_ent = 1;


                            if (parseInt(anio_ent, 10) < 1 || parseInt(anio_ent, 10) > 9999 || (isNaN(anio_ent)))
                                val_ent = 3;

                            resto = anio_ent % 400;
                            if (resto == 0) cuatrocientos = true;
                            else cuatrocientos = false;
                            resto = anio_ent % 100;
                            if (resto == 0) cien = true;
                            else cien = false;
                            resto = anio_ent % 4;
                            if (resto == 0) cuatro = true;
                            else cuatro = false;

                            bisiesto = (cuatrocientos || (cuatro && !(cien)));



                            if ((dia_ent == 29) && (mes_ent == 02) && !(bisiesto)) ok = false;

                            var anio_ent_aux;
                            anio_ent_aux = Number(anio_ent);
                            if (anio_ent < 1900) val_ent = 3;

                            if (val_ent == 1) ok = false;
                            if (val_ent == 2) ok = false;
                            if (val_ent == 3) ok = false;
                        }
                    }
                }

                if (ok) {
                    hoy = new Date();
                    if (hoy.getFullYear() < parseInt(anio_ent, 10))
                        ok = false;
                    else
                        if (hoy.getFullYear() == parseInt(anio_ent, 10))
                        if ((hoy.getMonth() + 1) < parseInt(mes_ent, 10))
                        ok = false;
                    else
                        if ((hoy.getMonth() + 1) == parseInt(mes_ent, 10))
                        if (hoy.getDate() < parseInt(dia_ent, 10))
                        ok = false;
                }

                if (ok)
                    elm.style.backgroundColor = textBoxValidado;
                else
                    elm.style.backgroundColor = textBoxError;
            }
        }
    }
}


function ValidarFechaAnteriorCompletaPorId(objectName) {
    var ok = true;

    elm = document.getElementById(objectName)

    straux = elm.value
    h = elm.value.indexOf("/")

    val_ent = 0

    if (h == -1) {
        ok = false;
    }
    else {

        dia_ent = straux.substring(0, h)

        if (isNaN(parseInt(dia_ent, 10))) {
            ok = false;
        }

        if (dia_ent.length == 1) {
            dia_ent = '0' + dia_ent
            straux = '0' + straux
            h = straux.indexOf("/")
        }
        straux = straux.substring(h + 1, straux.length)

        h = straux.indexOf("/")

        if (h == -1) {
            ok = false;
        }
        else {

            mes_ent = straux.substring(0, h)

            if (isNaN(parseInt(mes_ent, 10))) {
                ok = false;
            }

            if (mes_ent.length == 1) {
                mes_ent = '0' + mes_ent
                straux = '0' + straux
                h = straux.indexOf("/")
            }
            straux = straux.substring(h + 1, straux.length)


            anio_ent = straux

            if (anio_ent.length < 4) {
                ok = false;
            }
            else {


                if ((parseInt(dia_ent, 10) < 1) || (parseInt(dia_ent, 10) > 31) || (isNaN(dia_ent))) {
                    val_ent = 1
                }

                var diasxmes = new initArray(31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

                if (parseInt(mes_ent, 10) < 1 || parseInt(mes_ent, 10) > 12 || (isNaN(mes_ent)))
                    val_ent = 2;

                if (dia_ent > diasxmes[parseInt(mes_ent, 10)]) val_ent = 1;


                if (parseInt(anio_ent, 10) < 1 || parseInt(anio_ent, 10) > 9999 || (isNaN(anio_ent)))
                    val_ent = 3;

                resto = anio_ent % 400;
                if (resto == 0) cuatrocientos = true;
                else cuatrocientos = false;
                resto = anio_ent % 100;
                if (resto == 0) cien = true;
                else cien = false;
                resto = anio_ent % 4;
                if (resto == 0) cuatro = true;
                else cuatro = false;

                bisiesto = (cuatrocientos || (cuatro && !(cien)));



                if ((dia_ent == 29) && (mes_ent == 02) && !(bisiesto)) ok = false;

                var anio_ent_aux;
                anio_ent_aux = Number(anio_ent);
                if (anio_ent < 1900) val_ent = 3;

                if (val_ent == 1) ok = false;
                if (val_ent == 2) ok = false;
                if (val_ent == 3) ok = false;
            }
        }
    }

    if (ok) {
        hoy = new Date();
        if (hoy.getFullYear() < parseInt(anio_ent, 10))
            ok = false;
        else
            if (hoy.getFullYear() == parseInt(anio_ent, 10))
            if ((hoy.getMonth() + 1) < parseInt(mes_ent, 10))
            ok = false;
        else
            if ((hoy.getMonth() + 1) == parseInt(mes_ent, 10))
            if (hoy.getDate() < parseInt(dia_ent, 10))
            ok = false;
    }

    if (ok)
        elm.style.backgroundColor = textBoxValidado;
    else
        elm.style.backgroundColor = textBoxError;

    return ok;
}