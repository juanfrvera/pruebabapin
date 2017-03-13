using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SafResult : IResult<int>
    {        
		public virtual int ID{get{return IdSaf;}}
		 public int IdSaf{get;set;}
		 public string Codigo{get;set;}
		 public string Denominacion{get;set;}
		 public int IdTipoOrganismo{get;set;}
		 public int? IdSector{get;set;}
		 public int? IdAdministracionTipo{get;set;}
		 public int? IdEntidadTipo{get;set;}
		 public int? IdJurisdiccion{get;set;}
		 public int? IdSubJurisdiccion{get;set;}
		 public DateTime FechaAlta{get;set;}
		 public DateTime? FechaBaja{get;set;}
		 public bool Activo{get;set;}
		 
		 public string AdministracionTipo_Codigo{get;set;}	
	public string AdministracionTipo_Nombre{get;set;}	
	public bool? AdministracionTipo_Activo{get;set;}	
	public string EntidadTipo_Codigo{get;set;}	
	public string EntidadTipo_Nombre{get;set;}	
	public bool? EntidadTipo_Activo{get;set;}	
	public string Jurisdiccion_Codigo{get;set;}	
	public string Jurisdiccion_Nombre{get;set;}	
	public bool? Jurisdiccion_Activo{get;set;}	
	public string TipoOrganismo_Nombre{get;set;}	
	public bool TipoOrganismo_Activo{get;set;}	
	public string Sector_Codigo{get;set;}	
	public string Sector_Nombre{get;set;}	
	public bool? Sector_Activo{get;set;}	
	public string SubJurisdiccion_Codigo{get;set;}	
	public string SubJurisdiccion_Nombre{get;set;}	
	public bool? SubJurisdiccion_Activo{get;set;}	
					
		public virtual Saf ToEntity()
		{
		   Saf _Saf = new Saf();
		_Saf.IdSaf = this.IdSaf;
		 _Saf.Codigo = this.Codigo;
		 _Saf.Denominacion = this.Denominacion;
		 _Saf.IdTipoOrganismo = this.IdTipoOrganismo;
		 _Saf.IdSector = this.IdSector;
		 _Saf.IdAdministracionTipo = this.IdAdministracionTipo;
		 _Saf.IdEntidadTipo = this.IdEntidadTipo;
		 _Saf.IdJurisdiccion = this.IdJurisdiccion;
		 _Saf.IdSubJurisdiccion = this.IdSubJurisdiccion;
		 _Saf.FechaAlta = this.FechaAlta;
		 _Saf.FechaBaja = this.FechaBaja;
		 _Saf.Activo = this.Activo;
		 
		  return _Saf;
		}		
		public virtual void Set(Saf entity)
		{		   
		 this.IdSaf= entity.IdSaf ;
		  this.Codigo= entity.Codigo ;
		  this.Denominacion= entity.Denominacion ;
		  this.IdTipoOrganismo= entity.IdTipoOrganismo ;
		  this.IdSector= entity.IdSector ;
		  this.IdAdministracionTipo= entity.IdAdministracionTipo ;
		  this.IdEntidadTipo= entity.IdEntidadTipo ;
		  this.IdJurisdiccion= entity.IdJurisdiccion ;
		  this.IdSubJurisdiccion= entity.IdSubJurisdiccion ;
		  this.FechaAlta= entity.FechaAlta ;
		  this.FechaBaja= entity.FechaBaja ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Saf entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSaf.Equals(this.IdSaf))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Denominacion.Equals(this.Denominacion))return false;
		  if(!entity.IdTipoOrganismo.Equals(this.IdTipoOrganismo))return false;
		  if((entity.IdSector == null)?(this.IdSector.HasValue && this.IdSector.Value > 0):!entity.IdSector.Equals(this.IdSector))return false;
						  if((entity.IdAdministracionTipo == null)?(this.IdAdministracionTipo.HasValue && this.IdAdministracionTipo.Value > 0):!entity.IdAdministracionTipo.Equals(this.IdAdministracionTipo))return false;
						  if((entity.IdEntidadTipo == null)?(this.IdEntidadTipo.HasValue && this.IdEntidadTipo.Value > 0):!entity.IdEntidadTipo.Equals(this.IdEntidadTipo))return false;
						  if((entity.IdJurisdiccion == null)?(this.IdJurisdiccion.HasValue && this.IdJurisdiccion.Value > 0):!entity.IdJurisdiccion.Equals(this.IdJurisdiccion))return false;
						  if((entity.IdSubJurisdiccion == null)?(this.IdSubJurisdiccion.HasValue && this.IdSubJurisdiccion.Value > 0):!entity.IdSubJurisdiccion.Equals(this.IdSubJurisdiccion))return false;
						  if(!entity.FechaAlta.Equals(this.FechaAlta))return false;
		  if((entity.FechaBaja == null)?this.FechaBaja!=null:!entity.FechaBaja.Equals(this.FechaBaja))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Saf", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Denominacion","Denominacion")
			,new DataColumnMapping("TipoOrganismo","OrganismoTipo_Nombre")
			,new DataColumnMapping("Sector","Sector_Nombre")
			,new DataColumnMapping("AdministracionTipo","AdministracionTipo_Nombre")
			,new DataColumnMapping("EntidadTipo","EntidadTipo_Nombre")
			,new DataColumnMapping("Jurisdiccion","Jurisdiccion_Nombre")
			,new DataColumnMapping("SubJurisdiccion","SubJurisdiccion_Nombre")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaBaja","FechaBaja","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		