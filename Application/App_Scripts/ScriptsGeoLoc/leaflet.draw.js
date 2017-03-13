/*
 * Leaflet.draw assumes that you have already included the Leaflet library.
 */

L.drawVersion = '0.3.0-dev';

L.drawLocal = {
	draw: {
		toolbar: {
			// #TODO: this should be reorganized where actions are nested in actions
			// ex: actions.undo  or actions.cancel
			actions: {
				title: 'Cancelar dibujo',
				text: 'Cancelar'
			},
			finish: {
				title: 'Finalizar dibujo',
				text: 'Finalizar'
			},
			undo: {
			    title: 'Eliminar \u00FAltimo punto del dibujo',
			    text: 'Eliminar \u00FAltimo punto'
			},
			buttons: {
			    polyline: 'Dibujar l\u00EDnea',
			    polygon: 'Dibujar pol\u00EDgono',
			    rectangle: 'Dibujar rect\u00E1ngulo',
				circle: 'Dibujar c\u00EDrculo',
				marker: 'Dibujar marcador'
			}
		},
		handlers: {
			circle: {
				tooltip: {
				    start: 'Haga click y arrastre para dibujar el c\u00EDrculo.'
				},
				radius: 'Radio'
			},
			marker: {
				tooltip: {
				    start: 'Haga click en el mapa para colocar el marcador.'
				}
			},
			polygon: {
				tooltip: {
				    start: 'Haga click para empezar a dibujar el shape.',
					cont: 'Haga click para continuar el dibujo del shape.',
					end: 'Haga click en el primer punto para cerrar el shape'
				}
			},
			polyline: {
				error: '<strong>Error:</strong> los bordes del shape no se pueden cruzar!',
				tooltip: {
				    start: 'Haga click para empezar a dibujar la l\u00EDnea.',
				    cont: 'Haga click para continuar el dibujo de la l\u00EDnea',
				    end: 'Haga click para finalizar el dibujo de la l\u00EDnea'
				}
			},
			rectangle: {
				tooltip: {
				    start: 'Haga click y arrastre para dibujar un rect\u00E1ngulo.'
				}
			},
			simpleshape: {
				tooltip: {
				    end: 'Suelte el mouse para completar el dibujo.'
				}
			}
		}
	},
	edit: {
		toolbar: {
			actions: {
				save: {
					title: 'Guardar cambios.',
					text: 'Guardar'
				},
				cancel: {
				    title: 'Cancelar la edici\u00F3n, descartar todos los cambios.',
					text: 'Cancelar'
				}
			},
			buttons: {
				edit: 'Editar capas.',
				editDisabled: 'No hay capas para editar.',
				remove: 'Eliminar capas',
				removeDisabled: 'No hay capas para eliminar.'
			}
		},
		handlers: {
			edit: {
				tooltip: {
				    text: 'Control de arrastre, o marcador para editar funci\u00F3n.',
				    subtext: 'Haga click en Cancelar para deshacer los cambios.'
				}
			},
			remove: {
				tooltip: {
				    text: 'Haga click en una función para eliminar'
				}
			}
		}
	}
};
