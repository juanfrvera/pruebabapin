//obtengo el archivo seleccionado en pantalla
function changeFile(e) {

    var file = e.target.files[0];

    if (file != null) {

        //chequeo la extension del archivo que no sea distinto de zip
        var extension = file.name.substring(file.name.length - 4, file.name.length);

        if (extension !== ".zip") {
            alert("El archivo debe ser zip");
            return false;
        }

        var reader = new FileReader();

        if (reader != null) {
            reader.onloadend = function () {

                //Aca hacer una llamada ajax a un metodo en el servidor para que haga la copia del archivo
                // ver como obtener la ruta del archivo
                let url = 'ProyectoAlcanceGeograficoEditWebService.asmx/CopyFile';
                $('#formGeoRef').on('submit', copyFile(url));

            };
            reader.readAsDataURL(file);

        }
        else { alert("No se puede cargar el archivo"); }

    }
    else {
        alert("No se puede cargar el archivo");

    }

}

function buscarShape(event) {
    event.stopPropagation();
    event.preventDefault();
    document.getElementById("searchFile").click();
}