using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class PrestamoGeneralCompose 
    {
        public PrestamoResult Prestamo {get;set;}
        private List<PrestamoEstadoResult> estados;
        public List<PrestamoEstadoResult> Estados
        {
            get {
                if (estados == null) estados = new List<PrestamoEstadoResult>();
                return estados;
            }
            set {
                estados = value; 
            }
        }
        private List<PrestamoOficinaFuncionarioResult> funcionarios { get; set; }
        public List<PrestamoOficinaFuncionarioResult> Funcionarios
        {
            get
            {
                if (funcionarios == null) funcionarios = new List<PrestamoOficinaFuncionarioResult>();
                return funcionarios;
            }
            set
            {
                funcionarios = value;
            }
        }
        private List<PrestamoOficinaPerfilResult> oficinas { get; set; }
        public List<PrestamoOficinaPerfilResult> Oficinas
        {
            get
            {
                if (oficinas == null) oficinas = new List<PrestamoOficinaPerfilResult>();
                return oficinas;
            }
            set
            {
                oficinas = value;
            }
        }
        public List<PrestamoFinalidadFuncionResult> Clasificaciones { get; set; }
      
        // Observadores


        public PrestamoOficinaPerfilResult Responsable;
        public List<PrestamoOficinaPerfilResult> OficinasSinResponsable 
        {
            get
            {
                return (from o in Oficinas where  o.IdPerfil != PerfilConfig.IdResponsable select o).ToList();
            }
        }
    }
}
