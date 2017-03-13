using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    
    [Serializable]
    public class DictamenCompose
    {
        public DictamenCompose()
        {

        }
        public ProyectoDictamenResult ProyectoDictamen { get; set; }
        public Int32 IdProyectoDictamen
        {
            get { return ProyectoDictamen != null ? ProyectoDictamen.IdProyectoDictamen : 0; }
        }

        private List<ProyectoSeguimientoResult> _proyectoSeguimiento;
        public  List<ProyectoSeguimientoResult> proyectoSeguimiento
        {
            get
            {
                if (_proyectoSeguimiento == null) _proyectoSeguimiento = new List<ProyectoSeguimientoResult>();
                return _proyectoSeguimiento;
            }
            set
            {
                _proyectoSeguimiento = value;
            }

        }
        private List<ProyectoDictamenSeguimientoResult> _proyectoDictamenSeguimiento;
        public List<ProyectoDictamenSeguimientoResult> proyectoDictamenSeguimiento
        {
            get
            {
                if (_proyectoDictamenSeguimiento == null) _proyectoDictamenSeguimiento = new List<ProyectoDictamenSeguimientoResult>();
                return _proyectoDictamenSeguimiento;
            }
            set
            {
                _proyectoDictamenSeguimiento = value;
            }

        }
        private List<ProyectoDictamenEstadoResult> _ProyectoDictamenEstado;
        public List<ProyectoDictamenEstadoResult> ProyectoDictamenEstado
        {
            get
            {
                if (_ProyectoDictamenEstado == null) _ProyectoDictamenEstado = new List<ProyectoDictamenEstadoResult>();
                return _ProyectoDictamenEstado;
            }
            set
            {
                _ProyectoDictamenEstado = value;
            }
        }

        private List<ProyectoDictamenFileResult> _ProyectoDictamenFile;
        public List<ProyectoDictamenFileResult> ProyectoDictamenFile
        {
            get
            {
                if (_ProyectoDictamenFile == null) _ProyectoDictamenFile = new List<ProyectoDictamenFileResult>();
                return _ProyectoDictamenFile;
            }
            set
            {
                _ProyectoDictamenFile = value;
            }
        }
  }
}
