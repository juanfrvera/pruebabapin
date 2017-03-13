using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoLocalizacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoLocalizacion;}}
		 public int IdProyectoLocalizacion{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdClasificacionGeografica{get;set;}
		 
		 public string ClasificacionGeografica_Codigo{get;set;}	
	public string ClasificacionGeografica_Nombre{get;set;}	
	public int ClasificacionGeografica_IdClasificacionGeograficaTipo{get;set;}	
	public int? ClasificacionGeografica_IdClasificacionGeograficaPadre{get;set;}	
	public bool ClasificacionGeografica_Activo{get;set;}	
	public string ClasificacionGeografica_Descripcion{get;set;}	
	public string ClasificacionGeografica_BreadcrumbId{get;set;}	
	public string ClasificacionGeografica_BreadcrumOrden{get;set;}	
	public int? ClasificacionGeografica_Orden{get;set;}	
	public int? ClasificacionGeografica_Nivel{get;set;}	
	public string ClasificacionGeografica_DescripcionInvertida{get;set;}	
	public bool ClasificacionGeografica_Seleccionable{get;set;}	
	public string ClasificacionGeografica_BreadcrumbCode{get;set;}	
	public string ClasificacionGeografica_DescripcionCodigo{get;set;}	
	public int Proyecto_IdTipoProyecto{get;set;}	
	public int Proyecto_IdSubPrograma{get;set;}	
	public int Proyecto_Codigo{get;set;}	
	public string Proyecto_ProyectoDenominacion{get;set;}	
	public string Proyecto_ProyectoSituacionActual{get;set;}	
	public string Proyecto_ProyectoDescripcion{get;set;}	
	public string Proyecto_ProyectoObservacion{get;set;}	
	public int Proyecto_IdEstado{get;set;}	
	public int? Proyecto_IdProceso{get;set;}	
	public int? Proyecto_IdModalidadContratacion{get;set;}	
	public int? Proyecto_IdFinalidadFuncion{get;set;}	
	public int? Proyecto_IdOrganismoPrioridad{get;set;}	
	public int? Proyecto_SubPrioridad{get;set;}	
	public bool Proyecto_EsBorrador{get;set;}	
	public bool? Proyecto_EsProyecto{get;set;}	
	public int? Proyecto_NroProyecto{get;set;}	
	public int? Proyecto_AnioCorriente{get;set;}	
	public DateTime? Proyecto_FechaInicioEjecucionCalculada{get;set;}	
	public DateTime? Proyecto_FechaFinEjecucionCalculada{get;set;}	
	public DateTime Proyecto_FechaAlta{get;set;}	
	public DateTime Proyecto_FechaModificacion{get;set;}	
	public int Proyecto_IdUsuarioModificacion{get;set;}	
	public int? Proyecto_IdProyectoPlan{get;set;}	
	public bool Proyecto_EvaluarValidaciones{get;set;}	
					
		public virtual ProyectoLocalizacion ToEntity()
		{
		   ProyectoLocalizacion _ProyectoLocalizacion = new ProyectoLocalizacion();
		_ProyectoLocalizacion.IdProyectoLocalizacion = this.IdProyectoLocalizacion;
		 _ProyectoLocalizacion.IdProyecto = this.IdProyecto;
		 _ProyectoLocalizacion.IdClasificacionGeografica = this.IdClasificacionGeografica;
		 
		  return _ProyectoLocalizacion;
		}		
		public virtual void Set(ProyectoLocalizacion entity)
		{		   
		 this.IdProyectoLocalizacion= entity.IdProyectoLocalizacion ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
		 		  
		}		
		public virtual bool Equals(ProyectoLocalizacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoLocalizacion.Equals(this.IdProyectoLocalizacion))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoLocalizacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			}));
		}
	}
}
		