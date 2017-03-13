using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _FinalidadFuncionResult : IResult<int>
    {        
		public virtual int ID{get{return IdFinalidadFuncion;}}
		 public int IdFinalidadFuncion{get;set;}
		 public string Codigo{get;set;}
		 public string Denominacion{get;set;}
		 public bool Activo{get;set;}
		 public int? IdFinalidadFunciontipo{get;set;}
		 public int? IdFinalidadFuncionPadre{get;set;}
		 public string BreadcrumbId{get;set;}
		 public string BreadcrumbOrden{get;set;}
		 public int? Nivel{get;set;}
		 public int? Orden{get;set;}
		 public string Descripcion{get;set;}
		 public string DescripcionInvertida{get;set;}
		 public bool Seleccionable{get;set;}
		 public string BreadcrumbCode{get;set;}
		 public string DescripcionCodigo{get;set;}
		 
		 public string FinalidadFuncionPadre_Codigo{get;set;}	
	public string FinalidadFuncionPadre_Denominacion{get;set;}	
	public bool? FinalidadFuncionPadre_Activo{get;set;}	
	public int? FinalidadFuncionPadre_IdFinalidadFunciontipo{get;set;}	
	public int? FinalidadFuncionPadre_IdFinalidadFuncionPadre{get;set;}	
	public string FinalidadFuncionPadre_BreadcrumbId{get;set;}	
	public string FinalidadFuncionPadre_BreadcrumbOrden{get;set;}	
	public int? FinalidadFuncionPadre_Nivel{get;set;}	
	public int? FinalidadFuncionPadre_Orden{get;set;}	
	public string FinalidadFuncionPadre_Descripcion{get;set;}	
	public string FinalidadFuncionPadre_DescripcionInvertida{get;set;}	
	public bool? FinalidadFuncionPadre_Seleccionable{get;set;}	
	public string FinalidadFuncionPadre_BreadcrumbCode{get;set;}	
	public string FinalidadFuncionPadre_DescripcionCodigo{get;set;}	
	public string FinalidadFunciontipo_Nombre{get;set;}	
	public int? FinalidadFunciontipo_Nivel{get;set;}	
					
		public virtual FinalidadFuncion ToEntity()
		{
		   FinalidadFuncion _FinalidadFuncion = new FinalidadFuncion();
		_FinalidadFuncion.IdFinalidadFuncion = this.IdFinalidadFuncion;
		 _FinalidadFuncion.Codigo = this.Codigo;
		 _FinalidadFuncion.Denominacion = this.Denominacion;
		 _FinalidadFuncion.Activo = this.Activo;
		 _FinalidadFuncion.IdFinalidadFunciontipo = this.IdFinalidadFunciontipo;
		 _FinalidadFuncion.IdFinalidadFuncionPadre = this.IdFinalidadFuncionPadre;
		 _FinalidadFuncion.BreadcrumbId = this.BreadcrumbId;
		 _FinalidadFuncion.BreadcrumbOrden = this.BreadcrumbOrden;
		 _FinalidadFuncion.Nivel = this.Nivel;
		 _FinalidadFuncion.Orden = this.Orden;
		 _FinalidadFuncion.Descripcion = this.Descripcion;
		 _FinalidadFuncion.DescripcionInvertida = this.DescripcionInvertida;
		 _FinalidadFuncion.Seleccionable = this.Seleccionable;
		 _FinalidadFuncion.BreadcrumbCode = this.BreadcrumbCode;
		 _FinalidadFuncion.DescripcionCodigo = this.DescripcionCodigo;
		 
		  return _FinalidadFuncion;
		}		
		public virtual void Set(FinalidadFuncion entity)
		{		   
		 this.IdFinalidadFuncion= entity.IdFinalidadFuncion ;
		  this.Codigo= entity.Codigo ;
		  this.Denominacion= entity.Denominacion ;
		  this.Activo= entity.Activo ;
		  this.IdFinalidadFunciontipo= entity.IdFinalidadFunciontipo ;
		  this.IdFinalidadFuncionPadre= entity.IdFinalidadFuncionPadre ;
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
		public virtual bool Equals(FinalidadFuncion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdFinalidadFuncion.Equals(this.IdFinalidadFuncion))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Denominacion.Equals(this.Denominacion))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if((entity.IdFinalidadFunciontipo == null)?(this.IdFinalidadFunciontipo.HasValue && this.IdFinalidadFunciontipo.Value > 0):!entity.IdFinalidadFunciontipo.Equals(this.IdFinalidadFunciontipo))return false;
						  if((entity.IdFinalidadFuncionPadre == null)?(this.IdFinalidadFuncionPadre.HasValue && this.IdFinalidadFuncionPadre.Value > 0):!entity.IdFinalidadFuncionPadre.Equals(this.IdFinalidadFuncionPadre))return false;
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
		    return new DataTableMapping("FinalidadFuncion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Denominacion","Denominacion")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("FinalidadFunciontipo","FinalidadFuncionTipo_Nombre")
			,new DataColumnMapping("FinalidadFuncionPadre","FinalidadFuncion_Descripcion")
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
		