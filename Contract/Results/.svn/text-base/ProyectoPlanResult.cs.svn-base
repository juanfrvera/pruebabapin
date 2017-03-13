using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoPlanResult : IResult<int> //_ProyectoPlanResult
    {
        public int IdPlanTipo { get; set; }
        public string PlanTipo_Nombre { get; set; }
        public int PlanTipo_Orden { get; set; }
        public string PlanPeriodo_Periodo
        {
            get
            {
                return String.Format("{0} - {1}", PlanPeriodo_AnioInicial, PlanPeriodo_AnioFinal);
            }
        }
        public bool Activo { get; set; }

        public virtual int ID { get { return IdProyectoPlan; } }
        public int IdProyectoPlan { get; set; }
        public int IdProyecto { get; set; }
        public int IdPlanPeriodo { get; set; }
        public int IdPlanVersion { get; set; }
        public DateTime Fecha { get; set; }

        //public int PlanPeriodo_IdPlanTipo { get; set; }
        public string PlanPeriodo_Nombre { get; set; }
        //public string PlanPeriodo_Sigla { get; set; }
        public int PlanPeriodo_AnioInicial { get; set; }
        public int PlanPeriodo_AnioFinal { get; set; }
        //public bool PlanPeriodo_Activo { get; set; }
        //public int PlanVersion_IdPlanTipo { get; set; }
        public string PlanVersion_Nombre { get; set; }
        public int PlanVersion_Orden { get; set; }
        //public bool PlanVersion_Activo { get; set; }
        //public int Proyecto_IdTipoProyecto { get; set; }
        //public int Proyecto_IdSubPrograma { get; set; }
        //public int Proyecto_Codigo { get; set; }
        //public string Proyecto_ProyectoDenominacion { get; set; }
        //public string Proyecto_ProyectoSituacionActual { get; set; }
        //public string Proyecto_ProyectoDescripcion { get; set; }
        //public string Proyecto_ProyectoObservacion { get; set; }
        //public int Proyecto_IdEstado { get; set; }
        //public int? Proyecto_IdProceso { get; set; }
        //public int? Proyecto_IdModalidadContratacion { get; set; }
        //public int? Proyecto_IdFinalidadFuncion { get; set; }
        //public int? Proyecto_IdOrganismoPrioridad { get; set; }
        //public int? Proyecto_SubPrioridad { get; set; }
        //public bool Proyecto_EsBorrador { get; set; }
        //public bool? Proyecto_EsProyecto { get; set; }
        //public int? Proyecto_NroProyecto { get; set; }
        //public int? Proyecto_AnioCorriente { get; set; }
        //public DateTime? Proyecto_FechaInicioEjecucionCalculada { get; set; }
        //public DateTime? Proyecto_FechaFinEjecucionCalculada { get; set; }
        //public DateTime Proyecto_FechaAlta { get; set; }
        //public DateTime Proyecto_FechaModificacion { get; set; }
        //public int Proyecto_IdUsuarioModificacion { get; set; }
        //public int? Proyecto_IdProyectoPlan { get; set; }
        //public bool Proyecto_EvaluarValidaciones { get; set; }

        public virtual ProyectoPlan ToEntity()
        {
            ProyectoPlan _ProyectoPlan = new ProyectoPlan();
            _ProyectoPlan.IdProyectoPlan = this.IdProyectoPlan;
            _ProyectoPlan.IdProyecto = this.IdProyecto;
            _ProyectoPlan.IdPlanPeriodo = this.IdPlanPeriodo;
            _ProyectoPlan.IdPlanVersion = this.IdPlanVersion;
            _ProyectoPlan.Fecha = this.Fecha;

            return _ProyectoPlan;
        }
        public virtual void Set(ProyectoPlan entity)
        {
            this.IdProyectoPlan = entity.IdProyectoPlan;
            this.IdProyecto = entity.IdProyecto;
            this.IdPlanPeriodo = entity.IdPlanPeriodo;
            this.IdPlanVersion = entity.IdPlanVersion;
            this.Fecha = entity.Fecha;

        }
        public virtual bool Equals(ProyectoPlan entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoPlan.Equals(this.IdProyectoPlan)) return false;
            if (!entity.IdProyecto.Equals(this.IdProyecto)) return false;
            if (!entity.IdPlanPeriodo.Equals(this.IdPlanPeriodo)) return false;
            if (!entity.IdPlanVersion.Equals(this.IdPlanVersion)) return false;
            if (!entity.Fecha.Equals(this.Fecha)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoPlan", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("PlanPeriodo","PlanPeriodo_Nombre")
			,new DataColumnMapping("PlanVersion","PlanVersion_Nombre")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			}));
        }

    }
}
