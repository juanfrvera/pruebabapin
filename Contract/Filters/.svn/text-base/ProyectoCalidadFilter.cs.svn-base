using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
using System.Runtime.Serialization;
namespace Contract
{
    [Serializable, DataContract(Name = "ProyectoCalidadFilter")]
    public class ProyectoCalidadFilter : _ProyectoCalidadFilter
    {
        public int? IdSaf { get; set; }
        public int? IdPrograma { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public int? IdPlanVersion { get; set; }
        public int? IdPlanPeriodo { get; set; }
        public int? IdPlanTipo { get; set; }
        public int? IdEstado { get; set; }
        public int? IdProceso { get; set; }
        public int? Proyecto_Codigo { get; set; }
        private List<int> estados { get; set; }
        public List<int> Estados {
            get {
                if (estados == null)
                    estados = new List<int>();
                return estados; 
            }
            set {
                estados = value;
            }
        
        }
        private List<int> procesos { get; set; }
        public List<int> Procesos
        {
            get
            {
                if (procesos == null)
                    procesos = new List<int>();
                return procesos;
            }
            set
            {
                procesos = value;
            }
        }
        private List<int> estadosCalidad { get; set; }
        public List<int> EstadosCalidad {
            get
            {
                if (estadosCalidad == null)
                    estadosCalidad = new List<int>();
                return estadosCalidad;
            }
            set {
                estadosCalidad = value; 
            }
        }
        public int? IdOrganismoTipo { get; set; }
        public int? IdProyectoTipo { get; set; }

        public bool IgnorarProvincias { get; set; }

        public bool ProyectoActivo { get; set; }
        public bool ProyectoBorrador{ get; set; }
    }
}
