using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _OficinaResult : IResult<int>
    {        
		public virtual int ID{get{return IdOficina;}}
		 public int IdOficina{get;set;}
		 public string Nombre{get;set;}
		 public string Codigo{get;set;}
		 public bool Activo{get;set;}
		 public bool Visible{get;set;}
		 public int? IdOficinaPadre{get;set;}
		 public int? IdSaf{get;set;}
		 public string BreadcrumbId{get;set;}
		 public string BreadcrumbOrden{get;set;}
		 public int Nivel{get;set;}
		 public int? Orden{get;set;}
		 public string Descripcion{get;set;}
		 public string DescripcionInvertida{get;set;}
		 public bool Seleccionable{get;set;}
		 public string BreadcrumbCode{get;set;}
		 public string DescripcionCodigo{get;set;}
		 
		 public string OficinaPadre_Nombre{get;set;}	
	public string OficinaPadre_Codigo{get;set;}	
	public bool? OficinaPadre_Activo{get;set;}	
	public bool? OficinaPadre_Visible{get;set;}	
	public int? OficinaPadre_IdOficinaPadre{get;set;}	
	public int? OficinaPadre_IdSaf{get;set;}	
	public string OficinaPadre_BreadcrumbId{get;set;}	
	public string OficinaPadre_BreadcrumbOrden{get;set;}	
	public int? OficinaPadre_Nivel{get;set;}	
	public int? OficinaPadre_Orden{get;set;}	
	public string OficinaPadre_Descripcion{get;set;}	
	public string OficinaPadre_DescripcionInvertida{get;set;}	
	public bool? OficinaPadre_Seleccionable{get;set;}	
	public string OficinaPadre_BreadcrumbCode{get;set;}	
	public string OficinaPadre_DescripcionCodigo{get;set;}	
	public string Saf_Codigo{get;set;}	
	public string Saf_Denominacion{get;set;}	
	public int? Saf_IdTipoOrganismo{get;set;}	
	public int? Saf_IdSector{get;set;}	
	public int? Saf_IdAdministracionTipo{get;set;}	
	public int? Saf_IdEntidadTipo{get;set;}	
	public int? Saf_IdJurisdiccion{get;set;}	
	public int? Saf_IdSubJurisdiccion{get;set;}	
	public DateTime? Saf_FechaAlta{get;set;}	
	public DateTime? Saf_FechaBaja{get;set;}	
	public bool? Saf_Activo{get;set;}	
					
		public virtual Oficina ToEntity()
		{
		   Oficina _Oficina = new Oficina();
		_Oficina.IdOficina = this.IdOficina;
		 _Oficina.Nombre = this.Nombre;
		 _Oficina.Codigo = this.Codigo;
		 _Oficina.Activo = this.Activo;
		 _Oficina.Visible = this.Visible;
		 _Oficina.IdOficinaPadre = this.IdOficinaPadre;
		 _Oficina.IdSaf = this.IdSaf;
		 _Oficina.BreadcrumbId = this.BreadcrumbId;
		 _Oficina.BreadcrumbOrden = this.BreadcrumbOrden;
		 _Oficina.Nivel = this.Nivel;
		 _Oficina.Orden = this.Orden;
		 _Oficina.Descripcion = this.Descripcion;
		 _Oficina.DescripcionInvertida = this.DescripcionInvertida;
		 _Oficina.Seleccionable = this.Seleccionable;
		 _Oficina.BreadcrumbCode = this.BreadcrumbCode;
		 _Oficina.DescripcionCodigo = this.DescripcionCodigo;
		 
		  return _Oficina;
		}		
		public virtual void Set(Oficina entity)
		{		   
		 this.IdOficina= entity.IdOficina ;
		  this.Nombre= entity.Nombre ;
		  this.Codigo= entity.Codigo ;
		  this.Activo= entity.Activo ;
		  this.Visible= entity.Visible ;
		  this.IdOficinaPadre= entity.IdOficinaPadre ;
		  this.IdSaf= entity.IdSaf ;
		  this.BreadcrumbId= entity.BreadcrumbId ;
		  this.BreadcrumbOrden= entity.BreadcrumbOrden ;
		  this.Nivel= entity.Nivel ;
		  this.Orden= entity.Orden ;
		  this.Descripcion= entity.Descripcion ;
		  this.DescripcionInvertida= entity.DescripcionInvertida ;
		  this.Seleccionable= entity.Seleccionable ;
		  this.BreadcrumbCode= entity.BreadcrumbCode ;
		  this.DescripcionCodigo= entity.DescripcionCodigo ;
		 		  
		}		
		public virtual bool Equals(Oficina entity)
        {
		   if(entity == null)return false;
         if(!entity.IdOficina.Equals(this.IdOficina))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if((entity.Codigo == null)?this.Codigo!=null:!entity.Codigo.Equals(this.Codigo))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.Visible.Equals(this.Visible))return false;
		  if((entity.IdOficinaPadre == null)?(this.IdOficinaPadre.HasValue && this.IdOficinaPadre.Value > 0):!entity.IdOficinaPadre.Equals(this.IdOficinaPadre))return false;
						  if((entity.IdSaf == null)?(this.IdSaf.HasValue && this.IdSaf.Value > 0):!entity.IdSaf.Equals(this.IdSaf))return false;
						  if((entity.BreadcrumbId == null)?this.BreadcrumbId!=null:!entity.BreadcrumbId.Equals(this.BreadcrumbId))return false;
			 if((entity.BreadcrumbOrden == null)?this.BreadcrumbOrden!=null:!entity.BreadcrumbOrden.Equals(this.BreadcrumbOrden))return false;
			 if(!entity.Nivel.Equals(this.Nivel))return false;
		  if((entity.Orden == null)?this.Orden!=null:!entity.Orden.Equals(this.Orden))return false;
			 if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
			 if((entity.DescripcionInvertida == null)?this.DescripcionInvertida!=null:!entity.DescripcionInvertida.Equals(this.DescripcionInvertida))return false;
			 if(!entity.Seleccionable.Equals(this.Seleccionable))return false;
		  if((entity.BreadcrumbCode == null)?this.BreadcrumbCode!=null:!entity.BreadcrumbCode.Equals(this.BreadcrumbCode))return false;
			 if((entity.DescripcionCodigo == null)?this.DescripcionCodigo!=null:!entity.DescripcionCodigo.Equals(this.DescripcionCodigo))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Oficina", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("Visible","Visible")
			,new DataColumnMapping("OficinaPadre","Oficina_Nombre")
			,new DataColumnMapping("Saf","Saf_Codigo")
			,new DataColumnMapping("Breadcrumb","BreadcrumbId")
			,new DataColumnMapping("BreadcrumbOrden","BreadcrumbOrden")
			,new DataColumnMapping("Nivel","Nivel")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("DescripcionInvertida","DescripcionInvertida")
			,new DataColumnMapping("Seleccionable","Seleccionable")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
			,new DataColumnMapping("DescripcionCodigo","DescripcionCodigo")
			}));
		}
	}
}
		