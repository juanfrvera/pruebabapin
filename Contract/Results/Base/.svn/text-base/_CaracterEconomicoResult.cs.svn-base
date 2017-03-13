using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _CaracterEconomicoResult : IResult<int>
    {        
		public virtual int ID{get{return IdCaracterEconomico;}}
		 public int IdCaracterEconomico{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public int IdCaracterEconomicoTipo{get;set;}
		 public bool Activo{get;set;}
		 public int? IdCaracterEconomicoPadre{get;set;}
		 public bool? Visible{get;set;}
		 public string BreadcrumbId{get;set;}
		 public string BreadcrumbOrden{get;set;}
		 public int? Nivel{get;set;}
		 public int? Orden{get;set;}
		 public string Descripcion{get;set;}
		 public string DescripcionInvertida{get;set;}
		 public bool? Seleccionable{get;set;}
		 public string BreadcrumbCode{get;set;}
		 public string DescripcionCodigo{get;set;}
		 
		 public string CaracterEconomicoPadre_Codigo{get;set;}	
	public string CaracterEconomicoPadre_Nombre{get;set;}	
	public int? CaracterEconomicoPadre_IdCaracterEconomicoTipo{get;set;}	
	public bool? CaracterEconomicoPadre_Activo{get;set;}	
	public int? CaracterEconomicoPadre_IdCaracterEconomicoPadre{get;set;}	
	public bool? CaracterEconomicoPadre_Visible{get;set;}	
	public string CaracterEconomicoPadre_BreadcrumbId{get;set;}	
	public string CaracterEconomicoPadre_BreadcrumbOrden{get;set;}	
	public int? CaracterEconomicoPadre_Nivel{get;set;}	
	public int? CaracterEconomicoPadre_Orden{get;set;}	
	public string CaracterEconomicoPadre_Descripcion{get;set;}	
	public string CaracterEconomicoPadre_DescripcionInvertida{get;set;}	
	public bool? CaracterEconomicoPadre_Seleccionable{get;set;}	
	public string CaracterEconomicoPadre_BreadcrumbCode{get;set;}	
	public string CaracterEconomicoPadre_DescripcionCodigo{get;set;}	
	public string CaracterEconomicoTipo_Nombre{get;set;}	
	public int CaracterEconomicoTipo_Nivel{get;set;}	
					
		public virtual CaracterEconomico ToEntity()
		{
		   CaracterEconomico _CaracterEconomico = new CaracterEconomico();
		_CaracterEconomico.IdCaracterEconomico = this.IdCaracterEconomico;
		 _CaracterEconomico.Codigo = this.Codigo;
		 _CaracterEconomico.Nombre = this.Nombre;
		 _CaracterEconomico.IdCaracterEconomicoTipo = this.IdCaracterEconomicoTipo;
		 _CaracterEconomico.Activo = this.Activo;
		 _CaracterEconomico.IdCaracterEconomicoPadre = this.IdCaracterEconomicoPadre;
		 _CaracterEconomico.Visible = this.Visible;
		 _CaracterEconomico.BreadcrumbId = this.BreadcrumbId;
		 _CaracterEconomico.BreadcrumbOrden = this.BreadcrumbOrden;
		 _CaracterEconomico.Nivel = this.Nivel;
		 _CaracterEconomico.Orden = this.Orden;
		 _CaracterEconomico.Descripcion = this.Descripcion;
		 _CaracterEconomico.DescripcionInvertida = this.DescripcionInvertida;
		 _CaracterEconomico.Seleccionable = this.Seleccionable;
		 _CaracterEconomico.BreadcrumbCode = this.BreadcrumbCode;
		 _CaracterEconomico.DescripcionCodigo = this.DescripcionCodigo;
		 
		  return _CaracterEconomico;
		}		
		public virtual void Set(CaracterEconomico entity)
		{		   
		 this.IdCaracterEconomico= entity.IdCaracterEconomico ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.IdCaracterEconomicoTipo= entity.IdCaracterEconomicoTipo ;
		  this.Activo= entity.Activo ;
		  this.IdCaracterEconomicoPadre= entity.IdCaracterEconomicoPadre ;
		  this.Visible= entity.Visible ;
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
		public virtual bool Equals(CaracterEconomico entity)
        {
		   if(entity == null)return false;
         if(!entity.IdCaracterEconomico.Equals(this.IdCaracterEconomico))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.IdCaracterEconomicoTipo.Equals(this.IdCaracterEconomicoTipo))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if((entity.IdCaracterEconomicoPadre == null)?(this.IdCaracterEconomicoPadre.HasValue && this.IdCaracterEconomicoPadre.Value > 0):!entity.IdCaracterEconomicoPadre.Equals(this.IdCaracterEconomicoPadre))return false;
						  if((entity.Visible == null)?this.Visible!=null:!entity.Visible.Equals(this.Visible))return false;
			 if((entity.BreadcrumbId == null)?this.BreadcrumbId!=null:!entity.BreadcrumbId.Equals(this.BreadcrumbId))return false;
			 if((entity.BreadcrumbOrden == null)?this.BreadcrumbOrden!=null:!entity.BreadcrumbOrden.Equals(this.BreadcrumbOrden))return false;
			 if((entity.Nivel == null)?this.Nivel!=null:!entity.Nivel.Equals(this.Nivel))return false;
			 if((entity.Orden == null)?this.Orden!=null:!entity.Orden.Equals(this.Orden))return false;
			 if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
			 if((entity.DescripcionInvertida == null)?this.DescripcionInvertida!=null:!entity.DescripcionInvertida.Equals(this.DescripcionInvertida))return false;
			 if((entity.Seleccionable == null)?this.Seleccionable!=null:!entity.Seleccionable.Equals(this.Seleccionable))return false;
			 if((entity.BreadcrumbCode == null)?this.BreadcrumbCode!=null:!entity.BreadcrumbCode.Equals(this.BreadcrumbCode))return false;
			 if((entity.DescripcionCodigo == null)?this.DescripcionCodigo!=null:!entity.DescripcionCodigo.Equals(this.DescripcionCodigo))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("CaracterEconomico", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("CaracterEconomicoTipo","CaracterEconomicoTipo_Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("CaracterEconomicoPadre","CaracterEconomico_Nombre")
			,new DataColumnMapping("Visible","Visible")
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
		