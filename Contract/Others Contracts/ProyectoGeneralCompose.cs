using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;




namespace Contract
{
   [Serializable]
    public class ProyectoGeneralCompose
    {
        public ProyectoResult proyecto {get;set;}

        private List<ProyectoPrioridadResult> _proyectoPrioridad;
        public List<ProyectoPrioridadResult> proyectoPrioridad
        {
            get {
                if (_proyectoPrioridad == null) _proyectoPrioridad = new List<ProyectoPrioridadResult>();
                return _proyectoPrioridad; }
            set { _proyectoPrioridad = value; }
        }
        
        private List<ProyectoRelacionResult> _proyectoRelacion;
        public List<ProyectoRelacionResult> proyectoRelacion
        {
            get {
                if (_proyectoRelacion == null) _proyectoRelacion = new List<ProyectoRelacionResult>();
                return _proyectoRelacion; }
            set { _proyectoRelacion = value; }
        }

        private List<ProyectoPlanResult> _proyectoPlan;
        public List<ProyectoPlanResult> proyectoPlan
        {
            get {
                if (_proyectoPlan == null) _proyectoPlan = new List<ProyectoPlanResult>();
                return _proyectoPlan; }
            set { _proyectoPlan = value; }
        }

        private List<ProyectoDemoraResult> _proyectoDemora;
        public List<ProyectoDemoraResult> proyectoDemora
        {
            get {
                if (_proyectoDemora == null) _proyectoDemora = new List<ProyectoDemoraResult>();
                return _proyectoDemora; }
            set { _proyectoDemora = value; }
        }

        private List<ProyectoOrigenFinanciamientoResult> _proyectoOrigenFinanciamiento;
        public List<ProyectoOrigenFinanciamientoResult> proyectoOrigenFinanciamiento
        {
            get {
                if (_proyectoOrigenFinanciamiento == null) _proyectoOrigenFinanciamiento = new List<ProyectoOrigenFinanciamientoResult>();
                return _proyectoOrigenFinanciamiento; }
            set { _proyectoOrigenFinanciamiento = value; }
        }

        public ProyectoOficinaPerfilResult proyectoOficinaPerfilIniciador;
        public ProyectoOficinaPerfilResult proyectoOficinaPerfilEjecutor;
        public ProyectoOficinaPerfilResult proyectoOficinaPerfilResponsable;

        private List<ProyectoOficinaPerfilFuncionarioResult> _proyectoOficinaPerfilFuncionarioIniciador;
        public List<ProyectoOficinaPerfilFuncionarioResult> proyectoOficinaPerfilFuncionarioIniciador
        {
            get
            {
                if (_proyectoOficinaPerfilFuncionarioIniciador == null) _proyectoOficinaPerfilFuncionarioIniciador = new List<ProyectoOficinaPerfilFuncionarioResult>();
                return _proyectoOficinaPerfilFuncionarioIniciador;
            }
            set { _proyectoOficinaPerfilFuncionarioIniciador = value; }
        }

        private List<ProyectoOficinaPerfilFuncionarioResult> _proyectoOficinaPerfilFuncionarioEjecutor;
        public List<ProyectoOficinaPerfilFuncionarioResult> proyectoOficinaPerfilFuncionarioEjecutor
        {
            get {
                if (_proyectoOficinaPerfilFuncionarioEjecutor == null) _proyectoOficinaPerfilFuncionarioEjecutor = new List<ProyectoOficinaPerfilFuncionarioResult>();
                return _proyectoOficinaPerfilFuncionarioEjecutor; }
            set { _proyectoOficinaPerfilFuncionarioEjecutor = value; }
        }

        private List<ProyectoOficinaPerfilFuncionarioResult> _proyectoOficinaPerfilFuncionarioResponsable;
        public List<ProyectoOficinaPerfilFuncionarioResult> proyectoOficinaPerfilFuncionarioResponsable
        {
            get {
                if (_proyectoOficinaPerfilFuncionarioResponsable == null) _proyectoOficinaPerfilFuncionarioResponsable = new List<ProyectoOficinaPerfilFuncionarioResult>();
                return _proyectoOficinaPerfilFuncionarioResponsable; }
            set { _proyectoOficinaPerfilFuncionarioResponsable = value; }
        }

        private List<ProyectoLocalizacionResult> _localizaciones = new List<ProyectoLocalizacionResult>();
        public List<ProyectoLocalizacionResult> Localizaciones
        {
            get
            {
                if (_localizaciones == null) _localizaciones = new List<ProyectoLocalizacionResult>();
                return _localizaciones;
            }
            set { _localizaciones = value; }
        }
    }
}
