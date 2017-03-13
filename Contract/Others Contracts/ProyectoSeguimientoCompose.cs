using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable]
    public class ProyectoSeguimientoCompose   //Evaluacion de Factibilidad
    {
        public ProyectoSeguimientoResult ProyectoSeguimiento;
        #region Private
        private List<ProyectoSeguimientoProyectoResult> _ProyectoSeguimientoProyecto;
        private List<ProyectoSeguimientoLocalizacionResult> _ProyectoSeguimientoLocalizacion;
        private List<ProyectoSeguimientoEstadoResult> _ProyectoSeguimientoEstado;
        #endregion
        #region Public
        public List<ProyectoSeguimientoProyectoResult> ProyectoSeguimientoProyecto
        {
            get
            {
                if (_ProyectoSeguimientoProyecto == null) _ProyectoSeguimientoProyecto = new List<ProyectoSeguimientoProyectoResult>();
                return _ProyectoSeguimientoProyecto;
            }
            set
            {
                _ProyectoSeguimientoProyecto = value;
            }
        }
        public List<ProyectoSeguimientoLocalizacionResult> ProyectoSeguimientoLocalizacion
        {
            get
            {
                if (_ProyectoSeguimientoLocalizacion == null) _ProyectoSeguimientoLocalizacion = new List<ProyectoSeguimientoLocalizacionResult>();
                return _ProyectoSeguimientoLocalizacion;
            }
            set
            {
                _ProyectoSeguimientoLocalizacion = value;
            }
        }
        public List<ProyectoSeguimientoEstadoResult> ProyectoSeguimientoEstado
        {
            get
            {
                if (_ProyectoSeguimientoEstado == null) _ProyectoSeguimientoEstado = new List<ProyectoSeguimientoEstadoResult>();
                return _ProyectoSeguimientoEstado;
            }
            set
            {
                _ProyectoSeguimientoEstado = value;
            }
        }
        #endregion
    }
}
