using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class ProyectoDictamenFactibilidadCompose
    {
       

        #region Private
        private List<ProyectoDictamenSeguimientoResult> _ProyectoDictamenSeguimiento;
        private List<ProyectoSeguimientoLocalizacionResult> _ProyectoSeguimientoLocalizacion;
        private List<ProyectoSeguimientoEstadoResult> _ProyectoSeguimientoEstado;
        #endregion
        #region Public
        public List<ProyectoDictamenSeguimientoResult> ProyectoDictamenSeguimiento
        {
            get
            {
                if (_ProyectoDictamenSeguimiento == null) _ProyectoDictamenSeguimiento = new List<ProyectoDictamenSeguimientoResult>();
                return _ProyectoDictamenSeguimiento;
            }
            set
            {
                _ProyectoDictamenSeguimiento = value;
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
