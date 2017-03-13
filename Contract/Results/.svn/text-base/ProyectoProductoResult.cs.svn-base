using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoProductoResult : IResult<int>
    {
        public virtual int ID { get { return IdProyectoProducto; } }
        public int IdProyectoProducto { get; set; }
        public int IdProyecto { get; set; }
        public int IdObjetivo { get; set; }

        public string Objetivo_Nombre { get; set; }
        //public int Proyecto_IdTipoProyecto{get;set;}	
        //public int Proyecto_IdSubPrograma{get;set;}	
        //public int Proyecto_Codigo{get;set;}	
        //public string Proyecto_ProyectoDenominacion{get;set;}	
        //public string Proyecto_ProyectoSituacionActual{get;set;}	
        //public string Proyecto_ProyectoDescripcion{get;set;}	
        //public string Proyecto_ProyectoObservacion{get;set;}	
        //public int Proyecto_IdEstado{get;set;}	
        //public int? Proyecto_IdProceso{get;set;}	
        //public int? Proyecto_IdModalidadContratacion{get;set;}	
        //public int? Proyecto_IdFinalidadFuncion{get;set;}	
        //public int? Proyecto_IdOrganismoPrioridad{get;set;}	
        //public int? Proyecto_SubPrioridad{get;set;}	
        //public bool Proyecto_EsBorrador{get;set;}	
        //public bool? Proyecto_EsProyecto{get;set;}	
        //public int? Proyecto_NroProyecto{get;set;}	
        //public int? Proyecto_AnioCorriente{get;set;}	
        //public DateTime? Proyecto_FechaInicioEjecucionCalculada{get;set;}	
        //public DateTime? Proyecto_FechaFinEjecucionCalculada{get;set;}	
        //public DateTime Proyecto_FechaAlta{get;set;}	
        //public DateTime Proyecto_FechaModificacion{get;set;}	
        //public int Proyecto_IdUsuarioModificacion{get;set;}	
        //public int? Proyecto_IdProyectoPlan{get;set;}	
        //public bool Proyecto_EvaluarValidaciones{get;set;}	

        public virtual ProyectoProducto ToEntity()
        {
            ProyectoProducto _ProyectoProducto = new ProyectoProducto();
            _ProyectoProducto.IdProyectoProducto = this.IdProyectoProducto;
            _ProyectoProducto.IdProyecto = this.IdProyecto;
            _ProyectoProducto.IdObjetivo = this.IdObjetivo;

            return _ProyectoProducto;
        }
        public virtual void Set(ProyectoProducto entity)
        {
            this.IdProyectoProducto = entity.IdProyectoProducto;
            this.IdProyecto = entity.IdProyecto;
            this.IdObjetivo = entity.IdObjetivo;

        }
        public virtual bool Equals(ProyectoProducto entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoProducto.Equals(this.IdProyectoProducto)) return false;
            if (!entity.IdProyecto.Equals(this.IdProyecto)) return false;
            if (!entity.IdObjetivo.Equals(this.IdObjetivo)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoProducto", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("Objetivo","Objetivo_Nombre")
			}));
        }
    }
}
