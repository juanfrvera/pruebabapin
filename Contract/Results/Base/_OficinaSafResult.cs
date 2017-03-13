using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _OficinaSafResult : IResult<int>
    {        
		public virtual int ID{get{return IdOficinaSaf;}}
		 public int IdOficinaSaf{get;set;}
		 public int IdOficina{get;set;}
		 public int IdSaf{get;set;}
		 
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
	public string Saf_Codigo{get;set;}	
	public string Saf_Denominacion{get;set;}	
	public int Saf_IdTipoOrganismo{get;set;}	
	public int? Saf_IdSector{get;set;}	
	public int? Saf_IdAdministracionTipo{get;set;}	
	public int? Saf_IdEntidadTipo{get;set;}	
	public int? Saf_IdJurisdiccion{get;set;}	
	public int? Saf_IdSubJurisdiccion{get;set;}	
	public DateTime Saf_FechaAlta{get;set;}	
	public DateTime? Saf_FechaBaja{get;set;}	
	public bool Saf_Activo{get;set;}	
					
		public virtual OficinaSaf ToEntity()
		{
		   OficinaSaf _OficinaSaf = new OficinaSaf();
		_OficinaSaf.IdOficinaSaf = this.IdOficinaSaf;
		 _OficinaSaf.IdOficina = this.IdOficina;
		 _OficinaSaf.IdSaf = this.IdSaf;
		 
		  return _OficinaSaf;
		}		
		public virtual void Set(OficinaSaf entity)
		{		   
		 this.IdOficinaSaf= entity.IdOficinaSaf ;
		  this.IdOficina= entity.IdOficina ;
		  this.IdSaf= entity.IdSaf ;
		 		  
		}		
		public virtual bool Equals(OficinaSaf entity)
        {
		   if(entity == null)return false;
         if(!entity.IdOficinaSaf.Equals(this.IdOficinaSaf))return false;
		  if(!entity.IdOficina.Equals(this.IdOficina))return false;
		  if(!entity.IdSaf.Equals(this.IdSaf))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("OficinaSaf", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Oficina","Oficina_Nombre")
			,new DataColumnMapping("Saf","Saf_Codigo")
			}));
		}
	}
}
		