function loadMap(id, location) {

    var COUNTRY = location;
    var map = L.map(id);
    var tile_url ='http://{s}.tile.osm.org/{z}/{x}/{y}.png';
    var layer = L.tileLayer(tile_url, {
        attribution: 'OSM'
    });
    map.addLayer(layer);
    map.setView(COUNTRY, 100);
    map.setZoom(4);
    
    L.control.fullscreen({
        position: 'topleft', // change the position of the button can be topleft, topright, bottomright or bottomleft, defaut topleft
        title: 'Show me the fullscreen !', // change the title of the button, default Full Screen
        titleCancel: 'Exit fullscreen mode', // change the title of the button when fullscreen is on, default Exit Full Screen
        content: null, // change the content of the button, can be HTML, default null
    forceSeparateButton: true, // force seperate button to detach from zoom buttons, default false
    forcePseudoFullscreen: true, // force use of pseudo full screen even if full screen API is available, default false
    fullscreenElement: false // Dom element to render in full screen, false by default, fallback to map._container
    }).addTo(map);

    //obtiene la ubicacion actual, por ahora no se va a utilizar esta funcionalidad
    /* map.locate({ country: 'ARG', watch: false }) // This will return map so you can do chaining 
     .on('locationfound', function (e) {
         var markerCurrent = L.marker([e.latitude, e.longitude]).bindPopup('Usted esta aqui');
         var circleCurrent = L.circle([e.latitude, e.longitude], e.accuracy / 2, {
             weight: 1,
             color: 'blue',
             fillColor: '#cacaca',
             fillOpacity: 0.2
         });
         map.addLayer(markerCurrent);
         map.addLayer(circleCurrent);
     })
    .on('locationerror', function (e) {
        console.log(e);
        alert("Location access denied.");
    });*/

    new L.Control.GeoSearch({
        provider: new L.GeoSearch.Provider.Esri()
    }).addTo(map);

    //A PARTIR DE ACA SE REALIZAN LAS FUNCIONES PARA DIBUJAR FIGURAS GEOMETRICAS Y AGREGAR MARCADORES
    var editableLayers = new L.FeatureGroup();
    map.addLayer(editableLayers);

    var MyCustomMarker = L.Icon.extend({
        options: {
            shadowUrl: null,
            iconAnchor: new L.Point(12, 12),
            iconSize: new L.Point(24, 24),
            iconUrl: '../App_Themes/images/marker-icon.png'
        }
    });
    
    var options = {
        position: 'topright',
        draw: {
            polyline: {
                shapeOptions: {
                    color: '#f357a1',
                    weight: 10
                }
            },
            polygon: {
                allowIntersection: false, // Restricts shapes to simple polygons
                drawError: {
                    color: '#e1e100', // Color the shape will turn when intersects
                    message: '<strong>Oh snap!<strong> you can\'t draw that!' // Message that will show when intersect
                },
                shapeOptions: {
                    color: '#bada55'
                }
            },
            circle: false, /*{
                shapeOptions: {
                    color: '#f357a1',
                    weight: 10
                }
            }, // Turns off this drawing tool*/
            rectangle: {
                shapeOptions: {
                    clickable: true
                }
            },
            marker: {
                icon: new MyCustomMarker()
            }
        },
        edit: {
            featureGroup: editableLayers, //REQUIRED!!
            edit: true,
            remove: true
        }
    };

    var drawControl = new L.Control.Draw(options);
    map.addControl(drawControl);

    map.on('draw:created', function (e) {
        var type = e.layerType,
            layer = e.layer;

        if (type === 'marker') {
            layer.bindPopup('ubicacion');

        }

        layer.addEventListener('contextmenu', function (event) {
            map.removeLayer(layer);
        })

        editableLayers.addLayer(layer);
    });

    return map;
};