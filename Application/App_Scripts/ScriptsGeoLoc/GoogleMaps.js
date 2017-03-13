function geoLocation(mapa, textoBusqueda, textoLatitud, textoLongitud) {

    //para que esto funcione es necesario realizar unos pasos antes de codificar

    //1) habilitar las APIs de Google para poder acceder a las funcionalidades de los mapas, estas APIs son:
    // - Google Maps Directions API 
    // - Google Maps Geocoding API 
    // - Google Maps Geolocation API 
    // - Google Maps JavaScript API 
    // - Google Places API Web Service 

    //para habilitar las mismas vamos a la siguiente pagina:
    //https://console.developers.google.com/apis/library?project=proyecto-capurro&hl=es
    // y ahi vemos todas las aplis disponibles, pero debemos clickear las apis que estan en APIs de Google Maps, una vez ahi 
    //ya nos aparece para habilitar

    //2) luego debemos obtener una clave para usar las apis que habilitamos en el punto anterior, para ello, vamos a la pagina:
    //https://console.developers.google.com/apis/credentials?project=proyecto-capurro&hl=es
    //y presionamos el boton crear credenciales, seguimos los pasos para la creacion y listo

    //3) por ultimo, cuando creemos la clave, en la pagina mencionada en el punto 2 , veremos en una grilla, el registro con nuestra clave creada
    //hacemos click en el nombre que le dimos, en nuestro caso, clickeamos sobre el nombre RODRIGO. A continuacion, vamos a la seccion de
    //ACEPTAR SOLICITUDES DE ESTAS URL DE REFERENCIA HTTP (SITIOS WEB) y ahi escribimos las url que queremos permitir que naveguen en nuestra pagina donde 
    //creamos los mapas. PROBAR QUE FUNCIONES Y LISTO

    if (!!navigator.geolocation) {

        var map;
        var hexVal = "0123456789ABCDEF".split("");
        var defaultColor = '#f00';

        var mapOptions = {
            zoom: 17,
            mapTypeId: google.maps.MapTypeId.TERRAIN,
            draggableCursor: 'default',
            draggingCursor: 'default'
        };

        map = new google.maps.Map(document.getElementById(mapa), mapOptions);
       
        //creaa la configuracion para los poligonos
        var polygon = new google.maps.Polygon({
            path: new google.maps.MVCArray(),
		    map: map,
		    strokeColor: defaultColor,
		    strokeWeight: 3,
		    strokeOpacity: 0.5,
		    fillColor: defaultColor,
		    fillOpacity: 0.3,
		    clickable: false
        });

        //configura el color para el poligonos
        function makeColor() {
            /**
             * Otra forma de crear un color aleatoriamente:
             *
             * for(var color = Math.floor(Math.random()*0xffffff).toString(16); color.length < 6; color = '0'+color);
             * return '#' + color;
             */
            return '#' + hexVal.sort(function () {
                return (Math.round(Math.random()) - 0.5);
            }).slice(0, 6).join('');
        }

        polygon.currentColor = makeColor();

        google.maps.event.addListener(map, 'rightclick', function(){
            polygon.setOptions({
                strokeColor: polygon.currentColor
             , fillColor: polygon.currentColor
             , clickable: true
            });
            polygon = new google.maps.Polygon({
                path: new google.maps.MVCArray()
                , map: map
                , strokeColor: defaultColor
                , strokeWeight: 3
                , strokeOpacity: 0.5
                , fillColor: defaultColor
                , fillOpacity: 0.3
                , clickable: false
            });

            polygon.currentColor = makeColor();
            google.maps.event.addListener(polygon, 'click', function () {
                polygon.setOptions({
                    strokeColor: polygon.currentColor
                    , fillColor: polygon.currentColor
                    , clickable: true
                });
                polygon = this, this.setOptions({
                    strokeColor: defaultColor
                    , fillColor: defaultColor
                    , clickable: false
                });
            });
        })

        google.maps.event.addListener(map, 'click', function (event) {
            textoLatitud.value = event.latLng.lat();
            textoLongitud.value = event.latLng.lng();
            polygon.getPath().push(event.latLng);

        });

        google.maps.event.addListener(polygon, 'click', function (e) {
           
            polygon.setOptions({
                strokeColor: polygon.currentColor
			, fillColor: polygon.currentColor
			, clickable: true
            });
            polygon = this, this.setOptions({
                strokeColor: defaultColor
                , fillColor: defaultColor
                , clickable: false
            });

        });
        navigator.geolocation.getCurrentPosition(function (position) {

            var geolocate = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);

            var infowindow = new google.maps.Marker({
                position: geolocate,
                map: map
            });

            map.setCenter(geolocate);

        });

        // Create the search box and link it to the UI element.
        var input = document.getElementById(textoBusqueda);
        var searchBox = new google.maps.places.SearchBox(input);
        map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

        // Bias the SearchBox results towards current map's viewport.
        map.addListener('bounds_changed', function () {
            searchBox.setBounds(map.getBounds());
        });

        var markers = [];
        // [START region_getplaces]
        // Listen for the event fired when the user selects a prediction and retrieve
        // more details for that place.
        searchBox.addListener('places_changed', function () {
            var places = searchBox.getPlaces();

            if (places.length == 0) {
                return;
            }

            // Clear out the old markers.
            markers.forEach(function (marker) {
                marker.setMap(null);
            });
            markers = [];

            // For each place, get the icon, name and location.
            var bounds = new google.maps.LatLngBounds();
            places.forEach(function (place) {
                var icon = {
                    url: place.icon,
                    size: new google.maps.Size(71, 71),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(17, 34),
                    scaledSize: new google.maps.Size(25, 25)
                };

                // Create a marker for each place.
                markers.push(new google.maps.Marker({
                    map: map,
                    icon: icon,
                    title: place.name,
                    position: place.geometry.location
                }));

                if (place.geometry.viewport) {
                    // Only geocodes have viewport.
                    bounds.union(place.geometry.viewport);
                } else {
                    bounds.extend(place.geometry.location);
                }
            });
           
            map.fitBounds(bounds);
            map.setZoom(17);
        });
        // [END region_getplaces]

    } else {
        document.getElementById(mapa).innerHTML = 'Error en geolocalización.';
    }

}