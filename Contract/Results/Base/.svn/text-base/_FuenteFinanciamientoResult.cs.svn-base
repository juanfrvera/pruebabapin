using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _FuenteFinanciamientoResult : IResult<int>
    {        
		public virtual int ID{get{return IdFuenteFinanciamiento;}}
		 public int IdFuenteFinanciamiento{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public int IdFuenteFinanciamientoTipo{get;set;}
		 public bool Activo{get;set;}
		 public int? IdFuenteFinanciamientoPadre{get;set;}
		 public string BreadcrumbId{get;set;}
		 public string BreadcrumbOrden{get;set;}
		 public int? Nivel{get;set;}
		 public int? Orden{get;set;}
		 public string Descripcion{get;set;}
		 public string DescripcionInvertida{get;set;}
		 public bool Seleccionable{get;set;}
		 public string BreadcrumbCode{get;set;}
		 public string DescripcionCodigo{get;set;}
		 
		 public string FuenteFinanciamientoPadre_Codigo{get;set;}	
	public string FuenteFinanciamientoPadre_Nombre{get;set;}	
	public int? FuenteFinanciamientoPadre_IdFuenteFinanciamientoTipo{get;set;}	
	public bool? FuenteFinanciamientoPadre_Activo{get;set;}	
	public int? FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre{get;set;}	
	public string FuenteFinanciamientoPadre_BreadcrumbId{get;set;}	
	public string FuenteFinanciamientoPadre_BreadcrumbOrden{get;set;}	
	public int? FuenteFinanciamientoPadre_Nivel{get;set;}	
	public int? FuenteFinanciamientoPadre_Orden{get;set;}	
	public string FuenteFinanciamientoPadre_Descripcion{get;set;}	
	public string FuenteFinanciamientoPadre_DescripcionInvertida{get;set;}	
	public bool? FuenteFinanciamientoPadre_Seleccionable{get;set;}	
	public string FuenteFinanciamientoPadre_BreadcrumbCode{get;set;}	
	public string FuenteFinanciamientoPadre_DescripcionCodigo{get;set;}	
	public string FuenteFinanciamientoTipo_Nombre{get;set;}	
	public int FuenteFinanciamientoTipo_Nivel{get;set;}	
					
		public virtual FuenteFinanciamiento ToEntity()
		{
		   FuenteFinanciamiento _FuenteFinanciamiento = new FuenteFinanciamiento();
		_FuenteFinanciamiento.IdFuenteFinanciamiento = this.IdFuenteFinanciamiento;
		 _FuenteFinanciamiento.Codigo = this.Codigo;
		 _FuenteFinanciamiento.Nombre = this.Nombre;
		 _FuenteFinanciamiento.IdFuenteFinanciamientoTipo = this.IdFuenteFinanciamientoTipo;
		 _FuenteFinanciamiento.Activo = this.Activo;
		 _FuenteFinanciamiento.IdFuenteFinanciamientoPadre = this.IdFuenteFinanciamientoPadre;
		 _FuenteFinanciamiento.BreadcrumbId = this.BreadcrumbId;
		 _FuenteFinanciamiento.BreadcrumbOrden = this.BreadcrumbOrden;
		 _FuenteFinanciamiento.Nivel = this.Nivel;
		 _FuenteFinanciamiento.Orden = this.Orden;
		 _FuenteFinanciamiento.Descripcion = this.Descripcion;
		 _FuenteFinanciamiento.DescripcionInvertida = this.DescripcionInvertida;
		 _FuenteFinanciamiento.Seleccionable = this.Seleccionable;
		 _FuenteFinanciamiento.BreadcrumbCode = this.BreadcrumbCode;
		 _FuenteFinanciamiento.DescripcionCodigo = this.DescripcionCodigo;
		 
		  return _FuenteFinanciamiento;
		}		
		public virtual void Set(FuenteFinanciamiento entity)
		{		   
		 this.IdFuenteFinanciamiento= entity.IdFuenteFinanciamiento ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.IdFuenteFinanciamientoTipo= entity.IdFuenteFinanciamientoTipo ;
		  this.Activo= entity.Activo ;
		  this.IdFuenteFinanciamientoPadre= entity.IdFuenteFinanciamientoPadre ;
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
		public virtual bool Equals(FuenteFinanciamiento entity)
        {
		   if(entity == null)return false;
         if(!entity.IdFuenteFinanciamiento.Equals(this.IdFuenteFinanciamiento))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.IdFuenteFinanciamientoTipo.Equals(this.IdFuenteFinanciamientoTipo))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if((entity.IdFuenteFinanciamientoPadre == null)?(this.IdFuenteFinanciamientoPadre.HasValue && this.IdFuenteFinanciamientoPadre.Value > 0):!entity.IdFuenteFinanciamientoPadre.Equals(this.IdFuenteFinanciamientoPadre))return false;
						  if((entity.BreadcrumbId == null)?this.BreadcrumbId!=null:!entity.BreadcrumbId.Equals(this.BreadcrumbId))return false;
			 if((entity.BreadcrumbOrden == null)?this.BreadcrumbOrden!=null:!entity.BreadcrumbOrden.Equals(this.BreadcrumbOrden))return false;
			 if((entity.Nivel == null)?this.Nivel!=null:!entity.Nivel.Equals(this.Nivel))return false;
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
		    return new DataTableMapping("FuenteFinanciamiento", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("FuenteFinanciamientoTipo","FuenteFinanciamientoTipo_Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("FuenteFinanciamientoPadre","FuenteFinanciamiento_Nombre")
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
		