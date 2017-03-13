using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoOficinaPerfilResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoOficinaPerfil;}}
		 public int IdProyectoOficinaPerfil{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdOficina{get;set;}
		 public int IdPerfil{get;set;}
		 
		 public string Oficina_Nombre{get;set;}	
	public string Oficina_Codigo{get;set;}	
	public bool Oficina_Activo{get;set;}	
	public bool Oficina_Visible{get;set;}	
	public int? Oficina_IdOficinaPadre{get;set;}	
	public int? Oficina_IdSaf{get;set;}	
	public string Oficina_BreadcrumbId{get;set;}	
	public string Oficina_BreadcrumbOrden{get;set;}	
	public int Oficina_Nivel{get;set;}	
	public int? Oficina_Orden{get;set;}	
	public string Oficina_Descripcion{get;set;}	
	public string Oficina_DescripcionInvertida{get;set;}	
	public bool Oficina_Seleccionable{get;set;}	
	public string Oficina_BreadcrumbCode{get;set;}	
	public string Oficina_DescripcionCodigo{get;set;}	
	public string Perfil_Nombre{get;set;}	
	public int Perfil_IdPerfilTipo{get;set;}	
	public bool Perfil_Activo{get;set;}	
	public bool Perfil_EsDefault{get;set;}	
	public string Perfil_Codigo{get;set;}	
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
					
		public virtual ProyectoOficinaPerfil ToEntity()
		{
		   ProyectoOficinaPerfil _ProyectoOficinaPerfil = new ProyectoOficinaPerfil();
		_ProyectoOficinaPerfil.IdProyectoOficinaPerfil = this.IdProyectoOficinaPerfil;
		 _ProyectoOficinaPerfil.IdProyecto = this.IdProyecto;
		 _ProyectoOficinaPerfil.IdOficina = this.IdOficina;
		 _ProyectoOficinaPerfil.IdPerfil = this.IdPerfil;
		 
		  return _ProyectoOficinaPerfil;
		}		
		public virtual void Set(ProyectoOficinaPerfil entity)
		{		   
		 this.IdProyectoOficinaPerfil= entity.IdProyectoOficinaPerfil ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdOficina= entity.IdOficina ;
		  this.IdPerfil= entity.IdPerfil ;
		 		  
		}		
		public virtual bool Equals(ProyectoOficinaPerfil entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoOficinaPerfil.Equals(this.IdProyectoOficinaPerfil))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdOficina.Equals(this.IdOficina))return false;
		  if(!entity.IdPerfil.Equals(this.IdPerfil))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoOficinaPerfil", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("Oficina","Oficina_Nombre")
			,new DataColumnMapping("Perfil","Perfil_Nombre")
			}));
		}
	}
}
		