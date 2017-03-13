function GoolgleMapsView(mapa, direccion, textoLatitud, textoLongitud) {

	//referencia de donde se saco el codigo https://www.returngis.net/2011/02/google-maps-api-v-3-y-asp-net-mvc-3-con-razor/
    var bounds = new google.maps.LatLngBounds();
    var options = {
        mapTypeId: google.maps.MapTypeId.TERRAIN,
        zoom: 8
    };
    var googleMap = new google.maps.Map($('#' + mapa)[0], options);

    //con esta funcion obtengo la latitud y longitud segun en que parte del mapa clickee
    google.maps.event.addListener(googleMap, 'click', function (event) {
        textoLatitud.value = event.latLng.lat();
        textoLongitud.value = event.latLng.lng();
       
    });

    var infoWindow = new google.maps.InfoWindow({ content: "Cargando..." });
    
    var geocoder = new google.maps.Geocoder();

    geocoder.geocode({
        'address': direccion
      },
      function (results, status) {
          if (status == google.maps.GeocoderStatus.OK) {
          if (results[1]) {
                  googleMap.setZoom(17);
                  new google.maps.Marker({
                  position: results[0].geometry.location,
                  map: googleMap
              });
              googleMap.setCenter(results[0].geometry.location);
           }
       }
    });

    googleMap.fitBounds(bounds);
}