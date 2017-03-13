using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ClasificacionGastoResult : IResult<int>
    {        
		public virtual int ID{get{return IdClasificacionGasto;}}
		 public int IdClasificacionGasto{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public int IdClasificacionGastoTipo{get;set;}
		 public int? IdCaracterEconomico{get;set;}
		 public bool Activo{get;set;}
		 public int? IdClasificacionGastoPadre{get;set;}
		 public string BreadcrumbId{get;set;}
		 public string BreadcrumbOrden{get;set;}
		 public int? Nivel{get;set;}
		 public int? Orden{get;set;}
		 public string Descripcion{get;set;}
		 public string DescripcionInvertida{get;set;}
		 public int IdClasificacionGastoRubro{get;set;}
		 public bool Seleccionable{get;set;}
		 public string BreadcrumbCode{get;set;}
		 public string DescripcionCodigo{get;set;}
		 
		 public string ClasificacionGastoPadre_Codigo{get;set;}	
	public string ClasificacionGastoPadre_Nombre{get;set;}	
	public int? ClasificacionGastoPadre_IdClasificacionGastoTipo{get;set;}	
	public int? ClasificacionGastoPadre_IdCaracterEconomico{get;set;}	
	public bool? ClasificacionGastoPadre_Activo{get;set;}	
	public int? ClasificacionGastoPadre_IdClasificacionGastoPadre{get;set;}	
	public string ClasificacionGastoPadre_BreadcrumbId{get;set;}	
	public string ClasificacionGastoPadre_BreadcrumbOrden{get;set;}	
	public int? ClasificacionGastoPadre_Nivel{get;set;}	
	public int? ClasificacionGastoPadre_Orden{get;set;}	
	public string ClasificacionGastoPadre_Descripcion{get;set;}	
	public string ClasificacionGastoPadre_DescripcionInvertida{get;set;}	
	public int? ClasificacionGastoPadre_IdClasificacionGastoRubro{get;set;}	
	public bool? ClasificacionGastoPadre_Seleccionable{get;set;}	
	public string ClasificacionGastoPadre_BreadcrumbCode{get;set;}	
	public string ClasificacionGastoPadre_DescripcionCodigo{get;set;}	
	public string ClasificacionGastoRubro_Codigo{get;set;}	
	public string ClasificacionGastoRubro_Nombre{get;set;}	
	public string ClasificacionGastoTipo_Nombre{get;set;}	
	public int ClasificacionGastoTipo_Nivel{get;set;}	
					
		public virtual ClasificacionGasto ToEntity()
		{
		   ClasificacionGasto _ClasificacionGasto = new ClasificacionGasto();
		_ClasificacionGasto.IdClasificacionGasto = this.IdClasificacionGasto;
		 _ClasificacionGasto.Codigo = this.Codigo;
		 _ClasificacionGasto.Nombre = this.Nombre;
		 _ClasificacionGasto.IdClasificacionGastoTipo = this.IdClasificacionGastoTipo;
		 _ClasificacionGasto.IdCaracterEconomico = this.IdCaracterEconomico;
		 _ClasificacionGasto.Activo = this.Activo;
		 _ClasificacionGasto.IdClasificacionGastoPadre = this.IdClasificacionGastoPadre;
		 _ClasificacionGasto.BreadcrumbId = this.BreadcrumbId;
		 _ClasificacionGasto.BreadcrumbOrden = this.BreadcrumbOrden;
		 _ClasificacionGasto.Nivel = this.Nivel;
		 _ClasificacionGasto.Orden = this.Orden;
		 _ClasificacionGasto.Descripcion = this.Descripcion;
		 _ClasificacionGasto.DescripcionInvertida = this.DescripcionInvertida;
		 _ClasificacionGasto.IdClasificacionGastoRubro = this.IdClasificacionGastoRubro;
		 _ClasificacionGasto.Seleccionable = this.Seleccionable;
		 _ClasificacionGasto.BreadcrumbCode = this.BreadcrumbCode;
		 _ClasificacionGasto.DescripcionCodigo = this.DescripcionCodigo;
		 
		  return _ClasificacionGasto;
		}		
		public virtual void Set(ClasificacionGasto entity)
		{		   
		 this.IdClasificacionGasto= entity.IdClasificacionGasto ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.IdClasificacionGastoTipo= entity.IdClasificacionGastoTipo ;
		  this.IdCaracterEconomico= entity.IdCaracterEconomico ;
		  this.Activo= entity.Activo ;
		  this.IdClasificacionGastoPadre= entity.IdClasificacionGastoPadre ;
		  this.BreadcrumbId= entity.BreadcrumbId ;
		  this.BreadcrumbOrden= entity.BreadcrumbOrden ;
		  this.Nivel= entity.Nivel ;
		  this.Orden= entity.Orden ;
		  this.Descripcion= entity.Descripcion ;
		  this.DescripcionInvertida= entity.DescripcionInvertida ;
		  this.IdClasificacionGastoRubro= entity.IdClasificacionGastoRubro ;
		  this.Seleccionable= entity.Seleccionable ;
		  this.BreadcrumbCode= entity.BreadcrumbCode ;
		  this.DescripcionCodigo= entity.DescripcionCodigo ;
		 		  
		}		
		public virtual bool Equals(ClasificacionGasto entity)
        {
		   if(entity == null)return false;
         if(!entity.IdClasificacionGasto.Equals(this.IdClasificacionGasto))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.IdClasificacionGastoTipo.Equals(this.IdClasificacionGastoTipo))return false;
		  if((entity.IdCaracterEconomico == null)?this.IdCaracterEconomico!=null:!entity.IdCaracterEconomico.Equals(this.IdCaracterEconomico))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		  if((entity.IdClasificacionGastoPadre == null)?(this.IdClasificacionGastoPadre.HasValue && this.IdClasificacionGastoPadre.Value > 0):!entity.IdClasificacionGastoPadre.Equals(this.IdClasificacionGastoPadre))return false;
						  if((entity.BreadcrumbId == null)?this.BreadcrumbId!=null:!entity.BreadcrumbId.Equals(this.BreadcrumbId))return false;
			 if((entity.BreadcrumbOrden == null)?this.BreadcrumbOrden!=null:!entity.BreadcrumbOrden.Equals(this.BreadcrumbOrden))return false;
			 if((entity.Nivel == null)?this.Nivel!=null:!entity.Nivel.Equals(this.Nivel))return false;
			 if((entity.Orden == null)?this.Orden!=null:!entity.Orden.Equals(this.Orden))return false;
			 if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
			 if((entity.DescripcionInvertida == null)?this.DescripcionInvertida!=null:!entity.DescripcionInvertida.Equals(this.DescripcionInvertida))return false;
			 if(!entity.IdClasificacionGastoRubro.Equals(this.IdClasificacionGastoRubro))return false;
		  if(!entity.Seleccionable.Equals(this.Seleccionable))return false;
		  if((entity.BreadcrumbCode == null)?this.BreadcrumbCode!=null:!entity.BreadcrumbCode.Equals(this.BreadcrumbCode))return false;
			 if((entity.DescripcionCodigo == null)?this.DescripcionCodigo!=null:!entity.DescripcionCodigo.Equals(this.DescripcionCodigo))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ClasificacionGasto", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("ClasificacionGastoTipo","ClasificacionGastoTipo_Nombre")
			,new DataColumnMapping("CaracterEconomico","IdCaracterEconomico")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("ClasificacionGastoPadre","ClasificacionGasto_Nombre")
			,new DataColumnMapping("Breadcrumb","BreadcrumbId")
			,new DataColumnMapping("BreadcrumbOrden","BreadcrumbOrden")
			,new DataColumnMapping("Nivel","Nivel")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("DescripcionInvertida","DescripcionInvertida")
			,new DataColumnMapping("ClasificacionGastoRubro","ClasificacionGastoRubro_Nombre")
			,new DataColumnMapping("Seleccionable","Seleccionable")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
			,new DataColumnMapping("DescripcionCodigo","DescripcionCodigo")
			}));
		}
	}
}
		